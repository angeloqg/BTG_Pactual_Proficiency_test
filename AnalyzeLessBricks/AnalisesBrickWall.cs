using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace AnalyzeLessBricks
{
    [MemoryDiagnoser]
    public class AnalisesBrickWall
    {
        public List<List<int>> CreateWall(int columns, int lines, int totalBrickLength, int timeLapse = 0)
        {
            List<List<int>> grid = new List<List<int>>();

            for (int i = 1; i <= lines; i++)
            {
                List<int> aux = new List<int>(new AnalisesBrickWall().CreateBrickColumnsSequence(totalBrickLength, columns));

                if (timeLapse > 0)
                {
                    Thread.Sleep(timeLapse * 1000);
                }

                if (i % 2 == 0)
                {
                    aux.Reverse();
                }

                grid.Add(aux);
            }

            return grid;
        }

        private List<int> CreateBrickColumnsSequence(int totalBrickLength, int collumns)
        {
            List<int> sequence = new List<int>();
            Random rand = new Random();
            int cumulativeTotal = 0;

            for (int c = 1; c <= collumns; c++)
            {
                if (c == collumns)
                {
                    int aux = totalBrickLength - cumulativeTotal;
                    sequence.Add(aux);
                }
                else
                {
                    if (cumulativeTotal < totalBrickLength)
                    {
                        int randomSize = 0;
                        if (c == 1)
                        {
                            randomSize = rand.Next(totalBrickLength);
                            cumulativeTotal += totalBrickLength - randomSize;
                            sequence.Add(cumulativeTotal);
                        }
                        else
                        {
                            if (cumulativeTotal < totalBrickLength)
                            {
                                randomSize = rand.Next(cumulativeTotal);
                                int taux = 0;
                                if (randomSize < (totalBrickLength - cumulativeTotal))
                                {
                                    sequence.Add(randomSize);
                                    taux = cumulativeTotal + randomSize;
                                }
                                else
                                {
                                    taux = cumulativeTotal + (totalBrickLength - cumulativeTotal);
                                    sequence.Add(totalBrickLength - cumulativeTotal);
                                }

                                cumulativeTotal = taux;
                            }
                        }
                    }
                }
            }

            return sequence.Where(i => i != 0).ToList();
        }

        public void PrintBrickWall(int rows, List<List<int>> brickWall)
        {
            Console.Write("[");
            for (int i = 0; i < rows; i++)
            {
                var aux = brickWall[i];

                int colAux = aux.Count();
                Console.Write("[");
                for (int l = 0; l < colAux; l++)
                {
                    Console.Write(aux[l]);

                    if (colAux > 1 && l < colAux - 1)
                    {
                        Console.Write(",");
                    }
                }
                Console.Write("]");
                if (rows > 1 && i < rows - 1)
                {
                    Console.Write(",");
                }

                if (i == rows - 1)
                {
                    Console.Write("]");
                }

                Console.WriteLine("");
            }
        }
        
        public int MinimumOfBricks(List<List<int>> brickWall)
        {
            var edges_Per_Column = new Dictionary<int, int>();
            var max_Edges_Per_Column = 0;

            foreach (var course in brickWall)
            {
                var column_Index = 0;
                for (var i = 0; i < course.Count - 1; i++)
                {
                    column_Index += course[i];
                    edges_Per_Column.TryGetValue(column_Index, out int current);
                    edges_Per_Column[column_Index] = ++current;
                    if (current > max_Edges_Per_Column)
                    {
                        max_Edges_Per_Column = current;
                    }
                }
            }
            return brickWall.Count - max_Edges_Per_Column;
        }

        [Benchmark(Baseline = true)]
        public void BigONotationMinimumOfBricksTestMethod()
        {
            List<List<int>> mokBrickWall = new List<List<int>>();

            mokBrickWall.Add(new List<int>() { 1, 2, 2, 1 });
            mokBrickWall.Add(new List<int>() { 3, 1, 2 });
            mokBrickWall.Add(new List<int>() { 1, 3, 2 });
            mokBrickWall.Add(new List<int>() { 2, 4 });
            mokBrickWall.Add(new List<int>() { 3, 1, 2 });
            mokBrickWall.Add(new List<int>() { 1, 3, 1, 1 });

            MinimumOfBricks(mokBrickWall);
        }
    }
}
