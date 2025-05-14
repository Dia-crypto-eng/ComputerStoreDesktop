using ComputerStore.Cache;
using ComputerStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ComputerStore.ViewModels
{
    class InventoryViewModel : BaseViewModel
    {

        private ProductViewModel productViewModel;
        private InventoryModel selectInventory = new InventoryModel();
        private List<InventoryModel> listInventories = new List<InventoryModel>();
        private readonly InventoryCache _InventoryCache;
        public ICommand chooseCategory { get; }
        public ICommand chooseInventory { get; }
        
        public ProductViewModel Product
        {
            get { return productViewModel; }
            set { productViewModel = value; OnPropertyChanged("Product"); }
        }
        public List<InventoryModel> ListInventories { get { return listInventories; } set { listInventories = value; OnPropertyChanged("ListInventories"); } }
        public InventoryModel SelectInventory { get { return selectInventory; } set { selectInventory = value; OnPropertyChanged("SelectInventory"); } }


        public InventoryViewModel( )
        {
            Product =new ProductViewModel();
            _InventoryCache = CreateCache.Instance.InventoryCache;
            chooseCategory = new RelayCommand(ShowInventory);
            chooseInventory = new RelayCommand(RelateInventory);
        }

        private void RelateInventory()
        {if (SelectInventory != null)
            Product.SelectProduct = Product.ListProduct.Where(p =>p.IdProduct == SelectInventory.Product).FirstOrDefault();
        }

        private void ShowInventory()
        {
            Product.SelectProduct = null;
            Product.chooseFamily.Execute(this);
            Console.WriteLine(Product.ListProduct.Count);
            _InventoryCache.selectInventory(Product.ListProduct);
            getListInventory();
        }

        private void getListInventory()
        {
            ListInventories = _InventoryCache.getAllInventory().Result;
        }
    }
}
