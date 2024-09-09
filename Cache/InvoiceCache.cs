using ComputerStore.DATA;
using ComputerStore.Models;
using ComputerStore.Views.Invoices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Cache
{
    internal class InvoiceCache
    {
        string url;
        private FactureData factureData;
        private BuyInvoiceItemModel buyInvoiceItemModel;
        private BuyInvoiceModel buyInvoiceModel = new BuyInvoiceModel();
        private List<BuyInvoiceModel> listbuyInvoices = new List<BuyInvoiceModel>();
        private ObservableCollection<BuyInvoiceItemModel> listBuyInvoiceItem = new ObservableCollection<BuyInvoiceItemModel>();

        public InvoiceCache(HttpClient client , string url) 
        { 
            this.url = url + "invoice/";
            factureData = new FactureData(client, this.url);
            LoadAllInvoice();
        }
        // Method to reset or initialize values
        public void InitializeValues()
        {
            buyInvoiceItemModel = null;
            buyInvoiceModel = new BuyInvoiceModel();
            listBuyInvoiceItem = new ObservableCollection<BuyInvoiceItemModel>();
        }
        private async void LoadAllInvoice()
        {
            listbuyInvoices = factureData.getAllInvoice().Result;
        }
        public async Task<List<BuyInvoiceModel>> getAllInvoice()
        {
            return listbuyInvoices;
        }
       

        public async Task<ObservableCollection<BuyInvoiceItemModel>> getListInvoiceItem()
        {
            if (this.buyInvoiceModel.Id == 0)
            { if (this.buyInvoiceItemModel == null)
                       this.listBuyInvoiceItem.Clear();
              else 
               { 
                    this.listBuyInvoiceItem.Add(this.buyInvoiceItemModel);
                    this.buyInvoiceModel.Amount += this.buyInvoiceItemModel.Amount;
               }
            }
            else
                this.listBuyInvoiceItem = factureData.getInvoice(listbuyInvoices.IndexOf(this.buyInvoiceModel) + 1).Result;
           return this.listBuyInvoiceItem;
        }
        public void addInvoiceItem(BuyInvoiceItemModel buyInvoiceItemModel)
        {
            this.buyInvoiceItemModel = buyInvoiceItemModel;
            getListInvoiceItem();
        }
        public void selectInvoice(BuyInvoiceModel buyInvoiceModel)
        {
            this.buyInvoiceModel = buyInvoiceModel;
        }
        public void selectProvider(string provider)
        {
            this.buyInvoiceModel.Provider = provider;
        }

        public BuyInvoiceModel getInvoice()
        {
            return this.buyInvoiceModel;
        }


    }
}
