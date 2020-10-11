using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.ComponentModel;

namespace Project_Euler_Problems
{
    class main
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Project Euler Problem 1");
            Console.WriteLine("Sum of all natural numbers that are multiples of 3 and 5 below:");
            int limit = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Sum:");
            var Problem_1 = new Problem_1(limit);
            Console.WriteLine(Problem_1.GetResult());

            Console.WriteLine("Project Euler Problem 50");
            Console.WriteLine("Pick the limit below which to find longest list of consecutive primes that add to a prime:");
            int upperLimit = Int32.Parse(Console.ReadLine());
            var Problem_50 = new Problem_50(upperLimit);
            Console.WriteLine("Largest primes below {1} with consecutive primes summing to {0}", Problem_50.GetResult(), limit);
            //Console.WriteLine("It consists of {0} primes", numPrimes);
        }
    }
}
