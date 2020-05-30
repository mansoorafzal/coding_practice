namespace coding_practice.problem_solving.generic
{
    public static class Maths
    {
        // Implementation of binomial coefficient
        public static int BinomialCoefficient(int n, int k)
        {
            int bc = 1;

            if (k > n - k)
            {
                k = n - k;
            }

            for (int i = 0; i < k; ++i)
            {
                bc *= (n - i);
                bc /= (i + 1);
            }

            return bc;
        }

        // Implementation of catalan number
        public static int CatalanNumber(int n, bool binomialCoefficient = false)
        {
            if (binomialCoefficient)
            {
                return (BinomialCoefficient(2 * n, n) / (n + 1));
            }
            else
            {
                int?[] array = new int?[n];
                return CatalanNumber(n, array);
            }
        }
        private static int CatalanNumber(int n, int?[] array)
        {
            if (n <= 1)
            {
                return 1;
            }

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                if (!array[i].HasValue)
                {
                    array[i] = CatalanNumber(i, array);
                }

                if (!array[n - i - 1].HasValue)
                {
                    array[n - i - 1] = CatalanNumber(n - i - 1, array);
                }

                sum += array[i].Value * array[n - i - 1].Value;
            }

            return sum;
        }
        
        // Implementation of factorial
        public static double Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        // Implementation of fibonacci
        public static int Fibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        // Calculation of median
        public static float Median(int[] a, int[] b)
        {
            float f = 0;

            if (a.Length == 0 && b.Length == 0)
            {
                return f;
            }

            int index1 = (a.Length + b.Length) / 2;
            int? index2 = null;

            if ((a.Length + b.Length) % 2 == 0)
            {
                index2 = index1 - 1;
            }

            if (a.Length == 0 && b.Length > 0)
            {
                return Median(b, index1, index2);
            }

            if (a.Length > 0 && b.Length == 0)
            {
                return Median(a, index1, index2);
            }

            int i = 0;
            int j = 0;
            int k = 0;
            int[] c = new int[index1 + 1];

            while (i <= index1)
            {
                if (j > a.Length - 1 || k > b.Length - 1)
                {
                    if (j > a.Length - 1)
                    {
                        c[i++] = b[k++];
                    }
                    else if (k > b.Length - 1)
                    {
                        c[i++] = a[j++];
                    }
                }
                else if (a[j] < b[k])
                {
                    c[i++] = a[j++];
                }
                else if (b[k] < a[j])
                {
                    c[i++] = b[k++];
                }
                else
                {
                    c[i++] = a[j++];

                    if (i < c.Length)
                    {
                        c[i++] = b[k++];
                    }
                }
            }

            return Median(c, index1, index2);
        }
        private static float Median(int[] n, int index1, int? index2)
        {
            if (index2.HasValue)
            {
                return (float)(n[index1] + n[index2.Value]) / 2;
            }
            else
            {
                return n[index1];
            }
        }

        // Converting a given string to binary
        public static string ToBinary(string a)
        {
            if (a.Length == 0)
            {
                return string.Empty;
            }

            char[] c = a.ToCharArray();
            string b = string.Empty;

            for (int i = 0; i < c.Length; i++)
            {
                int d = c[i];
                string s = string.Empty;

                while (d > 1)
                {
                    s = (d % 2).ToString() + s;
                    d = d / 2;
                }

                if (d == 1)
                {
                    s = "1" + s;
                }

                b = b + s + " ";
            }

            return b;
        }
    }
}
