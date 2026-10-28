using ComputerStore.DATA;
using ComputerStore.Models;
using ComputerStore.Views.Clients;
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
    internal class ProductCache
    {
        string url;
        private ProductData productData;
        private ObservableCollection<FamilyModel> listFamily = new ObservableCollection<FamilyModel>();
        //private FamilyModel familyModel = new FamilyModel();
        Dictionary<string, ObservableCollection<ProductModel>> listProducts = new Dictionary<string, ObservableCollection<ProductModel>>();

        public ProductCache(HttpClient client, string url)
        {
            this.url = url + "product/";
            productData = new ProductData(client, this.url);
            LoadAllFamily();
            LoadAllProduct();
        }
        //public void InitializeValues()
        //{
        //    familyModel = new FamilyModel();
        //}
        //public void selectFamily(FamilyModel familyModel)
        //{
        //    this.familyModel = familyModel;
        //}
        private async void LoadAllFamily()
        {
            listFamily = productData.getAllFamily().Result;
        }
        private async void LoadAllProduct()
        {
            foreach (var item in listFamily)
                listProducts[item.Name] = productData.getProductCategory(item.Name).Result;
        }
        public async Task<ObservableCollection<FamilyModel>> getAllFamily()
        {
            return listFamily;
        }

        public async Task<ObservableCollection<ProductModel>> getProductCategory(FamilyModel family)
        {
            return listProducts.TryGetValue(family.Name, out var list) ? list : new ObservableCollection<ProductModel>();
        }
        //public async Task<List<ProductModel>> getProductCategory()
        //{
        //    return listProducts[familyModel.Name];
        //}
        //public ObservableCollection<string> getProperties()
        //{
        //    return this.familyModel.Properties;
        //}
        public async Task<bool> addProduct(ProductPostModel product)
        {
            if (!await productData.addProduct(product)) return false;
            LoadAllFamily();     // أولاً: لأن LoadAllProduct تعتمد على listFamily
            LoadAllProduct();
            return true;

            // products.Add(productModel);
            //productData.addProduct(product);

        }
       
    }
}
