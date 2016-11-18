using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblemGA
{
    class Knapsack
    {
        public static int[] weights; // weight of objects
        public static int[] costs; // cost of objects
        public static Random generator = new Random();

        public static int populationNumber;
        public static int individualsForChange;
        public static int individualsForMutation;
        public static int objectsNumber;
        public static int maxWeight;

        public static int[] GenerateIndividual()
        {
            int[] individual = new int[objectsNumber];
            for (int i = 0; i < objectsNumber; i++)
                individual[i] = generator.Next(2); // generates 0 or 1
            return individual;
        }

        public static List<int[]> GenerateRandomPopulation()
        {
            List<int[]> population = new List<int[]>();
            for (int i = 0; i < populationNumber; i++)
                population.Add(GenerateIndividual());
            return population;
        }

        public static int ComputeIndividualWeight(int[] individual)
        {
            int weight = individual
                                .Zip(weights, (i, w) => i * w)
                                .Sum();
            return weight;
        }

        public static int ComputeIndividualFitness(int[] individual)
        {
            int individualWeight = ComputeIndividualWeight(individual);
            int fitness = (individualWeight > maxWeight) ? 0 :
                        individual.Zip(costs, (i, c) => i * c).Sum();
            return fitness;

        }

        // gets k individuals with highest fitness
        public static List<int[]> GetKWithHighestFitness(List<int[]> population, int k)
        {
            return population.OrderByDescending(i => ComputeIndividualFitness(i))
                             .Take(k)
                             .ToList();
        }

        public static Tuple<int[], int[]> Cross(int[] i1, int[] i2)
        {
            int crossPoint = generator.Next(i1.Length);
            int[] newI1 = new int[i1.Length];
            Array.Copy(i1, 0, newI1, 0, crossPoint);
            Array.Copy(i2, crossPoint, newI1, crossPoint, i2.Length - crossPoint);
            int[] newI2 = new int[i2.Length];
            Array.Copy(i2, 0, newI2, 0, crossPoint);
            Array.Copy(i1, crossPoint, newI2, crossPoint, i1.Length - crossPoint);
            return Tuple.Create(newI1, newI2);
        }

        public static List<int[]> Crossover(List<int[]> newPopulation, int individualsForChange)
        {
            List<int[]> crossed = new List<int[]>();
            bool[] chosen = new bool[newPopulation.Count];
            int idx1, idx2;
            Tuple<int[], int[]> crossedIndividuals;
            for (int i = 0; i < individualsForChange / 2; i++)
            {
                idx1 = generator.Next(newPopulation.Count);
                while (chosen[idx1])
                    idx1 = generator.Next(newPopulation.Count);
                chosen[idx1] = true;
                idx2 = generator.Next(newPopulation.Count);
                while (chosen[idx2])
                    idx2 = generator.Next(newPopulation.Count);
                chosen[idx2] = true;
                crossedIndividuals = Cross(newPopulation[idx1], newPopulation[idx2]);
                crossed.Add(crossedIndividuals.Item1);
                crossed.Add(crossedIndividuals.Item2);
            }
            return crossed;
        }

        public static void Mutate(List<int[]> newPopulation, int individualsForMutation)
        {
            int[] mutationIndices =
                Enumerable.Range(0, individualsForMutation)
                .Select(i => generator.Next(newPopulation.Count))
                .ToArray();
            int bit;
            foreach (var i in mutationIndices)
            {
                bit = generator.Next(newPopulation[i].Length);
                ++newPopulation[i][bit];
                newPopulation[i][bit] %= 2;
            }
        }

        public static int SolveKnapsackProblem(int populationNumber, 
            int individualsForChange, int individualsForMutation)
        {
            List<int[]> population = GenerateRandomPopulation();
            int maxCost = 0;
            int previousMaxCost;
            int iterations = 0;
            List<int[]> pNew;
            List<int[]> crossed;
            while (iterations < 5)
            {
                pNew = GetKWithHighestFitness
                    (population, populationNumber - individualsForChange);
                crossed = Crossover(pNew, individualsForChange);
                Mutate(crossed, individualsForMutation);
                pNew.AddRange(crossed);
                population = pNew;
                previousMaxCost = maxCost;
                maxCost = ComputeIndividualFitness
                    (GetKWithHighestFitness(population, 1)[0]);
                if (maxCost == previousMaxCost)
                    iterations++;
                else
                    iterations = 0;
            }
            return maxCost;
        }

        public static void Print(int[] individual)
        {
            for (int i = 0; i < individual.Length; i++)
                Console.Write("{0} ", individual[i]);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Write("Knapsack capacity: ");
            maxWeight = int.Parse(Console.ReadLine());
            Console.Write("Objects number: ");
            objectsNumber = int.Parse(Console.ReadLine());
            Console.Write("Individuals number: ");
            populationNumber = int.Parse(Console.ReadLine());
            Console.Write("Individuals for change: ");
            individualsForChange = int.Parse(Console.ReadLine());
            Console.Write("Individuals for mutation: ");
            individualsForMutation = int.Parse(Console.ReadLine());

            string line = null;
            int[] costWeight = new int[2]; //1st number is cost of an object, 2nd number is weight
            costs = new int[objectsNumber]; // holds costs of all objects
            weights = new int[objectsNumber];
            for (int i = 0; i < objectsNumber; i++)
            {
                line = Console.ReadLine();
                costWeight = line.Split(' ').Select(int.Parse).ToArray();
                costs[i] = costWeight[0];
                weights[i] = costWeight[1];
            }
            Console.WriteLine("Max Cost: {0}", 
                SolveKnapsackProblem(populationNumber, individualsForChange, individualsForMutation));
        }
    }
}
