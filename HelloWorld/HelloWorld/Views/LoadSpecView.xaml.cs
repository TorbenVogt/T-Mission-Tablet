using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using TMissionMobile.Annotations;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TMissionMobile.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoadSpecView : Page, INotifyPropertyChanged
    {

        public LoadSpecView()
        {
            this.InitializeComponent();

           GetTypeOfLoadsSelected();
        }

        private string loadString;
        public string LoadString
        {
            get { return loadString; }
            set
            {
                if (value != loadString)
                    loadString = value;
                OnPropertyChanged();
            }
        }

        public void GetTypeOfLoadsSelected()
        {

            Windows.Storage.ApplicationDataContainer localSettings =
            Windows.Storage.ApplicationData.Current.LocalSettings;

            Object TypeOFLaods = localSettings.Values["TypeOfLoads"];

            LoadString = TypeOFLaods.ToString();
            Textbox.Text = LoadString;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
