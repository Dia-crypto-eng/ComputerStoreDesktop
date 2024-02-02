using ComputerStore.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComputerStore.Models
{
    internal class BuyInvoiceModel : BaseModel
    {
        private byte id;
        private string provider;
        private float amount;
        private DateTime date;
        public BuyInvoiceModel()
        {
        }

        public byte Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Provider { get { return provider; } set { provider = value; OnPropertyChanged("Provider"); } }
        public float Amount { get { return amount; } set { amount = value; OnPropertyChanged("Montant"); } }
        public DateTime Date { get { return date; } set { date = value; OnPropertyChanged("Date"); } }


    }
}
