using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ExtensionMethods.Logging
{
    public static class NlogExtension
    {
        public static Logger LogToPath(this Logger logger)
        {
            Windows.Storage.StorageFolder storageFolder= Windows.Storage.ApplicationData.Current.LocalFolder;
            LogManager.Configuration.Variables["LogPath"] = storageFolder.Path;

            return logger;
        }
    }
}
