using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Colorful;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Console = Colorful.Console;

namespace ImagineBreaker.Util
{
    public class StartupHelper
    {
        public int SepLength { get; }
        public readonly LogHandler<StartupHelper> Logger;
        
        private readonly PerformanceManager _perfManager;
        private IConfiguration Configuration { get; }
        
        private Timer _usagePushingTimer;
        private Timer _garbageCollectionTimer;

        public StartupHelper(IConfiguration configuration, int sepLength = 100)
        {
            Configuration = configuration;
            SepLength = sepLength;
            Logger = LogHandler<StartupHelper>.Log;
            _perfManager = new PerformanceManager();
        }
        
        public void Initialize()
        {
            Console.Title = "ImagineBreaker - QuantumlyTangled";
            Console.WindowHeight = 25;
            Console.WindowWidth = 150;

            PrintHeader();
            PrintSeparator();
            PrintSystemInformation();
            PrintSeparator();
            
            _perfManager.GetCurrentRamUsage();
            _perfManager.GetCurrentCpuUsage();

            ActivateGarbageCollectionTimer();
            if (Convert.ToBoolean(Configuration.GetSection("ImagineBreaker").GetSection("Logging")["UsageUpdates"])) ActivateUpdatePushingTimer();
        }
        
        private void PrintHeader()
        {
            var header = @"
 _____                      _           ______                _             
|_   _|                    (_)          | ___ \              | |            
  | | _ __ ___   __ _  __ _ _ _ __   ___| |_/ /_ __ ___  __ _| | _____ _ __ 
  | || '_ ` _ \ / _` |/ _` | | '_ \ / _ \ ___ \ '__/ _ \/ _` | |/ / _ \ '__|
 _| || | | | | | (_| | (_| | | | | |  __/ |_/ / | |  __/ (_| |   <  __/ |   
 \___/_| |_| |_|\__,_|\__, |_|_| |_|\___\____/|_|  \___|\__,_|_|\_\___|_|   
                       __/ |                                                
                      |___/                                                 
";
            Console.WriteLine(header, Color.FromArgb(101, 245, 173));
        }
        
        // TODO: Change color coding
        // TODO: Provide more ASP related data
        private void PrintSystemInformation()
        {
            var process = Process.GetCurrentProcess();
            var formatString =
                $"    {{0}}: {RuntimeInformation.FrameworkDescription}    |    {{1}}: {RuntimeInformation.OSDescription}\n" +
                "    {2}: {3} ID / Using {4} Threads / Started On {5}";
            var formats = new[]
            {
                new Formatter("FX Info", Color.Aquamarine),
                new Formatter("OS Info", Color.Aquamarine),
                new Formatter("Process", Color.Aquamarine),
                new Formatter(process.Id.ToString(), Color.Gold),
                new Formatter(process.Threads.Count.ToString(), Color.Gold),
                new Formatter($"{process.StartTime:MMM d - hh:mm:ss tt}", Color.Gold)
            };
            
            Console.WriteLineFormatted(formatString, Color.White, formats);
        }

        private void TimePostStats()
        {
            var mem = _perfManager.GetCurrentRamUsage();
            var cpu = _perfManager.GetCurrentCpuUsage();
            LogHandler<PerformanceManager>.Log.UsageUpdates($"Current Usage -=- Memory: {mem} =-= CPU: {cpu}");
        }

        private void PrintSeparator() 
            => Console.WriteLine(new string('-', SepLength), Color.Gray);

        private void ActivateUpdatePushingTimer()
        {
            _usagePushingTimer = new Timer(e => { TimePostStats(); }, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
        }
        
        private void ActivateGarbageCollectionTimer()
        {
            _garbageCollectionTimer = new Timer(e => { _perfManager.CollectGarbage(); }, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
        }
    }
}