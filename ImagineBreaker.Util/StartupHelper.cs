using System.Drawing;
using Console = Colorful.Console;

namespace ImagineBreaker.Util
{
    public sealed class StartupHelper
    {
        public void Initialize()
        {
            Console.Title = "ImagineBreaker - QuantumlyTangled";
            Console.WindowHeight = 25;
            Console.WindowWidth = 140;
            
            PrintHeader();
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
        
        private void PrintSeparator() 
            => Console.WriteLine(new string('-', 100), Color.Gray);
    }
}