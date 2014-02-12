using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfThreeStrikes.Commands;
using WpfThreeStrikes.Model;

namespace WpfThreeStrikes.ViewModel
{
    public class EndGameViewModel
    {
        private bool win;
        private Prize prize;

        public ICommand EndGameCommand
        {
            get;
            private set;
        }

        public string PrizeWorth
        {
            get
            {
                return string.Format("Prize value: ${0}", prize.Value.ToString("N2"));
            }
        }

        public string WinLoseText
        {
            get
            {
                return win ? "You Won!" : "Game Over";
            }
        }

        public EndGameViewModel(bool win, Prize prize, GameViewModel viewModel)
        {
            this.win = win;
            this.prize = prize;
            EndGameCommand = new NewGameCommand(viewModel);
        }
    }
}
