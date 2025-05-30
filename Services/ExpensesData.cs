using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    internal class ExpensesData
    {
        private HttpClient Client;
        private string url;

        public ExpensesData(HttpClient client, string url)
        {
            Client = client;
            this.url = url;
        }
    }
}
