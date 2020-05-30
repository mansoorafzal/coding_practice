using coding_practice.helper;
using coding_practice.problem_solving.generic;

namespace coding_practice.data_structure
{
    public class BinarySearchTree : BinaryTree
    {
        public BinarySearchTree() : base()
        {

        }

        public BinarySearchTree(Constant.Duplicate duplicate) : base(duplicate)
        {

        }

        public BinarySearchTree(int item, Constant.Duplicate duplicate = Constant.Duplicate.Ignore) : base(item, duplicate)
        {   
            
        }

        public override void Insert(int item)
        {
            if(Root == null)
            {
                Root = new Node<int>(item);
            }
            else
            {
                Insert(item, Root);
            }
        }

        private void Insert(int item, Node<int> start)
        {
            if (item < start.Item)
            {
                if (start.Left != null)
                {
                    Insert(item, start.Left);
                }
                else
                {
                    start.Left = new Node<int>(item);
                }
            }
            else if (item > start.Item)
            {
                if (start.Right != null)
                {
                    Insert(item, start.Right);
                }
                else
                {
                    start.Right = new Node<int>(item);
                }
            }
            else
            {
                if (Duplicate == Constant.Duplicate.Handle)
                {
                    start.Count++;
                }
            }
        }

        public override bool IsExist(int item)
        {
            if(Root != null)
            {
                return IsExist(item, Root);
            }

            return false;
        }

        private bool IsExist(int item, Node<int> start)
        {
            if (item < start.Item)
            {
                if (start.Left != null)
                {
                    return IsExist(item, start.Left);
                }
            }
            else if (item > start.Item)
            {
                if (start.Right != null)
                {
                    return IsExist(item, start.Right);
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        public override bool IsBinarySearchTree()
        {
            if (Root != null)
            {
                return IsBinarySearchTree(Root.Item, Root);
            }

            return false;
        }

        private bool IsBinarySearchTree(int item, Node<int> start)
        {
            if (start.Left != null)
            {
                if (item > start.Left.Item)
                {
                    return IsBinarySearchTree(start.Left.Item, start.Left);
                }
                else
                {
                    return false;
                }
            }
        
            if (start.Right != null)
            {
                if (item < start.Right.Item)
                {
                    return IsBinarySearchTree(start.Right.Item, start.Right);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public int PossibleBinarySearchTrees(int n)
        {
            return Maths.CatalanNumber(n);
        }

        // TODO - not working (constructing all possible trees)
        //private List<Node<T>> FindAllBinarySearchTrees(int begin, int end)
        //{
        //    List<Node<T>> list = new List<Node<T>>();

        //    if (begin > end)
        //    {
        //        list.Add(new Node<T>(default(T)));
        //        return list;
        //    }

        //    for (int i = begin; i <= end; i++)
        //    {   
        //        List<Node<T>> left = FindAllBinarySearchTrees(begin, i - 1);
        //        List<Node<T>> right = FindAllBinarySearchTrees(i + 1, end);

        //        for (int j = 0; j < left.Count; j++)
        //        {
        //            Node<T> l = new Node<T>(left[j].Item);

        //            for (int k = 0; k < right.Count; k++)
        //            {
        //                object o = i;
        //                Node<T> node = new Node<T>((T)o);
        //                node.Left = l;
        //                node.Right = new Node<T>(right[k].Item);
        //                list.Add(node);
        //            }
        //        }
        //    }

        //    return list;
        //}
    }
}
