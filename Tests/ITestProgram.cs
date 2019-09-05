namespace hackertests.Tests
{
    public interface ITestProgram
    {
       TestProgramName GetName(TestProgramName name);
       
         void RunTests();
    }
}