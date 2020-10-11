using System;
using System.Diagnostics;

/*
Problem 1

If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

Find the sum of all the multiples of 3 or 5 below 1000.

*/

namespace Project_Euler_Problems

{
    class Problem_1
    {
        //encapsulate vars we don't want changeable outside of this class
        private int limit, result;

        //Constructor with argument giving limit 
        public Problem_1(int limit)
        {
            this.limit = limit;
            Processing();
        }

        //Simple enough that we can just go up to limit
        void Processing()
        {
            for (int i = 1; i < this.limit; i++)
            {
                //check 3 and 5
                if (((i % 3) == 0) || ((i % 5) == 0))
                {
                    this.result += i;
                }
            }
        }

        public int GetResult()
        {
            return this.result;
        }
    }
}
