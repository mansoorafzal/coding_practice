using coding_practice.helper;
using System;

namespace coding_practice.data_structure
{
    public class _Driver
    {
        public static void Data_Structure_Driver()
        {   
            //BinarySearchTree_Driver();
            //Graph_Driver();
            //LinkedList_Driver();
            //MaxBinaryHeap_Driver();
            //MinBinaryHeap_Driver();
            //NStack_Driver();
            //PriorityQueue_Driver();
            //Queue_Driver();
            //Stack_Driver();
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

            BinarySearchTree negative = new BinarySearchTree(50);
            negative.Root.Left = new Node<int>(30);
            negative.Root.Left.Left = new Node<int>(20);
            negative.Root.Left.Right = new Node<int>(60);
            negative.Root.Right = new Node<int>(80);
            negative.Root.Right.Left = new Node<int>(70);
            negative.Root.Right.Right = new Node<int>(90);

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

        private static void NStack_Driver()
        {
            int totalStacks = 3;
            int capacity = 5;

            NStack<int> nStack = new NStack<int>(totalStacks, capacity);

            nStack.Push(0, 2);
            nStack.Push(1, 12);
            nStack.Push(2, 22);

            Console.WriteLine(nStack.Pop(1));
            Console.WriteLine(nStack.Pop(0));

            nStack.Push(2, 23);
            nStack.Push(2, 24);
            nStack.Push(0, 2);
            nStack.Push(1, 12);
            nStack.Push(1, 22);

            Console.WriteLine(nStack.Pop(2));
            Console.WriteLine(nStack.Pop(2));
            Console.WriteLine(nStack.Pop(2));
            Console.WriteLine(nStack.Pop(1));
            Console.WriteLine(nStack.Pop(0));
            Console.WriteLine(nStack.Pop(0));
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
    }
}
