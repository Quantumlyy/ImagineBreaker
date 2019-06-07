using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using Colorful;
using Console = Colorful.Console;

namespace ImagineBreaker.Util
{
    public sealed class StartupHelper
    {
        public int SepLength { get; } = 100;
        
        public void Initialize()
        {
            Console.Title = "ImagineBreaker - QuantumlyTangled";
            Console.WindowHeight = 25;
            Console.WindowWidth = 140;
            
            PrintHeader();
            PrintSeparator();
            PrintSystemInformation();
            PrintSeparator();
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
            Console.WriteLineFormatted(
                $"    {{0}}: {RuntimeInformation.FrameworkDescription}    |    {{1}}: {RuntimeInformation.OSDescription}\n" +
                "    {2}: {3} ID / Using {4} Threads / Started On {5}",
                Color.White,
                new Formatter("FX Info", Color.Aquamarine),
                new Formatter("OS Info", Color.Aquamarine),
                new Formatter("Process", Color.Aquamarine),
                new Formatter(process.Id.ToString(), Color.Gold),
                new Formatter(process.Threads.Count.ToString(), Color.Gold),
                new Formatter($"{process.StartTime:MMM d - hh:mm:ss tt}", Color.Gold));
        }
        
        private void PrintSeparator() 
            => Console.WriteLine(new string('-', SepLength), Color.Gray);
    }
}