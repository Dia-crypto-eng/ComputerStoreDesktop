using ComputerStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Cache
{
    internal class ExpensesCache
    {
        string url;
        private ExpensesData expensesData;
        public ExpensesCache(HttpClient client, string url)
        {
            this.url = url + "client/";
            this.expensesData = new ExpensesData(client, this.url);
        }
    }
}
