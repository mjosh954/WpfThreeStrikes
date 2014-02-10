using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfThreeStrikes.Model
{
    public abstract class Disk
    {
    }

    public class NumberDisk : Disk
    {
        public int Value { get; private set; }

        public NumberDisk(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class Strike : Disk
    {
        public override string ToString()
        {
            return "X";
        }
    }
}
