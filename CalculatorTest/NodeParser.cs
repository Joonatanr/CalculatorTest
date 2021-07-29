using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CalculatorTest
{
    public static class NodeParser
    {
        /// <summary>
        /// Binary operations
        /// TODO: Support < and > operators
        /// </summary>
        private static readonly Dictionary<string, Func<BigInteger, BigInteger, BigInteger>> BinaryOperations = new Dictionary<string, Func<BigInteger, BigInteger, BigInteger>>()
        {
            ["+"] = (l, r) => l + r,
            ["-"] = (l, r) => l - r,
            ["*"] = (l, r) => l * r,
            ["/"] = (l, r) => l / r,
            ["%"] = (l, r) => l % r,
            ["<<"] = (l, r) => l << (int)r,
            [">>"] = (l, r) => l >> (int)r,
            ["^"] = (l, r) => l ^ r,
            ["&"] = (l, r) => l & r,
            ["|"] = (l, r) => l | r,
            ["=="] = (l, r) => (l == r ? BigInteger.One : BigInteger.Zero),
            ["!="] = (l, r) => (l != r ? BigInteger.One : BigInteger.Zero),
            ["<="] = (l, r) => (l <= r ? BigInteger.One : BigInteger.Zero),
            [">="] = (l, r) => (l >= r ? BigInteger.One : BigInteger.Zero),
        };

        public static void parseNodeStructureFromString(string expr)
        {
            List<string> tokens = TokenizeExpression(expr);

            Console.WriteLine("Tokens parsed:");
            //First lets just see what tokens we got.
            foreach(string token in tokens)
            {
                Console.Write(token);

                //Next step should be to figure out if the the tokens are nodes, brackets or expressions...
                if (BinaryOperations.Keys.Contains(token))
                {
                    Console.WriteLine(" : Expression");
                }
                else if(token == "(" || token == ")")
                {
                    Console.WriteLine(" : Bracket");
                }
                //TODO : Lets validate numbers here already.
                else if (char.IsNumber(token[0]))
                {
                    Console.WriteLine(" : Number");
                }
            }



        }


        /// <summary>
        /// Tokenize expression
        /// </summary>
        /// <param name="expr">Expression</param>
        /// <returns>List of tokens</returns>
        private static List<string> TokenizeExpression(string expr)
        {
            string[] delimiters = new[] { "(", ")" }.Concat(BinaryOperations.Keys).Distinct().ToArray();
            List<string> tokens = new List<string>();
            string buffer = string.Empty;

            // Strip spaces
            expr = expr.Replace(" ", string.Empty);

            // Parse string chunk-by-chunk
            while (expr.Length > 0)
            {
                string del = delimiters.SingleOrDefault(d => expr.StartsWith(d));

                if (del != null)
                {
                    // If there was something else in between then store that in tokens list
                    if (buffer.Length > 0)
                    {
                        tokens.Add(buffer);
                        buffer = string.Empty;
                    }

                    // Add token to list
                    tokens.Add(del);
                    expr = expr.Remove(0, del.Length);
                }
                else
                {
                    // Add character to buffer
                    buffer += expr[0];
                    expr = expr.Remove(0, 1);
                }
            }

            // Anything left in buffer ?
            if (buffer.Length > 0)
            {
                tokens.Add(buffer);
            }

            return tokens;
        }
    }
}
