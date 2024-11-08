using DesctopForCafe.Views;
using DXFToPGApp.MVVMTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesctopForCafe.ViewModel
{
    public class MenuVM : ViewModelBase
    {
        private int _selectedMenuItem;
        private int _selectedGroup;
        public MenuVM()
        {
        }

        public int SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                OnPropertyChanged("SelectedMenuItem");
            }
        }

        public int SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                OnPropertyChanged("SelectedGroup");
            }
        }

        public ICommand OpenItem
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    OpenNextWin(); 
                }, CanContinue);
            }
        }
        public ICommand OpenProductGroup
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    OpenNextWin2();
                }, CanContinue2);
            }
        }

        private bool CanContinue(object obj)
        {
            return SelectedMenuItem >= 0 || SelectedMenuItem <=1;
        }

        private bool CanContinue2(object obj)
        {
            return SelectedGroup >= 0 || SelectedGroup <= 3;
        }

        private void OpenNextWin()
        {
            if (SelectedMenuItem == 0)
            {
                var orders = new OrdersView();
                var vm = new OrdersVM();
                orders.DataContext = vm;
                orders.ShowDialog();
            }
            if (SelectedMenuItem == 1)
            {
                var customers = new CustomersView();
                var vm = new CustomersVM();
                customers.DataContext = vm;
                customers.ShowDialog();
            }
        }
        private void OpenNextWin2()
        {
            SelectedMenuItem = 2;
            var products = new ProductsView();
            var vm = new ProductsVM(SelectedGroup);
            products.DataContext = vm;
            products.ShowDialog();
        }
    }
}
