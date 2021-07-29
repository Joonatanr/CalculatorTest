using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CalculatorTest
{
    public abstract class CalcNode
    {
        public abstract BigInteger getNodeValue();
    }


    public class NumericNode : CalcNode
    {
        private BigInteger myValue = 0;

        public NumericNode(BigInteger val)
        {
            myValue = val;
        }

        public override BigInteger getNodeValue()
        {
            return myValue;
        }
    }
}
