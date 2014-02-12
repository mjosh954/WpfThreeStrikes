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
        private StartViewModel viewModel;


        public StartGameCommand(StartViewModel viewModel)
        {
            this.viewModel = viewModel;
            
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(viewModel.PlayerName);
        }

        public void Execute(object parameter)
        {
            GameView view = new GameView();
            view.DataContext = new GameViewModel(new Player(viewModel.PlayerName));
            view.ShowDialog();
        }

        public event EventHandler CanExecuteChanged;
    }
}
