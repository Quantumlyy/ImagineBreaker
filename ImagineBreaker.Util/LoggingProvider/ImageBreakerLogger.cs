using System;
using Microsoft.Extensions.Logging;

namespace ImagineBreaker.Util.LoggingProvider
{
    public class ImagineBreakerLogger : ILogger
    {
        private readonly LogHandler<ImagineBreakerLogger> _log = LogHandler<ImagineBreakerLogger>.Log;
        
        private readonly string _name;
        private readonly ImagineBreakerLoggerConfiguration _config;
        
        public ImagineBreakerLogger(string name, ImagineBreakerLoggerConfiguration config)
        {
            _name = name;
            _config = config;
        }
        
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;
            if (formatter == null)
                throw new ArgumentNullException(nameof(formatter));

            var message = formatter(state, exception);
            var transformedEnum = (Enums.LogLevel)(int)logLevel;
            
            if (!string.IsNullOrEmpty(message) || exception != null)
            {
                _log.RawLog(transformedEnum, message, exception, _name);
            }
        }
        
        public bool IsEnabled(LogLevel logLevel)
        {
            return (int)logLevel != (int)Enums.LogLevel.None;
        }
        
        public IDisposable BeginScope<TState>(TState state)
            => null;
        
    }
}