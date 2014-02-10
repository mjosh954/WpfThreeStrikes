using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfThreeStrikes.Model
{
    public sealed class PrizePanel : IEnumerable<Panel>
    {

        private Panel[] panels;

        public PrizePanel(int prizeValue)
        {
            panels = new Panel[5];

            for (int i = 0; i < 5; i++)
            {
                Panel pan = new Panel(Convert.ToInt16(prizeValue.ToString().Substring(i, 1)), false);
                panels[i] = pan;
            }
        }

        public bool CheckSelectedPanel(NumberDisk onHand, int panelSelection)
        {
            return onHand.Value == panels[panelSelection].Value;
        }


        public bool EnabledPanelSelection(Panel panel)
        {
            bool isEnabled = false;
            return isEnabled;
        }

        public void SetCorrectPanel(int panel)
        {
            Panel firstOrDefault = panels.FirstOrDefault(p => p.Value == Convert.ToInt16(panel));
            if (firstOrDefault != null)
                firstOrDefault.IsCorrect = true;
        }

        #region  IEnumerable<Panel>

        public IEnumerator<Panel> GetEnumerator()
        {
            foreach (Panel p in panels)
            {
                if (p == null)
                    break;
                yield return p;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        #endregion
    }

    public sealed class Panel
    {
        public int Value { get; set; }
        public bool IsCorrect { get; set; }
        public Panel(int val, bool isCorrect)
        {
            IsCorrect = isCorrect;
            Value = val;
        }


    }
    
}
