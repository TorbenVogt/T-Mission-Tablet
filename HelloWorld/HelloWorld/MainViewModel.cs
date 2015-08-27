using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
