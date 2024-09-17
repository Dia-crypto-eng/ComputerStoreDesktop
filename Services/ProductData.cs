using ComputerStore.Models;
using ComputerStore.Views.Clients;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace ComputerStore.DATA
{
    class ProductData
    {

        private HttpClient Client;
        private string url;
        public ProductData(HttpClient Client,string url)
        {
            this.Client = Client;
            this.url = url;
        }

      
        private async void getFirebaseProduct()
        {
          




        }

        public async void addProduct()
        {
         
        }
        public void deleteProduct()
        {

        }

        public async Task<List<FamilyModel>> getAllFamily()
        {
            try
            {
                var res = await Client.GetAsync(url+"category").ConfigureAwait(false);
                string se = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FamilyModel>>(se);
            }
            catch (Exception e)
            {
                Console.WriteLine("fffffffffffff");
                throw;
            }
        }


        public async Task<List<ProductModel>> getProductCategory(string s)
        {
            try
            {
                var resp = await Client.GetAsync(url+s).ConfigureAwait(false);
                string se = await resp.Content.ReadAsStringAsync();

                // نستخدم JsonConvert لتحويل المنتجات
                var productsArray = JArray.Parse(se);
                //Console.WriteLine(productsArray) ;
                //var productModels = new List<ProductModel>();

                //foreach (var jsonObject in productsArray)
                //{
                //    var product = jsonObject.ToObject<ProductModel>();

                //    // تحويل المواصفات يدويًا
                //    var specificationsObject = jsonObject["specifications"] as JObject;
                //    if (specificationsObject != null)
                //    {
                //        product.SetSpecificationsFromJson(specificationsObject);
                //    }

                //    productModels.Add(product);
                //}

                //return productModels;
                //List<ProductModel> products = JsonConvert.DeserializeObject<List<ProductModel>>(se);
                //var productsSpecifications = products.Select(item => item.Specifications);
                //Console.WriteLine(productsSpecifications.ElementAt(1).ToString()) ;
               
                return JsonConvert.DeserializeObject<List<ProductModel>>(se);
            }
            catch(Exception e) {
                throw;
            }
              
        }

    }
}
