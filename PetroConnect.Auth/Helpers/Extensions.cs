using Microsoft.Extensions.Logging;
using PetroConnect.Auth.Models;
using PetroConnect.Auth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Common
{
    public class Extensions
    {
    }
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
        public static ILoggerFactory AddColoredConsoleLogger(this ILoggerFactory loggerFactory, DbLoggerConfiguration config)
        {
            loggerFactory.AddProvider(new DbLoggerProvider(config));
            return loggerFactory;
        }
        public static ILoggerFactory AddColoredConsoleLogger(this ILoggerFactory loggerFactory)
        {
            var config = new DbLoggerConfiguration();
            return loggerFactory.AddColoredConsoleLogger(config);
        }
        public static ILoggerFactory AddColoredConsoleLogger(this ILoggerFactory loggerFactory, Action<DbLoggerConfiguration> configure)
        {
            var config = new DbLoggerConfiguration();
            configure(config);
            return loggerFactory.AddColoredConsoleLogger(config);
        }
    }

}
