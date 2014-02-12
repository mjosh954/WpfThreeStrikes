using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WpfThreeStrikes.Model;
using WpfThreeStrikes.View;
using WpfThreeStrikes.ViewModel;

namespace WpfThreeStrikes.Commands
{
    class PickChipCommand : ICommand
    {
        private GameViewModel viewModel;

        public PickChipCommand(GameViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        #region ICommand

        public bool CanExecute(object parameter)
        {
            return viewModel.Player.OnHand == null;
        }

        public void Execute(object parameter)
        {
            viewModel.PickFromBag();
        }

        
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion
    }
}
