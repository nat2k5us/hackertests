using System.Collections.Generic;
using System.Linq;
namespace interviews.Tests
{
    public class StringOperations
    {

        public string Sample { get; set; }

        public int[] ArrayOfInts { get; set; }

        public char[] CharsArray { get; set; }

        public StringOperations()
        {
            Sample = "Hello World";
            ArrayOfInts = new int[] { 0, 4, 5, 6, 0, 0, 0 };
            CharsArray = new char[] { 'a', 'a', 'a', 'a', 'b', 'c', 'c', 'c', 'd', 'd', 'd', 'a', 'a' };
        }

        public string Reverse(string input)
        {
            var temp = input.ToCharArray().ToList();
            var returnStr = string.Empty;
            for (int i = temp.Count - 1; i >= 0; i--)
            {
                returnStr += temp[i];
            }
            return returnStr;
        }

        public int[] OrderInts(int[] array)
        {
            int current = 0;
            var returnList = new List<int>();
            while (current < array.Length)
            {
                if (!array[current].Equals(0))
                {
                    returnList.Add(array[current]);
                }
                current++;
            }
            for (int i = returnList.Count; i < array.Length; i++)
            {
                returnList.Add(0);
            }
            return returnList.ToArray();
        }

        public char[] RemoveRepeatingChars(char[] array)
        {
            int current = 0;
            var returnList = new List<char>();
            char prev = ' ';
            while (current < array.Length)
            {
                char c = array[current];
                if (!prev.Equals(c))
                {
                    returnList.Add(array[current]);
                }
                prev = c;
                current++;
            }

            return returnList.ToArray();
        }
        //Pack consecutive duplicates of list elements into sublists.
        // If a list contains repeated elements they should be placed in separate sublists.
        public Dictionary<char, List<char>> PackDuplicates(char[] array)
        {
            var dictionaryOfDuplicates = new Dictionary<char, List<char>>();
            int current = 0;
            var singlesList = new List<char>();
            char prev = ' ';

            while (current < array.Length)
            {
                char c = array[current];
                if (!prev.Equals(c))
                {
                    singlesList.Add(array[current]);
                }
                else
                {
                    List<char> existing = new List<char>();
                    if (dictionaryOfDuplicates.ContainsKey(c))
                    {
                        if (!dictionaryOfDuplicates.TryGetValue(c, out existing))
                        {
                            existing.Add(c);
                        }
                        existing.Add(c);
                    }
                    else
                    {
                        var duplicates = new List<char>();
                        duplicates.Add(c);
                        // add a new dictionary item
                        dictionaryOfDuplicates.Add(c, duplicates);
                    }
                }
                prev = c;
                current++;
            }
            return dictionaryOfDuplicates;
        }

        public void RunTests()
        {
            System.Console.WriteLine($"{Reverse(this.Sample)}");
            System.Console.WriteLine("Ordered Ints");
            OrderInts(this.ArrayOfInts).ToList().ForEach(x => System.Console.Write($"{x}, "));
            
            System.Console.WriteLine(" RemoveRepeatingChars ");
            RemoveRepeatingChars(this.CharsArray).ToList().ForEach(x => System.Console.Write($"{x}, "));
            System.Console.WriteLine(" PackDuplicates ");
            var duplicatesDictionary = PackDuplicates(this.CharsArray);
        }
    }
}