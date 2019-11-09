using System;

namespace hackertests.Tests
{
    public class DirectoryTests : ITestProgram
    {
        public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.DirectoryTests;
        }

        public void RunTests()
        {
            System.Console.WriteLine();
            string directoryName = AppDomain.CurrentDomain.BaseDirectory;
            if (directoryName == null) return;
            Console.WriteLine($"dir: {directoryName}");
        }
    }
}