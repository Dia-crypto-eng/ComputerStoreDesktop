using ComputerStore.DATA;
using ComputerStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ViewModels
{
    internal class SellInoiceViewModel : BaseViewModel,IInvoiceViewModel<SellInoiceModel>
    {
        private List<SellInoiceModel> listSellInoice;
        private string title = "Sell Invoice";
        public SellInoiceViewModel()
        {
            getListSellInvoice();
        }

        public List<SellInoiceModel> ListInvoice { get { return listSellInoice; } 
            set {   listSellInoice =  value; OnPropertyChanged("ListSellInoice"); } }
        public string Title { get { return title; } set { title = value; OnPropertyChanged("Title"); } }

      

        private void getListSellInvoice()
        {
            BonsData bn = new BonsData();
            ListInvoice = bn.GetAllBons() ;
        }

      
    }
}
