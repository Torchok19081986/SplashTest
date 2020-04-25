using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;

namespace SplashTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MetroWindow splash = new SplashScreenMetro("Data Loading in Progress.....");

            splash.Show();

            MainWindow main = new MainWindow();

            main.InitializeComponent();

            Current.MainWindow = main;

            await Task.Delay(2500);

            splash.Close();

            await Task.Delay(1000);

            main.Show();
        }
    }
}
