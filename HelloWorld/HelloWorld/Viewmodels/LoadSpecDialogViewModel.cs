using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
using GalaSoft.MvvmLight;

namespace TMissionMobile.Viewmodels
{
    class LoadSpecDialogViewModel : ViewModelBase
    {
        public string DisplayedImage
        {
            get { return "ms-appx:///Assets/homer-simpson.bmp"; }
        }
    }
}
