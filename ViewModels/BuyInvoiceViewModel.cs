using ComputerStore.DATA;
using ComputerStore.Models;
using GalaSoft.MvvmLight.Command;
//using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace ComputerStore.ViewModels
{
    internal class BuyInvoiceViewModel :BaseViewModel
    {
        
        private List<BuyInvoiceModel> listBuyInvoice = new List<BuyInvoiceModel>();
        private ObservableCollection<BuyInvoiceItemModel> listBuyInvoiceItem = new ObservableCollection<BuyInvoiceItemModel>();
        private BuyInvoiceModel buyInvoice = new BuyInvoiceModel();
        private FactureData factureData;
        private ProductViewModel productViewModel;
        private BuyInvoiceItemModel selectBuyInvoiceItemModel = new BuyInvoiceItemModel();


        public List<BuyInvoiceModel> ListBuyInvoice { get { return listBuyInvoice; } set { listBuyInvoice = value; OnPropertyChanged("ListBuyInvoice"); } }
        public ObservableCollection<BuyInvoiceItemModel> ListBuyInvoiceItem { get { return listBuyInvoiceItem; } set { listBuyInvoiceItem = value; OnPropertyChanged("ListBuyInvoiceItem"); } }
        public BuyInvoiceModel BuyInvoice { get { return buyInvoice; } set { buyInvoice = value; OnPropertyChanged("BuyInvoice"); } }
        public ProductViewModel Product { get { return productViewModel; } 
            set { productViewModel = value; OnPropertyChanged("Product"); } }
        public BuyInvoiceItemModel SelectBuyInvoiceItemModel 
                                 { get { return selectBuyInvoiceItemModel; } 
                                 set {selectBuyInvoiceItemModel=value; OnPropertyChanged("SelectBuyInvoiceItemModel"); } }
        public ICommand AddItem { get; }

        //constructor
        public BuyInvoiceViewModel()
        {
            getListBuyInvoice();
        }
        public BuyInvoiceViewModel(int id)
        {
            getBuyInvoice(id);
        }
        public BuyInvoiceViewModel(ProductViewModel productViewModel)
        {
            this.productViewModel = productViewModel;
            SelectBuyInvoiceItemModel.Price_buy = 0;
            SelectBuyInvoiceItemModel.Quantity = 0;
            AddItem = new RelayCommand(AddBuyInvoiceItem) ;
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

            }) ;
        }

        private void getListBuyInvoice()
        {
            factureData = new FactureData();
            ListBuyInvoice = factureData.getAllInvoice ().Result;
        }
        private void getBuyInvoice(int id)
        {  
                factureData = new FactureData();
                ListBuyInvoiceItem = factureData.getInvoice(id).Result;
                BuyInvoice = factureData.getAllInvoice().Result.ElementAt<BuyInvoiceModel>(id);
        }
        

    }
}
