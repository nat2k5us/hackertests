using System.Linq;
namespace hackertests.Tests
{
    public class ArrayTests : ITestProgram
    {
        int[] nums = new int[] { 2, 7, 11, 15 };

        public int[] TwoSumTarget(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int item = array[i];
                for (int i1 = 0; i1 < array.Length; i1++)
                {
                    int innerItem = array[i1];
                    if ((item + innerItem).Equals(target))
                    {
                        return new int[] { i, i1 };
                    }
                }
            }
            return null;
        }

        public void RunTests()
        {
            System.Console.WriteLine("Array of Ints");
            this.nums.ToList().ForEach(x => System.Console.Write($"{x} "));
            System.Console.WriteLine();
            System.Console.WriteLine("TwoSumToTarget indexes for 9");
            TwoSumTarget(nums, 9).ToList().ForEach(x => System.Console.Write($" {x}, "));
            System.Console.WriteLine();
            System.Console.WriteLine("TwoSumToTarget indexes for 18");
            TwoSumTarget(nums, 18).ToList().ForEach(x => System.Console.Write($"{x}, "));
        }

        public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.ArrayTests;
        }
    }
}