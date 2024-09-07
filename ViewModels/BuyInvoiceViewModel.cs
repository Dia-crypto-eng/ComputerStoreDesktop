using ComputerStore.Cache;
using ComputerStore.DATA;
using ComputerStore.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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

namespace ComputerStore.ViewModels
{
    internal class BuyInvoiceViewModel :BaseViewModel,IInvoiceViewModel<BuyInvoiceModel>
    {
        private string title = "Buy Invoice";
        private List<BuyInvoiceModel> listInvoice = new List<BuyInvoiceModel>();
        private BuyInvoiceModel buyInvoice = new BuyInvoiceModel();
        private BuyInvoiceItemModel selectBuyInvoiceItemModel = new BuyInvoiceItemModel();

        private ProviderViewModel providerViewModel;
        private ProductViewModel productViewModel;
        private readonly InvoiceCache _invoiceCache;
        public ICommand AddItem { get; }
        public ICommand ShowInvoiceDetailsCommand { get; private set; }

        public List<BuyInvoiceModel> ListInvoice { get { return listInvoice; } set { listInvoice = value; OnPropertyChanged("ListBuyInvoice"); } }
        public BuyInvoiceModel BuyInvoice { get { return buyInvoice; } set { buyInvoice = value; OnPropertyChanged("BuyInvoice"); } }
        public string Title { get { return title; } set { title = value; OnPropertyChanged("Title"); } }
        public BuyInvoiceItemModel SelectBuyInvoiceItemModel
        {
            get { return selectBuyInvoiceItemModel; }
            set { selectBuyInvoiceItemModel = value; OnPropertyChanged("SelectBuyInvoiceItemModel"); }
        }
        public ProductViewModel Product
        {
            get { return productViewModel; }
            set { productViewModel = value; OnPropertyChanged("Product"); }
        }
        public ProviderViewModel Provider
        {
            get { return providerViewModel; }
            set { providerViewModel = value; OnPropertyChanged("Provider"); }
        }

        //constructor
        public BuyInvoiceViewModel()
        {
            _invoiceCache = CreateCache.Instance.InvoiceCache;
            Product = new ProductViewModel();
            Provider = new ProviderViewModel();
            clearSelectBuyInvoiceItemModel();
            AddItem = new RelayCommand(AddBuyInvoiceItem);
            ShowInvoiceDetailsCommand = new RelayCommand(ShowInvoiceDetails);
            getListBuyInvoice();
        }

        private void ShowInvoiceDetails()
        {
            if (BuyInvoice != null)
            {
                _invoiceCache.selectInvoice(BuyInvoice);
                Messenger.Default.Send(new ShowDetailsMessage());
            }
        }

        private void getListBuyInvoice()
        {
            ListInvoice = _invoiceCache.getAllInvoice ().Result;
        }

        private void AddBuyInvoiceItem()
        {
            SelectBuyInvoiceItemModel.NameProduct = Product.SelectProduct.Name;
            SelectBuyInvoiceItemModel.CategoryProduct = Product.SelectFamily.Name;
            SelectBuyInvoiceItemModel.MarkProduct = Product.SelectProduct.Mark;
            _invoiceCache.addInvoiceItem(SelectBuyInvoiceItemModel);
            clearSelectBuyInvoiceItemModel();
            //BuyInvoice.Amount += SelectBuyInvoiceItemModel.Amount;
        }
        private void clearSelectBuyInvoiceItemModel()
        {
            SelectBuyInvoiceItemModel = new BuyInvoiceItemModel();
            SelectBuyInvoiceItemModel.Price_buy = 0;
            SelectBuyInvoiceItemModel.Quantity = 0;
        }

    }

    public class ShowDetailsMessage
    {
    }
}
