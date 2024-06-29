using BenchmarkDotNet.Running;

namespace BenmarkIterateCollections;


public class Program
{

    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<IterateCollectionsBenchmark>();
        Console.WriteLine("Benchmark finished. Hit the any key to exit");
        Console.ReadKey();
    }

  

}
