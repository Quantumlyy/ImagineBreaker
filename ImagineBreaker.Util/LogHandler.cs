using System;
using System.Drawing;
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
        
        public LogHandler()
        {
            _logLock = new object();
        }
        
        public void Information(string message, Exception exception = default)
        {
            RawLog(LogLevel.Information, message, exception);
        }

        public void Debug(string message, Exception exception = default)
        {
            RawLog(LogLevel.Debug, message, exception);
        }

        public void Warning(string message, Exception exception = default)
        {
            RawLog(LogLevel.Warning, message, exception);
        }

        public void Error(Exception exception)
        {
            RawLog(LogLevel.Error, string.Empty, exception);
        }

        public void RawLog(LogLevel logLevel, string message, Exception exception)
        {
            lock (_logLock)
            {
                var date = $"[{DateTimeOffset.Now:MMM d - hh:mm:ss tt}]";
                var log = $" [{GetLogLevel(logLevel)}] ";
                var msg = exception?.ToString() ?? message;
                
                Append(date, Color.Gray);
                Append(log, GetColor(logLevel));
                Append(msg, Color.White);
                Console.Write(Environment.NewLine);
            }
        }
        
        private void Append(string message, Color color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
        }
        
        private string GetLogLevel(LogLevel logLevel)
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
                    _ => "NONE"
                };
        }

        private Color GetColor(LogLevel logLevel)
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
                    _ => Color.SlateBlue
                };
        }
    }
}