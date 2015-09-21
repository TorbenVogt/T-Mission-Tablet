using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualBasic;
using TMissionMobile.Views;

namespace TMissionMobile.Viewmodels
{
    
    

    public class LoadOverviewModel : ViewModelBase 
    {
      
        private string currentImage;
        /// <summary>
        /// The property that the image binds to
        /// </summary>
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
        /// <summary>
        /// The property that controls the selected image for the listbox
        /// </summary>
        public string SelectedImageUri
        {
            get { return selectedImageUri; }
            set
            {
                selectedImageUri = value;
                RaisePropertyChanged();

                UpdateImage();
                
            }
        }

        private void UpdateImage()
        {
            CurrentImage = Common.Constants.FolderNames.AppxAssetsFolder + selectedImageUri;
            if (selectedImageUri == Common.Constants.PlaneImageUri.PlaneSide.ToString())
            {
                LoadImageUri = Common.Constants.FolderNames.AppxAssetsFolder + Common.Constants.ButtonImageUri.PlaneSideButtonNotSelected;
                LoadImageTop = 220;
                LoadImageLeft = 298;
            }
            else
            {
                LoadImageUri = Common.Constants.FolderNames.AppxAssetsFolder + Common.Constants.ButtonImageUri.PlaneTopButtonNotSelected;
                LoadImageTop = 140;
                LoadImageLeft = 295;
            }
        }


        private string loadImageUri = Common.Constants.FolderNames.AppxAssetsFolder +
                                      Common.Constants.ButtonImageUri.PlaneSideButtonNotSelected;
                
        /// <summary>
        /// the property that controls the uri for the plane button
        /// </summary>
        public string LoadImageUri 
        {
            get { return loadImageUri; }
            set
            {
                loadImageUri = value;
                RaisePropertyChanged();
            }
        }

        private int loadImageTop = 220;

        /// <summary>
        /// the property that controls the uri for the plane button
        /// </summary>
        public int LoadImageTop
        {
            get { return loadImageTop; }
            set
            {
                loadImageTop = value;
                RaisePropertyChanged();
            }
        }

        private int loadImageLeft = 298;

        /// <summary>
        /// the property that controls the uri for the plane button
        /// </summary>
        public int LoadImageLeft
        {
            get { return loadImageLeft; }
            set
            {
                loadImageLeft = value;
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
                        if(selectedImageUri == Common.Constants.PlaneImageUri.PlaneSide.ToString())
                            LoadImageUri = Common.Constants.FolderNames.AppxAssetsFolder + Common.Constants.ButtonImageUri.PlaneSideButtonSelected;
                        else
                        {
                            LoadImageUri = Common.Constants.FolderNames.AppxAssetsFolder + Common.Constants.ButtonImageUri.PlaneTopButtonSelected;
                        }
                        LoadDialog();
                    }
                    ));
            }
        }

        async void LoadDialog()
        {

            var contentDialog = new LoadSpecDialog();
            contentDialog.HorizontalAlignment = HorizontalAlignment.Right;
            contentDialog.HorizontalContentAlignment = HorizontalAlignment.Right;
            await contentDialog.ShowAsync();
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
