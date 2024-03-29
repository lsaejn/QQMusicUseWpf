﻿using QQMusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMusicPlayer.ViewModels
{
    internal class MusicListViewModel: ObservableCollection<MusicViewModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
