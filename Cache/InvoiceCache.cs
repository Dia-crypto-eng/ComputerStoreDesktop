using ComputerStore.DATA;
using ComputerStore.Models;
using ComputerStore.Services;
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
    internal class InvoiceCache<T,T2>
        where T : InvoiceModel
        where T2 : BuyInvoiceItemModel
    {
        private IInvoiceData<T, T2> factureData;
        private T2 InvoiceItemModel;
        private T InvoiceModel;
        private List<T> listInvoices = new List<T>();
        private ObservableCollection<T2> listInvoiceItem = new ObservableCollection<T2>();

        public InvoiceCache(IInvoiceData<T, T2> factureData) 
        { 
            this.factureData = factureData;
            LoadAllInvoice();
        }
        // Method to reset or initialize values
        public void InitializeValues(T2 t2, T t, ObservableCollection<T2> listT2)
        {
            InvoiceItemModel = t2;
            InvoiceModel = t;
            listInvoiceItem = listT2;
        }
        private async void LoadAllInvoice()
        {
            listInvoices = factureData.getAllInvoice().Result;
        }
       
        public async Task<List<T>> getAllInvoice()
        {
            return listInvoices;
        }

        public async Task<ObservableCollection<T2>> getListInvoiceItem()
        {
            if (this.InvoiceModel.Id != 0)
            {
                this.listInvoiceItem = factureData.getInvoice(listInvoices.IndexOf(this.InvoiceModel) + 1).Result;
            }
            return this.listInvoiceItem;
        }

        public void addInvoiceItem(T2 buyInvoiceItemModel)
        {
            this.listInvoiceItem.Add(buyInvoiceItemModel);
            this.InvoiceModel.AddAmountOf(buyInvoiceItemModel);
            getListInvoiceItem();
        }
     
        public void selectInvoice(T buyInvoiceModel)
        {
            this.InvoiceModel = buyInvoiceModel;
        }
      
        public void selectProvider(string provider)
        {
            this.InvoiceModel.Provider = provider;
        }

        public T getInvoice()
        {
            return this.InvoiceModel;
        }


    }
}
