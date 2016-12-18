using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KNN
{
    // dataset is from http://archive.ics.uci.edu/ml/machine-learning-databases/iris/iris.data

    // class 0 -> Iris-setosa
    // class 0.5 -> Iris-versicolor
    // class 1 -> Iris-virginica

    class KNearestNeighbours
    {
        #region StaticVariablesAndConstants

        private const int TESTSET_DIMENSION = 20; // number of entries/rows in test set
        private static int DATASET_DIMENSION = Data.DATA.GetLength(0); // number of entries/rows in data set
        private static int TRAINSET_DIMENSION = DATASET_DIMENSION - TESTSET_DIMENSION; // number of entries/rows in train set
        private const int ATTRIBUTES_NUMBER = 4;
        private const int CLASS_INDEX = 4;

        private const double IRIS_SETOSA = 0;
        private const double IRIS_VERSICOLOR = 0.5;
        private const double IRIS_VIRGINICA = 1;

        private static double[,] trainset = new double[TRAINSET_DIMENSION, ATTRIBUTES_NUMBER + 1];
        private static double[,] testset = new double[TESTSET_DIMENSION, ATTRIBUTES_NUMBER + 1];

        #endregion
        // takes an entry with row rownumber from data char array
        private static double[] TakeEntryWithRow(int rowNumber, ref double[,] set)
        {
            return set.Cast<double>().Skip((rowNumber - 1) * (ATTRIBUTES_NUMBER + 1)).Take(ATTRIBUTES_NUMBER + 1).ToArray();
        }

        private static void DivideDataIntoTrainAndTestSet(ref double[,] normalizedDataSet)
        {
            Random generator = new Random();
            double[] entry;
            int entryNumber;
            List<int> alreadyChosenEntries = new List<int>();

            testset = new double[TESTSET_DIMENSION, ATTRIBUTES_NUMBER + 1];
            for (int rowNumber = 0; rowNumber < TESTSET_DIMENSION; rowNumber++)
            {
                do
                {
                    entryNumber = generator.Next(DATASET_DIMENSION);
                } while (alreadyChosenEntries.Contains(entryNumber));

                entry = TakeEntryWithRow(entryNumber, ref normalizedDataSet);
                AssignEntry(ref testset, rowNumber, entry);
                alreadyChosenEntries.Add(entryNumber);
            }

            trainset = new double[TRAINSET_DIMENSION, ATTRIBUTES_NUMBER + 1];
            for (int rowNumber = 0; rowNumber < TRAINSET_DIMENSION; rowNumber++)
            {
                if (alreadyChosenEntries.Contains(rowNumber))
                    continue;
                entry = TakeEntryWithRow(rowNumber, ref normalizedDataSet);
                AssignEntry(ref trainset, rowNumber, entry);
            }
        }

        private static void AssignEntry(ref double[,] set, int rowNumber, double[] entry)
        {
            for (int col = 0; col < entry.Length; col++)
                set[rowNumber, col] = entry[col];
        }

        // finds maximum value for attribute with number 'attrNumber' in dataset
        private static double FindMaxInDataSet(int attrNumber)
        {
            double max = double.MinValue;
            for (int row = 0; row < DATASET_DIMENSION; row++)
                if (max < Data.DATA[row, attrNumber])
                    max = Data.DATA[row, attrNumber];
            return max;
        }

        // finds minimum value for every attribute with number 'attrNumber' in dataset
        private static double FindMinInDataSet(int attrNumber)
        {
            double min = double.MaxValue;
            for (int row = 0; row < DATASET_DIMENSION; row++)
                if (min > Data.DATA[row, attrNumber])
                    min = Data.DATA[row, attrNumber];
            return min;
        }

        // normalizes (converts all values to match the interval [0,1], max value
        // becomes 1 and min-0) attributes in dataset using method Normalize
        private static double[,] NormalizeValuesInDataSet()
        {
            double[] minValues = new double[ATTRIBUTES_NUMBER];
            double[] maxValues = new double[ATTRIBUTES_NUMBER];

            for (int attrNumber = 0; attrNumber < ATTRIBUTES_NUMBER; attrNumber++)
            {
                minValues[attrNumber] = FindMinInDataSet(attrNumber);
                maxValues[attrNumber] = FindMaxInDataSet(attrNumber);
            }

            double[,] normalizedDataset = new double[DATASET_DIMENSION, ATTRIBUTES_NUMBER + 1];
            
            for (int attrNumber = 0; attrNumber < ATTRIBUTES_NUMBER; attrNumber++)
                for (int row = 0; row < DATASET_DIMENSION; row++)
                    normalizedDataset[row, attrNumber] = Normalize(minValues[attrNumber], 
                                                                   maxValues[attrNumber], 
                                                                   Data.DATA[row, attrNumber]);
            for (int row = 0; row < DATASET_DIMENSION; row++)
                normalizedDataset[row, CLASS_INDEX] = Data.DATA[row, CLASS_INDEX];
                    
            return normalizedDataset;
        }

        // method that converts a value in order to be in the interval [0, 1]
        private static double Normalize(double min, double max, double value)
        {
            return (value - min) / (max - min);
        }

        // Absolute distance b/n 2 entries is the  sum(|entry1 for attri - entry2 for attri|), i = 0,..,3
        private static double AbsoluteDistanceBetween2DataPoints(double[] entry1, double[] entry2)
        {
            double sum = 0;
            for (int attrNumber = 0; attrNumber < ATTRIBUTES_NUMBER; attrNumber++)
                sum += Math.Abs(entry1[attrNumber] - entry2[attrNumber]);
            return sum;
        }

        // finds K nearest neighbours to entry in trainset
        public static List<DistanceClass> KNN(ref double[,] trainset, ref double[] entry, int K)
        {
            List<DistanceClass> distancesToEntryAndClasses = new List<DistanceClass>();
            double[] trainsetEntry;
            DistanceClass distanceClass;
            double distance;
            double classType;

            for (int entryNumber= 0; entryNumber < TRAINSET_DIMENSION; entryNumber++)
            {
                trainsetEntry = TakeEntryWithRow(entryNumber, ref trainset);
                distance = AbsoluteDistanceBetween2DataPoints(entry, trainsetEntry);
                classType = trainsetEntry[CLASS_INDEX];
                distanceClass = new DistanceClass(distance, classType);
                distancesToEntryAndClasses.Add(distanceClass);
            }
            List<DistanceClass> KNearestNeighbours = distancesToEntryAndClasses
                                                    .OrderBy(value => value.Distance)
                                                    .Take(K)
                                                    .ToList();
            return KNearestNeighbours;
        }

        // finds the class with highest frequency in kNearestNeighbours
        // if frequencies of classes are the same, chooses the class of the nearest neighbour
        private static double HighestFrequencyClass(ref List<DistanceClass> kNearestNeighbours)
        {
            int class1Number = 0;
            int class2Number = 0;
            int class3Number = 0;

            foreach (var item in kNearestNeighbours)
            {
                if (item.ClassType == IRIS_SETOSA)
                    class1Number++;
                else if (item.ClassType == IRIS_VERSICOLOR)
                    class2Number++;
                else
                    class3Number++;
            }

            if (class1Number == class2Number && class2Number == class3Number)
                return kNearestNeighbours.First().ClassType;

            if (class1Number > class2Number)
            {
                if (class1Number > class3Number)
                    return IRIS_SETOSA;
                else
                    return IRIS_VIRGINICA;
            }
            else
            {
                if (class2Number > class3Number)
                    return IRIS_VERSICOLOR;
                else
                    return IRIS_VIRGINICA;
            }
        }

        // for each entry in testset we check for coincidence b/n class of the entry 
        // and guessed class with KNN algorithm and compute the accuracy of the algorithm
        public static double ComputeKNNAccuracy(int K)
        {
            double[,] normalizedDataSet = NormalizeValuesInDataSet();
            DivideDataIntoTrainAndTestSet(ref normalizedDataSet);
            int correctGuesses = 0;
            double[] entry;
            List<DistanceClass> kNearestNeighbours;
            double highestFreqClass;
            for (int row = 0; row < TESTSET_DIMENSION; row++)
            {
                entry = TakeEntryWithRow(row, ref testset);
                kNearestNeighbours = KNN(ref trainset, ref entry, K);
                highestFreqClass = HighestFrequencyClass(ref kNearestNeighbours);
                if (entry[CLASS_INDEX] == highestFreqClass)
                    correctGuesses++;
            }
            return ((double)correctGuesses / TESTSET_DIMENSION) * 100;
        }

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Console.Write("K = ");
            int K = int.Parse(Console.ReadLine());
            Console.WriteLine("Accuracy of KNN is {0}%", ComputeKNNAccuracy(K));

            stopWatch.Stop();
            // get the elapsed time as a TimeSpan value
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Elapsed time " + elapsedTime);
        }
    }
}