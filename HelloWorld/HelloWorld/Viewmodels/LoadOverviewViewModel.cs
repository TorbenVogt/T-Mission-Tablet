using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using Microsoft.VisualBasic;

namespace TMissionMobile.Viewmodels
{
    public class LoadOverviewModel : ViewModelBase 
    {
       private int dummyValue = 3;
        
       public int DummyValue
        {
            get
            {
                return dummyValue;
            }
            set
            {
                dummyValue = value;
                RaisePropertyChanged();
            }
            
        }

        private Image planeImage;

        public Image PlaneImage
        {
            get { return planeImage; }
            set
            {
                BitmapImage src = new BitmapImage();
                src.UriSource = Common.Constants.ImageUri.PlaneTop;
                planeImage = new Image();
                planeImage.Source = src;
                planeImage = value;
                RaisePropertyChanged();
            }
        }

        private Uri imageUri;

        public Uri ImageUri
        {
            get { return imageUri; }
            set
            {
                imageUri = value;
                RaisePropertyChanged();
            }
        }

            


        public LoadOverviewModel()
        {

            Task task = new Task(ReadOurXML);
            task.Start();

        }

        static void ReadOurXML()
        {

            Windows.Storage.StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            
            XDocument booksFromFile = XDocument.Load(Path.Combine(installedLocation.Path, Common.Constants.FolderNames.AssetsFolder, "dummy.xml"));


        }

    }

    
}
