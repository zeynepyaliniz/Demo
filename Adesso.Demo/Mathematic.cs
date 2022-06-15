using System;
using System.Collections.Generic;
using System.Text;

namespace Adesso.Demo
{
    public class Mathematic : IMathematic
    {

        public double Divide(int first, int second)
        {
            double result = Math.Round((double)first / second, 2);
            return double.IsInfinity(result) ? throw new DivideByZeroException() : result;
        }
        public int Multiply(int first, int second)
        {
            if (first.Equals(0) || second.Equals(0)) throw new ArgumentException(message: "You are multiplying by 0 (zero)");
            return first * second;
        }

        public int Subtract(int first, int second)
        {
            //intentionally wrong calculation:
            return first % second;
        }

        public int Sum(int first, int second)
        {
            return first + second;
        }
    }
}
