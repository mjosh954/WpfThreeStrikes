using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfThreeStrikes.Model;
using WpfThreeStrikes.View;
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
            GameView view = new GameView();
            view.DataContext = new GameViewModel(viewModel.Player);
            view.ShowDialog();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion
    }
}
