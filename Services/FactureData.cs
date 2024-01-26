
using ComputerStore.ENTITY;
using ComputerStore.Models;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
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
        /* public async Task<List<BuyInvoiceItemModel>> getInvoice(int id)
         {    
         List<BuyInvoiceItemModel> listbuyItemInvoices = new List<BuyInvoiceItemModel>();

         try
             {
                 var res = await Clien.GetAsync("http://127.0.0.1:5000//facture/"+id).ConfigureAwait(false);       
                 string se = await res.Content.ReadAsStringAsync();
                 listbuyItemInvoices = JsonConvert.DeserializeObject<List<BuyInvoiceItemModel>>(se) ;
             }
             catch (Exception e)
             {
                 Console.WriteLine("qqqqqqqqqqqqqq");
             }


             return listbuyItemInvoices;

         }*/




        public async Task<List<BuyInvoiceModel>> getAllInvoice()
        {
            List<BuyInvoiceModel> listbuyInvoices = new List<BuyInvoiceModel>();
            try
            {
                var res = await Clien.GetAsync("http://127.0.0.1:5000//facture").ConfigureAwait(false);       
                string se = await res.Content.ReadAsStringAsync();
              //  listbuyInvoices = JsonConvert.DeserializeObject<List<BuyInvoiceModel>>(se) ;
            }
            catch (Exception e)
            {
                Console.WriteLine("qqqqqqqqqqqqqq");
            }

            return listbuyInvoices;
        }


    }

    
}
