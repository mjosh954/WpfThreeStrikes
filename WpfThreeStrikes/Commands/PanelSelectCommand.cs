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
            int selected  = Convert.ToInt16(parameter);
            bool correct = viewModel.PrizePanel.CheckSelectedPanel(viewModel.Player.OnHand, selected);
            if (correct)
            {
                viewModel.PrizePanel.SetCorrectPanel(selected);
                // disable the button
                // change the button
            }

            viewModel.Player.OnHand = null;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion
    }
}
