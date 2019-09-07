using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace hackertests.Tests
{
    public class LeetAddTwoNumbers : ITestProgram
    {
        public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.LeetAddTwoNumberLists;
        }

        public List<int> AddTwoLists(List<int> l1, List<int> l2)
        {
            var result = new List<int>();
            var maxItems = 0;
            if (l1.Count().Equals(l2.Count()))
                maxItems = l1.Count();
            else
                throw new InvalidDataException("Invalid argument exception");
            int i = 0;
            int carryOver = 0;
            while (i < maxItems)
            {
                var temp = l1[i] + l2[i] + carryOver;
                carryOver = 0;
                if (temp > 9)
                {
                    carryOver = temp - 9;
                    temp = 0;
                }

                result.Add(temp);
                i++;

            }
            return result;
        }

        public void RunTests()
        {
            var list1 = new List<int> { 2, 5, 1 };
            var list2 = new List<int> { 3, 6, 1 };

            System.Console.WriteLine(string.Join(", ", list1));
            System.Console.WriteLine(string.Join(", ", list2));
            System.Console.WriteLine(string.Join(", ", AddTwoLists(list1, list2)));
        }
    }
}