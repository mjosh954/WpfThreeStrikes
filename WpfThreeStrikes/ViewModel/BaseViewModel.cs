
using System;
using System.Windows;
using System.Windows.Input;
using WpfThreeStrikes.Commands;

namespace WpfThreeStrikes.ViewModel
{
    public class BaseViewModel
    {
        public ICommand CloseWindow { get; private set; }
        public Action CloseAction { get; set; }
        
        public BaseViewModel()
        {
            CloseWindow = new CloseCommand();
        }

        #region BaseViewModel Commands

        public class CloseCommand : ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                if(parameter != null)
                    ((Window)parameter).Close();
            }

            public event EventHandler CanExecuteChanged;
        }

        #endregion



    }
}
