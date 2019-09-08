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
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;

namespace hackertests
{
    class Program
    {

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add services
            serviceCollection.AddTransient<FizzBizz>();
            serviceCollection.AddTransient<ArrayTests>();
            serviceCollection.AddTransient<Fibonacci>();
            serviceCollection.AddTransient<DictionaryWords>();
            serviceCollection.AddTransient<MlastElement>();
            serviceCollection.AddTransient<Palindrome>();
            serviceCollection.AddTransient<Recursion>();
            serviceCollection.AddTransient<StragetyClient>();
            serviceCollection.AddTransient<AdapterClient>();
            serviceCollection.AddTransient<StringArrayTests>();
            serviceCollection.AddTransient<TestAges>();
            serviceCollection.AddTransient<ProxyPatternClient>();
            serviceCollection.AddTransient<LeetAddTwoNumbers>();
            serviceCollection.AddTransient<LeetLongestSubString>();
            // add app

            serviceCollection.AddTransient<Func<TestProgramName, ITestProgram>>(
                serviceProvider => key =>
            {
                switch (key)
                {
                    case TestProgramName.FizzBizz:
                        return serviceProvider.GetService<FizzBizz>();
                    case TestProgramName.AdapterClient:
                        return serviceProvider.GetService<AdapterClient>();
                    case TestProgramName.ArrayTests:
                        return serviceProvider.GetService<ArrayTests>();
                    case TestProgramName.DictionaryWords:
                        return serviceProvider.GetService<DictionaryWords>();
                    case TestProgramName.Fibonacci:
                        return serviceProvider.GetService<Fibonacci>();
                    case TestProgramName.MlastElement:
                        return serviceProvider.GetService<MlastElement>();
                    case TestProgramName.Palindrome:
                        return serviceProvider.GetService<Palindrome>();
                    case TestProgramName.Recursion:
                        return serviceProvider.GetService<Recursion>();
                    case TestProgramName.ProxyPattern:
                        return serviceProvider.GetService<ProxyPatternClient>();
                    case TestProgramName.LeetAddTwoNumberLists:
                        return serviceProvider.GetService<LeetAddTwoNumbers>();
                    case TestProgramName.LeetLongestSubString:
                        return serviceProvider.GetService<LeetLongestSubString>();
                    default:
                        throw new KeyNotFoundException();
                }
            });
            // serviceCollection.AddTransient<ConsoleApplication>();
        }

        private static IEnumerable<Type> GetAllTypesOf<T>()
        {
            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);

            return runtimeAssemblyNames
                .Select(Assembly.Load)
                .SelectMany(a => a.ExportedTypes)
                .Where(t => typeof(T).IsAssignableFrom(t));
        }

        static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            //  var programs = GetAllTypesOf<ITestProgram>();

            serviceProvider.GetService<Fibonacci>().RunTests();
            serviceProvider.GetService<AdapterClient>().RunTests();
            serviceProvider.GetService<FizzBizz>().RunTests();
            serviceProvider.GetService<StragetyClient>().RunTests();
            serviceProvider.GetService<ArrayTests>().RunTests();
            serviceProvider.GetService<TestAges>().RunTests();
            serviceProvider.GetService<Palindrome>().RunTests();
            serviceProvider.GetService<MlastElement>().RunTests();
            serviceProvider.GetService<ProxyPatternClient>().RunTests();
            serviceProvider.GetService<LeetAddTwoNumbers>().RunTests();
            serviceProvider.GetService<LeetLongestSubString>().RunTests();


            string directoryName = AppDomain.CurrentDomain.BaseDirectory;
            if (directoryName == null) return;
            Console.WriteLine($"dir: {directoryName}");

        }
    }
}