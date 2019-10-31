using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
// {
// {0, 0, 1, 1, 0, 1, 1, 1},
// {0, 1, 0, 1, 0, 1, 1, 1},
// {0, 0, 0, 1, 0, 1, 2, 3},
// {8, 9, 0, 1, 0, 1, 2, 3},
// {0, 1, 2, 3, 0, 1, 2, 3},
// {4, 5, 6, 7, 0, 1, 2, 3},
// {8, 9, 10, 11, 0, 1, 2, 3},
// {8, 9, 10, 11, 0, 1, 2, 3}
// };

namespace hackertests.Tests
{
    public class IslandCount : ITestProgram
    {
        public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.LeetAddTwoNumberLists;
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
                        else
                            System.Console.WriteLine("Zero Points !!!!!!!!");
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
            while (column++ < matrix.GetLength(1) - 1 && matrix[row, column] != 0)
            {
                var pt = new Point(row, column);
                if (!pointsAlreadyTraversed.Contains(pt))
                    returnPoints.Add(pt);

            }
            row = rowstart;
            column = columnStart;
            while (row++ < matrix.GetLength(0) - 1 && matrix[row, column] != 0)
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

            var matrix = new int[dim, dim];

            PrintRandomMatrix(rand, dim, matrix);


            System.Console.WriteLine($"Number of Islands {NumIslands(matrix)}");

            foreach (var key in foundsIslandsLocations.Keys)
            {
                System.Console.WriteLine($"################# {key} #######################");
                PrintListAsMatrix(dim, foundsIslandsLocations[key]);
                //  System.Console.WriteLine();
                //   System.Console.WriteLine($"################## End {key} #######################");
            }

            System.Console.WriteLine($"Number of Islands Using Recursion {NumIslandsUsingRecursion(matrix)}");
            System.Console.WriteLine();

        }

        private static void PrintRandomMatrix(Random rand, int dim, int[,] matrix)
        {
            for (int i = 0; i < dim; i++)
            {
                System.Console.WriteLine();
                for (int j = 0; j < dim; j++)
                {
                    int nextVal = rand.Next(2);
                    matrix[i, j] = nextVal;
                    //System.Console.Write($"[{i},{j}] = {nextVal} ");
                    System.Console.Write($"{nextVal} ");
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
                        System.Console.Write("_");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }
    }
}
