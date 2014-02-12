using System;
using System.Windows.Input;
using WpfThreeStrikes.ViewModel;

namespace WpfThreeStrikes.Commands
{
    public class NewGameCommand : ICommand
    {
        private readonly GameViewModel gameViewModel;
        private readonly EndGameViewModel endViewModel;

        public NewGameCommand(GameViewModel gameViewModel, EndGameViewModel endViewModel)
        {
            this.gameViewModel = gameViewModel;
            this.endViewModel = endViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            gameViewModel.StartNewGame();
            endViewModel.CloseAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
