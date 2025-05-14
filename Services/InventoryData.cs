using ComputerStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    class InventoryData
    {
        private HttpClient Client;
        private string url;
        public InventoryData(HttpClient Client, string url)
        {
            this.Client = Client;
            this.url = url;
        }

        public async Task<List<InventoryModel>> getAllInventory()
        {
            try
            {
                var res = await Client.GetAsync(url).ConfigureAwait(false);
                string se = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<InventoryModel>>(se);
            }
            catch (Exception e)
            {
                Console.WriteLine("mmmmmmmmmmmmmmmmmmmm");
                throw;
            }

        }
    }
}
