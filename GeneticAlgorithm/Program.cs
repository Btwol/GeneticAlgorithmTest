using System;

namespace GeneticAlgorithms
{
    internal class Program
    {
        public static int MatrixSize = 1000;

        static void Main(string[] args)
        {
            Random rand = new();
            GeneticAlgorithm<int> geneticAlgorithm = new(20, 4, rand, GetRandomGene, EvaluateFitness, 18, 0.15f);

            Console.WriteLine($"Square size: {MatrixSize}");
            while (true)
            {
                for (int i = 0; i < geneticAlgorithm.Population.Count; i++)
                {
                    Console.WriteLine($"{i}: Fitness: {geneticAlgorithm.Population[i].Fitness}\n" +
                        $" x1:{geneticAlgorithm.Population[i].Genes[0]}," +
                        $" x2:{geneticAlgorithm.Population[i].Genes[1]}," +
                        $" y1:{geneticAlgorithm.Population[i].Genes[2]}," +
                        $" y2:{geneticAlgorithm.Population[i].Genes[3]}");
                }
                Console.WriteLine("\nPress(or hold down) enter to add a new generation");
                Console.ReadKey();
                Console.Clear();
                geneticAlgorithm.NewGeneration(1, true); 
            }
        }

        public static int GetRandomGene()
        {
            Random random = new();
            int gene = random.Next(MatrixSize);
            return gene;
        }

        public static float EvaluateFitness(int[] array)
        {
            float maxDistance = (float)Math.Sqrt(Math.Pow(MatrixSize, 2) + Math.Pow(MatrixSize, 2));
            float geneDistance = (float)Math.Sqrt(Math.Pow(array[1] - array[0], 2) + Math.Pow(array[3] - array[2], 2));
            return geneDistance / maxDistance;
        }
    }
}