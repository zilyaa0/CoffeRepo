using DesctopForCafe.ViewModel;
using DesctopForCafe.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesctopForCafe
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            var win = new MenuView();
            this.MainWindow = win;

            var log = new LoginView();
            var viewModel = new LoginVM();
            log.DataContext = viewModel;
            if (log.ShowDialog() == true)
            {
                var data = new MenuVM();
                win.DataContext = data;
                win.Show();
            }
        }
    }
}
