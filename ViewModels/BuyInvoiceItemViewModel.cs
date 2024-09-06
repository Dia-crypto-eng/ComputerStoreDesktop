using ComputerStore.Cache;
using ComputerStore.DATA;
using ComputerStore.Models;
using ComputerStore.Views.Invoices;
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
        private BuyInvoiceModel buyInvoiceModel;
        private readonly InvoiceCache _invoiceCache;

        public ObservableCollection<BuyInvoiceItemModel> ListBuyInvoiceItem { get { return listBuyInvoiceItem; } set { listBuyInvoiceItem = value; OnPropertyChanged("ListBuyInvoiceItem"); } }
        public BuyInvoiceModel BuyInvoice { get { return buyInvoiceModel; } set { buyInvoiceModel = value; OnPropertyChanged("BuyInvoice"); } }

        public BuyInvoiceItemViewModel()
        {
            _invoiceCache = CreateCache.Instance.InvoiceCache;
            getBuyInvoice();
        }

        private void getBuyInvoice()
        {
            this.BuyInvoice = _invoiceCache.getInvoice();
            ListBuyInvoiceItem = _invoiceCache.getListInvoiceItem(BuyInvoice).Result;  
            //ListBuyInvoiceItem = buyInvoiceViewModel.factureData.getInvoice(buyInvoiceViewModel.BuyInvoice).Result;
        }


    }
}
