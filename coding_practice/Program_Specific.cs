using System;
using System.Collections.Generic;

namespace coding_challenges
{
    public class Program_Specific
    {
        public static void Specific_Driver()
        {
            //BinarySearchTree_Driver();
            //CoinChange_Driver();
            //Combination_Driver();
            //Graph_Driver();
            //Knapsack_Driver();
            //LinkedList_Driver();
            //MaxBinaryHeap_Driver();
            //MinBinaryHeap_Driver();
            //Permutation_Driver();
            PriorityQueue_Driver();
            //Queue_Driver();
            //Stack_Driver();
            //Sudoku_Driver();
            //TowerOfHanoi_Driver();

            Console.Read();
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

        private static void MaxBinaryHeap_Driver()
        {
            int capacity = 15;

            MaxBinaryHeap<int> maxBinaryHeap = new MaxBinaryHeap<int>(capacity);

            maxBinaryHeap.Insert(3);
            maxBinaryHeap.Insert(5);
            maxBinaryHeap.Insert(8);
            maxBinaryHeap.Insert(1);
            maxBinaryHeap.Insert(25);
            maxBinaryHeap.Insert(100);
            maxBinaryHeap.Insert(16);
            maxBinaryHeap.Insert(19);
            maxBinaryHeap.Insert(60);
            maxBinaryHeap.Insert(17);
            maxBinaryHeap.Insert(2);
            maxBinaryHeap.Insert(95);
            maxBinaryHeap.Insert(90);
            maxBinaryHeap.Insert(20);
            maxBinaryHeap.Insert(4);

            maxBinaryHeap.GenerateAndPrintTraversal();

            Console.WriteLine(maxBinaryHeap.Remove());
            Console.WriteLine(maxBinaryHeap.Remove());

            maxBinaryHeap.GenerateAndPrintTraversal();
        }

        private static void MinBinaryHeap_Driver()
        {
            int capacity = 15;

            MinBinaryHeap<int> minBinaryHeap = new MinBinaryHeap<int>(capacity);

            minBinaryHeap.Insert(3);
            minBinaryHeap.Insert(5);
            minBinaryHeap.Insert(8);
            minBinaryHeap.Insert(1);
            minBinaryHeap.Insert(25);
            minBinaryHeap.Insert(100);
            minBinaryHeap.Insert(16);
            minBinaryHeap.Insert(19);
            minBinaryHeap.Insert(60);
            minBinaryHeap.Insert(17);
            minBinaryHeap.Insert(2);
            minBinaryHeap.Insert(95);
            minBinaryHeap.Insert(90);
            minBinaryHeap.Insert(20);
            minBinaryHeap.Insert(4);

            minBinaryHeap.GenerateAndPrintTraversal();

            Console.WriteLine(minBinaryHeap.Remove());
            Console.WriteLine(minBinaryHeap.Remove());

            minBinaryHeap.GenerateAndPrintTraversal();
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

        private static void PriorityQueue_Driver()
        {
            int capacity = 15;

            Console.WriteLine("Max Priority Queue: Begin");

            PriorityQueue<int> maxPriorityQueue = new PriorityQueue<int>(capacity, Constant.Priority.Maximum);

            maxPriorityQueue.Enqueue(5);
            maxPriorityQueue.Enqueue(8);
            maxPriorityQueue.Enqueue(2);
            maxPriorityQueue.Enqueue(9);
            maxPriorityQueue.Enqueue(3);
            maxPriorityQueue.Enqueue(7);
            maxPriorityQueue.Enqueue(10);
            maxPriorityQueue.Enqueue(4);
            
            maxPriorityQueue.PrintRegular();

            Console.WriteLine(maxPriorityQueue.Dequeue());
            Console.WriteLine(maxPriorityQueue.Dequeue());
            Console.WriteLine(maxPriorityQueue.Dequeue());
            Console.WriteLine(maxPriorityQueue.Dequeue());

            maxPriorityQueue.PrintRegular();

            Console.WriteLine("Max Priority Queue: End");
            Console.WriteLine("Min Priority Queue: Begin");

            PriorityQueue<int> minPriorityQueue = new PriorityQueue<int>(capacity, Constant.Priority.Minimum);

            minPriorityQueue.Enqueue(5);
            minPriorityQueue.Enqueue(8);
            minPriorityQueue.Enqueue(2);
            minPriorityQueue.Enqueue(9);
            minPriorityQueue.Enqueue(3);
            minPriorityQueue.Enqueue(7);
            minPriorityQueue.Enqueue(10);
            minPriorityQueue.Enqueue(4);

            minPriorityQueue.PrintRegular();

            Console.WriteLine(minPriorityQueue.Dequeue());
            Console.WriteLine(minPriorityQueue.Dequeue());
            Console.WriteLine(minPriorityQueue.Dequeue());
            Console.WriteLine(minPriorityQueue.Dequeue());

            minPriorityQueue.PrintRegular();

            Console.WriteLine("Min Priority Queue: End");
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
