using System;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Diagnostics;
using System.Windows.Media;

namespace DanielMcHugh
{
    public class BoardWindow : MetroWindow
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof (Uri), typeof (BoardWindow), new PropertyMetadata(default(Uri)));

        public BoardWindow()
        {
            
            this.RightWindowCommands = Application.Current.FindResource("SampleWindowCommands") as WindowCommands;
            this.BorderThickness = new Thickness(0);
            this.GlowBrush = Brushes.Black;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public Uri Source
        {
            get { return (Uri) GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public ICommand OpenSourceUrlCommand { get; private set; }
    }
}