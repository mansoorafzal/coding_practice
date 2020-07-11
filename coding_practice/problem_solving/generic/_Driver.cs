using System;
using System.Collections.Generic;

namespace coding_practice.problem_solving.generic
{
    public class _Driver
    {
        public static void Problem_Solving_Generic_Driver()
        {
            //BinomialCoefficient_Driver();
            //CatalanNumber_Driver();
            //Factorial_Driver();
            //Fibonacci_Driver();
            //Median_Driver();
            //ToBinary_Driver();

            //AddCubes_Driver();
            //BinarySearch_Driver();
            //CopySortedArrays_Driver();
            //DigitSum_Driver();
            //FindConsecutive_Driver();
            //FindDuplicate_Driver();
            //FindNDigitNumbers_Driver();
            //GenerateSubsequences_Driver();
            //IsAnagram_Driver();
            //IsInterleaved_Driver();
            //IsOneStringPalindrome_Driver();
            //IsTwoStringsPalindrome_Driver();
            //IsExpressionValid_Driver();
            //MatrixProduct_Driver();
            //MatrixSearch_Driver();
            //MergeNSortedArrays_Driver();
            //ReverseWords_Driver();
            //SquareSubmatrix_Driver();
            //ZeroMatrix_Driver();
            //ZeroSum_Driver();

            //MergeSort_Driver();
            //QuickSort_Driver();
        }

        #region Maths

        private static void BinomialCoefficient_Driver()
        {
            int n = 8;
            int k = 5;

            Console.WriteLine(Maths.BinomialCoefficient(n, k));
        }

        private static void CatalanNumber_Driver()
        {
            int n = 8;

            Console.WriteLine("Recursive: " + Maths.CatalanNumber(n));
            Console.WriteLine("Binomial Coefficient: " + Maths.CatalanNumber(n, true));
        }

        private static void Factorial_Driver()
        {
            int n = 8;

            Console.WriteLine(Maths.Factorial(n));
        }

        private static void Fibonacci_Driver()
        {
            int n = 8;

            Console.WriteLine(Maths.Fibonacci(n));
        }

        private static void Median_Driver()
        {
            int[] a = { 1, 2, 3, 7, 8, 9 };
            int[] b = { 4, 5, 6, 7, 8, 9 };

            Console.WriteLine(Maths.Median(a, b));
        }

        private static void ToBinary_Driver()
        {
            string a = "MANSOOR";

            Console.WriteLine(Maths.ToBinary(a));
        }

        #endregion

        #region Problems

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

        private static void CopySortedArrays_Driver()
        {
            int[] a = { 2, 3, 6, 0, 0, 0 };
            int[] b = { 1, 4, 5 };

            int[] c = Problems.CopySortedArrays(a, b);

            for (int i = 0; i < c.Length; i++)
            {
                Console.Write(c[i] + " - ");
            }
        }

        private static void DigitSum_Driver()
        {
            int n = 3;
            int sum = 6;

            Problems.DigitSum(n, sum);
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

        private static void FindNDigitNumbers_Driver()
        {
            int n = 3;
            int sum = 6;
            List<string> list = new List<string>();

            Problems.FindNDigitNumbers(n, sum, string.Empty, list);

            foreach (string s in list)
            {
                Console.Write(s + " ");
            }
        }

        private static void GenerateSubsequences_Driver()
        {
            string a = "ABCD";

            List<string> list = Problems.GenerateSubsequences(a);

            foreach (string s in list)
            {
                Console.Write(s + " ");
            }
        }

        private static void IsAnagram_Driver()
        {
            string a = "aabcddef";
            string b = "abcdadef";

            Console.WriteLine(Problems.IsAnagram(a, b));
        }

        private static void IsInterleaved_Driver()
        {
            string a = "abcdefgh";
            string b = "stuvwxyz";
            string c = "stabucdevwxyfgzh";

            Console.WriteLine(Problems.IsInterleaved(a, b, c));
        }

        private static void IsOneStringPalindrome_Driver()
        {
            string a = "bananab";

            Console.WriteLine(Problems.IsOneStringPalindrome(a));
        }

        private static void IsTwoStringsPalindrome_Driver()
        {
            string a = "banana";
            string b = "ananab";

            Console.WriteLine(Problems.IsTwoStringsPalindrome(a, b));
        }

        private static void IsExpressionValid_Driver()
        {
            string s = "([]{[]})[]{{}()}";

            Console.WriteLine(Problems.IsExpressionValid(s));
        }

        private static void MatrixProduct_Driver()
        {
            int[][] matrix = new int[][]
            {
                new int[]{-1, 2, 3},
                new int[]{4, 5, -6},
                new int[]{7, 8, 9},
            };

            Console.WriteLine(Problems.MatrixProduct(matrix));
        }

        private static void MatrixSearch_Driver()
        {
            int x = 118;
            int[][] matrix = new int[][]
            {
                new int[]{1, 2, 3, 4},
                new int[]{5, 6, 7, 8},
                new int[]{9, 10, 11, 12},
                new int[]{14, 16, 18},
                new int[]{100, 102, 110, 118},
            };

            Console.WriteLine(Problems.MatrixSearch(matrix, x));
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

        private static void ReverseWords_Driver()
        {
            string a = "This code is being written in may 2020";
            
            Console.WriteLine("Original Sentence: " + a);
            Console.WriteLine("Reverse Sentence: " + Problems.ReverseWords(a));
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

        private static void ZeroSum_Driver()
        {
            int[] n = { 1, 2, -5, 1, 2, -1 };

            Problems.ZeroSum(n);
        }

        #endregion

        #region Sort

        private static void MergeSort_Driver()
        {
            int min = 1;
            int max = 100;
            int size = 15;
            int[] N = new int[size];

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                N[i] = random.Next(min, max);
            }

            Sort.Merge(N);
        }

        private static void QuickSort_Driver()
        {
            int min = 1;
            int max = 100;
            int size = 15;
            int[] N = new int[size];

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                N[i] = random.Next(min, max);
            }

            Sort.Quick(N);
        }

        #endregion
    }
}
