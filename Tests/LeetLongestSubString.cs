using System.Linq;
namespace hackertests.Tests
{
    public class LeetLongestSubString : ITestProgram
    {
        public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.LeetLongestSubString;
        }
        public string LeetLongestSubStringImpl(string str)
        {
            var temp = str.ToCharArray().ToList();
            var subStr = string.Empty;
            var longestSubStr = string.Empty;
            for (int i = 0; i < temp.Count; i++)
            {
                if (!subStr.Contains(temp[i]))
                {
                    subStr += temp[i];
                    if (longestSubStr.Count() < subStr.Count())
                    {
                        longestSubStr = subStr;
                    }
                }
                else
                {
                    subStr = string.Empty;
                }
            }
            return longestSubStr;
        }
        public void RunTests()
        {
            System.Console.WriteLine("Longest Substring");
            System.Console.WriteLine($"{LeetLongestSubStringImpl("abcabcder")}");
        }
    }
}