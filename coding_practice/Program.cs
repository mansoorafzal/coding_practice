﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace coding_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment the relevant driver code in below method.
            data_structure._Driver.Data_Structure_Driver();

            // Uncomment the relevant driver code in below method.
            problem_solving.specific._Driver.Problem_Solving_Specific_Driver();

            // Uncomment the relevant driver code in below method.
            problem_solving.generic._Driver.Problem_Solving_Generic_Driver();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
    }
}
