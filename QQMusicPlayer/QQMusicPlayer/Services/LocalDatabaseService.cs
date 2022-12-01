using QQMusicPlayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMusicPlayer.Services
{
    internal class LocalDatabaseService
    {
        public static ObservableCollection<MusicViewModel> ReadMyFavorMusicList()
        {
            ObservableCollection<MusicViewModel> MusicList = new ObservableCollection<MusicViewModel>();
            MusicList.Add(new MusicViewModel { Name = "执迷不悔", FirstArtist = "王菲", Album = "执迷不悔", MusicMark = 1, IsMylove = true });
            MusicList.Add(new MusicViewModel { Name = "邮差", FirstArtist = "王菲", Album = "只爱陌生人", MusicMark = 2, IsMylove = true });
            MusicList.Add(new MusicViewModel { Name = "如风", FirstArtist = "王菲", Album = "十万个为什么", MusicMark = 3, IsMylove = false });
            MusicList.Add(new MusicViewModel { Name = "红豆", FirstArtist = "王菲", Album = "畅游", MusicMark = 3, IsMylove = true });
            return MusicList;
        }

        //public static List<>
    }
}
