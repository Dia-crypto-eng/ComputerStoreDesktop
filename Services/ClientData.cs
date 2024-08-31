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
        private HttpClient Clien = new HttpClient();

        public async Task<List<ClientModel>> getAllClient()
        {
            List<ClientModel> listClients = new List<ClientModel>();
            try
            {
                var res = await Clien.GetAsync("http://127.0.0.1:8000/client/").ConfigureAwait(false);
                string se = await res.Content.ReadAsStringAsync();
                listClients = JsonConvert.DeserializeObject<List<ClientModel>>(se);
            }
            catch (Exception e)
            {
                Console.WriteLine("mmmmmmmmmmmmmmmmmmmm");
            }

            return listClients;
        }

    }
}
