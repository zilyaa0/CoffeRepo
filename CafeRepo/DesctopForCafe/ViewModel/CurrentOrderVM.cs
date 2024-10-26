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
    public class CurrentOrderVM : ViewModelBase
    {
        private readonly DbService dbService;
        private OrdersData _order;
        public CurrentOrderVM(OrdersData order)
        {
            dbService = new DbService();
            CurrentOrder = order;
        }
        public OrdersData CurrentOrder
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged("CurrentOrder");
            }
        }

        public ICommand Complete
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    var win = obj as CurrentOrderView;
                    CompleteOrder(win);
                });
            }
        }
        private void CompleteOrder(CurrentOrderView win)
        {
            dbService.CompleteOrder(CurrentOrder.Id);
            win.DialogResult = true;
            var orders = new OrdersView();
            var vm = new OrdersVM();
            orders.DataContext = vm;
            orders.ShowDialog();
        }
    }
}
