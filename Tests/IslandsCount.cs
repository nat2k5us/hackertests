using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace hackertests.Tests
{
    public class IslandCount : ITestProgram
    {
        public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.IslandCount;
        }

        static Dictionary<int, List<Point>> foundsIslandsLocations = new Dictionary<int, List<Point>>();
        static List<Point> pointsAlreadyTraversed = new List<Point>();
        public static int NumIslands(int[,] matrix)
        {
            int maxIslands = 0;
            if (matrix == null || matrix.GetLength(0) == 0)
            {
                return maxIslands;
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] == 1)
                    {
                        //  maxIslands += getIslandSize(matrix, row, column);
                        var IslandPoints = PopulateIslandVerticies(matrix, row, column);
                        if (IslandPoints.Count > 0)
                        {
                            maxIslands++;
                            pointsAlreadyTraversed.AddRange(IslandPoints);
                            foundsIslandsLocations.Add(maxIslands, IslandPoints);
                        }
                        // else
                        //    System.Console.WriteLine("Zero Points !!!!!!!!");
                    }
                }
            }
            return maxIslands;
        }
        public static int NumIslandsUsingRecursion(int[,] matrix)
        {
            int maxIslands = 0;
            if (matrix == null || matrix.GetLength(0) == 0)
            {
                return maxIslands;
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] == 1)
                    {
                        maxIslands += getIslandSize(matrix, row, column);
                    }
                }
            }
            return maxIslands;
        }
        private static List<Point> PopulateIslandVerticies(int[,] matrix, int rowstart, int columnStart)
        {
            var returnPoints = new List<Point>();
            var ptRoot = new Point(rowstart, columnStart);
            if (!pointsAlreadyTraversed.Contains(ptRoot))
                returnPoints.Add(ptRoot);
            else
                return returnPoints;
            int row = rowstart;
            int column = columnStart;

            // Right
            while (column++ < matrix.GetLength(1) - 1 && matrix[row, column] != 0)
            {
                var pt = new Point(row, column);
                if (!pointsAlreadyTraversed.Contains(pt))
                    returnPoints.Add(pt);
            }
            // Down
            row = rowstart;
            column = columnStart;
            while (row++ < matrix.GetLength(0) - 1 && matrix[row, column] != 0)
            {
                var pt = new Point(row, column);
                if (!pointsAlreadyTraversed.Contains(pt))
                    returnPoints.Add(pt);
            }
            // South-East ↘
            row = rowstart;
            column = columnStart;
            while (row++ < matrix.GetLength(0) - 1 && column++ < matrix.GetLength(1) - 1 && matrix[row, column] != 0)
            {
                var pt = new Point(row, column);
                if (!pointsAlreadyTraversed.Contains(pt))
                    returnPoints.Add(pt);
            }
            // South-West   ↙
            row = rowstart;
            column = columnStart;
            while (row++ < matrix.GetLength(0) - 1 && column-- < 0 && matrix[row, column] != 0)
            {
                var pt = new Point(row, column);
                if (!pointsAlreadyTraversed.Contains(pt))
                    returnPoints.Add(pt);
            }
            row = rowstart;
            column = columnStart;
            while (column-- > 0 && matrix[row, column] != 0)
            {
                var pt = new Point(row, column);
                if (!pointsAlreadyTraversed.Contains(pt))
                    returnPoints.Add(pt);
            }
            row = rowstart;
            column = columnStart;
            // North-West   ↖
            while (row-- < 0 && column-- < 0 && matrix[row, column] != 0)
            {
                var pt = new Point(row, column);
                if (!pointsAlreadyTraversed.Contains(pt))
                    returnPoints.Add(pt);
            }
            row = rowstart;
            column = columnStart;
            // North-East   ↗
            while (row++ < 0 && column++ < matrix.GetLength(1) - 1 && matrix[row, column] != 0)
            {
                var pt = new Point(row, column);
                if (!pointsAlreadyTraversed.Contains(pt))
                    returnPoints.Add(pt);
            }
            row = rowstart;
            column = columnStart;
            while (row-- > 0 && matrix[row, column] != 0)
            {
                var pt = new Point(row, column);
                if (!pointsAlreadyTraversed.Contains(pt))
                    returnPoints.Add(pt);
            }
            return returnPoints;
        }

        public static int getIslandSize(int[,] matrix, int row, int column)
        {
            if (row >= 0 && row < matrix.GetLength(0) && column >= 0 && column < matrix.GetLength(1) && matrix[row, column] == 1)
            {
                matrix[row, column] = 0;
                getIslandSize(matrix, row - 1, column);
                getIslandSize(matrix, row + 1, column);
                getIslandSize(matrix, row, column - 1);
                getIslandSize(matrix, row, column + 1);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void RunTests()
        {
            var rand = new Random(DateTime.Now.Millisecond);
            Console.WriteLine("IsLand Count!");
            int dim = 8;
            var sampleMatrix = new int[,]{
                    {0, 0, 1, 1, 0, 1, 1, 1},
                    {0, 1, 0, 1, 0, 1, 1, 1},
                    {0, 0, 0, 1, 0, 1, 1, 1},
                    {1, 1, 0, 1, 0, 1, 1, 1},
                    {0, 1, 1, 1, 0, 1, 1, 1},
                    {1, 1, 1, 1, 0, 1, 1, 1},
                    {1, 1, 1, 1, 0, 1, 1, 1},
                    {1, 1, 1, 1, 0, 1, 1, 1}
                };
            var matrix = GenerateRandomMatrix(rand, dim);
            PrintMatrix(sampleMatrix);
            System.Console.WriteLine();
            System.Console.WriteLine($"Number of Islands {NumIslands(sampleMatrix)}");

            foreach (var key in foundsIslandsLocations.Keys)
            {
                System.Console.WriteLine($"################# {key} #######################");
                PrintListAsMatrix(dim, foundsIslandsLocations[key]);
                //  System.Console.WriteLine();
                //   System.Console.WriteLine($"################## End {key} #######################");
            }

            System.Console.WriteLine($"Number of Islands Using Recursion {NumIslandsUsingRecursion(sampleMatrix)}");
            System.Console.WriteLine();
        }

        private static int[,] GenerateRandomMatrix(Random rand, int dim)
        {
            var matrix = new int[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                System.Console.WriteLine();
                for (int j = 0; j < dim; j++)
                {
                    int nextVal = rand.Next(2);
                    matrix[i, j] = nextVal;
                    //System.Console.Write($"[{i},{j}] = {nextVal} ");
                    // System.Console.Write($"{nextVal} ");
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                System.Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    System.Console.Write($"{ matrix[i, j]} ");
                }
            }
        }

        private static void PrintListAsMatrix(int dim, List<Point> matrix)
        {
            string indent = $"        ";
            for (int i = 0; i < dim; i++)
            {
                System.Console.Write("            ");
                for (int j = 0; j < dim; j++)
                {
                    var thisPoint = new Point(i, j);
                    if (matrix.Contains(thisPoint))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.Write($"1");
                        //  Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.Write("0");
                    }
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }
    }
}
