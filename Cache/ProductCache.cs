using ComputerStore.DATA;
using ComputerStore.Models;
using ComputerStore.Views.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Cache
{
    internal class ProductCache
    {
        string url;
        private ProductData productData;
        private List<FamilyModel> listFamily = new List<FamilyModel>();
        //private List<ProductModel> products = new List<ProductModel>();
        Dictionary<string, List<ProductModel>> listProducts = new Dictionary<string, List<ProductModel>>();

        public ProductCache(HttpClient client, string url)
        {
            this.url = url + "product/";
            productData = new ProductData(client, this.url);
            LoadAllFamily();
            LoadAllProduct();
        }
        private async void LoadAllFamily()
        {
            listFamily = productData.getAllFamily().Result;
        }
        private async void LoadAllProduct()
        {
            listFamily.ForEach(item => listProducts[item.Name] = productData.getProductCategory(item.Name).Result);                      
        }
        public async Task<List<FamilyModel>> getAllFamily()
        {
            return listFamily;
        }
        public async Task<List<ProductModel>> getProductCategory(string s)
        {
            return listProducts[s];
        }
    }
}
