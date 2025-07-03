using ComputerStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ViewModels
{
    internal abstract class IInvoiceViewModel<T> : BaseViewModel
    {
        private string title;
        //private List<BuyInvoiceModel> listInvoice = new List<BuyInvoiceModel>();
        private List<T> listInvoice ;

        //private BuyInvoiceModel buyInvoice = new BuyInvoiceModel();
        private T buyInvoice;
        private ProviderViewModel providerViewModel;
        private ProductViewModel productViewModel;

        protected IInvoiceViewModel()
        {
            Product = new ProductViewModel();
            Provider = new ProviderViewModel();
        }

        public string Title { get { return title; } set { title = value; OnPropertyChanged("Title"); } }
        public ProductViewModel Product
        {
            get { return productViewModel; }
            set { productViewModel = value; OnPropertyChanged("Product"); }
        }
        public ProviderViewModel Provider
        {
            get { return providerViewModel; }
            set { providerViewModel = value; OnPropertyChanged("Provider"); }
        }
        public List<T> ListInvoice { get { return listInvoice; } set { listInvoice = value; OnPropertyChanged("ListBuyInvoice"); } }
        public T BuyInvoice { get { return buyInvoice; } set { buyInvoice = value; OnPropertyChanged("BuyInvoice"); } }
    }
}
