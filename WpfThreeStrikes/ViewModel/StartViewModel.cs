using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfThreeStrikes.Annotations;
using WpfThreeStrikes.Commands;
using WpfThreeStrikes.Model;

namespace WpfThreeStrikes.ViewModel
{

    public partial class StartViewModel : BaseViewModel, INotifyPropertyChanged
    {

        private readonly Player player;

        public Player Player
        {
            get
            {
                return player;
            }
        }

        public ICommand StartGameCommand
        {
            get;
            private set;
        }

        public StartViewModel() 
        {
            StartGameCommand = new StartGameCommand(this);
            player = new Player();
        }

        public void StartGame()
        {
            GameView view = new GameView();
            GameViewModel vm = new GameViewModel(Player);
            view.DataContext = vm;
            if(vm.CloseAction == null)
                vm.CloseAction = view.Close;
            view.ShowDialog();
        }
        


        #region

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
