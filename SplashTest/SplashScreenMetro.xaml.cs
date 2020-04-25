using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SplashTest
{
    /// <summary>
    /// Interaktionslogik für SplashScreenMetro.xaml
    /// </summary>
    public partial class SplashScreenMetro : MetroWindow
    {
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }

            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(Label), new UIPropertyMetadata("Working, wait...."));

        public SplashScreenMetro()
        {
            InitializeComponent();
        }

        public SplashScreenMetro(string message)
        {
            InitializeComponent();

            Message = message;

            lblmessage.Content = Message;

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
