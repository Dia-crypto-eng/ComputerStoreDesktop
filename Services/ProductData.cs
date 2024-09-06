using ComputerStore.Models;
using Newtonsoft.Json;
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
        public ProductData(HttpClient Client,string url)
        {
         
        
        }

        public ProductData()
        {
            Client = new HttpClient();

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
            List<FamilyModel> listFamily = new List<FamilyModel>();
            try
            {
                var res = await Client.GetAsync("http://127.0.0.1:8000/product/category").ConfigureAwait(false);
                string se = await res.Content.ReadAsStringAsync();
                listFamily = JsonConvert.DeserializeObject<List<FamilyModel>>(se);
            }
            catch (Exception e)
            {
                Console.WriteLine("fffffffffffff");
            }

            return listFamily;
        }



        public async Task<List<ProductModel>> getProductCategory(string s)
        {
            List<ProductModel> product = new List<ProductModel>();
            try
            {
                var resp = await Client.GetAsync("http://127.0.0.1:8000/product/"+s).ConfigureAwait(false);
                string se = await resp.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<List<ProductModel>>(se);
            }
            catch(Exception e) { Console.WriteLine(); }

            return product;
            
            
        }

    }
}
