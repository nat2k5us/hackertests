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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace hackertests
{
    class Program
    {

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add services
            serviceCollection.AddSingleton<ITestProgram, FizzBizz>();
            serviceCollection.AddTransient<ITestProgram, ArrayTests>();
            serviceCollection.AddTransient<ITestProgram, Fibonacci>();
            serviceCollection.AddTransient<ITestProgram, DictionaryWords>();
            serviceCollection.AddTransient<ITestProgram, MlastElement>();
            serviceCollection.AddTransient<ITestProgram, Palindrome>();
            serviceCollection.AddTransient<ITestProgram, Recursion>();
            serviceCollection.AddTransient<ITestProgram, StragetyClient>();
            serviceCollection.AddTransient<ITestProgram, AdapterClient>();
            serviceCollection.AddTransient<ITestProgram, StringArrayTests>();
            serviceCollection.AddTransient<ITestProgram, TestAges>();
            // add app
            serviceCollection.AddTransient<ConsoleApplication>();
        }

        static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // entry to run app
            serviceProvider.GetService<ConsoleApplication>().Run();

            string directoryName = AppDomain.CurrentDomain.BaseDirectory;
            if (directoryName == null) return;
            Console.WriteLine($"dir: {directoryName}");

        }
    }
}