using DesctopForCafe.Services;
using DesctopForCafe.Services.DbService;
using DesctopForCafe.Views;
using DXFToPGApp.MVVMTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesctopForCafe.ViewModel
{
    public class LoginVM : ViewModelBase
    {
        private string _login = "";
        private string _password = "";

        public LoginVM()
        {
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
 
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public ICommand ContinueCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    var win = obj as LoginView;
                    Continue(win);
                }, CanContinue);
            }
        }

        private bool CanContinue(object obj)
        {
            var win = obj as LoginView;
            return win.log.Text != string.Empty && win.pas.Text != string.Empty;
        }

        private void Continue(LoginView win)
        {
            var dbService = new DbService();
            var result = dbService.CanLogin(Login, Password);
            if (result)
                win.DialogResult = true;
            else
                MessageBox.Show("Проверьте правильность логина или пароля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);

        }
    }
}
