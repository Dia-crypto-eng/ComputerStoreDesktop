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
    class ClientData
    {
        private HttpClient Client ;
        private string url;

        public ClientData(HttpClient Client, string url) 
        {
            this.Client = Client;
            this.url = url;
        }


        public async Task<List<ClientModel>> getAllClient()
        {   
            try
            {
                var res = await Client.GetAsync(url).ConfigureAwait(false);
                string se = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ClientModel>>(se);
            }
            catch (Exception e)
            {
                Console.WriteLine("mmmmmmmmmmmmmmmmmmmm");
                throw;
            }

        }

        public async Task<List<CompanyStatusModel>> getAllFinancialStatus()
        {
            try
            {
                var res = await Client.GetAsync(url + "Finance").ConfigureAwait(false);
                string se = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CompanyStatusModel>>(se);
            }
            catch (Exception e)
            {
                Console.WriteLine("mmmmmmmmmmmmmmmmmmmm");
                throw;
            }

        }

    }
}
