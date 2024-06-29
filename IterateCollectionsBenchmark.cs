using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace BenmarkIterateCollections;

public class IterateCollectionsBenchmark
{

    private Random _rnd = new Random();
    private int[] _array = default!;

    private List<int> _list = default!;
    private const int ITEM_COUNT = 1001;

    [GlobalSetup]
    public void Init()
    {
        _array = Enumerable.Range(0, ITEM_COUNT).Select(_ => _rnd.Next(0, 1024)).ToArray();
        _list = _array.ToList();
    }

    [Benchmark(Description = "Iterate an array with foreach", Baseline = true)]
    public void IterateArray()
    {
        foreach (var item in _array)
        {
        }
    }

    [Benchmark(Description = "Iterate a list using a span with foreach")]
    public void IterateArrayUsingSpan()
    {
        Span<int> span = _array; //note : implicit operator used here to convert an array to a Span
        foreach (var item in span)
        {

        }
    }

    [Benchmark(Description = "Iterate a list with foreach")]
    public void IterateList()
    {
        foreach (var item in _list)
        {

        }
    }

    [Benchmark(Description = "Iterate a list using a span with foreach")]
    public void IterateListUsingSpan()
    {
        Span<int> span = CollectionsMarshal.AsSpan(_list);
        foreach (var item in span)
        {

        }
    }

}