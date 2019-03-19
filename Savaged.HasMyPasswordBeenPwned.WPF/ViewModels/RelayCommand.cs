using System;
using System.Windows.Input;

namespace Savaged.HasMyPasswordBeenPwned.WPF.ViewModels
{
    /// <Summary>
    /// Had to roll my own here because I couldn't find the MvvmLight verison.
    /// Actually I didn't roll my own, I just copied from 
    /// https://docs.microsoft.com/en-us/dotnet/standard/cross-platform/using-portable-class-library-with-model-view-view-model
    /// </Summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _handler;
        private bool _isEnabled;

        public RelayCommand(Action handler)
        {
            _handler = handler;
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _handler();
        }
    }
}