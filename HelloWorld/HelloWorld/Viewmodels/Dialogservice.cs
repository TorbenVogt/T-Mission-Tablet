namespace TMissionMobile.Viewmodels
{
    public class Dialogservice
    {

        public interface IDialogService
        {
            void RegisterView<TView, TViewModel>() where TViewModel : IDialogViewModel;
            bool? ShowDialog(IDialogViewModel viewModel);
        }

        public interface IDialogViewModel
        {
            bool CanClose();
            void Close();
        }

    }
}