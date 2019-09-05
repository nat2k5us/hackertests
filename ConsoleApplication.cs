using hackertests.Tests;

namespace hackertests
{

    public class ConsoleApplication
    {
        private readonly ITestProgram _testService;

        public ConsoleApplication(ITestProgram testService)
        {
            _testService = testService;
        }
        public void Run()
        {
            _testService.RunTests();
            // System.Console.ReadKey();
        }
    }
}