using System;
using System.Collections.Generic;
using System.Drawing;
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
namespace IslandCount
{
    class Program
    {
        Dictionary<int, List<Point>> foundsIslandsLocations = new Dictionary<int, List<Point>>();
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
                        maxIslands += getIslandSize(matrix, row, column);
                       // foundsIslandsLocations.Add(maxIslands, new List<Point>().Add(new Point(row,column)) );
                    }
                }
            }
            return maxIslands;
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
        static void Main(string[] args)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            Console.WriteLine("IsLand Count!");
            int dim = 16;

            var matrix = new int[dim, dim];

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
            System.Console.WriteLine();
            System.Console.WriteLine($"Number of Islands {NumIslands(matrix)}");
        }
    }
}
