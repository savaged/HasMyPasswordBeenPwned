using GalaSoft.MvvmLight;

namespace Savaged.HasMyPasswordBeenPwned.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _feedback;

        public MainWindowViewModel()
        {
            _feedback = "Hello .NET Core from VM!";
        }

        public string Feedback
        {
            get => _feedback;
            set => Set(ref _feedback, value);
        }
    }
}