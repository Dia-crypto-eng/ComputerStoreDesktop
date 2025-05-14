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
        private BuyInvoiceItemModel selectBuyInvoiceItem ;
        private bool isModifiableItem = false;
        private bool isModifiable = false;
        public ICommand visibilityModify { get; }
        public bool IsModifiableItem { get { return isModifiableItem; } set { isModifiableItem = value; OnPropertyChanged("IsModifiableItem"); } }
        public bool IsModifiable { get { return isModifiable; } set { isModifiable = value; OnPropertyChanged("IsModifiable"); } }
        public ObservableCollection<BuyInvoiceItemModel> ListBuyInvoiceItem { get { return listBuyInvoiceItem; } set { listBuyInvoiceItem = value; OnPropertyChanged("ListBuyInvoiceItem"); } }
        public BuyInvoiceItemModel SelectBuyInvoiceItem { get { return selectBuyInvoiceItem; } set { selectBuyInvoiceItem = value; OnPropertyChanged("SelectBuyInvoiceItem"); } }
        public BuyInvoiceModel BuyInvoice { get { return buyInvoiceModel; } set { buyInvoiceModel = value; OnPropertyChanged("BuyInvoice"); } }

        public BuyInvoiceItemViewModel()
        {
            _invoiceCache = CreateCache.Instance.InvoiceCache;
            visibilityModify = new RelayCommand(ActivateVisibility);
            getBuyInvoice();
        }

        private void ActivateVisibility()
        {
            IsModifiable = true;
        }

        private void getBuyInvoice()
        {
            this.BuyInvoice = _invoiceCache.getInvoice();
            ListBuyInvoiceItem = _invoiceCache.getListInvoiceItem().Result;  
            //ListBuyInvoiceItem = buyInvoiceViewModel.factureData.getInvoice(buyInvoiceViewModel.BuyInvoice).Result;
        }
     

    }
}
