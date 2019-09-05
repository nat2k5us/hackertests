using System;

namespace hackertests.Tests
{
  
    public class FizzBizz : ITestProgram
    {
        public void FizzBizzProcess(int range)
        {
            var consoleMessage = string.Empty;
            for (int i = 1; i <= range; i++)
            {
                if(i % 3 == 0 && i % 5 == 0)
                {
                    consoleMessage += $"FizzBizz {i}  {Environment.NewLine}";
                }
                else if(i % 5 == 0)
                {
                    consoleMessage += $"Bizz {i}  {Environment.NewLine}";
                }
                else if(i % 3 == 0)
                {
                    consoleMessage += $"Fizz {i}  {Environment.NewLine}";
                }
                else
                {
                    consoleMessage += $" No Fizz - {i} {Environment.NewLine}";
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine(consoleMessage);
        }

         public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.FizzBizz;
        }

        public void RunTests()
        {
            FizzBizzProcess(100);
        }
    }
}