using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlayerControl
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:PlayerControl.Themes"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:PlayerControl.Themes;assembly=PlayerControl.Themes"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:NaviButton/>
    ///
    /// </summary>
    public class NaviButton : RadioButton
    {
        static NaviButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NaviButton), new FrameworkPropertyMetadata(typeof(NaviButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        #region Dependency Properties  

        //图标  
        public static DependencyProperty SourceProperty
            = DependencyProperty.Register("Source", typeof(Uri), typeof(NaviButton), null);

        public static readonly DependencyProperty SourceSelectedProperty
            = DependencyProperty.Register("SourceSelected", typeof(Uri), typeof(NaviButton), null);

        public static readonly DependencyProperty SourcePressedProperty
            = DependencyProperty.Register("SourcePressed", typeof(Uri), typeof(NaviButton), null);

        public static readonly DependencyProperty SourceHeightProperty
            = DependencyProperty.Register("SourceHeight", typeof(double), typeof(NaviButton), new PropertyMetadata(24.0, null));

        public static readonly DependencyProperty SourceWidthProperty
            = DependencyProperty.Register("SourceWidth", typeof(double), typeof(NaviButton), new PropertyMetadata(24.0, null));

        public static readonly DependencyProperty SourceVisibilityProperty
    = DependencyProperty.Register("SourceVisibility", typeof(Visibility), typeof(NaviButton), new PropertyMetadata(Visibility.Visible, null));

        #endregion

        #region Property Wrappers  

        public Uri Source
        {
            get { return (Uri)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public Uri SourceSelected
        {
            get { return (Uri)GetValue(SourceSelectedProperty); }
            set { SetValue(SourceSelectedProperty, value); }
        }

        public Uri SourcePressed
        {
            get { return (Uri)GetValue(SourcePressedProperty); }
            set { SetValue(SourcePressedProperty, value); }
        }

        public double SourceHeight
        {
            get { return (double)GetValue(SourceHeightProperty); }
            set { SetValue(SourceHeightProperty, value); }
        }

        public double SourceWidth
        {
            get { return (double)GetValue(SourceWidthProperty); }
            set { SetValue(SourceWidthProperty, value); }
        }

        public Visibility SourceVisibility
        {
            get { return (Visibility)GetValue(SourceVisibilityProperty); }
            set { SetValue(SourceVisibilityProperty, value); }
        }

        #endregion
    }
}
