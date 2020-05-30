using coding_practice.helper;

namespace coding_practice
{
    public static class Sort
    {
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
    }
}
