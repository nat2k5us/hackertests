using System.Collections.Generic;
using System;
using System.Linq;
namespace hackertests.Tests
{
    public class Palindrome: ITestProgram
    {
        public Palindrome()
        {

        }

        public bool isStringPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            var temp = input.ToCharArray().Reverse();
            var reversedInput = string.Concat(temp);
            System.Console.WriteLine($"input {input} in reverse {reversedInput}");
            if (input.Equals(reversedInput))
                return true;
            return false;
        }
        Func<string, bool> IsPalindrome = s => s.Reverse().Equals(s);
        public bool isPalindromeAble(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
           // if (input.Count() % 2 != 0) return false;

            var dictionary = new Dictionary<char, int>();
            var dictionaryPossibleItems = new Dictionary<char, bool>();
            foreach (var item in input.ToCharArray())
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item] = dictionary[item] + 1;
                    if (dictionary[item] % 2 == 0)
                        dictionaryPossibleItems[item] = true;
                    else
                        dictionaryPossibleItems[item] = false;
                }
                else
                {
                    dictionary.Add(item, 1);
                    dictionaryPossibleItems.Add(item, false);
                }
            }
            var falseItems = from entry in dictionaryPossibleItems where entry.Value.Equals(false) select entry;
            if (falseItems.Count() > 1)
                return false;
            char centerChar;
            if (falseItems.Count() == 1)
                centerChar = falseItems.ElementAt(0).Key;
            
            return true;

        }

        public void RunTests()
        {
            string test1 = "ABCDDCBA";
            string test2 = "ASSWE";
            string test3 = "whattahw";

            System.Console.WriteLine($"is Palindrome {test1} {isStringPalindrome(test1)}");
            System.Console.WriteLine($"is Palindrome {test2} {isStringPalindrome(test2)}");
            System.Console.WriteLine($"is isPalindromeAble {test3} {isPalindromeAble(test3)}");
        }

        public object GetObject()
        {
            return $"Palindrome Pattern";
        }
    }
}