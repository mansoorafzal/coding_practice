using System;
using System.Collections.Generic;
using System.Text;

namespace coding_practice
{
    public static class StringManipulation
    {
        

        

        public static string SortBubble(string a)
        {   
            char[] c = a.ToCharArray();

            for(int i = 0; i < a.Length; i++)
            {
                for(int j = i + 1; j < a.Length; j++)
                {
                    if(c[i] > c[j])
                    {
                        char temp = c[i];
                        c[i] = c[j];
                        c[j] = temp;
                    }
                }
            }

            return new string(c);
        }

        public static string SortCounter(string a)
        {   
            int[] counter = new int[26];
            string b = string.Empty;

            for (int i = 0; i < a.Length; i++)
            {
                counter[a[i] - 97]++;
            }

            for(int i = 0; i < counter.Length; i++)
            {
                for(int j = 0; j < counter[i]; j++)
                {
                    b += (char)(i + 97);
                }
            }

            return b;
        }

        

        

        

        
    }
}
