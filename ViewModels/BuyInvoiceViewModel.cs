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

namespace ComputerStore.ViewModels
{
    internal class BuyInvoiceViewModel :BaseViewModel,IInvoiceViewModel<BuyInvoiceModel>
    {
        private string title = "Buy Invoice";
        private List<BuyInvoiceModel> listInvoice = new List<BuyInvoiceModel>();
        private BuyInvoiceModel buyInvoice = new BuyInvoiceModel();
        private ProviderViewModel providerViewModel = new ProviderViewModel();
        public FactureData factureData;
       
        public List<BuyInvoiceModel> ListInvoice { get { return listInvoice; } set { listInvoice = value; OnPropertyChanged("ListBuyInvoice"); } }
        public BuyInvoiceModel BuyInvoice { get { return buyInvoice; } set { buyInvoice = value; OnPropertyChanged("BuyInvoice"); } }
        public string Title { get { return title; } set { title = value; OnPropertyChanged("Title"); } }
        public ProviderViewModel ProviderViewModel
        {
            get { return providerViewModel; }
            set { providerViewModel = value; OnPropertyChanged("ProviderViewModel"); }
        }
        //constructor
        public BuyInvoiceViewModel()
        {
            getListBuyInvoice();
        }
        
        private void getListBuyInvoice()
        {
            factureData = new FactureData();
            ListInvoice = factureData.getAllInvoice ().Result;
        }

    }
}
