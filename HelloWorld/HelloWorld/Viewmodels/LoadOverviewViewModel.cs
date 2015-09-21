using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private string currentImage;

        public string CurrentImage
        {
            get { return currentImage; }
            set
            {
                currentImage = value;
                RaisePropertyChanged();
            }
        }


        
        private string selectedImageUri;

        public string SelectedImageUri
        {
            get { return selectedImageUri; }
            set
            {
                selectedImageUri = value;
                RaisePropertyChanged();

                CurrentImage = Common.Constants.FolderNames.AppxAssetsFolder + selectedImageUri;
            }
        }

        private string loadImageUri = Common.Constants.FolderNames.AppxAssetsFolder + Common.Constants.ButtonImageUri.PlaneButtonNotSelected;

        public string LoadImageUri 
        {
            get { return loadImageUri; }
            set
            {
                loadImageUri = value;
                RaisePropertyChanged();
            }
        }
        private RelayCommand changeButtonCommand;

        /// <summary>
        /// Gets the ChangeButtonCommand
        /// </summary>
        public RelayCommand ChangeButtonCommand
        {
            get
            {
                return changeButtonCommand ?? (changeButtonCommand = new RelayCommand(
                    ()=>
                    {
                        LoadImageUri = Common.Constants.FolderNames.AppxAssetsFolder + Common.Constants.ButtonImageUri.PlaneButtonSelected;
                    }
                    ));
            }
        }


        private ObservableCollection<string> imageUris;

        public ObservableCollection<string> ImageUris
        {
            get { return imageUris; }
            set { imageUris = value;
                  RaisePropertyChanged();}
        } 

        public LoadOverviewModel()
        {
            ImageUris = new ObservableCollection<string>();

            foreach (var p in typeof(Common.Constants.PlaneImageUri).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                ImageUris.Add(p.GetValue(null).ToString());
            }
            SelectedImageUri = ImageUris.First();

            
            

             
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
