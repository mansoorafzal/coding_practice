using coding_practice.data_structure;
using System;
using System.Collections.Generic;

namespace coding_practice.problem_solving.specific
{
    public class _Driver
    {
        public static void Problem_Solving_Specific_Driver()
        {
            //CoinChange_Driver();
            //Combination_Driver();
            //Knapsack_Driver();
            //Permutation_Driver();
            //Sudoku_Driver();
            //TowerOfHanoi_Driver();
        }

        private static void CoinChange_Driver()
        {
            int[] C = { 2, 5, 10 };
            int a = 22;

            CoinChange.Resolve(C, a);
        }

        private static void Combination_Driver()
        {
            int n = 4;
            int r = 0;
            int[] N = { 6, 7, 8, 9 };
            string[] S = { "W", "X", "Y", "Z" };

            Console.WriteLine(n + "C" + r + ": " + Combination<int>.NCR(n, r));
            Console.WriteLine(n + "C: " + Combination<int>.NCR(n));

            Combination<int>.Generate(n, r);
            Combination<string>.Generate(n, r);

            Combination<int>.Generate(N, r);
            Combination<string>.Generate(S, r);
        }

        private static void Knapsack_Driver()
        {
            Item<int>[] items = { new Item<int>(2, 20), new Item<int>(3, 8), new Item<int>(4, 12), new Item<int>(5, 15) };
            int weight = 10;

            Knapsack.Resolve(items, weight);
        }

        private static void Permutation_Driver()
        {
            int n = 4;
            int r = 2;
            int[] N = { 6, 7, 8, 9 };
            string[] S = { "W", "X", "Y", "Z" };

            Console.WriteLine(n + "P" + r + ": " + Permutation<int>.NPR(n, r));
            Console.WriteLine(n + "P: " + Permutation<int>.NPR(n));

            Permutation<int>.Generate(n, r);
            Permutation<string>.Generate(n, r);

            Permutation<int>.Generate(N, r);
            Permutation<string>.Generate(S, r);
        }

        private static void Sudoku_Driver()
        {
            char[][] board = new char[9][]
            {
                new char[9]{ '.', '.', '9', '7', '4', '8', '.', '.', '.' },
                new char[9]{ '7', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[9]{ '.', '2', '.', '1', '.', '9', '.', '.', '.' },
                new char[9]{ '.', '.', '7', '.', '.', '.', '2', '4', '.' },
                new char[9]{ '.', '6', '4', '.', '1', '.', '5', '9', '.' },
                new char[9]{ '.', '9', '8', '.', '.', '.', '3', '.', '.' },
                new char[9]{ '.', '.', '.', '8', '.', '3', '.', '2', '.' },
                new char[9]{ '.', '.', '.', '.', '.', '.', '.', '.', '6' },
                new char[9]{ '.', '.', '.', '2', '7', '5', '9', '.', '.' },
            };

            Sudoku.Resolve(board);
        }

        private static void TowerOfHanoi_Driver()
        {
            int n = 4;

            TowerOfHanoi.Resolve(n);
        }
    }
}
