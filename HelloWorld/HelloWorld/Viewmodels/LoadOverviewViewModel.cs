using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using GalaSoft.MvvmLight;

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
