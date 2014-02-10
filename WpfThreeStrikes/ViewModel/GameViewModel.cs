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
    public class GameViewModel
    {
        private Player player;
        private Prize prize;
        private PrizePanel prizePanel;

        public PrizePanel PrizePanel
        {
            get
            {
                return prizePanel;
            }
        }

        public string StrikeCountText
        {
            get
            {
                if (player.StrikeCount == 0)
                    return null;

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < player.StrikeCount; i++)
                {
                    sb.Append("X");
                }
                return sb.ToString();
            }
        }



        public string OnHandText
        {
            get
            {
                if(player.OnHand == null)
                    return null;
                
                return player.OnHand.ToString();
            }
        }

        private Bag bag;
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

        public GameViewModel()
        {
            player = new Player("Josh");
            prize = new Prize("Car", 12345);
            bag = new Bag(prize.Value);
            prizePanel = new PrizePanel(prize.Value);

            GrabChipCommand = new PickChipCommand(this);
            PickPanelCommand = new PanelSelectCommand(this);
        }

        


       

       
    }
}
