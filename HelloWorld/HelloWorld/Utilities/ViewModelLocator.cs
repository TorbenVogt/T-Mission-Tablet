using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TMissionMobile.Viewmodels;

namespace TMissionMobile.Utilities
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

            SimpleIoc.Default.Register<LoadOverviewModel>();
            SimpleIoc.Default.Register<LoadSpecDialogViewModel>();
        }
        
        public ViewModelBase LoadOverviewModel
        {
            get { return SimpleIoc.Default.GetInstance<LoadOverviewModel>(); }
        }

        public ViewModelBase LoadSpecDialogViewModel
        {
            get { return SimpleIoc.Default.GetInstance<LoadSpecDialogViewModel>(); }
        }


    }
}
