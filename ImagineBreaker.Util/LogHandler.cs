using System;
using System.Drawing;
using System.IO;
using ImagineBreaker.Util.Enums;

using Console = Colorful.Console;

namespace ImagineBreaker.Util
{
    public class LogHandler<T>
    {
        public static LogHandler<T> Log => LazyLogHandler.Value;
        private static readonly Lazy<LogHandler<T>> LazyLogHandler
            = new Lazy<LogHandler<T>>(() => new LogHandler<T>());
        
        private readonly object _logLock;
        private readonly DateTimeOffset _date;
        
        public LogHandler()
        {
            _logLock = new object();
            _date = DateTimeOffset.Now;
        }
        
        public void Information(string message, Exception exception = default)
        {
            RawLog(LogLevel.Information, message, exception);
        }
        
        public void UsageUpdates(string message, Exception exception = default)
        {
            RawLog(LogLevel.UsageUpdates, message, exception);
        }

        public void RawLog(LogLevel logLevel, string message, Exception exception, string logPoster = "?")
        {
            lock (_logLock)
            {
                var date = $"[{DateTimeOffset.Now:MMM d - hh:mm:ss tt}]";
                var log = $" [{GetLogLevel(logLevel)}] ";
                var msg = exception?.ToString() ?? message;
                var loggedName = logPoster != "?" ? logPoster : typeof(T).Name;
                var logMessage = $"{date}{log}[{loggedName}] {msg}";
                
                Append(date, Color.Gray);
                Append(log, GetColor(logLevel));
                Append(msg, Color.White);
                Console.Write(Environment.NewLine);
                
                WriteToFile(logMessage);
            }
        }
        
        private static void Append(string message, Color color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
        }

        private static string GetLogLevel(LogLevel logLevel)
        {
            return logLevel switch
                {
                    LogLevel.Critical => "CRIT",
                    LogLevel.Debug => "DBUG",
                    LogLevel.Error => "EROR",
                    LogLevel.Information => "INFO",
                    LogLevel.None => "NONE",
                    LogLevel.Trace => "TRCE",
                    LogLevel.Warning => "WARN",
                    LogLevel.UsageUpdates => "USGU",
                    _ => "NONE"
                };
        }

        private static Color GetColor(LogLevel logLevel)
        {
            return logLevel switch
                {
                    LogLevel.Critical => Color.Red,
                    LogLevel.Debug => Color.SlateBlue,
                    LogLevel.Error => Color.Red,
                    LogLevel.Information => Color.SpringGreen,
                    LogLevel.None => Color.BurlyWood,
                    LogLevel.Trace => Color.SlateBlue,
                    LogLevel.Warning => Color.Yellow,
                    LogLevel.UsageUpdates => Color.LightSeaGreen,
                    _ => Color.SlateBlue
                };
        }
        
        private void WriteToFile(string message)
        {
            File.AppendAllText($"{_date.Year}-{_date.Month}-{_date.Day}.log", $"{message}\n");
        }
    }
}