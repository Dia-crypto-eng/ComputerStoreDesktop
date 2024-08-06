using ComputerStore.DATA;
using ComputerStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ViewModels
{
    internal class SellInoiceViewModel : BaseViewModel
    {
        private List<SellInoiceModel> listSellInoice;
        public SellInoiceViewModel()
        {
            getListSellInvoice();
        }

        public List<SellInoiceModel> ListSellInoice { get { return listSellInoice; } 
            set {   listSellInoice =  value; OnPropertyChanged("ListSellInoice"); } }
        private void getListSellInvoice()
        {
            BonsData bn = new BonsData();
            ListSellInoice = bn.GetAllBons() ;
        }
    }
}
