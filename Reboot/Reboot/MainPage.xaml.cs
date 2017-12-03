//source: 
//http://www.c-sharpcorner.com/article/restart-the-app-programmatically-in-universal-windows-programming-fall-creator/
//Restart An App Programmatically In UWP(Windows 10 Fall Creators Update Features)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415


namespace Reboot
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = await CoreApplication.RequestRestartAsync("Restart from my app");
            VerifyResult(result);
        }

        private async void VerifyResult(AppRestartFailureReason result)
        {
            if (result == AppRestartFailureReason.NotInForeground ||
                result == AppRestartFailureReason.RestartPending ||
                result == AppRestartFailureReason.Other ||
                result == AppRestartFailureReason.InvalidUser
                )
            {
                var msgBox = new Windows.UI.Popups.MessageDialog("Restart Failed", result.ToString());
                await msgBox.ShowAsync();
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            var msgBox = new Windows.UI.Popups.MessageDialog("Restart will start in 5 seconds");
            try
            {
                ShutdownManager.BeginShutdown(ShutdownKind.Restart, TimeSpan.FromSeconds(5));
            }
            catch (System.UnauthorizedAccessException ex)
            {
                msgBox = new Windows.UI.Popups.MessageDialog("Restart Failed", ex.Message);
                throw;
            }
            finally
            {
                msgBox = new Windows.UI.Popups.MessageDialog("Restart proccess finished.");
            }
           
            //var manager = BeginShutdown(ShutdownKind shutdownKind, TimeSpan timeout);
        }
    }
}
