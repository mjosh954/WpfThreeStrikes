using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfThreeStrikes.Annotations;

namespace WpfThreeStrikes.ViewModel
{
    public class AlertViewModel : INotifyPropertyChanged
    {
        private int strikeCount;

        private int StrikeCount
        {
            get
            {
                return strikeCount;
            }
            set
            {
                strikeCount = value;
                OnPropertyChanged(StrikeText);
            }
        }

        public string StrikeText
        {
            get
            {
                return string.Format("Strike {0}", StrikeCount);
            }
        }

        public AlertViewModel(int strikeCount)
        {
            StrikeCount = strikeCount;
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
