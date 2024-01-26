using ComputerStore.DATA;
using ComputerStore.Models;
//using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ViewModels
{
    internal class BuyInvoiceViewModel :BaseViewModel
    {
        private List<BuyInvoiceModel> listBuyInvoice = new List<BuyInvoiceModel>();
        FactureData factureData;
        public BuyInvoiceViewModel()
        {
            factureData = new FactureData();
            getListBuyInvoice();
        }
        public BuyInvoiceViewModel(int id)
        {
            factureData = new FactureData();
            getBuyInvoice(id);
        }

        public List<BuyInvoiceModel> ListBuyInvoice { get { return listBuyInvoice; } set { listBuyInvoice = value; OnPropertyChanged("Tab"); } }

        private void getListBuyInvoice()
        {
            ListBuyInvoice = factureData.getAllInvoice ().Result;
        }
        private void getBuyInvoice(int id)
        {
          //  ListBuyInvoice = factureData.getInvoice(id).Result;
        }

    }
}
