using QQMusicPlayer.Services;
using QQMusicPlayer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace QQMusicPlayer.ViewModels
{
    class MyFavouriteViewModel
    {
        public ObservableCollection<MusicViewModel> MusicList { get; set; }
        public MyFavouriteViewModel(ObservableCollection<MusicViewModel> musicList)
        {
            if(musicList is null)
            {
                MusicList = LocalDatabaseService.ReadMyFavorMusicList();
            }
            else
                MusicList = musicList;
        }

    }
}
