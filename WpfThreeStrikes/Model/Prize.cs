using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WpfThreeStrikes.Annotations;

namespace WpfThreeStrikes.Model
{
    public class Prize : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private int value;
        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                OnPropertyChanged();
            }
        }

        public Prize(string name, int value)
        {
            Name = name;
            Value = value;
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
