using System;
namespace hackertests.Tests
{
    public class fibonacci
    {
        public fibonacci()
        {

        }
        // 0, 1, 1, 2, 3, .....
        public int nthFibonacci(int n)
        {
            if (n < 2) return n;
            int current = 2;
            int last = 1;
            int prev2Last = 0;
            int nthFib = last;
            while (current <= n)
            {
                var temp = last + prev2Last;
                nthFib = temp;
                prev2Last = last;
                last = temp;
                current++;
            }

            return nthFib;
        }

        public int? GetFibOrder(int FibNumber, out string err)
        {
            err = string.Empty;
            if (FibNumber < 2) return FibNumber;
            int current = 2;
            int last = 1;
            int prev2Last = 0;
            int nthFib = last;
            while (nthFib < FibNumber)
            {
                var temp = last + prev2Last;
                if (temp.Equals(FibNumber))
                    return current;
                nthFib = temp;
                prev2Last = last;
                last = temp;

                current++;
            }
            err = $"The number {FibNumber} was not a fibonachi number.";
            return null;
        }
        public void fibonacciTests()
        {
            
            Console.WriteLine($" 0 : {nthFibonacci(0)}");
            Console.WriteLine($" 1 : {nthFibonacci(1)}");
            Console.WriteLine($" 3 : {nthFibonacci(3)}");
            Console.WriteLine($" 7:  {nthFibonacci(7)}");
            Console.WriteLine($" 17:  {nthFibonacci(17)}");
            Console.WriteLine($" 27:  {nthFibonacci(27)}");
            string err;
            Console.WriteLine($" 34:  {GetFibOrder(34, out err)}");
            Console.WriteLine($" 35:  {GetFibOrder(35, out err)}");
            if (!string.IsNullOrEmpty(err))
                System.Console.WriteLine(err);
        }

    }
}