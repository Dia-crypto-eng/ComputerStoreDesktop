using ComputerStore.DATA;
using ComputerStore.Models;
using ComputerStore.Views.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Cache
{
    internal class ClientCache
    {
        string url;
        private ClientData clientData;
        private List<ClientModel> listClients = new List<ClientModel>();
        private List<CompanyStatusModel> listClientStatus = new List<CompanyStatusModel>();

        public ClientCache(HttpClient client, string url)
        {
            this.url = url + "client/";
            this.clientData = new ClientData(client, this.url);
            LoadAllFinancialStatus();
            LoadAllClient();
        }
        private async void LoadAllFinancialStatus()
        {
            listClientStatus = clientData.getAllFinancialStatus().Result;
        }
        private async void LoadAllClient()
        {
            listClients = clientData.getAllClient().Result;
        }

        public async Task<List<CompanyStatusModel>> getAllFinancialStatus()
        {
            return listClientStatus;
        }
        public async Task<List<ClientModel>> getAllClient()
        {
            return listClients;
        }

      
    }
}
