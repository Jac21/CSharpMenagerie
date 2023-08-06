using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace MultiFrameworkBenchmarking;

[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser]
public class DateTimeCreationBenchmarks
{
    private static readonly string _dateString = "21 05 1993";

    [Benchmark(Baseline = true)]
    public DateTime StringManipulation()
    {
        var day = _dateString.Substring(0, 2);
        var month = _dateString.Substring(3, 2);
        var year = _dateString.Substring(6);

        return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
    }

    [Benchmark]
    public DateTime SpanManipulation()
    {
        ReadOnlySpan<char> dateSpan = _dateString;

        var day = dateSpan.Slice(0, 2);
        var month = dateSpan.Slice(3, 2);
        var year = dateSpan.Slice(6);

        return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
    }
}