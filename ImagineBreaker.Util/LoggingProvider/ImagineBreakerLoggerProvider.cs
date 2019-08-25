using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace ImagineBreaker.Util.LoggingProvider
{
    public class ImagineBreakerLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, ImagineBreakerLogger> _loggers = new ConcurrentDictionary<string, ImagineBreakerLogger>();
        
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new ImagineBreakerLogger(name));
        }
        
        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}