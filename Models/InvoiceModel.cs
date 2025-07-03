using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    internal class InvoiceModel :BaseModel
    {
        private byte id;
        private string provider;
        private float amount;
        private DateTime date;

        public InvoiceModel()
        {
        }

        public byte Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Provider { get { return provider; } set { provider = value; OnPropertyChanged("Provider"); } }
        public float Amount { get { return amount; } set { amount = value; OnPropertyChanged("Amount"); } }
        public DateTime Date { get { return date; } set { date = value; OnPropertyChanged("Date"); } }
        public void AddAmountOf(BuyInvoiceItemModel item)
        {
            Amount += item.Amount;
        }
    }
}
