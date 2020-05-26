namespace coding_practice.data_structure
{
    public class Item<T>
    {
        public Item(T weight, T value)
        {
            Weight = weight;
            Value = value;
        }

        public T Weight { get; set; }

        public T Value { get; set; }
    }
}
