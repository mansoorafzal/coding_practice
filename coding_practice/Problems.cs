using System;
using System.Collections.Generic;
using System.Text;

namespace coding_challenges
{
    public static class Problems
    {
        // Find all numbers till n where a^3 + b^3 = c^3 + d^3
        public static void AddCubes(int n, bool displayNumbers = false)
        {
            List<int[]> list = null;

            list = AddCubesBruteForce(n);

            if (displayNumbers)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i][0] + ", " + list[i][1] + ", " + list[i][2] + ", " + list[i][3]);
                }
            }

            list = AddCubesDictionary(n);

            if (displayNumbers)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i][0] + ", " + list[i][1] + ", " + list[i][2] + ", " + list[i][3]);
                }
            }
        }
        private static List<int[]> AddCubesBruteForce(int n)
        {
            List<int[]> list = new List<int[]>();
            HashSet<double> hashset = new HashSet<double>();
            int loop = 0;

            for (int a = 1; a <= n; a++)
            {
                for (int b = a + 1; b <= n; b++)
                {
                    for (int c = a + 1; c <= n; c++)
                    {
                        for (int d = c + 1; d <= n; d++)
                        {
                            if (a != c && b != d)
                            {
                                loop++;

                                double d1 = Math.Pow(a, 3);
                                double d2 = Math.Pow(b, 3);

                                if (!hashset.Contains(d1 + d2))
                                {
                                    if (Math.Pow(a, 3) + Math.Pow(b, 3) == Math.Pow(c, 3) + Math.Pow(d, 3))
                                    {
                                        list.Add(new int[] { a, b, c, d });
                                        hashset.Add(d1 + d2);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Brute Force Loop Counter = " + loop);
            Console.WriteLine("Brute Force Count = " + list.Count);

            return list;
        }
        private static List<int[]> AddCubesDictionary(int n)
        {
            List<int[]> list = new List<int[]>();
            Dictionary<double, Point<int>> dictionary = new Dictionary<double, coding_challenges.Point<int>>();
            int loop = 0;

            for (int a = 1; a <= n; a++)
            {
                for (int b = a + 1; b <= n; b++)
                {
                    loop++;

                    double d1 = Math.Pow(a, 3);
                    double d2 = Math.Pow(b, 3);

                    if (!dictionary.ContainsKey(d1 + d2))
                    {
                        dictionary.Add(d1 + d2, new Point<int>(a, b));
                    }
                    else
                    {
                        Point<int> point = null;
                        dictionary.TryGetValue(d1 + d2, out point);

                        list.Add(new int[] { point.X, point.Y, a, b });
                    }
                }
            }

            Console.WriteLine("Dictionary Loop Counter = " + loop);
            Console.WriteLine("Dictionary Count = " + list.Count);

            return list;
        }

        // Search a number in a sorted array using binary search.
        public static bool BinarySearch(int[] n, int t)
        {
            if (n.Length == 0)
            {
                return false;
            }

            if (t < n[0] || t > n[n.Length - 1])
            {
                return false;
            }

            return BinarySearch(n, t, 0, n.Length - 1);
        }
        private static bool BinarySearch(int[] n, int t, int begin, int end)
        {
            if (begin > end)
            {
                return false;
            }

            int middle = ((end - begin) / 2) + begin;

            if (t == n[middle])
            {
                return true;
            }

            if (t < n[middle])
            {
                return BinarySearch(n, t, begin, middle - 1);
            }

            if (t > n[middle])
            {
                return BinarySearch(n, t, middle + 1, end);
            }

            return false;
        }

        // Find longest sequence of consecutive numbers in unsorted array.
        public static int FindConsecutive(int[] n)
        {
            if (n.Length == 0 || n.Length == 1)
            {
                return n.Length;
            }

            HashSet<int> hashset = new HashSet<int>();

            for (int i = 0; i < n.Length; i++)
            {
                hashset.Add(n[i]);
            }

            int max = 1;

            for (int i = 0; i < n.Length; i++)
            {
                if (hashset.Contains(n[i] - 1))
                {
                    continue;
                }

                int count = 0;

                while (hashset.Contains(n[i]++))
                {
                    count++;
                }

                if (count > max)
                {
                    max = count;
                }
            }

            return max;
        }

        // Find duplicates in unsorted array.
        public static int[] FindDuplicate(int[] n)
        {
            HashSet<int> original = new HashSet<int>();
            HashSet<int> duplicate = new HashSet<int>();

            if (n.Length == 0)
            {
                return new int[0];
            }

            for (int i = 0; i < n.Length; i++)
            {
                if (original.Contains(n[i]))
                {
                    duplicate.Add(n[i]);

                    continue;
                }

                original.Add(n[i]);
            }

            int[] array = new int[duplicate.Count];

            duplicate.CopyTo(array);

            return array;
        }

        // Find largest square submatrix of 1s in a matrix which consists of 0s and 1s.
        public static void SquareSubmatrix(int[][] matrix)
        {
            DateTime dt1 = DateTime.Now;
            int bf = SquareSubmatrixBruteForce(matrix);
            DateTime dt2 = DateTime.Now;
            int r = SquareSubmatrixRecursive(matrix);
            DateTime dt3 = DateTime.Now;

            Console.WriteLine("Brute Force: " + bf + " took " + (dt2 - dt1).TotalMilliseconds + " ms");
            Console.WriteLine("Recursive: " + r + " took " + (dt3 - dt2).TotalMilliseconds + " ms");
        }
        private static int SquareSubmatrixBruteForce(int[][] matrix)
        {
            if (matrix.Length == 1)
            {
                if (matrix[0][0] == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            int y = 0;
            int x = 0;
            int size = 1;
            int max = 1;

            while (y < matrix.GetLength(0))
            {
                while (x < matrix[y].GetLength(0))
                {
                    size = SquareSubmatrixBruteForce(matrix, y, x, size + 1);

                    if (size > max)
                    {
                        max = size;
                    }
                    else
                    {
                        x++;
                    }
                }

                y++;
            }

            return max;
        }
        private static int SquareSubmatrixBruteForce(int[][] matrix, int col, int row, int size)
        {
            if (col + size > matrix.GetLength(0) || row + size > matrix[0].GetLength(0))
            {
                return size - 1;
            }

            for (int y = col; y < col + size; y++)
            {
                for (int x = row; x < row + size; x++)
                {
                    if (matrix[y][x] == 0)
                    {
                        return size - 1;
                    }
                }
            }

            return size;
        }
        private static int SquareSubmatrixRecursive(int[][] matrix)
        {
            int?[][] cache = new int?[matrix.GetLength(0)][];

            for (int col = 0; col < cache.Length; col++)
            {
                cache[col] = new int?[matrix[col].GetLength(0)];
            }

            int y = 0;
            int x = 0;
            int max = 0;

            while (y < matrix.GetLength(0))
            {
                while (x < matrix[y].GetLength(0))
                {
                    max = Math.Max(max, SquareSubmatrixRecursive(matrix, y, x, cache));

                    x++;
                }

                y++;
            }

            return max;
        }
        private static int SquareSubmatrixRecursive(int[][] matrix, int y, int x, int?[][] cache)
        {
            if (y >= matrix.GetLength(0) || x >= matrix[0].GetLength(0))
            {
                return 0;
            }

            if (matrix[y][x] == 0)
            {
                return 0;
            }

            if (!cache[y][x].HasValue)
            {
                cache[y][x] = 1 + Math.Min(
                    Math.Min(SquareSubmatrixRecursive(matrix, y + 1, x, cache), SquareSubmatrixRecursive(matrix, y, x + 1, cache)),
                    SquareSubmatrixRecursive(matrix, y + 1, x + 1, cache));
            }

            return cache[y][x].Value;
        }

        // Update all cells of corresponding row and column to true if any cell is true.
        public static void ZeroMatrix(bool[][] matrix)
        {
            bool[][] matrix1 = Utility<bool>.CopyTwoDimentionalMatrix(matrix);
            bool[][] matrix2 = Utility<bool>.CopyTwoDimentionalMatrix(matrix);

            Utility<bool>.DisplayMatrix(matrix1, 6, false);
            ZeroMatrixBruteForce(matrix1);

            Utility<bool>.DisplayMatrix(matrix2, 6, false);
            ZeroMatrixEffecient(matrix2);
        }
        private static void ZeroMatrixBruteForce(bool[][] matrix)
        {
            Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();

            for (int y = 0; y < matrix.Length; y++)
            {
                List<int> list = new List<int>();

                for (int x = 0; x < matrix.Length; x++)
                {
                    if (matrix[y][x] == true)
                    {
                        list.Add(x);
                    }
                }

                if (list.Count > 0)
                {
                    dictionary.Add(y, list);
                }
            }

            foreach (int y in dictionary.Keys)
            {
                List<int> list = dictionary[y];

                for (int x = 0; x < list.Count; x++)
                {
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        matrix[i][list[x]] = true;
                    }
                }

                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[y][i] = true;
                }
            }

            Utility<bool>.DisplayMatrix(matrix, 6, false);
        }
        private static void ZeroMatrixEffecient(bool[][] matrix)
        {
            bool col = false;

            for (int y = 0; y < matrix.Length; y++)
            {
                if (matrix[y][0] == true)
                {
                    col = true;
                    break;
                }
            }

            bool row = false;

            for (int x = 0; x < matrix.Length; x++)
            {
                if (matrix[0][x] == true)
                {
                    row = true;
                    break;
                }
            }

            for (int y = 1; y < matrix.Length; y++)
            {
                for (int x = 1; x < matrix[y].Length; x++)
                {
                    if (matrix[y][x] == true)
                    {
                        matrix[y][0] = true;
                        matrix[0][x] = true;
                    }
                }
            }

            for (int y = 1; y < matrix.Length; y++)
            {
                if (matrix[y][0] == true)
                {
                    for (int x = 1; x < matrix[y].Length; x++)
                    {
                        matrix[y][x] = true;
                    }
                }
            }


            for (int x = 1; x < matrix[0].Length; x++)
            {
                if (matrix[0][x] == true)
                {
                    for (int y = 1; y < matrix.Length; y++)
                    {
                        matrix[y][x] = true;
                    }
                }
            }

            if (col)
            {
                for (int y = 0; y < matrix.Length; y++)
                {
                    matrix[y][0] = true;
                }

            }

            if (row)
            {
                for (int x = 0; x < matrix[0].Length; x++)
                {
                    matrix[0][x] = true;
                }
            }

            Utility<bool>.DisplayMatrix(matrix, 6, false);
        }


        // Given N sorted arrays, merge them in to single sorted array.
        public static void MergeNSortedArrays(int[][] matrix)
        {
            DateTime dt1 = DateTime.Now;
            int[] bst = MergeNSortedArraysBinarySearchTree(matrix);
            DateTime dt2 = DateTime.Now;
            int[] dp = MergeNSortedArraysDynamicProgramming(matrix);
            DateTime dt3 = DateTime.Now;

            Console.WriteLine("Binary Search Tree took " + (dt2 - dt1).TotalMilliseconds + " ms");
            Utility<int>.DisplaArray(bst);

            Console.WriteLine("Dynamic Programming took " + (dt3 - dt2).TotalMilliseconds + " ms");
            Utility<int>.DisplaArray(MergeNSortedArraysDynamicProgramming(matrix));
        }
        private static int[] MergeNSortedArraysBinarySearchTree(int[][] matrix)
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree(Constant.Duplicate.Handle);

            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix[y].GetLength(0); x++)
                {
                    binarySearchTree.Insert(matrix[y][x]);
                }
            }

            return binarySearchTree.GenerateTraversal(Constant.TraversalType.InOrder);
        }
        private static int[] MergeNSortedArraysDynamicProgramming(int[][] matrix)
        {
            if (matrix.Length == 1)
            {
                return new int[] { matrix[0][0] };
            }

            int[] merged = new int[matrix[0].Length];

            for (int i = 0; i < matrix[0].Length; i++)
            {
                merged[i] = matrix[0][i];
            }

            for (int y = 1; y < matrix.GetLength(0); y++)
            {
                merged = MergeNSortedArraysDynamicProgramming(merged, matrix[y]);
            }

            return merged;
        }
        private static int[] MergeNSortedArraysDynamicProgramming(int[] a, int[] b)
        {
            if (a.Length == 0)
            {
                return b;
            }

            if (b.Length == 0)
            {
                return a;
            }

            int[] merged = new int[a.Length + b.Length];
            int index = 0;
            int ai = 0;
            int bi = 0;

            while (index < merged.Length)
            {
                if (ai >= a.Length && bi >= b.Length)
                {
                    break;
                }

                if (ai >= a.Length && bi < b.Length)
                {
                    merged[index] = b[bi];
                    bi++;
                    index++;

                    continue;
                }

                if (ai < a.Length && bi >= b.Length)
                {
                    merged[index] = a[ai];
                    ai++;
                    index++;

                    continue;
                }

                if (a[ai] < b[bi])
                {
                    merged[index] = a[ai];
                    ai++;
                    index++;
                }
                else if (a[ai] > b[bi])
                {
                    merged[index] = b[bi];
                    bi++;
                    index++;
                }
                else if (a[ai] == b[bi])
                {
                    merged[index] = a[ai];
                    ai++;
                    index++;

                    merged[index] = b[bi];
                    bi++;
                    index++;
                }
            }

            return merged;
        }

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

        public static void DigitSum(int n, int sum)
        {
            List<int> list = new List<int>();
            int?[][] table = new int?[n + 1][];

            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new int?[sum + 1];
            }

            Console.WriteLine(DigitSumRecursive(n, sum, n, list) + " " + list.Count);
            list.Clear();
            Console.WriteLine(DigitSumRecursiveCache(n, sum, n, table, list) + " " + list.Count);
        }

        private static int DigitSumRecursive(int n, int sum, int N, List<int> list)
        {
            list.Add(1); // to count the recursive calls

            if (n == 0 && sum == 0)
            {
                return 1;
            }

            if (n == 0 && (sum < 0 || sum > 0))
            {
                return 0;
            }

            int count = 0;

            for (int i = 0; i <= 9; i++)
            {
                if (n == N && i == 0)
                {
                    continue;
                }

                count += DigitSumRecursive(n - 1, sum - i, N, list);
            }

            return count;
        }

        private static int DigitSumRecursiveCache(int n, int sum, int N, int?[][] table, List<int> list)
        {
            list.Add(1); // to count the recursive calls

            if (n == 0 && sum == 0)
            {
                return 1;
            }

            if (n == 0 && (sum < 0 || sum > 0))
            {
                return 0;
            }

            int count = 0;

            for (int i = 0; i <= 9; i++)
            {
                if (n == N && i == 0)
                {
                    continue;
                }

                if (n - 1 >= 0 && sum - i >= 0)
                {
                    if (!table[n - 1][sum - i].HasValue)
                    {
                        table[n - 1][sum - i] = DigitSumRecursiveCache(n - 1, sum - i, N, table, list);
                    }

                    count += table[n - 1][sum - i].Value;
                }
            }

            return count;
        }

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

        

        public static void FindNDigitNumbers(int n, int sum, string number)
        {
            if (n > 0 && sum >= 0)
            {
                int i = 0;

                if (number.Equals(string.Empty))
                {
                    i = 1;
                }

                while (i <= 9)
                {
                    FindNDigitNumbers(n - 1, sum - i, number + i.ToString());

                    i++;
                }
            }
            else if (n == 0 && sum == 0)
            {
                Console.Write(number + " ");
            }
        }

        

        // TODO - not working
        // Find minimum swaps to arrange R together in a string of R and W.
        public static int FindMinimumSwaps(string a)
        {
            if (a.Length == 0 || !a.Contains("R"))
            {
                return 0;
            }

            char[] c = a.ToCharArray();

            int swaps = 0;

            for (int i = 0; i < c.Length; i++)
            {
                swaps += Math.Min(FindMinimumSwaps(c, i + 1, 'f'), FindMinimumSwaps(c, i + 1, 'b'));
            }

            return swaps;
        }

        private static int FindMinimumSwaps(char[] c, int end, char direction)
        {
            int count = 0;

            if (direction == 'f')
            {
                for (int i = 1; i < end; i++)
                {
                    if (c[i] != c[i - 1] && c[i] == 'W')
                    {
                        Utility<char>.Swap(ref c[i], ref c[i - 1]);
                        count++;
                    }
                }
            }
            else if (direction == 'b')
            {
                for (int i = end; i > 0; i--)
                {
                    if (c[i] != c[i - 1] && c[i] == 'R')
                    {
                        Utility<char>.Swap(ref c[i], ref c[i - 1]);
                        count++;
                    }
                }
            }

            return count;
        }

        public static bool IsAnagram(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            int start = 0;
            int end = b.Length - 1;

            string s1 = a.ToLower();
            string s2 = b.ToLower();

            int[] counter = new int[256];

            while (start <= end)
            {
                counter[s1[start]]++;
                counter[s2[start]]--;
                start++;
            }

            for (int i = 0; i < counter.Length; i++)
            {
                if (counter[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsInterleaved(string A, string B, string C)
        {
            /*
             *   | 0 1 2 3 .... A
             * --------------------
             * 0 |
             * 1 |
             * 2 |
             * 3 |
             * . |
             * . |
             * . |
             * . |
             * B |
            */

            if (A.Length + B.Length != C.Length)
            {
                return false;
            }

            if (A.Length == 0)
            {
                return B.Equals(C);
            }

            if (B.Length == 0)
            {
                return A.Equals(C);
            }

            bool[][] table = new bool[A.Length + 1][];

            for (int y = 0; y < table.Length; y++)
            {
                table[y] = new bool[B.Length + 1];

                for (int x = 0; x < table[y].Length; x++)
                {
                    if (y == 0 && x == 0) // a = empty, b = empty
                    {
                        table[y][x] = true;
                    }
                    else if (y == 0) // a = empty
                    {
                        if (B[x - 1] == C[x - 1])
                        {
                            table[y][x] = table[y][x - 1];
                        }
                    }
                    else if (x == 0) // b = empty
                    {
                        if (A[y - 1] == C[y - 1])
                        {
                            table[y][x] = table[y - 1][x];
                        }
                    }
                    else if (A[y - 1] == C[y + x - 1] && B[x - 1] != C[y + x - 1]) // a = match
                    {
                        table[y][x] = table[y - 1][x];
                    }
                    else if (A[y - 1] != C[y + x - 1] && B[x - 1] == C[y + x - 1]) // b = match
                    {
                        table[y][x] = table[y][x - 1];
                    }
                    else if (A[y - 1] == C[y + x - 1] && B[x - 1] == C[y + x - 1]) // a = match, b = match
                    {
                        table[y][x] = table[y - 1][x] || table[y][x - 1];
                    }
                }
            }

            Utility<bool>.DisplayMatrix(table);

            return table[A.Length][B.Length];
        }

        public static bool IsPalindrome(string a, string b)
        {
            int start = 0;
            int end = b.Length - 1;

            string s1 = a.ToLower();
            string s2 = b.ToLower();

            while (start <= end)
            {
                if (s1[start] == s2[end])
                {
                    start++;
                    end--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPalindrome(string a)
        {
            return IsPalindrome(a, 0, a.Length - 1);
        }

        private static bool IsPalindrome(string a, int begin, int end)
        {
            if (a[begin] != a[end])
            {
                return false;
            }

            while (begin <= end)
            {
                return IsPalindrome(a, begin + 1, end - 1);
            }

            return true;
        }

        public static int MatrixProduct(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return 0;
            }

            if (matrix.Length == 1)
            {
                return matrix[0][0];
            }

            int[][] min = new int[matrix.GetLength(0)][];

            for (int i = 0; i < min.GetLength(0); i++)
            {
                min[i] = new int[matrix[i].GetLength(0)];
            }

            int[][] max = new int[matrix.GetLength(0)][];

            for (int i = 0; i < max.GetLength(0); i++)
            {
                max[i] = new int[matrix[i].GetLength(0)];
            }

            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix[y].GetLength(0); x++)
                {
                    int mini = 0;
                    int maxi = 0;

                    if (y == 0 && x == 0)
                    {
                        mini = matrix[y][x];
                        maxi = matrix[y][x];
                    }
                    else if (y == 0 && x > 0)
                    {
                        mini = matrix[y][x] * min[y][x - 1];
                        maxi = matrix[y][x] * max[y][x - 1];
                    }
                    else if (y > 0 && x == 0)
                    {
                        mini = matrix[y][x] * min[y - 1][x];
                        maxi = matrix[y][x] * max[y - 1][x];
                    }
                    else
                    {
                        if (matrix[y][x] * min[y - 1][x] < matrix[y][x] * max[y - 1][x])
                        {
                            mini = matrix[y][x] * min[y - 1][x];
                            maxi = matrix[y][x] * max[y - 1][x];
                        }
                        else
                        {
                            mini = matrix[y][x] * max[y - 1][x];
                            maxi = matrix[y][x] * min[y - 1][x];
                        }

                        if (matrix[y][x] * min[y][x - 1] < matrix[y][x] * max[y][x - 1])
                        {
                            if (matrix[y][x] * min[y][x - 1] < mini)
                            {
                                mini = matrix[y][x] * min[y][x - 1];
                            }

                            if (matrix[y][x] * max[y][x - 1] > maxi)
                            {
                                maxi = matrix[y][x] * max[y][x - 1];
                            }
                        }
                        else
                        {
                            if (matrix[y][x] * max[y][x - 1] < mini)
                            {
                                mini = matrix[y][x] * max[y][x - 1];
                            }

                            if (matrix[y][x] * min[y][x - 1] > maxi)
                            {
                                maxi = matrix[y][x] * min[y][x - 1];
                            }
                        }
                    }

                    min[y][x] = Math.Min(mini, maxi);
                    max[y][x] = Math.Max(mini, maxi);
                }
            }

            return max[max.GetLength(0) - 1][max[0].GetLength(0) - 1];
        }

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
                    c[i++] = b[k++];
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

        public static string ReverseWords(string a)
        {
            if (a.Length == 0)
            {
                return string.Empty;
            }

            char[] c = a.ToCharArray();
            int i = 0;
            int j = c.Length - 1;

            while (i < j)
            {
                char temp = c[i];
                c[i] = c[j];
                c[j] = temp;

                i++;
                j--;
            }

            int k = 0;
            int begin = 0;
            int end = 0;

            while (k < c.Length)
            {
                if (char.IsWhiteSpace(c[k]) || k == c.Length - 1)
                {
                    end = k - 1;

                    while (begin < end)
                    {
                        char temp = c[begin];
                        c[begin] = c[end];
                        c[end] = temp;

                        begin++;
                        end--;
                    }

                    begin = k + 1;
                }

                k++;
            }

            return new string(c);
        }

        public static List<string> Subsequences(string a)
        {
            List<string> list = new List<string>();

            if (a.Length == 0)
            {
                return list;
            }

            if (a.Length == 1)
            {
                list.Add(a);

                return list;
            }

            Subsequences(a, list, string.Empty);

            return list;
        }

        private static void Subsequences(string a, List<string> list, string s)
        {
            if (a.Length == 0)
            {
                list.Add(s);
                return;
            }

            Subsequences(a.Substring(1), list, s + a.Substring(0, 1));

            Subsequences(a.Substring(1), list, s);
        }

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
