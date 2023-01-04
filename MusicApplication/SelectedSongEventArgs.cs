using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication
{
    public class SelectedSongEventArgs : EventArgs
    {
        public int SongIndex { get; set; }
    }
}
