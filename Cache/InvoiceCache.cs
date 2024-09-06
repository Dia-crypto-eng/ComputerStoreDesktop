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
        FactureData factureData;
        private BuyInvoiceItemModel buyInvoiceItemModel;
        private BuyInvoiceModel buyInvoiceModel = new BuyInvoiceModel();
        private BuyInvoiceModel buyInvoiceModeltest = new BuyInvoiceModel();
        private List<BuyInvoiceModel> listbuyInvoices = new List<BuyInvoiceModel>();
        private ObservableCollection<BuyInvoiceItemModel> listBuyInvoiceItem = new ObservableCollection<BuyInvoiceItemModel>();

        public InvoiceCache(HttpClient client , string url) 
        { 
            this.url = url + "invoice/";
            factureData = new FactureData(client, this.url);
        }
        public async Task<List<BuyInvoiceModel>> getAllInvoice()
        {
            listbuyInvoices = factureData.getAllInvoice().Result;
            return listbuyInvoices;
        }
        public async Task<ObservableCollection<BuyInvoiceItemModel>> getListInvoiceItem(BuyInvoiceModel buyInvoice)
        {
            if (buyInvoice.Id == 0)
            { if (this.buyInvoiceItemModel == null)
                       this.listBuyInvoiceItem.Clear();
              else 
               { 
                    this.listBuyInvoiceItem.Add(this.buyInvoiceItemModel);
                    this.buyInvoiceModel.Amount += this.buyInvoiceItemModel.Amount;
               }
            }
            else
                this.listBuyInvoiceItem = factureData.getInvoice(listbuyInvoices.IndexOf(buyInvoice) + 1).Result;
           return this.listBuyInvoiceItem;
        }
        public void addInvoiceItem(BuyInvoiceItemModel buyInvoiceItemModel)
        {
            this.buyInvoiceItemModel = buyInvoiceItemModel;
            getListInvoiceItem(new BuyInvoiceModel());
        }
        public void selectInvoice(BuyInvoiceModel buyInvoiceModel)
        {
            this.buyInvoiceModeltest = buyInvoiceModel;
        }

        public BuyInvoiceModel getInvoice()
        {
            return this.buyInvoiceModeltest;
        }


    }
}
