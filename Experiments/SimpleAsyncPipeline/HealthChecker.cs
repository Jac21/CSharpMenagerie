using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAsyncPipeline
{
    public class HealthChecker
    {
        public void Check()
        {
            UptimeChecker uptimeChecker = new UptimeChecker();
            TlsChecker tlsChecker = new TlsChecker();
            DnsChecker dnsChecker = new DnsChecker();
            LogChecker logChecker = new LogChecker();

            Data data = new Data();
            List<CheckInfo> checkinfo = new List<CheckInfo>();

            foreach (var check in checkinfo)
            {
                var result = Task.FromResult(new AggregateCheckResult())
                    .Pipe(uptimeChecker.Check, check)
                    .Pipe(tlsChecker.Check, check)
                    .Pipe(dnsChecker.Check, check)
                    .Pipe(data.Save, check)
                    .Pipe(logChecker.Check, check);
            }
        }
    }

    public class CheckInfo
    {
        public bool AllowanceForUptimeChecks { get; set; }

        public bool CheckUptime { get; set; }

        public bool CheckTls { get; set; }

        public bool AllowanceForUptimeCheckDnsChecks { get; set; }
    }

    public class Data
    {
        public async Task<AggregateCheckResult> Save(Task<AggregateCheckResult> result, CheckInfo check)
        {
            await Task.Delay(1000);

            Console.WriteLine("Saved!");

            return await result;
        }
    }

    public class AggregateCheckResult
    {
    }

    public class LogChecker : IChecker
    {
        public async Task<AggregateCheckResult> Check(Task<AggregateCheckResult> result, CheckInfo check)
        {
            await Task.Delay(1000);

            Console.WriteLine($"{nameof(LogChecker)} checked!");

            return await result;
        }
    }

    public class DnsChecker : IChecker
    {
        public async Task<AggregateCheckResult> Check(Task<AggregateCheckResult> result, CheckInfo check)
        {
            await Task.Delay(1000);

            Console.WriteLine($"{nameof(DnsChecker)} checked!");

            return await result;
        }
    }

    public class TlsChecker : IChecker
    {
        public async Task<AggregateCheckResult> Check(Task<AggregateCheckResult> result, CheckInfo check)
        {
            await Task.Delay(1000);

            Console.WriteLine($"{nameof(TlsChecker)} checked!");

            return await result;
        }
    }

    public class UptimeChecker : IChecker
    {
        public async Task<AggregateCheckResult> Check(Task<AggregateCheckResult> result, CheckInfo check)
        {
            await Task.Delay(1000);

            Console.WriteLine($"{nameof(UptimeChecker)} checked!");

            return await result;
        }
    }

    public interface IChecker
    {
        Task<AggregateCheckResult> Check(Task<AggregateCheckResult> result, CheckInfo check);
    }
}