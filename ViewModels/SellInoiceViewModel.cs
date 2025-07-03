using ComputerStore.DATA;
using ComputerStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ViewModels
{
    internal class SellInoiceViewModel : IInvoiceViewModel<SellInoiceModel>
    {
        
        public SellInoiceViewModel()
        {
            Title = "Sell Invoice";
            getListSellInvoice();
        }

        private void getListSellInvoice()
        {
            BonsData bn = new BonsData();
            ListInvoice = bn.GetAllBons() ;
        }

      
    }
}
