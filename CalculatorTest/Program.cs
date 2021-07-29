using System;
using System.Numerics;

namespace CalculatorTest
{
    
    class Program
    {  
        static void Main(string[] args)
        {
            BigInteger value;
            string errorString;
            TryEvaluate("2+2", out value, out errorString);
        }

        public static bool TryEvaluate(string expr, out BigInteger value, out string error)
        {
            NodeParser.parseNodeStructureFromString(expr);
            
            /* Placeholder. */
            value = BigInteger.Zero;
            error = "None";
            return true;
        }
    }
}
