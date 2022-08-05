// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using EFCoreBenchmark;
using System;

namespace EFCoreBenchMark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(EFCoreBencher).Assembly);
            Console.WriteLine(summary);
        }
    }
}






