using coding_practice.helper;
using coding_practice.problem_solving.generic;
using System;
using System.Collections.Generic;

namespace coding_practice.data_structure
{
    public class BinaryTree
    {
        public BinaryTree()
        {
            Root = null;
            Traversal = string.Empty;
            Duplicate = Constant.Duplicate.Ignore;
        }

        public BinaryTree(Constant.Duplicate duplicate)
        {   
            Traversal = string.Empty;
            Duplicate = duplicate;
        }

        public BinaryTree(int item, Constant.Duplicate duplicate)
        {
            Root = new Node<int>(item);
            Traversal = string.Empty;
            Duplicate = duplicate;
        }

        public Node<int> Root { get; set; }

        public string Traversal { get; private set; }

        protected Constant.Duplicate Duplicate { get; private set; }

        public int[] GenerateTraversal(Constant.TraversalType traversalType)
        {
            List<int> list = new List<int>();

            if (traversalType == Constant.TraversalType.PreOrder)
            {
                PreOrder(Root, list);
            }
            else if (traversalType == Constant.TraversalType.InOrder)
            {
                InOrder(Root, list);
            }
            else if (traversalType == Constant.TraversalType.PostOrder)
            {
                PostOrder(Root, list);
            }
            else if (traversalType == Constant.TraversalType.LevelOrder)
            {
                LevelOrder(Root, list);
            }
            else if (traversalType == Constant.TraversalType.ReverseLevelOrder)
            {
                ReverseLevelOrder(Root, list);
            }

            return list.ToArray();
        }

        public void GenerateAndPrintTraversal(Constant.TraversalType traversalType)
        {
            int[] list = GenerateTraversal(traversalType);

            Traversal = string.Empty;

            for (int i = 0; i < list.Length; i++)
            {
                Traversal += list[i].ToString() + " - ";
            }

            Console.WriteLine(traversalType + ": " + Traversal);
        }

        public void CalculateAndPrintProperties(Constant.PropertyType propertyType)
        {
            int property = 0;

            if (propertyType == Constant.PropertyType.Height)
            {
                property = CalculateHeight(Root);
            }
            else if (propertyType == Constant.PropertyType.Size_Iterative)
            {
                property = CalculateSize();
            }
            else if (propertyType == Constant.PropertyType.Size_Recursive)
            {
                property = CalculateSize(Root);
            }

            Console.WriteLine(propertyType + ": " + property.ToString());
        }

        public virtual void Insert(int item)
        {

        }

        public virtual bool IsExist(int item)
        {
            return false;
        }

        public virtual bool IsBinarySearchTree()
        {
            return false;
        }

        // Depth First
        protected void PreOrder(Node<int> start, List<int> list)
        {
            if (start != null)
            {
                AddToTraversalList(start, list);
                PreOrder(start.Left, list);
                PreOrder(start.Right, list);
            }
        }

        // Depth First
        protected void InOrder(Node<int> start, List<int> list)
        {
            if (start != null)
            {
                InOrder(start.Left, list);
                AddToTraversalList(start, list);
                InOrder(start.Right, list);
            }
        }

        // Depth First
        protected void PostOrder(Node<int> start, List<int> list)
        {
            if (start != null)
            {
                PostOrder(start.Left, list);
                PostOrder(start.Right, list);
                AddToTraversalList(start, list);
            }
        }

        // Breadth First
        protected void LevelOrder(Node<int> start, List<int> list)
        {
            if (start != null)
            {
                Queue<Node<int>> queue = new Queue<Node<int>>();
                queue.Enqueue(start);

                Node<int> node = null;

                while (queue.Count > 0)
                {
                    node = queue.Dequeue();

                    AddToTraversalList(node, list);

                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }
            }
        }

        protected void ReverseLevelOrder(Node<int> start, List<int> list)
        {
            if (start != null)
            {
                Queue<Node<int>> queue = new Queue<Node<int>>();
                Stack<Node<int>> stack = new Stack<Node<int>>();

                queue.Enqueue(start);

                Node<int> node = null;

                while (queue.Count > 0)
                {
                    node = queue.Dequeue();

                    stack.Push(node);

                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }

                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                }

                while (stack.Count > 0)
                {
                    node = stack.Pop();
                    AddToTraversalList(node, list);
                }
            }
        }

        private void AddToTraversalList(Node<int> start, List<int> list)
        {
            if (Duplicate == Constant.Duplicate.Handle)
            {
                int index = 0;

                while (index < start.Count)
                {
                    list.Add(start.Item);
                    index++;
                }
            }
            else
            {
                list.Add(start.Item);
            }
        }

        protected int CalculateHeight(Node<int> start)
        {
            int h = -1;

            if(start != null)
            {
                int hl = CalculateHeight(start.Left);
                int hr = CalculateHeight(start.Right);
                h = Math.Max(hl, hr) + 1;
            }

            return h;
        }

        protected int CalculateSize()
        {
            int s = 0;

            if(Root != null)
            {
                Stack<Node<int>> stack = new Stack<Node<int>>();

                s++;
                stack.Push(Root);

                Node<int> node = null;

                while (stack.Count > 0)
                {
                    node = stack.Pop();

                    if (node.Left != null)
                    {
                        s++;
                        stack.Push(node.Left);
                    }

                    if (node.Right != null)
                    {
                        s++;
                        stack.Push(node.Right);
                    }
                }
            }

            return s;
        }

        protected int CalculateSize(Node<int> start)
        {
            int s = 0;

            if (start != null)
            {
                int sl = CalculateSize(start.Left);
                int sr = CalculateSize(start.Right);
                s = sl + sr + 1;
            }

            return s;
        }

        public int PossibleBinaryTrees(int n)
        {
            int c = Maths.CatalanNumber(n);
            return (c * (int)Maths.Factorial(n));
        }
    }
}
