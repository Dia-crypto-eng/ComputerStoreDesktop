using ComputerStore.DATA;
using ComputerStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Cache
{
    internal class DashboardCache
    {
        string url;
        private DashboardData dashboardData;

        public DashboardCache(HttpClient client, string url)
        {
            this.url = url + "client/";
            this.dashboardData = new DashboardData(client, this.url);
        }
    }
}
