using System;
using System.Numerics;

namespace CalculatorTest
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static bool TryEvaluate(string expr, out BigInteger value, out string error)
        {
            /* Placeholder. */
            value = BigInteger.Zero;
            error = "None";
            return true;
        }
    }
}
