using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Meting4Net.Core;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using QQMusicPlayer.Commands;
using QQMusicPlayer.Models;
using QQMusicPlayer.Views;

namespace QQMusicPlayer.ViewModels
{
    public class MusicEventArgs : EventArgs
    {
        public Uri uri { get; set; }
        public bool IsPlaying { get; set; }
    }
    public class SystemButtonEventArgs : EventArgs
    {
        public int type { get; set; }
    }

    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public event EventHandler PlayRequested;
        public event EventHandler SystemButtonRequested;

        public bool _showSearchResult;
        bool _playingMusic;
        public bool PlayingMusic
        {
            get
            {
                return _playingMusic;
            }
            set
            {
                _playingMusic = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("PlayingMusic"));
                }
            }
        }
        public string _searchText = "";
        public bool ShowSearchResult
        {
            get
            {
                return _showSearchResult;
            }
            set
            {
                _showSearchResult = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("ShowSearchResult"));
                }
            }
        }

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("SearchText"));
                }
            }
        }
        public MainWindowViewModel()
        {
            StackWidgets = new ObservableCollection<StackWidget>();

            PlayCommand = new RelayCommand(new Action<object>(PlayCommandExcute), new Func<Boolean>(CanPlayCommandExcute));
            SelectedSearchResultChangedCommand = new RelayCommand(new Action<object>(SelectedSearchResultChangedExcute), new Func<Boolean>(CanNavigateExcute));
            TextChangedCommand = new RelayCommand(new Action<object>(TextChangedExcute), new Func<Boolean>(CanNavigateExcute));
            MaximumCommand = new RelayCommand(new Action<object>(MaximumCommandExcute), new Func<Boolean>(CanMaximumCommandExcute));
            MinimumCommand = new RelayCommand(new Action<object>(MinimumCommandExcute), new Func<Boolean>(CanMinimumCommandExcute));
            CloseCommand = new RelayCommand(new Action<object>(CloseCommandExcute), new Func<Boolean>(CanCloseCommandExcute));

            foreach (var item in GenerateStackWidgets())
            {
                StackWidgets.Add(item);
            }

            SelectedIndex = 0;
            ShowSearchResult = false;
            Navigate = new RelayCommand(new Action<object>(NavigateExcute), new Func<Boolean>(CanNavigateExcute));
        }

        private StackWidget? _selectedItem;
        private int _selectedIndex;

        public Uri MusicPlaying
        {
            get
            {
                var path = AppDomain.CurrentDomain.BaseDirectory;
                return new Uri(path + "邮差.mp3", UriKind.Absolute);
            }
        }

        public ObservableCollection<SearchedSong> MusicList { get; set; } = new ObservableCollection<SearchedSong>();
        public ObservableCollection<SearchedSong> MusicSearched { get; set; } = new ObservableCollection<SearchedSong>();
        public ObservableCollection<SearchedSong> FuzzySearchResult { get; set; } = new ObservableCollection<SearchedSong>();
        public ObservableCollection<StackWidget> StackWidgets { get; }
        public StackWidget? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItem"));
            }
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                //StackWidgets.
                if (value == -1)
                    value = StackWidgets.Count - 1;
                _selectedIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedIndex"));
                SelectedItem = StackWidgets[_selectedIndex];
            }
        }


        private List<StackWidget> GenerateStackWidgets()
        {
            var col = new List<StackWidget>();
            {
                col.Add(new StackWidget("我喜欢", typeof(MyFavourite), new MyFavouriteViewModel(null)));
            }

            {
                ObservableCollection<MusicViewModel> MusicList = new ObservableCollection<MusicViewModel>();
                MusicList.Add(new MusicViewModel { Name = "11执迷不悔", FirstArtist = "王菲2222", Album = "执迷不悔", MusicMark = 1, IsMylove = true });
                MusicList.Add(new MusicViewModel { Name = "11邮差", FirstArtist = "王菲222", Album = "只爱陌生人", MusicMark = 2, IsMylove = true });
                MusicList.Add(new MusicViewModel { Name = "11如风", FirstArtist = "王菲22", Album = "十万个为什么", MusicMark = 3, IsMylove = false });
                MusicList.Add(new MusicViewModel { Name = "11红豆", FirstArtist = "王菲22", Album = "畅游", MusicMark = 3, IsMylove = true });
                
            }

            {
                ObservableCollection<MusicViewModel> MusicList = new ObservableCollection<MusicViewModel>();
                MusicList.Add(new MusicViewModel { Name = "11执迷不悔", FirstArtist = "王菲2222", Album = "执迷不悔", MusicMark = 1, IsMylove = true });
                MusicList.Add(new MusicViewModel { Name = "11邮差", FirstArtist = "王菲222", Album = "只爱陌生人", MusicMark = 2, IsMylove = true });
                MusicList.Add(new MusicViewModel { Name = "11如风", FirstArtist = "王菲22", Album = "十万个为什么", MusicMark = 3, IsMylove = false });
                MusicList.Add(new MusicViewModel { Name = "11红豆", FirstArtist = "王菲22", Album = "畅游", MusicMark = 3, IsMylove = true });
                MusicList.Add(new MusicViewModel { Name = "11执迷不悔", FirstArtist = "王菲2222", Album = "执迷不悔", MusicMark = 1, IsMylove = true });
                MusicList.Add(new MusicViewModel { Name = "11邮差", FirstArtist = "王菲222", Album = "只爱陌生人", MusicMark = 2, IsMylove = true });
                MusicList.Add(new MusicViewModel { Name = "11如风", FirstArtist = "王菲22", Album = "十万个为什么", MusicMark = 3, IsMylove = false });
                MusicList.Add(new MusicViewModel { Name = "11红豆", FirstArtist = "王菲22", Album = "畅游", MusicMark = 3, IsMylove = true });
                MusicList.Add(new MusicViewModel { Name = "11执迷不悔", FirstArtist = "王菲2222", Album = "执迷不悔", MusicMark = 1, IsMylove = true });
                MusicList.Add(new MusicViewModel { Name = "11邮差", FirstArtist = "王菲222", Album = "只爱陌生人", MusicMark = 2, IsMylove = true });
                MusicList.Add(new MusicViewModel { Name = "11如风", FirstArtist = "王菲22", Album = "十万个为什么", MusicMark = 3, IsMylove = false });
                MusicList.Add(new MusicViewModel { Name = "11红豆", FirstArtist = "王菲22", Album = "畅游", MusicMark = 3, IsMylove = true });
                col.Add(new StackWidget("最近播放", typeof(HistoryMusic), new MyFavouriteViewModel(MusicList)));
            }



            col.Add(new StackWidget("推荐", typeof(Recommended)));
            col.Add(new StackWidget("音乐馆", typeof(MusicHall)));
            col.Add(new StackWidget("视频", typeof(Video)));
            col.Add(new StackWidget("电台", typeof(RadioStation)));
            col.Add(new StackWidget("试听列表", typeof(Audition)));
            col.Add(new StackWidget("纯音乐", typeof(UserList)));
            col.Add(new StackWidget("王菲", typeof(UserList)));
            col.Add(new StackWidget("周杰伦", typeof(UserList)));
            col.Add(new StackWidget("搜索结果", typeof(SearchResult), MusicSearched));
            return col;
        }

        public RelayCommand Navigate { get; set; }
        private void NavigateExcute(Object parameter)
        {
            for (int i = 0; i < StackWidgets.Count; ++i)
            {
                if (StackWidgets[i].Name.Equals((string)parameter))
                {
                    if (SelectedIndex == i)
                        return;
                    else
                        SelectedIndex = i;
                }
            }
        }

        private bool CanNavigateExcute()
        {
            return true;
        }

        public RelayCommand SelectedSearchResultChangedCommand { get; set; }
        public RelayCommand PlayCommand { get; set; }
        public RelayCommand TextChangedCommand { get; set; }

        public RelayCommand MaximumCommand { get; set; }
        public RelayCommand MinimumCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        private string CurrentSearchText;
        //fix me,由于输入法的关系，中文输入字母会唤起两次事件
        private async void TextChangedExcute(Object parameter)
        {
            var textNow = (string)parameter;
            if (CurrentSearchText == textNow)
                return;

            CurrentSearchText = textNow;

            if (textNow.Length == 0)
                return;

            var ch = textNow[textNow.Length - 1];
            if (InputLanguageManager.Current.CurrentInputLanguage.Name == "zh-CN")
            {
                if (ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z')
                    return;
            }
            if (textNow.Length > 0)
            {

                List<SearchedSong> ls = await Task.Run(() =>
                {
                    //Thread.Sleep(500);
                    Meting api = new Meting(ServerProvider.Kugou);
                    try
                    {
                        var musicJson = api.FormatMethod().Search(textNow, new Meting4Net.Core.Models.Standard.Options
                        {
                            page = 1,
                            limit = 10
                        });
                        var lst = JsonConvert.DeserializeObject<List<SearchedSong>>(musicJson);
                        var l = lst[0];
                        //var album = api.Album(l.id);
                        var lyric = api.Lyric(l.id);
                        var song = api.Song(l.id);
                        //var artist = api.Artist(l.id);
                        //var playlist = api.Playlist(l.id);
                        var pic = api.Pic(l.id);

                        return lst;
                    }
                    catch
                    {
                        return null;
                    }
                });

                if (textNow == CurrentSearchText)
                {
                    FuzzySearchResult.Clear();
                    foreach (var i in ls)
                        FuzzySearchResult.Add(i);
                }
            }
            else
            {
                //fix me, insert default items
            }
        }

        //
        private async void SelectedSearchResultChangedExcute(Object parameter)
        {
            var si = (SearchedSong)parameter;
            SelectedIndex = -1;
            //fix me
            //searchResultButton.IsChecked = true;
            ShowSearchResult = true;
            if (si == null)
            {
                return;
            }

            var selectedSong = si.name;

            List<SearchedSong> ls = await Task.Run(() =>
            {
                Meting api = new Meting(ServerProvider.Kugou);
                try
                {
                    var musicJson = api.FormatMethod(true).Search(selectedSong, new Meting4Net.Core.Models.Standard.Options
                    {
                        page = 1,
                        limit = 10
                    });
                    return JsonConvert.DeserializeObject<List<SearchedSong>>(musicJson);
                }
                catch
                {
                    return null;
                }
            });
            MusicSearched.Clear();
            foreach (var i in ls)
                MusicSearched.Add(i);
        }

        private void PlayCommandExcute(Object parameter)
        {
            if (this.PlayRequested != null)
            {
                var param = new MusicEventArgs() { uri = MusicPlaying };
                this.PlayRequested(this, param);
                PlayingMusic = param.IsPlaying;
            }
        }

        private bool CanPlayCommandExcute()
        {
            return true;
        }

        private void MaximumCommandExcute(Object parameter)
        {
            if (this.SystemButtonRequested != null)
                SystemButtonRequested(this, new SystemButtonEventArgs() { type = 1 });
        }
        private bool CanMaximumCommandExcute()
        {
            return true;
        }

        private void MinimumCommandExcute(Object parameter)
        {
            if (this.SystemButtonRequested != null)
                SystemButtonRequested(this, new SystemButtonEventArgs() { type = 0 });
        }

        private bool CanMinimumCommandExcute()
        {
            return true;
        }

        private void CloseCommandExcute(Object parameter)
        {
            if (this.SystemButtonRequested != null)
                SystemButtonRequested(this, new SystemButtonEventArgs() { type = 2 });
        }

        private bool CanCloseCommandExcute()
        {
            return true;
        }


    }
}
