using System.IO.Compression;
using System;
using System.Linq;
using System.Collections.Generic;

namespace hackertests.Tests
{
    public class Neighbour
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: { Name}, Age :{Age}";
        }
    }

    public enum Condition
    {
        LessThan,
        EqualTo,
        GreaterThan
    }
    public class TestAges : ITestProgram
    {
        List<Neighbour> _neighbours { get; set; }
        public int combinedAge { get; set; }
        public TestAges()
        {
            _neighbours = new List<Neighbour> {
                    new Neighbour {Name="Todd", Age=31},
                    new Neighbour {Name="Margo", Age=28},
                    new Neighbour {Name="Clark", Age=41},
                    new Neighbour {Name="Ellen", Age=39}
            };
        }
        public List<Neighbour> GetNeighboursbyAge(int age, Condition condition)
        {
            switch (condition)
            {
                case Condition.EqualTo:
                    return _neighbours.Where(x => x.Age == age).ToList();
                case Condition.LessThan:
                    return _neighbours.Where(x => x.Age < age).ToList();
                case Condition.GreaterThan:
                    return _neighbours.Where(x => x.Age > age).ToList();
                default:
                    throw new IndexOutOfRangeException("Unspecified condition");
            }
        }

        public List<Neighbour> GetNeighboursbyName(string name)
        {
            var result = GetNeighboursbyAge(40, Condition.LessThan);
            return result.Where(x => x.Name.Equals(name)).ToList();
        }


        public void RunTests()
        {
            // 1. Get neighbours less than 40 years of age
            var result = GetNeighboursbyAge(40, Condition.LessThan);
            result.ForEach(x => System.Console.WriteLine($"{x}"));
            // 2. Get Neighbours by name "Clark"
            var result2 = GetNeighboursbyName("Clark");
            result2.ForEach(x => System.Console.WriteLine($"{x}"));
            //Compute the combined age
            this.combinedAge = _neighbours.Select(x => x.Age).ToList().Sum();
            System.Console.WriteLine($"combined age: {this.combinedAge}");
            // empty the neighbours array
            this._neighbours.Clear();
        }
    }
}