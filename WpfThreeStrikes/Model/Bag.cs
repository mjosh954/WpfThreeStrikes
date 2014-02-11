using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfThreeStrikes.Annotations;

namespace WpfThreeStrikes.Model
{
    public sealed class Bag : ICollection<Disk>, INotifyPropertyChanged
    {
        private List<Disk> disks;

        private List<Disk> Disks
        {
            get
            {
                return disks;
            }
            set
            {
                disks = value;
                OnPropertyChanged();
            }
        }

        public Bag(int prize)
        {
            Disks = new List<Disk>();

            string prizeValue = prize.ToString();
            foreach (char c in prizeValue)
            {
                Disk disk = new NumberDisk(Convert.ToInt32(c.ToString()));
                Disks.Add(disk);
            }
            for (int i = 0; i <= 2; i++)
                Disks.Add(new Strike());
        }


        public IEnumerator<Disk> GetEnumerator()
        {
            foreach (var d in Disks)
            {
                if (d == null)
                    break;
                yield return d;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PutBack(Disk disk)
        {
            Add(disk);
        }

        public void Add(Disk item)
        {
            Disks.Add(item);
        }

        public void Clear()
        {
            Disks.Clear();
        }

        public bool Contains(Disk item)
        {
            return Disks.Contains(item);
        }

        public void CopyTo(Disk[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Disk item)
        {
            return Disks.Remove(item);
        }

        public Disk GetOneDisk()
        {
            Shuffle();
            return Disks.First();
        }

        public int Count
        {
            get
            {
                return Disks.Count;
            }
        }

        public bool IsReadOnly { get; private set; }

        private void Shuffle()
        {
            int n = Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                Disk value = Disks[k];
                Disks[k] = Disks[n];
                Disks[n] = value;
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
