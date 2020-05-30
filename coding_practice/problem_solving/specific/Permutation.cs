using coding_practice.helper;
using coding_practice.problem_solving.generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace coding_practice
{

    // TODO - not working (https://stattrek.com/online-calculator/combinations-permutations.aspx)
    public static class Permutation<T>
    {
        // nPr = n! / (n - r)!
        public static double NPR(int n, int r = 0)
        {
            if (r == 0)
            {
                return 1;
            }

            return Maths.Factorial(n) / Maths.Factorial(n - r);
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
            bool duplicate = true;

            if (r == 0)
            {
                list.Add(A);
            }
            else
            {
                Generate(A, list, new T[r], 0, ref duplicate);
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    Console.Write(list[i][j]);
                }

                Console.Write(" - ");
            }

            Console.WriteLine();
        }

        private static void Generate(T[] A, List<T[]> list, T[] data, int start, ref bool duplicate)
        {
            if (start == data.Length)
            {
                if (!duplicate)
                {
                    T[] temp = (T[])data.Clone();
                    list.Add(temp);

                    duplicate = true;
                }
            }
            else
            {
                for (int i = 0; i < A.Length; i++)
                {  
                    if (data.Length > 1 && start > 0 && start < data.Length)
                    {
                        if (duplicate && Utility<T>.Compare(data[start - 1], A[i]) != 0)
                        {
                            duplicate = false;
                        }
                    }
                    else
                    {
                        duplicate = false;
                    }

                    data[start] = A[i];
                    Generate(A, list, data, start + 1, ref duplicate);
                }
            }
        }
    }
}
