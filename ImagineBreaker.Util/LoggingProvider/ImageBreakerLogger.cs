using System;
using Microsoft.Extensions.Logging;

namespace ImagineBreaker.Util.LoggingProvider
{
    public class ImagineBreakerLogger : ILogger
    {
        private readonly LogHandler<ImagineBreakerLogger> _logger;
        internal IExternalScopeProvider ScopeProvider { get; set; }
        
        public ImagineBreakerLogger()
        {
            _logger = LogHandler<ImagineBreakerLogger>.Log;
        }
        
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;
            if (formatter == null)
                throw new ArgumentNullException(nameof(formatter));

            var message = formatter(state, exception);
            Enums.LogLevel transformedEnum = (Enums.LogLevel)(int)logLevel;
            
            if (!string.IsNullOrEmpty(message) || exception != null)
            {
                _logger.RawLog(transformedEnum, message, exception);
            }
        }
        
        public bool IsEnabled(LogLevel logLevel)
        {
            return (int)logLevel != (int)Enums.LogLevel.None;
        }
        
        public IDisposable BeginScope<TState>(TState state) => ScopeProvider?.Push(state.ToString()) ?? NullScope.Instance;
    }

    internal class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();

        private NullScope()
        {
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}