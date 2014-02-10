using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfThreeStrikes.Annotations;

namespace WpfThreeStrikes.Model
{
    

    public class Player : INotifyPropertyChanged
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

        private int strikeCount;
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
            }
        }

        private NumberDisk onHand;
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

        public Player(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public Disk PickOne(Bag bag)
        {
            Disk d = bag.GetOneDisk();
            bag.Remove(d);

            return d;
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
