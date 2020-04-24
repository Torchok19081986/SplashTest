using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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

            this.Message = message;

            lblmessage.Content = this.Message;
        }
    }
}
