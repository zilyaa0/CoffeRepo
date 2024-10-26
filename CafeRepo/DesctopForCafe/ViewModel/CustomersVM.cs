using DesctopForCafe.Services.DbService;
using DXFToPGApp.MVVMTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesctopForCafe.ViewModel
{
    public class CustomersVM : ViewModelBase
    {
        public CustomersVM()
        {
            var dbService = new DbService();
            Customers = dbService.GetCustomers();
        }
        private List<CustomersData> _customers;
        public List<CustomersData> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged("Customers");
            }
        }
    }
}
