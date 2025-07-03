
using ComputerStore.Models;
using ComputerStore.Services;
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
        //private HttpClient Clien ;
        //private string url;

        //public void addInvoice()
        //{

        //}
        //public void deleteInvoice()
        //{

        //}
        //public FactureData(HttpClient client, string url) 
        //{ 
        //    this.Clien = client;
        //    this.url = url;
        
        //}
       

        //public async Task<List<BuyInvoiceModel>> getAllInvoice()
        //{
        //    try
        //    {
        //        var res = await Clien.GetAsync(url).ConfigureAwait(false);       
        //        string se = await res.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<List<BuyInvoiceModel>>(se) ;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("qqqqqqqqqqqqqq");
        //        throw;
        //    }

        //}


        //public async Task<ObservableCollection<BuyInvoiceItemModel>> getInvoice(int id)
        //{
        //    try
        //    {
        //        var res = await Clien.GetAsync(url+id).ConfigureAwait(false);
        //        string se = await res.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<ObservableCollection<BuyInvoiceItemModel>>(se);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("qqqqqqqqqqqqqq");
        //        throw;
        //    }

        //}

    }

    
}
