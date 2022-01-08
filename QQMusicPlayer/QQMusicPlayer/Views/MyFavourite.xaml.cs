using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QQMusicPlayer.Views
{

    class MusicTest
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }

        public int MusicMark { get; set; }
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
    }
    /// <summary>
    /// MyFavourite.xaml 的交互逻辑
    /// </summary>
    public partial class MyFavourite : UserControl
    {
        public MyFavourite()
        {
            InitializeComponent();
        }
    }
}
