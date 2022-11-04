using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication
{
    public class PlayerValueChangedEventArgs : EventArgs
    {
        //public float CurrentValue { get; set; }
        public float NewValue { get; set; }
    }
}
