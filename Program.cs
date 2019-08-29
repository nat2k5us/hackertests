using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using hackertests.Tests;

namespace hackertests
{
    class Program
    {
        // Complete the hourglassSum function below.
        static int hourglassSum(int[][] arr)
        {
            Console.WriteLine($"{arr.GetUpperBound(0)}");
            return -1;
        }

        static void Main(string[] args)
        {
            string directoryName = AppDomain.CurrentDomain.BaseDirectory;
            if (directoryName == null) return;
            Console.WriteLine($"dir: {directoryName}");

            MLast.RunTest();

            var fibonacci = new fibonacci();
            fibonacci.fibonacciTests();

            var palindrome = new palindrome();
            palindrome.RunTests();

            var testAges = new TestAges();
            testAges.RunTests();

            var adapterClient = new AdapterClient();
            adapterClient.DoSomething();

            //var spellcheck = new DictionaryWords();
            //spellcheck.RunTests();

            var stragetyClient = new StragetyClient();
            stragetyClient.RunTests();
        }
    }
}