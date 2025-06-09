using ComputerStore.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Cache
{
    internal class CreateCache
    {
        private HttpClient Client = new HttpClient();
        private string url = "http://127.0.0.1:8000/";
        private static readonly Lazy<CreateCache> _instance = new Lazy<CreateCache>(() => new CreateCache());

        public static CreateCache Instance => _instance.Value;

        public InvoiceCache InvoiceCache { get; private set; }
        public ProductCache ProductCache { get; private set; }
        public ClientCache ClientCache { get; private set; }
        public InventoryCache InventoryCache { get; private set; }
        public DashboardCache DashboardCache { get; private set; }
        public ExpensesCache ExpensesCache { get; private set; }
        public ReportCache ReportCache { get; private set; }

        public CreateCache()
        {
            // إنشاء الكاشات هنا
            ProductCache = new ProductCache(Client, url);
            InvoiceCache = new InvoiceCache(Client, url);
            ClientCache = new ClientCache(Client, url);
            InventoryCache = new InventoryCache(Client, url);
            DashboardCache = new DashboardCache(Client, url);
            ExpensesCache = new ExpensesCache(Client, url);
            ReportCache = new ReportCache(Client, url);

        }
    }
}

