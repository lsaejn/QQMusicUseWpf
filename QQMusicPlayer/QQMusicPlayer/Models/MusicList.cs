using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace QQMusicPlayer.Models
{
    class MusicList
    {
        public string name { get; set; }
        public List<Music> musicList { get; set; } = new List<Music>();
    }
}
