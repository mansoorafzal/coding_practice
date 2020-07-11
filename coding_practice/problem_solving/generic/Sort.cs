using coding_practice.helper;

namespace coding_practice
{
    public static class Sort
    {
        // Merge Sort - Top Down Split
        public static void Merge(int[] N)
        {
            Utility<int>.DisplaArray(N);

            Merge(N, 0, N.Length - 1);

            Utility<int>.DisplaArray(N);
        }
        private static void Merge(int[] N, int begin, int end)
        {
            if (end <= begin)
            {
                return;
            }

            int middle = ((end - begin) / 2) + begin;

            Merge(N, begin, middle);
            Merge(N, middle + 1, end);
            Merge(N, begin, middle, end);
        }
        private static void Merge(int[] N, int begin, int middle, int end)
        {
            int[] temp = (int[])N.Clone();

            int first = begin;
            int second = middle + 1;
            int merged = begin;

            while (first <= middle && second <= end)
            {
                if (temp[first] <= temp[second])
                {
                    N[merged++] = temp[first++];
                }
                else
                {
                    N[merged++] = temp[second++];
                }
            }

            while (first < middle + 1)
            {
                N[merged++] = temp[first++];
            }

            while (second < end)
            {
                N[merged++] = temp[second++];
            }
        }

        // Quick Sort - Lomuto Partition Scheme
        public static void Quick(int[] N)
        {
            Utility<int>.DisplaArray(N);

            Quick(N, 0, N.Length - 1);

            Utility<int>.DisplaArray(N);
        }
        private static void Quick(int[] N, int low, int high)
        {
            if (low < high)
            {
                int middle = Partition(N, low, high);
                Quick(N, low, middle - 1);
                Quick(N, middle + 1, high);
            }
        }
        private static int Partition(int[] N, int low, int high)
        {
            int pivot = N[high];
            int i = low;

            for (int j = low; j < high; j++)
            {
                if (N[j] < pivot)
                {
                    Utility<int>.Swap(ref N[i], ref N[j]);
                    i++;
                }
            }

            Utility<int>.Swap(ref N[i], ref N[high]);

            return i;
        }
    }
}
