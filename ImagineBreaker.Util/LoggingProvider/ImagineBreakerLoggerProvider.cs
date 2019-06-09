using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace ImagineBreaker.Util.LoggingProvider
{
    public class ImagineBreakerLoggerProvider : ILoggerProvider
    {
        private readonly ImagineBreakerLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, ImagineBreakerLogger> _loggers = new ConcurrentDictionary<string, ImagineBreakerLogger>();
        
        public ImagineBreakerLoggerProvider(ImagineBreakerLoggerConfiguration config)
        {
            _config = config;
        }
        
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new ImagineBreakerLogger(name, _config));
        }
        
        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}