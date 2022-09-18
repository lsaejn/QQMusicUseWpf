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
    //显然，歌曲只有两类，本地导入，网络下载
    //加入歌单的时候，我们记录歌单类型
    //如果是网络下载，看起来至少要记录source(音乐网站类型kugou)和id，是否喜欢
    //从api结果看，id/picid/lyricid是相同的
    //然后加入歌单
    /*
     *那么，数据库应该有下列表
     *音乐信息MusicInfo source id islocal localpath url(backup) name(backup) album(backup) artist(backup),backup都是缓存，后台更新
     *歌单类型MusicListInfo name type(除了本地，都是2) annotation  某个歌单的信息，所有用户
     *歌单内容MusicList music_id(不使用外键) 某个歌单的音乐id列表 
     *用户信息 userid username pass 
     *用户歌单 userid MusicList-id
     *
     *过程: 登录 查用户信息 ->获取用户歌单(初始化各个歌单)->歌单内容/歌单类型->音乐信息 
     */
    class Music
    {
        public SearchedSong searchedSongInfo { get; set; } = new SearchedSong();
        public string id { get; set; }
        public string name { get; set; }
        public List<string> artist { get; set; } = new List<string>() { "test" };
        public string album { get; set; }
        public Uri pic_uri { get; set; } = new Uri("http://www.baidu.com");
        public string url { get; set; }
        public string localPath { get; set; }
        public string lyric { get; set; }
        public string source { get; set; }
    }
}
