using System;

namespace ExceptionDemo
{
    public static class Calculator
    {
        public static int Caculate(int total, int numberOfItems)
        {
            try
            {
                return total / numberOfItems;
            }
            catch (DivideByZeroException)
            {
                return 100;
            }
        }
    }
}