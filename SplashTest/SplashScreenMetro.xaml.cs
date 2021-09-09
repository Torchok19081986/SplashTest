using MahApps.Metro.Controls;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SplashTest
{
    /// <summary>
    /// Interaktionslogik für SplashScreenMetro.xaml
    /// </summary>
    public partial class SplashScreenMetro : MetroWindow
    {
        #region Properties

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }

            set { SetValue(MessageProperty, value); }
        }

        public Brush IndicatorBrush
        {
            get { return (Brush)GetValue(IndicatorProperty); }

            set { SetValue(IndicatorProperty, value); }
        }

        public Brush BackgroundBrush
        {
            get { return (Brush)GetValue(BackgroundBrushpProperty); }

            set { SetValue(BackgroundBrushpProperty, value); }

        }

        #endregion

        #region Properties Toregister

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(Label), new UIPropertyMetadata("Working, wait...."));

        public static readonly DependencyProperty IndicatorProperty = DependencyProperty.Register("IndicatorBrush", typeof(Brush), typeof(Brush), new UIPropertyMetadata(Brushes.Orange));

        public static readonly DependencyProperty BackgroundBrushpProperty = DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(Brush), new UIPropertyMetadata(Brushes.AliceBlue));

        #endregion

        public SplashScreenMetro()
        {
            InitializeComponent();
        }

        public SplashScreenMetro(string message, Brush progressbarbrush = null, Brush backgroundbrush = null)
        {
            InitializeComponent();

            Message = message;

            lblmessage.Content = Message;

            if(progressbarbrush != null)
            {
                IndicatorBrush = progressbarbrush;
                progressloadingindecator.Foreground = IndicatorBrush;

            }
            else
            {
                progressloadingindecator.Foreground = Brushes.Orange;
            }

            if(backgroundbrush != null)
            {
                BackgroundBrush = backgroundbrush;

                mainwindow.Background = BackgroundBrush;
            }
            else
            {
                mainwindow.Background = Brushes.AliceBlue;
            }
        }

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblmessage.Content = Message + "  " +  e.ProgressPercentage + " % loadded ";
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                
                Thread.Sleep(25);
            }
        }
    }
}
