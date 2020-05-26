using System;
using System.Collections.Generic;
using System.Text;

namespace coding_challenges
{
    public static class Utility<T>
    {
        public static int Compare(T t1, T t2)
        {
            if (typeof(T) == typeof(int))
            {
                return Compare(Convert.ToInt32(t1), Convert.ToInt32(t2));
            }

            if (typeof(T) == typeof(Vertex))
            {
                return Compare(((Vertex)(object)t1).Name, ((Vertex)(object)t2).Name);
            }

            if (typeof(T) == typeof(Edge))
            {
                return Compare(((Edge)(object)t1).Destination.Name, ((Edge)(object)t2).Destination.Name);
            }

            return 0;
        }

        public static int Compare(int i1, int i2)
        {
            if (i1 > i2)
            {
                return 1;
            }

            if (i1 < i2)
            {
                return -1;
            }

            return 0;
        }

        public static int Compare(string s1, string s2)
        {
            return s1.Equals(s2) ? 0 : -1;
        }

        public static void Swap(ref T t1, ref T t2)
        {
            T temp = t1;
            t1 = t2;
            t2 = temp;
        }

        public static void DisplayMatrix(T[][] matrix, int defaultLength = 11, bool displayHeader = true)
        {
            if (matrix.Length == 0)
            {
                return;
            }

            if (displayHeader)
            {
                Console.WriteLine();
                for (int y = 0; y < matrix[0].Length; y++)
                {
                    Console.Write("{0, " + defaultLength.ToString() + "}", y);
                }
                Console.WriteLine("");
                for (int y = 0; y < matrix[0].Length; y++)
                {
                    Console.Write("-".PadRight(defaultLength, '-'));
                }
            }

            Console.WriteLine("");
            for (int y = 0; y < matrix.Length; y++) // vertical
            {
                for (int x = 0; x < matrix[y].Length; x++) // horizontal
                {
                    Console.Write("{0, " + defaultLength.ToString() + "}", matrix[y][x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void DisplaArray(T[] array, int defaultLength = 4)
        {
            if (array.Length == 0)
            {
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0, " + defaultLength.ToString() + "}", array[i]);
            }

            Console.WriteLine();
        }

        public static T[][] CopyTwoDimentionalMatrix(T[][] matrix)
        {
            T[][] t = new T[matrix.GetLength(0)][];

            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                t[y] = new T[matrix[y].GetLength(0)];

                for (int x = 0; x < matrix[y].GetLength(0); x++)
                {
                    t[y][x] = matrix[y][x];
                }
            }

            return t;
        }
    }
}
