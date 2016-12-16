using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NaiveBayesClassifier
{
    class NaiveBayes
    {
        #region Constants
        private const int K = 10;
        private const int NUMBER_OF_ATTRIBUTES = 16 + 1;
        private const int CLASS_INDEX = 16;
        private const int SETS_TO_TRAIN = 9;

        private const char DEMOCRAT = 'd';
        private const char REPUBLICAN = 'r';

        private const char YES = 'y';
        private const char NO = 'n';
        private const char MISSING = '?';
        #endregion

        #region StaticFields
        private static int NUMBER_OF_ENTRIES_IN_SET = Data.DATA.GetLength(0) / K;
        public static double[] accuracies;
        public static double accuracy;
        private static double[,] conditionalProbabilitiesDemocrat;
        private static double[,] conditionalProbabilitiesRepublican;
        private static double priorProbabilityDemocrat;
        private static double priorProbabilityRepublican;
        #endregion

        #region Methods

        // takes an entry with row rownumber from data char array
        private static char[] TakeEntryWithRow(int rowNumber, char[,] data)
        {
            return data.Cast<char>().Skip((rowNumber - 1) * NUMBER_OF_ATTRIBUTES).Take(NUMBER_OF_ATTRIBUTES).ToArray();
        }

        /// <summary>
        /// Help method for increasing the number of P(attri and democrat|republican)
        /// </summary>
        /// <param name="conditionalProbabilities">Matrix for holding conditional probabilities</param>
        /// <param name="entry">char array with 17 values</param>
        /// <param name="attrNumber">[0,15]</param>
        private static void HelpConditionalProbability(ref double[,] conditionalProbabilities, char[] entry, int attrNumber)
        {
            if (entry[attrNumber] == YES)
                conditionalProbabilities[attrNumber, 1]++; // increase number for P(attrNumber, attr = 'y' and democrat|republican)
            else if (entry[attrNumber] == NO)
                conditionalProbabilities[attrNumber, 0]++;
            else
                conditionalProbabilities[attrNumber, 2]++;
        }

        /// <summary>
        /// Divides each probability P(attri and democrat|republican), i = 1...16 by the number of democrats 
        /// or republicans depending on whether the conditionalProbabilities matrix is for democrats or republicans
        /// </summary>
        /// <param name="conditionalProbabilities">conditionalProbabilities matrix for democrats or republicans</param>
        /// <param name="numberDemocratsOrRepublicans">democrats or republicans number</param>
        private static void DivideByDemocratsOrRepublicansNumber(ref double[,] conditionalProbabilities, int numberDemocratsOrRepublicans)
        {
            for (int attrNumber = 0; attrNumber < NUMBER_OF_ATTRIBUTES - 1; attrNumber++)
                for (int i = 0; i < 3; i++)
                    conditionalProbabilities[attrNumber, i] = (double)conditionalProbabilities[attrNumber, i] / numberDemocratsOrRepublicans;
        }

        /// <summary>
        /// Computes conditional and prior probabilities for democrats and republicans
        /// </summary>
        /// <param name="trainset">all entries in trainset represented as a char matrix</param>
        private static void ComputeProbabilities(char[,] trainset) // computes all conditional and prior probabilities
        {
            // 0th dimension is for attrNumber, 1th dimension -> 0-th index is for 'n', 1-for 'y', 2-for '?'
            conditionalProbabilitiesDemocrat = new double[NUMBER_OF_ATTRIBUTES - 1, 3];
            conditionalProbabilitiesRepublican = new double[NUMBER_OF_ATTRIBUTES - 1, 3];
            int democratsNumber = 0;
            char[] entry;
            for (int attrNumber = 0; attrNumber < NUMBER_OF_ATTRIBUTES - 1; attrNumber++)
                for (int entryNumber = 0; entryNumber < trainset.GetLength(0); entryNumber++)
                {
                    entry = TakeEntryWithRow(entryNumber, trainset);
                    if (entry[CLASS_INDEX] == DEMOCRAT) // democrat
                    {
                        democratsNumber++;
                        HelpConditionalProbability(ref conditionalProbabilitiesDemocrat, entry, attrNumber);
                    }
                    else // republican
                        HelpConditionalProbability(ref conditionalProbabilitiesRepublican, entry, attrNumber);
                }
            DivideByDemocratsOrRepublicansNumber(ref conditionalProbabilitiesDemocrat, democratsNumber);
            DivideByDemocratsOrRepublicansNumber(ref conditionalProbabilitiesRepublican, trainset.GetLength(0) - democratsNumber);
            priorProbabilityDemocrat = (double)democratsNumber / trainset.GetLength(0);
            priorProbabilityRepublican = 1 - priorProbabilityDemocrat;
        }

        /// <summary>
        /// Method returns 0 if char is 'n', 1 if char is 'y' and 2 otherwise
        /// </summary>
        /// <param name="yesNoOrMissing">'y', 'n' or '?'</param>
        /// <returns>0, 1 or 2 depending on the char given as param</returns>
        private static int YesNoOrMissingIndex(char yesNoOrMissing)
        {
            if (yesNoOrMissing == YES)
                return 1;
            else if (yesNoOrMissing == NO)
                return 0;
            else
                return 2;
        }

        /// <summary>
        /// Classifies a person as democrat/republican based on the higher of 2 probabilities
        /// </summary>
        /// <param name="entry">entry with attributes we will classify as democrat/republican</param>
        /// <param name="trainset">our train set</param>
        /// <returns>the higher of 2 probabilities</returns>
        private static char NaiveBayesClassifier(char[] entry)
        {
            // product of conditional probabilities and prior probability for democrat
            double democratProbability = priorProbabilityDemocrat;

            // product of conditional probabilities and prior probability for republican
            double republicanProbability = priorProbabilityRepublican;

            for (int attrNumber = 0; attrNumber < CLASS_INDEX; attrNumber++)
            {
                int index = YesNoOrMissingIndex(entry[attrNumber]);
                democratProbability *= conditionalProbabilitiesDemocrat[attrNumber, index];
                republicanProbability *= conditionalProbabilitiesRepublican[attrNumber, index];
            }
            return (democratProbability > republicanProbability) ? DEMOCRAT : REPUBLICAN;
        }

        private static char[,,] DivideIntoKSetsRandomly(char[,] data)
        {
            char[,,] sets = new char[K, NUMBER_OF_ENTRIES_IN_SET, NUMBER_OF_ATTRIBUTES];
            Random generator = new Random();
            char[] entry = new char[NUMBER_OF_ATTRIBUTES];
            Dictionary<int, char[]> alreadyChosenEntries = new Dictionary<int, char[]>();
            int numberOfChosenEntry;

            for (int setNum = 0; setNum < K; setNum++)
            {
                for (int row = 0; row < NUMBER_OF_ENTRIES_IN_SET; row++)
                {
                    do
                    {
                        numberOfChosenEntry = generator.Next(data.GetLength(0));
                    } while (alreadyChosenEntries.ContainsKey(numberOfChosenEntry));

                    entry = TakeEntryWithRow(numberOfChosenEntry, data);
                    alreadyChosenEntries.Add(numberOfChosenEntry, entry);

                    for (int col = 0; col < NUMBER_OF_ATTRIBUTES; col++)
                        sets[setNum, row, col] = entry[col];
                }
            }
            return sets;
        }

        private static double ComputeAccuraciesAverage(double[] accuracies)
        {
            double sum = 0;
            for (int i = 0; i < accuracies.Length; i++)
            {
                sum += accuracies[i];
            }
            return sum / accuracies.Length;
        }

        private static double ComputeAccuracy(char[,] testSet)
        {

            char[] entry;
            char result; // is 'd' or 'r' for democrat and republican
            int coincidenceNumber = 0;
            for (int row = 0; row < testSet.GetLength(0); row++)
            {
                entry = TakeEntryWithRow(row, testSet);
                result = NaiveBayesClassifier(entry);
                if (result == entry[CLASS_INDEX])
                    coincidenceNumber++;
            }
            return (double)coincidenceNumber / testSet.GetLength(0);
        }

        private static void CopySetToAnotherSet(char[,,] source, ref char[,] target, int setNum, int iteration)
        {
            for (int row = 0; row < NUMBER_OF_ENTRIES_IN_SET; row++)
                for (int col = 0; col < NUMBER_OF_ATTRIBUTES; col++)
                    target[iteration * NUMBER_OF_ENTRIES_IN_SET + row, col] = source[setNum, row, col];
        }

        public static void Print(double[] accuracies)
        {
            for (int i = 0; i < accuracies.Length; i++)
            {
                accuracies[i] *= 100;
                Console.Write("{0:0.0}% ", accuracies[i]);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Does 10 trainings and 10 tests and for every iteration takes 1 set for testing 
        /// and the other 9 for training and computes 10 times the accuracy of Naive Bayes Classifier 
        /// function of each of the 10 sets by comparing the output of the function for each entry 
        /// and the actual class of the entry in the test set and counts the number of times there
        /// is coincidence i.e. the algorithm guesses correctly the class of an entry. The accuracy 
        /// is the number of times there is coincidence divided by the total number of entries in the test set
        /// </summary>
        public static void KCrossValidation()
        {
            char[,] trainSet;
            char[,] testSet;
            char[,,] sets = DivideIntoKSetsRandomly(Data.DATA);
            accuracies = new double[K];

            for (int testSetNum = 0; testSetNum < K; testSetNum++)
            {
                testSet = new char[NUMBER_OF_ENTRIES_IN_SET, NUMBER_OF_ATTRIBUTES];
                CopySetToAnotherSet(sets, ref testSet, testSetNum, 0);

                trainSet = new char[NUMBER_OF_ENTRIES_IN_SET * SETS_TO_TRAIN, NUMBER_OF_ATTRIBUTES];
                int i = 0;
                for (int trainSetNum = 0; trainSetNum < K; trainSetNum++)
                    if (trainSetNum != testSetNum)
                    {
                        CopySetToAnotherSet(sets, ref trainSet, trainSetNum, i);
                        i++;
                    }
                ComputeProbabilities(trainSet);
                accuracies[testSetNum] = ComputeAccuracy(testSet);
            }
            accuracy = ComputeAccuraciesAverage(accuracies);
        }

        #endregion

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            KCrossValidation();
            Print(accuracies);
            Console.WriteLine("Average accuracy: {0:0.0}%", accuracy * 100);

            stopWatch.Stop();
            // get the elapsed time as a TimeSpan value
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Elapsed time " + elapsedTime);
        }
    }
}