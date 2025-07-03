using ComputerStore.Cache;
using ComputerStore.DATA;
using ComputerStore.Models;
using ComputerStore.Views.Clients;
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
    internal class BuyInvoiceViewModel :IInvoiceViewModel<BuyInvoiceModel>
    {

        private BuyInvoiceItemModel selectBuyInvoiceItemModel = new BuyInvoiceItemModel();
        
        private readonly InvoiceCache<BuyInvoiceModel, BuyInvoiceItemModel> _invoiceCache;
        public ICommand AddItem { get; }
        public ICommand AddProviderName { get; }
        public ICommand ShowInvoiceDetailsCommand { get; private set; }

        
        public BuyInvoiceItemModel SelectBuyInvoiceItemModel
        {
            get { return selectBuyInvoiceItemModel; }
            set { selectBuyInvoiceItemModel = value; OnPropertyChanged("SelectBuyInvoiceItemModel"); }
        }


        //constructor
        public BuyInvoiceViewModel():base()
        {
            Title = "Buy Invoice";
            _invoiceCache = CreateCache.Instance.InvoiceCache;
            _invoiceCache.InitializeValues(null,new BuyInvoiceModel(),new ObservableCollection<BuyInvoiceItemModel>());
            _invoiceCache.selectProvider(Provider.ListClient.ElementAt(0).FirstName);
            clearSelectBuyInvoiceItemModel();
            AddItem = new RelayCommand(AddBuyInvoiceItem);
            AddProviderName = new RelayCommand(AddInvoiceProvider);
            ShowInvoiceDetailsCommand = new RelayCommand(ShowInvoiceDetails);
            getListBuyInvoice();
        }

        private void AddInvoiceProvider()
        {
            _invoiceCache.selectProvider(Provider.SelectClient.FirstName);
        }

        private void ShowInvoiceDetails()
        {
            if (BuyInvoice != null)
            {
                _invoiceCache.selectInvoice(BuyInvoice);
                Messenger.Default.Send("go to buyInvoice.xaml");
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

   
}
