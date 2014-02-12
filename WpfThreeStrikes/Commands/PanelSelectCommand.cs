using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfThreeStrikes.Model;
using WpfThreeStrikes.ViewModel;

namespace WpfThreeStrikes.Commands
{
    class PanelSelectCommand : ICommand
    {
        private GameViewModel viewModel;

        public PanelSelectCommand(GameViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        #region ICommand

        public bool CanExecute(object parameter)
        {
            return viewModel.Player.OnHand != null;
        }

        public void Execute(object parameter)
        {
            viewModel.SelectPanel(Convert.ToInt32(parameter));
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion
    }
}
