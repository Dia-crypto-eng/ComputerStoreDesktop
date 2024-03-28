using ComputerStore.ENTITY;
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
       
        HttpClient Client = new HttpClient();
        public ProductData()
        {
         
        
        }

        private async void getFirebaseProduct()
        {
            /*use firebase
            FirebaseResponse Response = await firebaseClient.GetAsync("PRODUCT").ConfigureAwait(false);
            this.product = Response.ResultAs<List<Product>>();
            Console.WriteLine("number of products in firebase : " + this.product.Count);
            */






        }

        public async void addProduct()
        {
           //var dui = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
          //  await Client.PostAsync("http://127.0.0.1:5000//product/", dui) ;
            //Console.WriteLine(dui.ReadAsStringAsync) ;
           //Console.WriteLine("success");
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



        public async Task<List<ProductModel>> getAllProduct()
        {
            List<ProductModel> product = new List<ProductModel>();
            try
            {
                var resp = await Client.GetAsync("http://127.0.0.1:5000//product").ConfigureAwait(false);
                string se = await resp.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<List<ProductModel>>(se);
            }
            catch(Exception e) { Console.WriteLine(); }

            return product;
            
            
        }

    }
}
