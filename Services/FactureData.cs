
using ComputerStore.ENTITY;
using ComputerStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.DATA
{
    class FactureData
    {

        HttpClient Clien= new HttpClient();

        public void addInvoice()
        {

        }
        public void deleteInvoice()
        {

        }
      


        public async Task<List<BuyInvoiceModel>> getAllInvoice()
        {
            List<BuyInvoiceModel> listbuyInvoices = new List<BuyInvoiceModel>();
            try
            {
                var res = await Clien.GetAsync("http://127.0.0.1:8000/invoice/").ConfigureAwait(false);       
                string se = await res.Content.ReadAsStringAsync();
               listbuyInvoices = JsonConvert.DeserializeObject<List<BuyInvoiceModel>>(se) ;
            }
            catch (Exception e)
            {
                Console.WriteLine("qqqqqqqqqqqqqq");
            }

            return listbuyInvoices;
        }


        public async Task<List<BuyInvoiceItemModel>> getInvoice(int id)
        {
            List<BuyInvoiceItemModel> listbuyInvoicesItem = new List<BuyInvoiceItemModel>();
          
            try
            {
                var res = await Clien.GetAsync("http://127.0.0.1:8000/invoice/"+(id+1)).ConfigureAwait(false);
                string se = await res.Content.ReadAsStringAsync();
                listbuyInvoicesItem = JsonConvert.DeserializeObject<List<BuyInvoiceItemModel>>(se);
            }
            catch (Exception e)
            {
                Console.WriteLine("qqqqqqqqqqqqqq");
            }

            return listbuyInvoicesItem;

            //listbuyInvoicesItem =new List<BuyInvoiceItemModel>()
            //{ new BuyInvoiceItemModel
            //{
            //    Id = 111,
            //    IdFactureElement = 122,
            //    CategoryProduct = "SSS",
            //    MarkProduct = "RRRRR",
            //    NameProduct = "TTTTtttttttttttttttttt",
            //    Price_buy = 333,
            //    Quantity = 4,
            //    Amount = 5555 },
            //new BuyInvoiceItemModel
            //{
            //    Id = 111,
            //    IdFactureElement = 122,
            //    CategoryProduct = "SSS",
            //    MarkProduct = "RRRRR",
            //    NameProduct = "TTTT",
            //    Price_buy = 333,
            //    Quantity = 4,
            //    Amount = 5555
            //}};

         
            //return listbuyInvoicesItem;
        }






    }

    
}
