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
    public class SelectedProductVM : ViewModelBase
    {
        private readonly DbService dbService;
        private ProductsData _product;
        public SelectedProductVM(ProductsData product)
        {
            dbService = new DbService();
            SelectedProduct = product;
        }
        public ProductsData SelectedProduct
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged("SelectedProduct");
            }
        }
        public ICommand Redact
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    var win = obj as SelectedProductView;
                    RedactProduct(win);
                }, CanRedact);
            }
        }
        private bool CanRedact(object obj)
        {
            var win = obj as SelectedProductView;
            return win.NameTextBlock.IsReadOnly == true && win.PriceTextBlock.IsReadOnly == true;
        }
        private void RedactProduct(SelectedProductView win)
        {
            win.NameTextBlock.IsReadOnly = false;
            win.PriceTextBlock.IsReadOnly = false;
        }
        public ICommand SaveChanges
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    var win = obj as SelectedProductView;
                    SaveProduct(win);
                }, CanSave);
            }
        }
        private bool CanSave(object obj)
        {
            var win = obj as SelectedProductView;
            return win.NameTextBlock.IsReadOnly == false && win.PriceTextBlock.IsReadOnly == false;
        }
        private void SaveProduct(SelectedProductView win)
        {
            win.NameTextBlock.IsReadOnly = true;
            win.PriceTextBlock.IsReadOnly = true;
            dbService.SaveProduct(SelectedProduct);
        }
    }
}
