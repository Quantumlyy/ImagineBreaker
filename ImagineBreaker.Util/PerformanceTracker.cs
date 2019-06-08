using System;
using System.Diagnostics;

namespace ImagineBreaker.Util
{
    public class PerformanceTracker
    {
        public PerformanceCounter CPU { get; } = new PerformanceCounter
        {
            CategoryName = "Process",
            CounterName = "% Processor Time",
            InstanceName = Process.GetCurrentProcess().ProcessName,
            ReadOnly = true
        };

        private bool _firstCpuCheckConducted;

        public string GetCurrentCpuUsage()
        {
            if (!_firstCpuCheckConducted)
            {
                CPU.NextValue();
                _firstCpuCheckConducted = true;
            }
            return CPU.NextValue().ToString("P");
        }
        
        public string GetCurrentRamUsage()
        {
            using (var proc = Process.GetCurrentProcess())
            {
                return $"{Math.Round(proc.PrivateMemorySize64 / 1e+6, 2).ToString("F1")}MB";
            }
        }
    }
}