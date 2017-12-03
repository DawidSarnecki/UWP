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
using ExtensionMethods.Logging;
using NLog;
using NLog.Config;
using System.Reflection;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace ExtensionWithNlogNuget
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static readonly LogFactory Instance = new LogFactory(new XmlLoggingConfiguration("nlog"));

        public MainPage()
        {
            Logger logger = LogManager.GetLogger("Foo");
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //LogManager.GetCurrentClassLogger();

            var foo = LogManager.Configuration;

            //Logger logger = LogManager.GetCurrentClassLogger().LogToPath();

            logger.Trace("Sample trace message");
            logger.Debug("Sample debug message");
            logger.Info("Sample informational message");
            logger.Warn("Sample warning message");
            logger.Error("Sample error message");
            logger.Fatal("Sample fatal error message");


            this.InitializeComponent();
        }
    }
}
