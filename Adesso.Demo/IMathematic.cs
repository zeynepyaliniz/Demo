using System;
using System.Collections.Generic;
using System.Text;

namespace Adesso.Demo
{
    public interface IMathematic
    {
        int Sum(int first, int second);
        double Divide(int first, int second);
        int Subtract(int first, int second);
        int Multiply(int first, int second);
    }
}
