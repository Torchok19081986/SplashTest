using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            
            var controller = await splash.ShowProgressAsync("Tets","Test", false, new MetroDialogSettings() { MaximumBodyHeight = 70, DialogMessageFontSize = 18  }) as ProgressDialogController;

            controller.SetIndeterminate();

            MainWindow main = new MainWindow();

            main.InitializeComponent();

            Current.MainWindow = main;

            await Task.Delay(2500);

            await controller.CloseAsync();

            splash.Close();

            await Task.Delay(1000);

            main.Show();
        }
    }
}
