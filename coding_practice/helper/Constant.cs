namespace coding_practice.helper
{
    public static class Constant
    {
        public enum Duplicate
        {
            Handle = 0,
            Ignore = 1,
        }

        public enum GraphType
        {
            Directed = 0,
            Undirected = 1,
        }

        public enum Priority
        {
            Maximum = 0,
            Minimum = 1,
        }

        public enum PropertyType
        {
            Height = 0,
            Size_Iterative = 1,
            Size_Recursive = 2,
        }

        public enum TraversalType
        {
            BreadthFirst = 0,
            DepthFirst = 1,
            InOrder = 2,
            LevelOrder = 3,
            PostOrder = 4,
            PreOrder = 5,
            ReverseLevelOrder = 6,
        }
    }
}
