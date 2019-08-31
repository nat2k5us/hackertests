using System.Linq;
using System.Collections.Generic;

namespace hackertests.Tests
{
    public class StringArrayTests : ITestProgram
    {
        public string ReverseString(string str)
        {
            var returnStr = new List<char>();
            var chars = str.ToCharArray();
            for (int i = chars.Length - 1; i >=0; i--)
            {
                returnStr.Add(chars[i]);
            }
            return returnStr.ToList().ToString();
        }

        public void RunTests()
        {
            System.Console.WriteLine($" {ReverseString("Hello")} ");
        }
    }
}