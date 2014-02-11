using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using WpfThreeStrikes.Annotations;
using WpfThreeStrikes.ViewModel;

namespace WpfThreeStrikes.Model
{
    public sealed class PrizePanel : IEnumerable<Panel>, INotifyPropertyChanged
    {

        private Panel[] panels;
        private GameViewModel viewModel;


        public PrizePanel(GameViewModel viewModel, int prizeValue)
        {
            panels = new Panel[5];

            for (int i = 0; i < 5; i++)
            {
                Panel pan = new Panel(Convert.ToInt16(prizeValue.ToString().Substring(i, 1)), false);
                panels[i] = pan;
            }
            this.viewModel = viewModel;
            SetViewModelPanels();
        }

        private void SetViewModelPanels()
        {
            viewModel.Panel0 = panels[0];
            viewModel.Panel1 = panels[1];
            viewModel.Panel2 = panels[2];
            viewModel.Panel3 = panels[3];
            viewModel.Panel4 = panels[4];

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
            Panel firstOrDefault = panels[panel];
            if (firstOrDefault != null)
            {
                firstOrDefault.IsCorrect = true;
            }
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

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public sealed class Panel : INotifyPropertyChanged
    {
        public int Value { get; set; }
        private bool isCorrect;
        private bool isEnabled;

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool IsCorrect
        {
            get
            {
                return isCorrect;
            }
            set
            {
                isCorrect = value;
                IsEnabled = false;
                OnPropertyChanged();
                OnPropertyChanged("ShownValue");
                OnPropertyChanged("IsEnabled");
            }
        }

        private const string hiddenVal = "X";

        public Panel(int val, bool isCorrect)
        {
            IsCorrect = isCorrect;
            IsEnabled = true;
            Value = val;
        }

        public string ShownValue
        {
            get
            {
                if (isCorrect)
                    return Value.ToString();
                return hiddenVal;
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));

        }
        
        #endregion
    }
    
}
