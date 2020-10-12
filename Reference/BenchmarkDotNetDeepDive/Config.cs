using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;

namespace BenchmarkDotNetDeepDive
{
    public class Config : ManualConfig
    {
        public Config()
        {
            AddColumn(
                StatisticColumn.P0,
                StatisticColumn.P50,
                StatisticColumn.P90,
                StatisticColumn.P95,
                StatisticColumn.P100);
        }
    }
}