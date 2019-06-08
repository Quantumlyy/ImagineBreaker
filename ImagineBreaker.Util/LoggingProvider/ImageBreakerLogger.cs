using System;
using Microsoft.Extensions.Logging;

namespace ImagineBreaker.Util.LoggingProvider
{
    public class ImagineBreakerLogger<T> : ILogger<T>
    {
        private readonly LogHandler<ImagineBreakerLogger<T>> _log = LogHandler<ImagineBreakerLogger<T>>.Log;
        private readonly ILogger _logger;
        
        public ImagineBreakerLogger(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger(typeof(T).Name);
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
                _log.RawLog(transformedEnum, message, exception);
            }
        }
        
        public bool IsEnabled(LogLevel logLevel)
        {
            return (int)logLevel != (int)Enums.LogLevel.None;
        }
        
        IDisposable ILogger.BeginScope<TState>(TState state)
            => _logger.BeginScope(state);
    }
}