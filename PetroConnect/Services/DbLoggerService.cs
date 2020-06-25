using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetroConnect.Data.Common;
using PetroConnect.Data.Context;
using System;
using System.Linq;

namespace PetroConnect.API.Services
{
    public interface IDbLogger
    {
        void Log(LogLevel logLevel, string Message, Exception exception);
        void Log(string v);
    }

    public class DbLoggerService : IDbLogger
    {
        private readonly PetroConnectContext _context;
        public DbLoggerService(PetroConnectContext context)
        {
            _context = context;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public void Log(LogLevel logLevel, string Message, Exception exception)
        {

            var excepMessage = exception != null ?
                              (exception.Message != null ?
                                  exception.Message : (exception.InnerException != null ?
                                      exception.InnerException.ToString() : exception.ToString())) : Message;

            var res = _context.spExceptionLog.FromSqlRaw("exec " + SPConstants.spExceptionLogger + " {0} , {1}", logLevel.ToString(), excepMessage).ToList();

        }

        public void Log(LogLevel logLevel, Exception exception)
        {

            var excepMessage = exception != null ?
                              (exception.Message != null ?
                                  exception.Message : (exception.InnerException != null ?
                                      exception.InnerException.ToString() : exception.ToString())) : "";

            var res = _context.spExceptionLog.FromSqlRaw("exec " + SPConstants.spExceptionLogger + " {0} , {1}", logLevel.ToString(), excepMessage).ToList();

        }

        public void Log(string v)
        {
            var res = _context.spExceptionLog.FromSqlRaw("exec " + SPConstants.spExceptionLogger + " {0} , {1}", LogLevel.Information.ToString(), v).ToList();

        }
    }
}
