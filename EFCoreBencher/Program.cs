// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;


namespace EFCoreBenchMark;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}