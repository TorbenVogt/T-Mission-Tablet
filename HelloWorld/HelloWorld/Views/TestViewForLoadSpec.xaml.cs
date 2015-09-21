using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TMissionMobile.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestViewForLoadSpec : Page
    {
        internal Frame rootFrame;
        public TestViewForLoadSpec()
        {
            this.InitializeComponent();

            // Create a Frame to act as the navigation context
            rootFrame = new Frame();
        }

        void DismissTestViewAsNormal()
        {
            Windows.Storage.ApplicationDataContainer localSettings =
            Windows.Storage.ApplicationData.Current.LocalSettings;

            localSettings.Values["TypeOfLoads"] = "Normal Load";
            // Navigate to mainpage

            //rootFrame.Navigate(typeof(LoadSpecView));
            // Place the frame in the current Window
            
        }

        void DismissAsCrazy()
        {
            Windows.Storage.ApplicationDataContainer localSettings =
            Windows.Storage.ApplicationData.Current.LocalSettings;

            localSettings.Values["TypeOfLoads"] = "Crazy Load";
            // Navigate to mainpage

            //rootFrame.Navigate(typeof(LoadSpecView));
            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }

        void CrazyLoads_Click(object sender, RoutedEventArgs e)
        {
            DismissAsCrazy();
        }

        async void NormalLoads_click(object sender, RoutedEventArgs e)
        {
            DismissTestViewAsNormal();

            var contentDialog = new LoadSpecDialog();

            await contentDialog.ShowAsync();

            // Load the app data for the setting LoginUserId

            //Windows.Storage.ApplicationDataContainer localSettings =
            //Windows.Storage.ApplicationData.Current.LocalSettings;

            //Object value = localSettings.Values["LoginUserId"];
        }
    }
}
