using System;
using System.Collections.Generic;
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

namespace PlayerControl
{
    public class SvgButtonBox : Button
    {
        static SvgButtonBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SvgButtonBox), new FrameworkPropertyMetadata(typeof(SvgButtonBox)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        #region Dependency Properties  

        public static DependencyProperty SourceProperty
            = DependencyProperty.Register("Source", typeof(Uri), typeof(SvgButtonBox), null);

        public static readonly DependencyProperty SourceMouseOverProperty
            = DependencyProperty.Register("SourceMouseOver", typeof(Uri), typeof(SvgButtonBox), null);

        public static readonly DependencyProperty SourcePressedProperty
            = DependencyProperty.Register("SourcePressed", typeof(Uri), typeof(SvgButtonBox), null);

        public static readonly DependencyProperty SourceDisabledProperty
    = DependencyProperty.Register("SourceDisabled", typeof(Uri), typeof(SvgButtonBox), null);

        public static readonly DependencyProperty SourceVisibilityProperty
    = DependencyProperty.Register("SourceVisibility", typeof(Visibility), typeof(SvgButtonBox), new PropertyMetadata(Visibility.Visible, null));

        public static readonly DependencyProperty SourceHeightProperty
    = DependencyProperty.Register("SourceHeight", typeof(double), typeof(SvgButtonBox), new PropertyMetadata(24.0, null));

        public static readonly DependencyProperty SourceWidthProperty
            = DependencyProperty.Register("SourceWidth", typeof(double), typeof(SvgButtonBox), new PropertyMetadata(24.0, null));

        #endregion

        #region Property Wrappers  

        public Uri Source
        {
            get { return (Uri)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public Uri SourceMouseOver
        {
            get { return (Uri)GetValue(SourceMouseOverProperty); }
            set { SetValue(SourceMouseOverProperty, value); }
        }

        public Uri SourcePressed
        {
            get { return (Uri)GetValue(SourcePressedProperty); }
            set { SetValue(SourcePressedProperty, value); }
        }

        public Uri SourceDisabled
        {
            get { return (Uri)GetValue(SourceDisabledProperty); }
            set { SetValue(SourceDisabledProperty, value); }
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
