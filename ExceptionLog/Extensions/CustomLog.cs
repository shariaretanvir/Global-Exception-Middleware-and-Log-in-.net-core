using CustomLogService.Class;
using CustomLogService.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionLog.Extensions
{
    public static class CustomLog
    {
        public static IServiceCollection UseCustomLogs(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}
