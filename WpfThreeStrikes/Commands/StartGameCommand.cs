using System;
using System.Windows.Input;
using WpfThreeStrikes.ViewModel;

namespace WpfThreeStrikes.Commands
{
    class StartGameCommand : ICommand
    {
        private readonly StartViewModel viewModel;

        public StartGameCommand(StartViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        #region ICommand

        public bool CanExecute(object parameter)
        {
            return string.IsNullOrEmpty(viewModel.Player.Error);
        }

        public void Execute(object parameter)
        {
            viewModel.StartGame();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion
    }
}
