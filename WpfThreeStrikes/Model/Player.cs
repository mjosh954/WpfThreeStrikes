using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfThreeStrikes.Annotations;

namespace WpfThreeStrikes.Model
{
    

    public class Player : INotifyPropertyChanged, IDataErrorInfo
    {
        private string name;
        private NumberDisk onHand;

        public Player(string name)
        {
            Name = name;
        }

        public Player()
        {
            
        }

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

      

        public NumberDisk OnHand
        {
            get
            {
                return onHand;
            }
            set
            {
                onHand = value;
                OnPropertyChanged();
            }
        }

        public Disk PickOne(Bag bag)
        {
            Disk d = bag.GetOneDisk();
            bag.Remove(d);

            return d;
        }

        public void PutBack(Bag bag)
        {
            bag.PutBack(OnHand);
            OnHand = null;
        }

        public override string ToString()
        {
            return Name;
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

        #region IDataErrorInfo

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    Error = string.IsNullOrWhiteSpace(Name) ? "Must provide a name" : null;
                }
                return Error;

            }
        }

        public string Error { get; private set; }

        #endregion
    }
}
