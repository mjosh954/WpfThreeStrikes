using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfThreeStrikes.ViewModel;

namespace WpfThreeStrikes.Commands
{
    public class NewGameCommand : ICommand
    {
        private GameViewModel viewModel;
            

        public NewGameCommand(GameViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.StartNewGame();
        }

        public event EventHandler CanExecuteChanged;
    }
}
