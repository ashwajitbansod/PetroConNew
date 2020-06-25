using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace PetroConnect.Auth.Services
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly DbLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, DbLogger> _loggers = new ConcurrentDictionary<string, DbLogger>();

        public DbLoggerProvider(DbLoggerConfiguration config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new DbLogger(name, _config));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }

    public class DbLogger : ILogger
    {
        private readonly string _name;
        private readonly DbLoggerConfiguration _config;

        public DbLogger(string name, DbLoggerConfiguration config)
        {
            _name = name;
            _config = config;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.LogLevel;
        }

        public void Log<T>(LogLevel logLevel, EventId eventId, T state, Exception exception, Func<T, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
        }
    }


    public class DbLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
    }
}
