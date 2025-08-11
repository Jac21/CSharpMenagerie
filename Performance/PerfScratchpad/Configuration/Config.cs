using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

namespace PerfScratchpad.Configuration;

public class Config : ManualConfig
{
    public Config()
    {
        AddDiagnoser(MemoryDiagnoser.Default);
        AddDiagnoser(ThreadingDiagnoser.Default);
    }
}