using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Xml;
using WpfThreeStrikes.Annotations;
using WpfThreeStrikes.Commands;
using WpfThreeStrikes.Model;
using WpfThreeStrikes.Resources;
using WpfThreeStrikes.View;

namespace WpfThreeStrikes.ViewModel
{
    public class GameViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly Player player;
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
            private set
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
            private set
            {
                prizePanel = value;
                OnPropertyChanged();
            }
        }

        public Bag Bag
        {
            get { return bag; }
            private set
            {
                bag = value;
                OnPropertyChanged();
            }
        }

        public Prize Prize
        {
            get { return prize; }
            set
            {
                prize = value;
                OnPropertyChanged("PrizeText");
            }
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

        public string PlayerNameText
        {
            get
            {
                return string.Format("Welcome {0}", Player.Name);
            }
        }

        public GameViewModel(Player player)
        {
            this.player = player;
            
            StartNewGame();
            GrabChipCommand = new PickChipCommand(this);
            PickPanelCommand = new PanelSelectCommand(this);
        }

        private Prize GetRandomPrize()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Res.Prizes);
            XmlNodeList prizes = doc.SelectNodes("//Prize");
            List<Prize> Prizes = new List<Prize>();

            if(prizes == null)
                throw new ArgumentNullException("No prizes in Prizes.xml");

            foreach (XmlNode prize in prizes)
            {
                string prizeName = prize.FirstChild.InnerText;
                string prizeValue = prize.LastChild.InnerText;
                Prizes.Add(new Prize(prizeName, int.Parse(prizeValue)));
            }
            

            Random rand = new Random();
            Prizes = Prizes.OrderBy(p => rand.Next()).ToList();

            return Prizes.First();
        }

        public void GameOver(bool win)
        {
            EndGameView view = new EndGameView(win, prize, this);
            view.ShowDialog();
        }

        public void ShowStrike()
        {
            AlertView view = new AlertView(2500)
            {
                DataContext = new AlertViewModel(strikeCount)
            };
            view.Show();
        }

        public void SelectPanel(int panelNum)
        {
            bool correct = PrizePanel.CheckSelectedPanel(Player.OnHand, panelNum);
            if (!correct)
            {
                
                Player.PutBack(Bag);
                return;
            }

            PrizePanel.SetCorrectPanel(panelNum);
            Player.OnHand = null;

            if (CheckIfWon())
                GameOver(true);
        }

        private bool CheckIfWon()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(panel0.ShownValue);
            sb.Append(panel1.ShownValue);
            sb.Append(panel2.ShownValue);
            sb.Append(panel3.ShownValue);
            sb.Append(panel4.ShownValue);

            if (sb.ToString() == Prize.Value.ToString())
                return true;

            return false;
        }


        public void PickFromBag()
        {
            Disk pickedDisk = Player.PickOne(Bag);
            if (pickedDisk as Strike != null)
            {
                StrikeCount++;
                if (StrikeCount < 3)
                {
                    ShowStrike();
                    return;
                }

                // show game over view
                GameOver(false);
                return;
            }

            // set on hand to the number disk
            Player.OnHand = (NumberDisk)pickedDisk;
        }

        public void StartNewGame()
        {
            Prize = GetRandomPrize();
            Bag = new Bag(prize.Value);
            PrizePanel = new PrizePanel(this, prize.Value);
            StrikeCount = 0;
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
