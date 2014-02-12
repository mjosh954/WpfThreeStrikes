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
    public class GameViewModel : INotifyPropertyChanged
    {
        private Player player;
        private Prize prize;
        private PrizePanel prizePanel;
        private Bag bag;
        private int strikeCount;

        private Panel panel0;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;

        public Panel Panel0
        {
            get
            {
                return panel0;
            }
            set
            {
                panel0 = value;
                OnPropertyChanged();
            }
           
        }

        public Panel Panel1
        {
            get
            {
                return panel1;
            }
            set
            {
                panel1 = value;
                OnPropertyChanged();
            }

        }

        public Panel Panel2
        {
            get
            {
                return panel2;
            }
            set
            {
                panel2 = value;
                OnPropertyChanged();
            }

        }

        public Panel Panel3
        {
            get
            {
                return panel3;
            }
            set
            {
                panel3 = value;
                OnPropertyChanged();
            }

        }

        public Panel Panel4
        {
            get
            {
                return panel4;
            }
            set
            {
                panel4 = value;
                OnPropertyChanged();
            }

        }

        public int StrikeCount
        {
            get
            {
                return strikeCount;
            }
            set
            {
                strikeCount = value;
                OnPropertyChanged();
                OnPropertyChanged("StrikeCountText");
            }
        }

        public string StrikeAlertText
        {
            get
            {
                return startAlert ? "Strike" : string.Empty;
            }
        }

        private bool startAlert;

        public bool StartStrikeAlert
        {
            get
            {
                return startAlert;
            }
            set
            {
                startAlert = value;
                OnPropertyChanged();
                OnPropertyChanged(StrikeAlertText);
            }
        }

        public string StrikeCountText
        {
            get
            {
                if (strikeCount == 0)
                    return null;

                StringBuilder sb = new StringBuilder();
                sb.Append("Strike: ");
                for (int i = 0; i < strikeCount; i++)
                {
                    sb.Append("X");
                }
                return sb.ToString();
            }
        }

        public PrizePanel PrizePanel
        {
            get
            {
                return prizePanel;
            }
        }

        public Bag Bag
        {
            get { return bag; }
        }

        public Prize Prize
        {
            get { return prize; }
        }


        public ICommand PickPanelCommand
        {
            get;
            private set;
        }

        public ICommand GrabChipCommand
        {
            get;
            private set;
        }

        public Player Player
        {
            get { return player; }
        }

        public string PrizeText
        {
            get
            {
                return string.Format("Prize: {0}", Prize);
            }
        }

        public GameViewModel(Player player)
        {
            this.player = player;
            prize = new Prize("Car", 12345);
            bag = new Bag(prize.Value);
            prizePanel = new PrizePanel(this, prize.Value);

            GrabChipCommand = new PickChipCommand(this);
            PickPanelCommand = new PanelSelectCommand(this);
        }


        #region INotifyPropertyChanged

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
