using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
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

        static async void ReadOurXML()
        {

            Windows.Storage.StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            installedLocation.
            XDocument booksFromFile = XDocument.Load( @"C:\Users\MathiasHoffmann\Documents\GitHub\T-Mission-Tablet\HelloWorld\HelloWorld\bin\x86\Debug\AppX\Assets\dummy.xml");
        }

    }

    
}
