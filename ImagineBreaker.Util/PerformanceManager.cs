using System;
using System.Diagnostics;

namespace ImagineBreaker.Util
{
    public class PerformanceManager
    {
        private bool _firstCpuCheckConducted;

        private PerformanceCounter Cpu { get; } = new PerformanceCounter
        {
            CategoryName = "Process",
            CounterName = "% Processor Time",
            InstanceName = Process.GetCurrentProcess().ProcessName,
            ReadOnly = true
        };

        public string GetCurrentCpuUsage()
        {
            if (_firstCpuCheckConducted) return Cpu.NextValue().ToString("P");
            Cpu.NextValue();
            _firstCpuCheckConducted = true;
            return Cpu.NextValue().ToString("P");
        }
        
        public static string GetCurrentRamUsage()
        {
            var proc = Process.GetCurrentProcess();
            return $"{Math.Round(proc.PrivateMemorySize64 / 1e+6, 2):F1}MB";
        }

        public static void CollectGarbage()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}