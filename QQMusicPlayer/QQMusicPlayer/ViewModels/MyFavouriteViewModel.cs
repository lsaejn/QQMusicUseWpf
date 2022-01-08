using QQMusicPlayer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace QQMusicPlayer.ViewModels
{
    class MyFavouriteViewModel
    {
        public ObservableCollection<MusicTest> MusicList { get; set; }
        public MyFavouriteViewModel(ObservableCollection<MusicTest> musicList)
        {
            MusicList = musicList;
        }

    }
}
