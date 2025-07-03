using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    internal class IInvoiceData<T, T2>
    {
        private HttpClient Clien;
        private string url;
        public IInvoiceData(HttpClient client, string url)
        {
            this.Clien = client;
            this.url = url;
        }
        public async Task<List<T>> getAllInvoice() 
            {
            try
                  {
                        var res = await Clien.GetAsync(url).ConfigureAwait(false);       
                        string se = await res.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<T>>(se) ;
                    }
            catch (Exception e)
                   {
                      Console.WriteLine("qqqqqqqqqqqqqq");
                       throw;
                  }
            }
        public async Task<ObservableCollection<T2>> getInvoice(int id)
                {
                 try
                      {
                        var res = await Clien.GetAsync(url+id).ConfigureAwait(false);
                        string se = await res.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ObservableCollection<T2>>(se);
                        }
                 catch (Exception e)
                        {
                        Console.WriteLine("qqqqqqqqqqqqqq");
                        throw;
                        }

                }

    }
}
