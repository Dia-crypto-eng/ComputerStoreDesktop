
using ComputerStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.DATA
{
    class FactureData
    {
        private List<BuyInvoiceModel> listbuyInvoices = new List<BuyInvoiceModel>();
        private HttpClient Clien= new HttpClient();

        public void addInvoice()
        {

        }
        public void deleteInvoice()
        {

        }
      


        public async Task<List<BuyInvoiceModel>> getAllInvoice()
        {
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


        public async Task<ObservableCollection<BuyInvoiceItemModel>> getInvoice(BuyInvoiceModel buyInvoice)
        {
            ObservableCollection<BuyInvoiceItemModel> listbuyInvoicesItem = new ObservableCollection<BuyInvoiceItemModel>();
          
            try
            {
                var res = await Clien.GetAsync("http://127.0.0.1:8000/invoice/"+(listbuyInvoices.IndexOf(buyInvoice)+1)).ConfigureAwait(false);
                string se = await res.Content.ReadAsStringAsync();
                listbuyInvoicesItem = JsonConvert.DeserializeObject<ObservableCollection<BuyInvoiceItemModel>>(se);
            }
            catch (Exception e)
            {
                Console.WriteLine("qqqqqqqqqqqqqq");
            }

            return listbuyInvoicesItem;

         
        }

    }

    
}
