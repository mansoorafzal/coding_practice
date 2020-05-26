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
        public static double NPR(int n, int r = 0)
        {
            if (r == 0)
            {
                return 1;
            }

            return Problems.Factorial(n) / Problems.Factorial(n - r);
        }

        public static void Generate(int n, int r = 0)
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
            List<string> strings = new List<string>();

            //if (removeDuplicate)
            //{
            //    string a = string.Empty;

            //    for (int i = 0; i < A.Length; i++)
            //    {
            //        a += A[i];
            //    }

            //    if (r == 0)
            //    {
            //        strings.Add(a);
            //    }
            //    else
            //    {
            //        Generate(a.ToCharArray(), strings, 0, new HashSet<string>());
            //    }

            //    foreach (string s in strings)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
            //else
            //{
                
            //}

            if (r == 0)
            {
                Generate(A, list, 0);
            }
            else
            {
                Generate(A, list, new T[r], 0);
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    Console.Write(list[i][j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void Generate(T[] A, List<T[]> list, T[] data, int start)
        {
            if (start == data.Length)
            {   
                T[] temp = (T[])data.Clone();
                list.Add(temp);
            }
            else
            {
                for (int i = 0; i < A.Length; i++)
                {  
                    data[start] = A[i];
                    Generate(A, list, data, start + 1);
                }
            }
        }

        private static void Generate(T[] A, List<T[]> list, int start)
        {
            if (start == A.Length)
            {
                T[] temp = (T[])A.Clone();
                list.Add(temp);
            }
            else
            {
                for (int i = start; i < A.Length; i++)
                {
                    Utility<T>.Swap(ref A[start], ref A[i]);
                    Generate(A, list, start + 1);
                    Utility<T>.Swap(ref A[start], ref A[i]);
                }
            }
        }

        private static void Generate(char[] C, List<string> list, int start, HashSet<string> hashset)
        {
            if (start == C.Length)
            {
                string A = new string(C);

                if(!hashset.Contains(A))
                {
                    hashset.Add(A);
                    list.Add(A);
                }
            }
            else
            {
                for (int i = start; i < C.Length; i++)
                {
                    Utility<char>.Swap(ref C[start], ref C[i]);
                    Generate(C, list, start + 1, hashset);
                    Utility<char>.Swap(ref C[start], ref C[i]);
                }
            }
        }
    }
}
