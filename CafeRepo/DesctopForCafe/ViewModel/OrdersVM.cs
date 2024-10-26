using DesctopForCafe.Services.DbService;
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
    public class OrdersVM : ViewModelBase
    {
        public OrdersVM() 
        {
            var dbService = new DbService();
            Orders = dbService.GetOrders();
        }
        private List<OrdersData> _orders;
        public List<OrdersData> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }
        private OrdersData _currentOrder;
        public OrdersData CurrentOrder
        {
            get { return _currentOrder; }
            set
            {
                _currentOrder = value;
                OnPropertyChanged("CurrentOrder");
            }
        }

        public ICommand OpenItem

        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    var win = obj as OrdersView;
                    Continue(win);
                });
            }
        }

        private bool CanContinue()
        {
            return CurrentOrder != null;
        }

        private void Continue(OrdersView win)
        {
            if (!CanContinue())
                return;
            var orders = new CurrentOrderView();
            var vm = new CurrentOrderVM(CurrentOrder);
            orders.DataContext = vm;
            orders.ShowDialog();
            win.Close();
        }
    }
}
