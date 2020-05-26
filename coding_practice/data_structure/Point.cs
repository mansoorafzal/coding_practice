namespace coding_practice.data_structure
{
    public class Point<T>
    {
        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }

        public T X { get; set; }

        public T Y { get; set; }
    }
}
