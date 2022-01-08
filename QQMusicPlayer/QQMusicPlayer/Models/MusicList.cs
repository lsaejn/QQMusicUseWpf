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
        public ObservableCollection<Music> musicList = new ObservableCollection<Music>();
    }
}
