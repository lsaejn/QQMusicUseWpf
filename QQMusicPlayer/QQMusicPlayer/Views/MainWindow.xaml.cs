using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Gu.Wpf.Media;
using System.Windows.Threading;
using QQMusicPlayer.ViewModels;
using MediaState = Gu.Wpf.Media.MediaState;

namespace QQMusicPlayer.Views
{
    //.net core打包单文件时，程序路径居然在临时盘...马一下
    //https://docs.microsoft.com/en-us/dotnet/desktop/wpf/app-development/pack-uris-in-wpf?redirectedfrom=MSDN&view=netframeworkdesktop-4.8#Resource_File_Pack_URIs___Local_Assembly
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //SpeechRecognizer speechRecognizer = new SpeechRecognizer();
            var mvm = new MainWindowViewModel();
            mvm.PlayRequested += (sender, e) => {

                var arg = (MusicEventArgs)e;
                arg.IsPlaying = true;
                if (this.MediaElement.State == MediaState.Play)
                {
                    this.MediaElement.IsPlaying = false;
                    arg.IsPlaying = false;
                }

                else if (this.MediaElement.State == MediaState.Pause)
                    this.MediaElement.IsPlaying = true;
                else
                {
                    this.MediaElement.Source = new Uri("a-bug.mp3", UriKind.Relative);
                    this.MediaElement.SetCurrentValue(MediaElementWrapper.SourceProperty, arg.uri);
                    this.MediaElement.Play();
                }

            };

            mvm.SystemButtonRequested += (sender, e) => {
                var arg = (SystemButtonEventArgs)e;
                int i = arg.type;
                if (0 == i)
                    this.WindowState = WindowState.Minimized;
                if (1 == i)
                {
                    this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                    restoreButton.Visibility = this.WindowState == WindowState.Maximized ? Visibility.Visible : Visibility.Collapsed;
                    maxButton.Visibility = this.WindowState != WindowState.Maximized ? Visibility.Visible : Visibility.Collapsed;
                }

                if (2 == i)
                    this.Close();
            };

            DataContext = mvm;
            //var db = new UserDatabaseService();
            //db.createNewDatabase();
            //db.connectToDatabase();
            //db.createTable();
            //db.fillTable();
            //db.printHighscores();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            leftButton.Focus();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //fix me, 拿屏幕坐标，转到主窗口坐标，判断高度
                //if (e.Source.GetType() != FrameChrome.GetType())
                //    return;

                if (protect)
                    return;
                if (this.WindowState == WindowState.Maximized)
                {
                    Point pt = Mouse.GetPosition(e.Source as FrameworkElement);
                    if (pt.Y > 75)
                        return;

                    this.WindowState = WindowState.Normal;
                    restoreButton.Visibility = Visibility.Collapsed;
                    maxButton.Visibility = Visibility.Visible;
                    var w = this.Width;
                    pt = Mouse.GetPosition(Application.Current.MainWindow);
                    if (w > pt.X)
                        this.Left = 0;
                    else if (pt.X > SystemParameters.PrimaryScreenWidth - w)
                        this.Left = SystemParameters.PrimaryScreenWidth - w;
                    else
                        this.Left = pt.X - w / 2;
                    this.Top = 0;
                }
                Point pp = Mouse.GetPosition(e.Source as FrameworkElement);
                if (pp.Y < 75)
                    DragMove();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            protect = false;
            timer.Stop();
        }
        public bool protect { get; set; }
        public DispatcherTimer timer;
        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Point pp = Mouse.GetPosition(e.Source as FrameworkElement);
            if (pp.Y > 40)
                return;
            //this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            {
                this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                restoreButton.Visibility = this.WindowState == WindowState.Maximized ? Visibility.Visible : Visibility.Collapsed;
                maxButton.Visibility = this.WindowState != WindowState.Maximized ? Visibility.Visible : Visibility.Collapsed;
            }

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer1_Tick;
            //timer.Repeat = false; //we are not writing qml~~
            protect = true;
            timer.Start();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            leftButton.Focus();//理应交给播放键
            Keyboard.ClearFocus();
        }
    }
}

