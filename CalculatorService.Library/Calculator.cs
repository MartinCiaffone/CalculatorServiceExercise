using System;
using System.Linq;

namespace CalculatorService.Library
{
    // By default, the .Net runtime will not raise exceptions when doing numeric calculations. 
    // If you want to ensure that arithmetic operations will throw overflow exceptions if an overflow happens, you need to use the checked { ... } code block.

    public static class Calculator
    {
        public static int Addition(int[] addends)
        {
            //Sum
            checked
            {
                return addends.Sum(); ;
            };
        }

        public static int Subtraction(int minuend, int subtrahend)
        {
            //Difference
            checked
            {
                return minuend - subtrahend;
            }
        }

        public static int Multiplication(int[] factors)
        {
            //Product
            checked
            {
                return factors.Aggregate(1, (a, b) => a * b);
                // Note: if Count(factors) --> Big number, it is worth checking for 0 values inside the array.
            }
        }

        public static (int quotient, int remainder) Division(int dividend, int divisor)
        {
            //Quotient - Remainder
            checked
            {
                return (quotient: dividend / divisor, remainder: dividend % divisor);
            }
        }
        public static int SquareRooting(int number)
        {
            //Square
            checked
            {
                if (number < 0) { throw new ArgumentException("No negative argument allowed"); }
                return (int)Math.Sqrt(number);
                // Note: Square root can not overflow. number must be >= 0
            }
        }

    }

}
