using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;

namespace LoggerTest.Logging
{
    public static class LoggerExtension
    {
        public static Logger LoggerPath(this Logger logger)
        {
            string logPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            LogManager.Configuration.Variables["LogPath"] = logPath;

            return logger;
        }
    }
}
