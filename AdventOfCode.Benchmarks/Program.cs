using AdventOfCode.Benchmarks;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

ManualConfig config = new()
{
    SummaryStyle = new(default, true, SizeUnit.B, TimeUnit.GetBestTimeUnit())
};
config.AddLogger(ConsoleLogger.Default);
config.AddColumn(TargetMethodColumn.Method, StatisticColumn.Mean, StatisticColumn.Error);
config.AddColumnProvider(DefaultColumnProviders.Metrics, DefaultColumnProviders.Params);

//BenchmarkRunner.Run<Benchmarks2021>(config);
BenchmarkRunner.Run<Benchmarks2022>(config);
