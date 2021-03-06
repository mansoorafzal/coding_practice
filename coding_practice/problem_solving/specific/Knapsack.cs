﻿using coding_practice.data_structure;
using coding_practice.helper;
using System;
using System.Collections.Generic;

namespace coding_practice.problem_solving.specific
{
    public static class Knapsack
    {
        public static void Resolve(Item<int>[] items, int W)
        {
            Console.WriteLine("0-1 Recursive: " + Recursive(items, W, 0));
            Console.WriteLine("0-1 Recursive Cache: " + RecursiveCache(items, W, 0));
            Console.WriteLine("0-1 Dynamic Programing: " + DynamicProgramingMatrix(items, W));
            Console.WriteLine("Unbounded Dynamic Programing: " + DynamicProgramingArray(items, W));
        }

        public static int Recursive(Item<int>[] items, int W, int start)
        {
            if (start == items.Length)
            {
                return 0;
            }

            if (W - items[start].Weight < 0)
            {
                return Recursive(items, W, start + 1);
            }

            return Math.Max(Recursive(items, W - items[start].Weight, start + 1) + items[start].Value, Recursive(items, W, start + 1));
        }

        public static int RecursiveCache(Item<int>[] items, int W, int start)
        {
            Dictionary<int, Dictionary<int, int>> dictionary = new Dictionary<int, Dictionary<int, int>>();

            return RecursiveCache(items, W, start, dictionary);
        }

        public static int RecursiveCache(Item<int>[] items, int W, int start, Dictionary<int, Dictionary<int, int>> dictionary)
        {
            int v;

            if (start == items.Length)
            {
                return 0;
            }

            if (!dictionary.ContainsKey(start))
            {
                dictionary.Add(start, new Dictionary<int, int>());
            }

            Dictionary<int, int> d = null;

            if (dictionary.TryGetValue(start, out d))
            {
                if (d.TryGetValue(W, out v))
                {
                    return v;
                }
            }

            if (W - items[start].Weight < 0)
            {
                return RecursiveCache(items, W, start + 1);
            }

            v = Math.Max(RecursiveCache(items, W - items[start].Weight, start + 1, dictionary) + items[start].Value, RecursiveCache(items, W, start + 1, dictionary));

            d = new Dictionary<int, int>();
            d.Add(W, v);

            dictionary[start] = d;

            return v;
        }

        public static int DynamicProgramingMatrix(Item<int>[] items, int W)
        {
            /*
             *   | 0 1 2 3 .... W
             * --------------------
             * 0 |
             * 1 |
             * 2 |
             * 3 |
             * . |
             * . |
             * . |
             * . |
             * I |
            */

            int[][] table = new int[items.Length + 1][];

            for (int y = 0; y <= items.Length; y++)
            {
                table[y] = new int[W + 1];
            }

            // iterate vertically
            for (int y = 0; y <= items.Length; y++)
            {
                if (y == 0)
                {
                    continue;
                }

                // iterate horizontally
                for (int x = 0; x <= W; x++)
                {
                    if (items[y - 1].Weight > x)
                    {
                        table[y][x] = table[y - 1][x];
                    }
                    else
                    {
                        table[y][x] = Math.Max(table[y - 1][x], table[y - 1][x - items[y - 1].Weight] + items[y - 1].Value);
                    }
                }
            }

            //Utility<int>.DisplayMatrix(table, 5);

            return table[items.Length][W];
        }

        public static int DynamicProgramingArray(Item<int>[] items, int W)
        {
            int[] table = new int[W + 1];

            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    if (items[i].Weight <= j)
                    {
                        table[j] = Math.Max(table[j], table[j - items[i].Weight] + items[i].Value);
                    }
                }
            }

            //Utility<int>.DisplaArray(table, 5);

            return table[W];
        }
    }
}
