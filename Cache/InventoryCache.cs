using ComputerStore.DATA;
using ComputerStore.Models;
using ComputerStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Cache
{
    class InventoryCache
    {
        string url;
        private InventoryData inventoryData;
        private List<InventoryModel> listInventories;
        private List<InventoryModel> listCategoryInventories;
        public InventoryCache(HttpClient client, string url) 
        {
            this.url = url + "inventory/";
            inventoryData = new InventoryData(client, this.url);
            LoadAllInventory();
        }
        private async void LoadAllInventory()
        {
            listInventories = inventoryData.getAllInventory().Result;
        }
        public async Task<List<InventoryModel>> getAllInventory()
        {
            return listCategoryInventories;
            
        }
        public void selectInventory(List<ProductModel> ListProduct)
        {
            //this.buyInvoiceModel = buyInvoiceModel;
            listCategoryInventories = new List<InventoryModel>();
             foreach (var row in ListProduct)
             foreach (var item in listInventories)
               if (row.IdProduct == item.Product)
                listCategoryInventories.Add(item);
            //ListProduct.ForEach(p => Console.WriteLine(p.IdProduct));
        }
    }
}
