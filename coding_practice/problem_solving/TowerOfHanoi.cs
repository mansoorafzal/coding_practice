using System;
using System.Collections.Generic;

namespace coding_challenges
{
    public class TowerOfHanoi
    {
        public static void Resolve(int n)
        {   
            List<int> source = new List<int>();
            List<int> auxiliary = new List<int>();
            List<int> target = new List<int>();

            for (int i = n; i > 0; i--)
            {
                source.Add(i);
            }

            PrintTowers(source, auxiliary, target);

            Solve(source, auxiliary, target, source.Count);

            PrintTowers(source, auxiliary, target);
        }

        private static void Solve(List<int> source, List<int> auxiliary, List<int> target, int n)
        {
            //PrintTowers(source, auxiliary, target);

            if (n > 0)
            {
                Solve(source, target, auxiliary, n - 1); // move n - 1 disks from source to auxiliary tower 

                source.Remove(n);
                target.Add(n);

                Solve(auxiliary, source, target, n - 1); // move n - 1 disks from auxiliary to target
            }
        }

        private static void PrintTowers(List<int> source, List<int> auxiliary, List<int> target)
        {
            Console.Write("source: ");
            for (int i = 0; i < source.Count; i++)
            {
                Console.Write(source[i] + " ");
            }

            Console.WriteLine();

            Console.Write("auxiliary: ");
            for (int i = 0; i < auxiliary.Count; i++)
            {
                Console.Write(auxiliary[i] + " ");
            }

            Console.WriteLine();

            Console.Write("target: ");
            for (int i = 0; i < target.Count; i++)
            {
                Console.Write(target[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
