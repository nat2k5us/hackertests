namespace hackertests.Tests
{
    public class Recursion : ITestProgram
    {

        public static double Factorial(int number)
        {
            if (number == 0)
                return 1;
            return number * Factorial(number - 1);//Recursive call    

        }

        public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.Recursion;
        }

        public void RunTests()
        {
            System.Console.WriteLine($"4 factorial => {Factorial(4)}");
        }
    }


}