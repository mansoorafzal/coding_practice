using System;
using System.Collections.Generic;

namespace coding_challenges
{
    public class Program_Generic
    {
        public static void Generic_Driver()
        {
            //AddCubes_Driver();
            //BinarySearch_Driver();
            //FindConsecutive_Driver();
            //FindDuplicate_Driver();
            MergeNSortedArrays_Driver();
            //SquareSubmatrix_Driver();
            //ZeroMatrix_Driver();

            Console.Read();
        }

        private static void AddCubes_Driver()
        {
            int n = 200;

            Problems.AddCubes(n);
        }

        private static void BinarySearch_Driver()
        {
            int[] N = { -4, -1, 0, 2, 5, 6, 7, 9, 11, 14, 18, 22, 23, 23, 28, 32 };
            int a = -4;
            int b = 0;
            int c = 32;
            int d = 15;

            Console.WriteLine(a + ": " + Problems.BinarySearch(N, a));
            Console.WriteLine(b + ": " + Problems.BinarySearch(N, b));
            Console.WriteLine(c + ": " + Problems.BinarySearch(N, c));
            Console.WriteLine(d + ": " + Problems.BinarySearch(N, d));
        }

        private static void FindConsecutive_Driver()
        {
            int[] N = { 4, 3, 6, 7, 9, 4, 3, 6, 6, 6, 4, 5 };

            Console.WriteLine(Problems.FindConsecutive(N));
        }

        private static void FindDuplicate_Driver()
        {
            int[] N = { 4, 3, 6, 7, 9, 4, 3, 6, 6, 6, 4 };

            int[] duplicates = Problems.FindDuplicate(N);

            for (int i = 0; i < duplicates.Length; i++)
            {
                Console.Write(duplicates[i] + " - ");
            }
        }

        private static void MergeNSortedArrays_Driver()
        {
            int[][] matrix = new int[][]
            {
                new int[]{1, 4, 7, 11, 23},
                new int[]{2, 5, 8, 9},
                new int[]{3, 6, 9, 11},
                new int[]{4, 6, 8},
                new int[]{10},
            };

            Problems.MergeNSortedArrays(matrix);
        }

        private static void SquareSubmatrix_Driver()
        {
            int[][] matrix = new int[][]
            {
                new int[]{0, 1, 1, 0},
                new int[]{1, 1, 1, 1},
                new int[]{1, 0, 1, 1},
                new int[]{0, 1, 1, 1},
            };

            Problems.SquareSubmatrix(matrix);
        }

        private static void ZeroMatrix_Driver()
        {
            bool[][] matrix = new bool[9][]
            {
                new bool[9]{ false, false, false, false, false, false, false, false, true },
                new bool[9]{ true, false, false, false, false, false, false, false, false },
                new bool[9]{ false, false, false, false, false, false, false, false, false },
                new bool[9]{ false, false, true, false, false, false, false, false, false },
                new bool[9]{ false, false, false, false, false, false, false, false, false },
                new bool[9]{ false, false, false, false, false, false, false, false, false },
                new bool[9]{ false, false, false, false, false, false, false, false, false },
                new bool[9]{ false, false, false, false, false, false, false, false, false },
                new bool[9]{ false, false, false, false, true, false, false, false, false },
            };

            Problems.ZeroMatrix(matrix);
        }
    }
}
