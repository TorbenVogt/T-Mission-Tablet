using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelloWorld
{
    public class MainViewModel : ViewModelBase 
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
        public MainViewModel()
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
