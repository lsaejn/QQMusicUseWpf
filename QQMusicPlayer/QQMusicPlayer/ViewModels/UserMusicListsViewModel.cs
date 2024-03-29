﻿using QQMusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMusicPlayer.ViewModels
{
    internal class UserMusicInfoViewModel
    {
        public string UserName { get; set; }
        public ObservableCollection<MusicListViewModel> MusicLists { get; set; }
    }
}
