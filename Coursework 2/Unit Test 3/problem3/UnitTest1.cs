using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p3
{
    //https://sites.google.com/site/eulerproblemsincsharp/home/problem-3
    [TestClass]
    public class unittest3
    {
        static void Main(string[] args)

        {

            Console.WriteLine((SumOfN(100) * SumOfN(100)) - SumSquareOf(100));

            Console.ReadLine();

        }


        static long SumSquareOf(int n)


        {

            return ((n * (n + 1) * (2 * n + 1) / 6));

        }

        static long SumOfN(int n)

        {

            return n * (n + 1) / 2;

        }

        // The sum of the squares of the first ten natural numbers is,
        //	12 + 22 + ... + 102 = 385
        // The square of the sum of the first ten natural numbers is,
        //	(1 + 2 + ... + 10)2 = 552 = 3025
        // Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
        // Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
        public static int Prob3(int limit)
        {
            // Start with 0 
            int sum = 0;
            int squaresSum = 0;

            // start from 1 -> limit (inclusive)
            for (int i = 1; i <= limit; i++)
            {
                sum += i;                   // Add this number to our sum of numbers 1->limit
                squaresSum += (i * i);      // Square this number and add it to the sum of squares
            }
            int squaresq = sum * sum;            // Square the sum of the numbers
            int thedifference = squaresq - squaresSum;    // Get the difference between the sum of squares and the square of the sum
            Console.WriteLine(thedifference);
            return thedifference;
        }

        [TestMethod]
        public void TestProb3()
        {
            // Make sure that Problem 3 1->10 is 2640 like the example
            Assert.AreEqual(2640, Prob3(10));

            // Problem 3 with 1 -> 100 is 25,164,150
            Assert.AreEqual(25164150, Prob3(100));
        }
    }
}