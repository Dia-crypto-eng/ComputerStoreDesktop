using ComputerStore.DATA;
using ComputerStore.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComputerStore.ViewModels
{
    internal class BuyInvoiceItemViewModel:BaseViewModel
    {
        private ObservableCollection<BuyInvoiceItemModel> listBuyInvoiceItem = new ObservableCollection<BuyInvoiceItemModel>();
        private BuyInvoiceItemModel selectBuyInvoiceItemModel = new BuyInvoiceItemModel();
        private ProductViewModel productViewModel;
        private BuyInvoiceViewModel buyInvoiceViewModel;
        public ICommand AddItem { get; }

        public BuyInvoiceItemViewModel(BuyInvoiceViewModel buyInvoiceViewModel)
        {
            this.buyInvoiceViewModel = buyInvoiceViewModel;
            SelectBuyInvoiceItemModel.Price_buy = 0;
            SelectBuyInvoiceItemModel.Quantity = 0;
            productViewModel = new ProductViewModel();
            
            AddItem = new RelayCommand(AddBuyInvoiceItem);
            getBuyInvoice();
        }

        public BuyInvoiceItemModel SelectBuyInvoiceItemModel
        {
            get { return selectBuyInvoiceItemModel; }
            set { selectBuyInvoiceItemModel = value; OnPropertyChanged("SelectBuyInvoiceItemModel"); }
        }
        public ObservableCollection<BuyInvoiceItemModel> ListBuyInvoiceItem { get { return listBuyInvoiceItem; } set { listBuyInvoiceItem = value; OnPropertyChanged("ListBuyInvoiceItem"); } }
        public ProductViewModel Product
        {
            get { return productViewModel; }
            set { productViewModel = value; OnPropertyChanged("Product"); }
        }
        public BuyInvoiceViewModel BuyInvoiceViewModel
        {
            get { return buyInvoiceViewModel; }
            set { buyInvoiceViewModel = value; OnPropertyChanged("BuyInvoiceViewModel"); }
        }


        private void AddBuyInvoiceItem()
        {
            ListBuyInvoiceItem.Add(new BuyInvoiceItemModel()
            {
                Price_buy = SelectBuyInvoiceItemModel.Price_buy,
                Quantity = SelectBuyInvoiceItemModel.Quantity,
                NameProduct = Product.SelectProduct.Name,
                CategoryProduct = Product.SelectFamily.Name,
                MarkProduct = Product.SelectProduct.Mark,

            });

            BuyInvoiceViewModel.BuyInvoice.Amount += ListBuyInvoiceItem.Last().Amount;
         
        }

        private void getBuyInvoice()
        {
            ListBuyInvoiceItem = buyInvoiceViewModel.factureData.getInvoice(buyInvoiceViewModel.BuyInvoice).Result;
        }


    }
}
