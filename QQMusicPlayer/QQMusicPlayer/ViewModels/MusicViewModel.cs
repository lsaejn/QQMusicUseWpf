using QQMusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMusicPlayer.ViewModels
{
    internal class MusicViewModel
    {
        private Music _music;

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
        public string Album
        {
            get { return _music.album; }
            set { _music.album = value; }
        }
        public Uri pic_uri
        { 
            get { return _music.pic_uri; } 
            set => _music.pic_uri = value;
        }
        public System.Drawing.Bitmap cover { get; set; }
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
