using QQMusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace QQMusicPlayer.ViewModels
{
    class MusicContextMenu
    {
        public MusicContextMenu(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public ObservableCollection<MusicContextMenu> Children { get; set; }
    }

    internal class MusicViewModel
    {
        private Music _music = new Music();

        private ObservableCollection<MusicContextMenu> _menuItems =new ObservableCollection<MusicContextMenu>()
        {
            new MusicContextMenu("播放"),
            new MusicContextMenu("我喜欢"),
            new MusicContextMenu("添加到")
            {
                Children =new ObservableCollection<MusicContextMenu>()
                {
                    new MusicContextMenu("111"),
                    new MusicContextMenu("222")
                }
            },
            new MusicContextMenu("删除"),
            new MusicContextMenu("浏览本地文件")
        };
        public ObservableCollection<MusicContextMenu> MenuItems
        {
            get
            {
                return _menuItems;
            }
        }

        public bool IsMylove { get; set; }

        public string MusicMarkString
        {
            get
            {
                if (IsMylove)
                    return "/images/favorPink.svg";
                else
                    return "/images/likeGray.svg";
            }
        }

        public int MusicMark { get; set; }

        public string Id
        {
            get { return _music.id; }
            set { _music.id = value; }
        }
        public string Name
        {
            get { return _music.name; }
            set { _music.name = value; }
        }
        public List<string> Artist
        {
            get { return _music.artist; }
            set
            {
                _music.artist = value;
            }
        }

        public string FirstArtist
        {
            get { return Artist[0]; }
            set { Artist[0] = value; }
        }

        public string Album
        {
            get { return _music.album; }
            set { _music.album = value; }
        }
        public Uri Pic_uri
        {
            get { return _music.pic_uri; }
            set => _music.pic_uri = value;
        }
        public System.Drawing.Bitmap Cover
        {
            get
            {
                //fix me
                WebClient wc = new WebClient();
                //Byte[] pageData = wc.DownloadData(Pic_uri);
                wc.DownloadFileAsync(Pic_uri, @"temp\\Pic_uri");
                System.Drawing.Bitmap pic = new System.Drawing.Bitmap(@"temp\\Pic_uri");
                return pic;
            }
        }
        public string url
        {
            get { return _music.url; }
            set { _music.url = value; }
        }
        public string localPath { get; set; }
        public string lyric
        {
            get { return _music.lyric; }
            set
            {
                _music.lyric = value;
            }
        }
        public string source
        {
            get { return _music.source; }
            set { _music.source = value; }
        }
    }
}
