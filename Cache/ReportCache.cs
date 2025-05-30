using ComputerStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Cache
{
    internal class ReportCache
    {
        string url;
        private ReportData reportData;
        public ReportCache(HttpClient client, string url)
        {
            this.url = url + "client/";
            this.reportData = new ReportData(client, this.url);
        }
    }
}
