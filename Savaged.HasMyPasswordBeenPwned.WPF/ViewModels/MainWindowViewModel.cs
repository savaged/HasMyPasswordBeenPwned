using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace Savaged.HasMyPasswordBeenPwned.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _feedback;
        private string _input;
        private bool _isBusy;

        public MainWindowViewModel()
        {
            _feedback = string.Empty;
            CheckInputCmd = new RelayCommand(OnCheckInput);
        }

        public string Input
        {
            get => _input;
            set
            {
                Set(ref _input, value);
                CheckInputCmd.IsEnabled = CanExecuteCheck;
            }
        }

        public string Feedback
        {
            get => _feedback;
            set => Set(ref _feedback, value);
        }

        public bool IsBusy 
        {
            get => _isBusy;
            set => Set(ref _isBusy, value);
        }

        public bool CanExecuteCheck => !string.IsNullOrEmpty(Input) && !IsBusy;

        public RelayCommand CheckInputCmd { get; }

        private void OnCheckInput()
        {
            if (CanExecuteCheck)
            {
                IsBusy = true;
                
                Feedback = "TODO Wire up the lib";

                IsBusy = false;
            }
        }
    }
}