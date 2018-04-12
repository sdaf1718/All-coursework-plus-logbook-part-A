using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p2
{
    // guidence from https://sites.google.com/site/eulerproblemsincsharp/home/problem-5
    public class Class1
    {
        [TestClass]
        public class UnitTest1
        {
            private long Prob2(long n)
            {
                if (n < 2)
                    throw new ArgumentException("n must be greater than 1");

                bool got;
                long res;
                for (int i = 1; i < Int32.MaxValue; i++)
                {
                    // First Improvement
                    res = n * i;
                    got = true;

                    // Second Improvement
                    for (var si = n / 2; si <= n; ++si)
                    {
                        if (res % si != 0)
                        {
                            got = false;
                            break;
                        }
                    }
                    if (got)
                        return res;
                }
                return -1;
            }

            public object Prob2_2()
            {
                var Outcome = Prob2(2);
                Assert.AreEqual(9009, Outcome);
                return Outcome;
            }

            // 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
            // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20? and 1 can go into everything and 2 only even prime number
            public static int prob2(int higher)
            {
                // repeat to the maximum integer to find the first number that meets our conditions
                for (int i = higher; i < Int32.MaxValue; i++)
                {
                    bool noGood = false;        // Assume that this number will work for us

                    // repeat through 1 -> higher
                    for (int si = 1; si < higher; si++)
                    {
                        // Mod the number we are testing with the digit here in our range (1 -> upper)						
                        if (i % si != 0)
                        {
                            // The result of a MOD is the remainder of the division. So if the result here is not 0, i is not evenly divisible.						
                            noGood = true;
                            break;  // No need to check the rest of the range 
                        }
                    }
                    if (!noGood)
                    {
                        // This number was evenly divisible by our entire range, this meets the condition
                        Console.WriteLine(i);
                        return i;   // Return the number we found 
                    }
                }
                return -1;  // Return -1 if we didn't find a suitable number
            }

            [TestMethod]
            public void TestProb2()
            {
                // The example range is 1 -> 10, the result should be 2520
                Assert.AreEqual(2520, prob2(10));

                // The Question range 1 -> 20, the result is 232,792,560
                Assert.AreEqual(232792560, prob2(20));
            }
        }
    }
}