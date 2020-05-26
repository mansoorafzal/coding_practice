using System;
using System.Collections.Generic;

namespace coding_challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program_Generic.Generic_Driver();

            Program_Specific.Specific_Driver();

            Console.Read();

            //Console.WriteLine("Hello World!");

            //int[] a = { 1, 2, 3, 4, 15, 7, 9, 10, 12, 5, 7, 8, 4, 9, 8, 2, 3, 5, 11, 6 };
            //int[] b = { 4, 5, 5, 6, 8, 9, 10, 11, 12, 13 };
            //Console.WriteLine(Trivia.FindConsecutive(a));


            //Trivia.ZeroMatrixBruteForce(matrix);
            //Trivia.ZeroMatrixEffecient(matrix);
            //Sudoku.Resolve(board);

            //int[][] matrix = new int[3][];
            //matrix[0] = new int[3];
            //matrix[0][0] = 1;
            //matrix[0][1] = 2;
            //matrix[0][2] = 3;
            //matrix[1] = new int[3];
            //matrix[1][0] = 4;
            //matrix[1][1] = 5;
            //matrix[1][2] = 6;
            //matrix[2] = new int[3];
            //matrix[2][0] = 7;
            //matrix[2][1] = 8;
            //matrix[2][2] = 9;
            //Console.WriteLine(Trivia.MatrixProduct(matrix));

   

            #region Binary Tree



            #endregion

            //int[] A = { -2, 1, 2, 4, 7, 11 };
            //int target = 13;

            //Console.WriteLine(TwoSum.BruteForce(A, target));
            //Console.WriteLine(TwoSum.Dictionary(A, target));
            //Console.WriteLine(TwoSum.Linear(A, target));

            #region String Manipulation

            //string a = "ACA";
            //string b = "BD";
            //string c = "AABCD";

            //Console.WriteLine(StringManipulation.IsInterleaved(a, b, c));

            //List<string> list = StringManipulation.Subsequences(c);
            //foreach(string s in list)
            //{
            //    Console.Write(s + " ");
            //}
            //Console.WriteLine(StringManipulation.ToBinary(c));
            //Console.WriteLine(StringManipulation.ReverseWords(c));
            //Console.WriteLine(StringManipulation.SortBubble(a));
            //Console.WriteLine(StringManipulation.SortCounter(a));
            //Console.WriteLine(StringManipulation.IsPalindrome(a, b));
            //Console.WriteLine(StringManipulation.IsPalindrome(a));
            //Console.Write(StringManipulation.IsAnagram(a, b));

            #endregion

            #region Mathematics

            //Mathematics.FindNDigitNumbers(3, 6, "");
            //Console.WriteLine(Mathematics.Fibonacci(2));

            //int n = 3;
            //int r = 2;
            //int[] N = { 5, 6, 7 };
            //Console.WriteLine("P: " + Mathematics.NPR(n, r));
            //Console.WriteLine("C: " + Mathematics.NCR(n, r));
            //Mathematics.Combination(n, r);
            //Console.WriteLine();
            //Mathematics.Combination(N, r);

            //int n = 5;
            //int sum = 40;
            //Mathematics.DigitSum(n, sum);

            //int n = 9;
            //Console.WriteLine(Mathematics.Factorial(n));

            //Console.WriteLine(Trivia.BinarySearch(N, t));

            #endregion

            //int n = 2;
            //int r = 0;
            //int[] N = { 1, 2, 3, 4 };
            //string[] S = { "A", "B", "A" };

            //Console.WriteLine("C: " + Mathematics.NCR(n, r));
            //Combination<int>.Generate(n, r);
            //Combination<int>.Generate(N, r);
            //Combination<string>.Generate(n, r);
            //Combination<string>.Generate(S, r);

            //Console.WriteLine("P: " + Mathematics.NPR(n, r));
            //Permutation<int>.Generate(n, r);
            //Permutation<int>.Generate(N, r);
            //Permutation<string>.Generate(n, r);
            //Permutation<string>.Generate(S, r, true);
            //Permutation<string>.Generate(S, r);


        }

        private static void Problems_Driver()
        {
            int[] N_BinarySearch = { -4, -1, 0, 2, 5, 6, 7, 9, 11, 14, 18, 22, 23, 23, 28, 32 };
            int a_BinarySearch = -4;
            int b_BinarySearch = 0;
            int c_BinarySearch = 32;
            int d_BinarySearch = 15;

            Console.WriteLine(a_BinarySearch + ": " + Problems.BinarySearch(N_BinarySearch, a_BinarySearch));
            Console.WriteLine(b_BinarySearch + ": " + Problems.BinarySearch(N_BinarySearch, b_BinarySearch));
            Console.WriteLine(c_BinarySearch + ": " + Problems.BinarySearch(N_BinarySearch, c_BinarySearch));
            Console.WriteLine(d_BinarySearch + ": " + Problems.BinarySearch(N_BinarySearch, d_BinarySearch));
        }

        private static void BinarySearchTree_Driver()
        {
            int n = 7;
            int a = 6;
            int b = 12;

            BinarySearchTree binarySearchTree = new BinarySearchTree(10, Constant.Duplicate.Handle);
            binarySearchTree.Insert(6);
            binarySearchTree.Insert(14);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(11);
            binarySearchTree.Insert(4);
            binarySearchTree.Insert(20);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(22);
            binarySearchTree.Insert(11);

            BinarySearchTree negative = new BinarySearchTree(1);
            negative.Root.Left = new Node<int>(2);
            negative.Root.Right = new Node<int>(3);

            binarySearchTree.CalculateAndPrintProperties(Constant.PropertyType.Height);
            binarySearchTree.CalculateAndPrintProperties(Constant.PropertyType.Size_Iterative);
            binarySearchTree.CalculateAndPrintProperties(Constant.PropertyType.Size_Recursive);

            Console.WriteLine("Possible Binary Search Trees (" + n + "): " + binarySearchTree.PossibleBinarySearchTrees(n));
            Console.WriteLine("Possible Binary Trees (" + n + "): " + binarySearchTree.PossibleBinaryTrees(n));
        
            binarySearchTree.GenerateAndPrintTraversal(Constant.TraversalType.PreOrder);
            binarySearchTree.GenerateAndPrintTraversal(Constant.TraversalType.InOrder);
            binarySearchTree.GenerateAndPrintTraversal(Constant.TraversalType.PostOrder);
            binarySearchTree.GenerateAndPrintTraversal(Constant.TraversalType.LevelOrder);
            binarySearchTree.GenerateAndPrintTraversal(Constant.TraversalType.ReverseLevelOrder);

            Console.WriteLine("Is Exists(" + a + "): " + binarySearchTree.IsExist(a));
            Console.WriteLine("Is Exists(" + b + "): " + binarySearchTree.IsExist(b));

            Console.WriteLine("Is Binary Search Tree: " + binarySearchTree.IsBinarySearchTree());
            Console.WriteLine("Is Binary Search Tree (negative): " + negative.IsBinarySearchTree());
        }

        private static void CoinChange_Driver()
        {
            int[] C = { 2, 5, 10 };
            int a = 22;

            CoinChange.Resolve(C, a);
        }

        private static void Combination_Driver()
        {
            int n = 5;
            int r = 3;
            int[] N = { 5, 6, 7, 8, 9 };
            string[] S = { "V", "W", "X", "Y", "Z" };

            Console.WriteLine(n + "C" + r + ": " + Combination<int>.NCR(n, r));
            Console.WriteLine(n + "C: " + Combination<int>.NCR(n));

            Combination<int>.Generate(n, r);
            Combination<string>.Generate(n, r);

            Combination<int>.Generate(N, r);
            Combination<string>.Generate(S, r);
        }

        private static void Graph_Driver()
        {
            string s = "A";
            string d = "D";

            Graph graph = new Graph();
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "E");
            graph.AddEdge("B", "E");
            graph.AddEdge("B", "C");
            graph.AddEdge("E", "D");
            graph.AddEdge("C", "D");
            graph.AddEdge("D", "F");

            graph.PrintAdjacencyMatrix();

            graph.GenerateAndPrintTraversal(Constant.TraversalType.BreadthFirst);
            graph.GenerateAndPrintTraversal(Constant.TraversalType.DepthFirst);

            graph.FindAndPrintPaths(s, d);
        }

        private static void Knapsack_Driver()
        {
            Item<int>[] items = { new Item<int>(1, 6), new Item<int>(2, 10), new Item<int>(3, 12), new Item<int>(4, 15) };
            int weight = 7;

            Knapsack.Resolve(items, weight);
        }

        private static void LinkedList_Driver()
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.InsertFirst("A");
            linkedList.InsertFirst("B");
            linkedList.InsertFirst("C");
            linkedList.InsertFirst("D");
            linkedList.InsertFirst("E");
            linkedList.PrintRegular();
            linkedList.InsertLast("F");
            linkedList.InsertLast("G");
            linkedList.InsertLast("H");
            linkedList.PrintRegular();
            linkedList.RemoveFirst();
            linkedList.RemoveFirst();
            linkedList.PrintRegular();
            linkedList.RemoveLast();
            linkedList.RemoveLast();
            linkedList.PrintRegular();
            linkedList.PrintReverse();
        }

        private static void Permutation_Driver()
        {
            int n = 3;
            int r = 2;
            int[] N = { 7, 8, 9 };
            string[] S = { "X", "Y", "Z" };

            Console.WriteLine(n + "P" + r + ": " + Permutation<int>.NPR(n, r));
            Console.WriteLine(n + "P: " + Permutation<int>.NPR(n));

            //Permutation<int>.Generate(n, r);
            //Permutation<string>.Generate(n, r);

            //Permutation<int>.Generate(N, r, true);
            //Permutation<string>.Generate(S, r);
        }

        private static void Queue_Driver()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.PrintRegular();
            queue.Dequeue();
            queue.Dequeue();
            queue.PrintRegular();
        }

        private static void Stack_Driver()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.PrintRegular();
            stack.Pop();
            stack.Pop();
            stack.PrintRegular();
            stack.PushAtBottom(6);
            stack.PushAtBottom(7);
            stack.PrintRegular();
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
