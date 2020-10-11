using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.ComponentModel;

/*
Problem 1

The prime 41, can be written as the sum of six consecutive primes:
41 = 2 + 3 + 5 + 7 + 11 + 13

This is the longest sum of consecutive primes that adds to a prime below one-hundred.

The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

Which prime, below one-million, can be written as the sum of the most consecutive primes?


*/

namespace Project_Euler_Problems
{
    class Problem_50
    {

        private int upperLimit;
        private long result = 0;

        public Problem_50(int upperLimit)
        {
            this.upperLimit = upperLimit;
            Processing(upperLimit);

        }
        //Sieve of Eratosthenes 
        //https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
        private long[] Sieve(int upperLimit)
        {
            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            List<long> numbers = new List<long>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));

            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray();
        }

        private void Processing(int limit)
        {
            int numPrimes = 0;
            long[] primes = Sieve(limit);
            long[] primeSum = new long[primes.Length + 1];


            primeSum[0] = 0;
            for (int i = 0; i < primes.Length; i++)
            {
                primeSum[i + 1] = primeSum[i] + primes[i];
            }

            for (int i = numPrimes; i < primeSum.Length; i++)
            {
                for (int j = i - (numPrimes + 1); j >= 0; j--)
                {

                    if (primeSum[i] - primeSum[j] > limit)
                    {
                        break;
                    }

                    if (Array.BinarySearch(primes, primeSum[i] - primeSum[j]) >= 0)
                    {
                        numPrimes = i - j;
                        this.result = primeSum[i] - primeSum[j];
                    }
                }
            }


        }

        public long GetResult()
        {
            return this.result;
        }
    }
}
