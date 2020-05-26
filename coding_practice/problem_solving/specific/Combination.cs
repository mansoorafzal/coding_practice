using coding_practice.problem_solving.generic;
using System;
using System.Collections.Generic;

namespace coding_practice.problem_solving.specific
{
    public static class Combination<T>
    {
        public static double NCR(int n, int r = 0)
        {
            if (n == r || r == 0)
            {
                return 1;
            }

            if (r == 1)
            {
                return n;
            }

            return Problems.Factorial(n) / (Problems.Factorial(r) * Problems.Factorial(n - r));
        }

        public static void Generate(int n, int r)
        {
            T[] N = new T[n];

            for (int i = 0; i < n; i++)
            {
                if (typeof(T) == typeof(int))
                {
                    N[i] = (T)Convert.ChangeType(i + 1, typeof(T));
                }
                else if (typeof(T) == typeof(string))
                {
                    N[i] = (T)Convert.ChangeType((char)(i + 65), typeof(T));
                }
            }

            Generate(N, r);
        }

        public static void Generate(T[] A, int r)
        {
            List<T[]> list = new List<T[]>();

            if (r == 0)
            {
                list.Add(A);
            }
            else
            {
                Generate(A, list, new T[r], 0, 0);
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    Console.Write(list[i][j] + " ");
                }

                Console.Write(" - ");
            }

            Console.WriteLine();
        }

        private static void Generate(T[] A, List<T[]> list, T[] data, int start, int index)
        {
            if (index == data.Length)
            {
                T[] temp = (T[])data.Clone();
                list.Add(temp);
            }
            else if (start <= A.Length - 1)
            {
                data[index] = A[start];
                Generate(A, list, data, start + 1, index + 1);
                Generate(A, list, data, start + 1, index);
            }
        }
    }
}
