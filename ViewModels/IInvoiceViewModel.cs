using ComputerStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ViewModels
{
    internal interface IInvoiceViewModel<T>
    {
        List<T> ListInvoice { get; set; }
    }
}
