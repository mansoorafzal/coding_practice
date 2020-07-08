using System;

namespace coding_practice.problem_solving.specific
{
    public class CoinChange
    {
        public static void Resolve(int[] C, int a)
        {
            Console.WriteLine("Number Of Possible Ways: " + RecursivePossibleWays(C, a, C.Length));
            Console.WriteLine("Number Of Possible Ways: " + DynamicProgramingArrayPossibleWays(C, a));
            Console.WriteLine("Number Of Possible Ways: " + DynamicProgramingMatrixPossibleWays(C, a));
            Console.WriteLine("Minimum Coins Required: " + RecursiveOptimalWay(C, a));
            Console.WriteLine("Minimum Coins Required: " + DynamicProgramingArrayOptimalWay(C, a));
        }

        private static int RecursivePossibleWays(int[] C, int a, int c)
        {
            if (a == 0)
            {
                return 1;
            }

            if (a < 0)
            {
                return 0;
            }

            if (c <= 0 && a > 0)
            {
                return 0;
            }

            return RecursivePossibleWays(C, a, c - 1) + RecursivePossibleWays(C, a - C[c - 1], c);
        }

        private static int DynamicProgramingArrayPossibleWays(int[] C, int a)
        {
            int[] table = new int[a + 1];

            table[0] = 1; // base condition

            for (int i = 0; i < C.Length; i++)
            {
                for (int j = C[i]; j <= a; j++)
                {
                    table[j] = table[j] + table[j - C[i]];
                }
            }

            return table[a];
        }

        private static int DynamicProgramingMatrixPossibleWays(int[] C, int a)
        {
            /*
             *   | 0 1 2 3 .... A
             * --------------------
             * 0 |
             * 1 |
             * 2 |
             * 3 |
             * . |
             * . |
             * . |
             * . |
             * C |
            */

            int[][] table = new int[C.Length + 1][];

            // iterate vertically on first column
            for (int y = 0; y <= C.Length; y++)
            {
                table[y] = new int[a + 1];

                table[y][0] = 1; // amount is zero, so default value is set
            }

            // iterate horizontally on first row
            for (int x = 0; x < table[0].Length; x++)
            {
                table[0][x] = 0; // coins are zero, so shouldn't be part of calculation
            }

            //Utility<int>.DisplayMatrix(table);

            for (int y = 1; y <= C.Length; y++) // coins
            {
                for (int x = 1; x <= a; x++) // amount
                {
                    if (C[y - 1] > x)
                    {
                        table[y][x] = table[y - 1][x];
                    }
                    else
                    {
                        table[y][x] = table[y - 1][x] + table[y][x - C[y - 1]];
                    }
                }
            }

            //Utility<int>.DisplayMatrix(table);

            return table[C.Length][a];
        }

        private static int RecursiveOptimalWay(int[] C, int a)
        {
            if (a == 0)
            {
                return 0;
            }

            int count = 0;
            int result = int.MaxValue;

            for (int i = 0; i < C.Length; i++)
            {
                if (C[i] <= a)
                {
                    count = RecursiveOptimalWay(C, a - C[i]);

                    if (count != int.MaxValue && count + 1 < result)
                    {
                        result = count + 1;
                    }
                }
            }

            return result;
        }

        private static int DynamicProgramingArrayOptimalWay(int[] C, int a)
        {
            int[] table = new int[a + 1];

            table[0] = 0; // base condition

            for (int i = 1; i < table.Length; i++)
            {
                table[i] = int.MaxValue;
            }

            int count = 0;

            for (int i = 0; i < C.Length; i++)
            {
                for (int j = C[i]; j <= a; j++)
                {
                    count = table[j - C[i]];

                    if (count != int.MaxValue && count + 1 < table[j])
                    {
                        table[j] = count + 1;
                    }
                }
            }

            return table[a];
        }
    }
}
