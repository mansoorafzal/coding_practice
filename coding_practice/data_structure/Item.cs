namespace coding_practice.data_structure
{
    public class Item<T>
    {
        public Item(T weight, T value)
        {
            Weight = weight;
            Value = value;
        }

        public Item(T serial, T index, T value)
        {
            Serial = serial;
            Index = index;
            Value = value;
        }

        public T Weight { get; set; }

        public T Value { get; set; }

        public T Serial { get; set; }

        public T Index { get; set; }
    }
}
