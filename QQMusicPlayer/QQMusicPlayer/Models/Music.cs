using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQMusicPlayer.Models
{
    public class SearchedSong
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> artist { get; set; }
        public string album { get; set; }
        public string pic_id { get; set; }
        public string url_id { get; set; }
        public string lyric_id { get; set; }
        public string source { get; set; }
    }

    //meting不提供时长
    class Music
    {
        public SearchedSong searchedSongInfo { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public List<string> artist { get; set; }
        public string album { get; set; }
        public Uri pic_uri { get; set; }
        public string url { get; set; }
        public string localPath { get; set; }
        public string lyric { get; set; }
        public string source { get; set; }
    }
}
