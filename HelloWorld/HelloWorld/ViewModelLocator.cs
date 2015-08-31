using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Command;

using Microsoft.Practices.ServiceLocation;


namespace HelloWorld
{
    

    public class ViewModelLocator
    {
        

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
              //  SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                //SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }
        
        public ViewModelBase MainViewModel
        {
            get { return SimpleIoc.Default.GetInstance<MainViewModel>(); }
        }
        
        
        
    }
}
