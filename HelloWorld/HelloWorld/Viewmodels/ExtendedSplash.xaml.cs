﻿using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TMissionMobile.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/p/?LinkID=234238

namespace TMissionMobile.Utilities
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    partial class ExtendedSplash : Page
    {
        internal Rect splashImageRect; // Rect to store splash screen image coordinates.
        private SplashScreen splash; // Variable to hold the splash screen object.
        internal bool dismissed = false; // Variable to track splash screen dismissal status.
        internal Frame rootFrame;

        public ExtendedSplash(SplashScreen splashscreen)
        {
            InitializeComponent();

            // Listen for window resize events to reposition the extended splash screen image accordingly.
            // This is important to ensure that the extended splash screen is formatted properly in response to snapping, unsnapping, rotation, etc...
            Window.Current.SizeChanged += new WindowSizeChangedEventHandler(ExtendedSplash_OnResize);

            splash = splashscreen;

            if (splash != null)
            {
                // Register an event handler to be executed when the splash screen has been dismissed.
                splash.Dismissed += DismissedEventHandler;

                // Retrieve the window coordinates of the splash screen image.
                splashImageRect = splash.ImageLocation;
                PositionImage();

                // Optional: Add a progress ring to your splash screen to show users that content is loading
                PositionRing();
                LoadXMLdata();

            }

            // Create a Frame to act as the navigation context
            rootFrame = new Frame();





        }

        async void LoadXMLdata()
        {
            //Loads XML data
            await Task.Delay(200);
            splashProgressRing.Visibility = Visibility.Collapsed;
            ShowLogInBtns();
        }

        void ShowLogInBtns()
        {
            LoginTechnicianBtn.Visibility = Visibility.Visible;
            LoginPilotBtn.Visibility = Visibility.Visible;
            positionLogInBtn();
        }

        // Position the extended splash screen image in the same location as the system splash screen image.
        void PositionImage()
        {
            extendedSplashImage.SetValue(Canvas.LeftProperty, splashImageRect.X);
            extendedSplashImage.SetValue(Canvas.TopProperty, splashImageRect.Y);
            extendedSplashImage.Height = splashImageRect.Height;
            extendedSplashImage.Width = splashImageRect.Width;

        }

        void PositionRing()
        {
            splashProgressRing.SetValue(Canvas.LeftProperty, splashImageRect.X + (splashImageRect.Width * 0.5) - (splashProgressRing.Width * 0.5));
            splashProgressRing.SetValue(Canvas.TopProperty, (splashImageRect.Y + splashImageRect.Height + splashImageRect.Height * 0.1));
        }

        void positionLogInBtn()
        {
            LoginTechnicianBtn.SetValue(Canvas.LeftProperty, splashImageRect.X + (splashImageRect.Width * 0.1) - (LoginTechnicianBtn.Width * 0.1));
            LoginTechnicianBtn.SetValue(Canvas.TopProperty, (splashImageRect.Y + splashImageRect.Height + splashImageRect.Height * 0.1));

            LoginPilotBtn.SetValue(Canvas.LeftProperty, splashImageRect.X + (splashImageRect.Width * 0.6) - (LoginTechnicianBtn.Width * 0.1));
            LoginPilotBtn.SetValue(Canvas.TopProperty, (splashImageRect.Y + splashImageRect.Height + splashImageRect.Height * 0.1));
        }

        void ExtendedSplash_OnResize(Object sender, WindowSizeChangedEventArgs e)
        {
            // Safely update the extended splash screen image coordinates. This function will be fired in response to snapping, unsnapping, rotation, etc...
            if (splash != null)
            {
                // Update the coordinates of the splash screen image.
                splashImageRect = splash.ImageLocation;
                PositionImage();
                PositionRing();
                positionLogInBtn();
            }
        }

        // Include code to be executed when the system has transitioned from the splash screen to the extended splash screen (application's first view).
        void DismissedEventHandler(SplashScreen sender, object e)
        {
            dismissed = true;
            // Complete app setup operations here...

        }

        void DismissExtendedSplash()
        {
            // Navigate to mainpage

            rootFrame.Navigate(typeof(LoadOverviewView));
            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }

        void DismissAsAPilot()
        {
            // Navigate to mainpage

            rootFrame.Navigate(typeof(TestViewForLoadSpec));
            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }

        void LoginPilotBtn_Click(object sender, RoutedEventArgs e)
        {
            DismissAsAPilot();
        }

        void LogInTechnician_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer localSettings =
            Windows.Storage.ApplicationData.Current.LocalSettings;

            localSettings.Values["LoginUserId"] = "Technician";

            DismissExtendedSplash();


            // Load the app data for the setting LoginUserId

            //Windows.Storage.ApplicationDataContainer localSettings =
            //Windows.Storage.ApplicationData.Current.LocalSettings;

            //Object value = localSettings.Values["LoginUserId"];
        }
    }
}
