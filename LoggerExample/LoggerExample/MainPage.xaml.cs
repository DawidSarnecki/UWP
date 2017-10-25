using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NLog;
using System.Diagnostics;
using Windows.Storage;
using NLog.Config;
using NLog.Targets;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace LoggerExample
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //https://docs.microsoft.com/en-us/uwp/api/windows.storage.applicationdata
        //https://stackoverflow.com/questions/7898392/append-timestamp-to-a-file-name

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private StorageFile logFile;

        async void CreateLogFile()
        {
            string logfileName = string.Format($"AppLog_{DateTime.Now.ToString("yyyyMMddHHmmss")}.log"); 
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            logFile = await storageFolder.CreateFileAsync(logfileName, CreationCollisionOption.OpenIfExists);
        }

        public MainPage()
        {
            InitializeComponent();

            //https://github.com/NLog/NLog/wiki/Configuration-API
            CreateLogFile();

            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);
            fileTarget.FileName = logFile.Path;
            fileTarget.Layout = @"${date:format=yyyyMMdd_HH\:mm\:ss\:fff} ${pad:padding=5:inner=${level:uppercase=true}} ${pad:padding=5:inner=${logger}} ${message}";


            var rule = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;
            long k = DateTime.Now.Ticks;
            long l = DateTime.Now.Ticks;

            // Example usage
            logger.Log(LogLevel.Info, "Sample informational message, k={0}, l={1}", k, l);
            logger.Trace("Sample trace message, k={0}, l={1}", k, l);
            logger.Debug("Sample debug message, k={0}, l={1}", k, l);
            logger.Info("Sample informational message, k={0}, l={1}", k, l);
            logger.Warn("Sample warning message, k={0}, l={1}", k, l);
            logger.Error("Sample error message, k={0}, l={1}", k, l);
            logger.Fatal("Sample fatal error message, k={0}, l={1}", k, l);
            logger.Log(LogLevel.Info, "Sample informational message, k={0}, l={1}", k, l);

            Logger appLogger = LogManager.GetLogger("App");
            for (int i = 0; i < 10; ++i)
            {
                appLogger.Trace("trace log message ");
                appLogger.Debug("debug log message ");
                appLogger.Info("info log message ");
                appLogger.Warn("warn log message ");
            }


            Logger userLogger = LogManager.GetLogger("User");
            for (int i = 0; i < 10; ++i)
            {
                userLogger.Error("error log message ");
                userLogger.Fatal("fatal log message");
                userLogger.Debug("debug log message");
                userLogger.Info("info log message");
                userLogger.Warn("warn log message");
            }


        }
    }
}
