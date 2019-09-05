using System.Collections.Generic;
using System.Reflection.Emit;
using System;

namespace hackertests.Tests
{
    public class MlastElement : ITestProgram
    {
        public int? GetMlastElement(List<int> numbers, int m)
        {
            if (numbers.Count < m) return null;
            numbers.Reverse();
            return numbers[m - 1];

        }

         public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.MlastElement;
        }

        public  void RunTests()
        {
            List<int> arryNumbers = new List<int> { 10, 200, 3, 4000, 5 };
            Console.WriteLine($"Mlast: { GetMlastElement(arryNumbers, 8) }");

            Console.WriteLine($"Mlast: { GetMlastElement(arryNumbers, 3) }");
        }

    }
}