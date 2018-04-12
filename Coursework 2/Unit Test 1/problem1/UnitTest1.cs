using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;




namespace problem1 // problem 1 to list all the mutliples of 3 and 5 below 1000
{

    public class multiplesof3and5
    {


        static void Main(string[] args)
        {
            int res = Solution(1000);
            Console.WriteLine(res);


        }

        // guidence for code from https://sites.google.com/site/eulerproblemsincsharp/home/problem-5
        // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        // Find the sum of all the multiples of 3 or 5 below 1000.
        public static int DoProb1()
        {
            int sum = 8; // 3 + 5 // we start with the two numbers and add them together as these are the first two numbers we want the multiples from

            // repeat from the number immediately after our largest if (5) -> 1000
            for (int i = 6; i < 1000; i++)
            {
                // Check to see if this number is divisible by 3 and 5 without any remainders
                if ((i % 3) == 0 ||
                    (i % 5) == 0)
                    sum += i;   // number is evenly divisible by 3 and 5, so add in our sum
            }
            Console.WriteLine(sum);
            return sum; // Give the sum back 
        }


        public static int Solution(int lim) // lim is for the limit 
        {
            return sum(lim, 3) + sum(lim, 5) - sum(lim, 15);
        }


        static int sum(int lim, int inc) // inc for increment 
        {
            int n = (lim - 1) / inc;
            return inc * n * (n + 1) / 2;

        }
        [TestClass]
        public class Problem1Test
        {
            public void StmtEx()
            {
                int outcomeres = multiplesof3and5.Solution(10);
                Assert.AreEqual(23, outcomeres);
            }

            [TestMethod]
            public void TestProblem1()
            {
                // The sum of all the multiples of 3 or 5 below 1000 which is 233,168
                Assert.AreEqual(233168, DoProb1());
            }

        }
    }
}
