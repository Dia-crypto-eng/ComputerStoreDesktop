using ComputerStore.ENTITY;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ComputerStore.Models
{
    internal class BuyInvoiceItemModel : BaseModel
    {
        
        private byte id;
        private byte idFactureElement;
        private string categoryProduct;
        private string markProduct;
        private string nameProduct;
        private float price_buy;
        private byte quantity;
        private float amount;
        public BuyInvoiceItemModel()
        {
        }

        public byte Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public byte IdFactureElement { get { return idFactureElement; } set { idFactureElement = value; OnPropertyChanged("IdFactureElement"); } }
        public string CategoryProduct { get { return categoryProduct; } set { categoryProduct = value; OnPropertyChanged("FamilyProduct"); } }
        public string MarkProduct { get { return markProduct; } set { markProduct = value; OnPropertyChanged("CodeProduct"); } }
        public string NameProduct { get { return nameProduct; } set { nameProduct = value; OnPropertyChanged("NameProduct"); } }
        public float Price_buy { get { return price_buy; } set { price_buy = value; OnPropertyChanged("Price_buy"); } }
        public byte Quantity { get { return quantity; } set { quantity = value; OnPropertyChanged("Quantity"); } }
        public float Amount { get { return amount; } set { amount = value; OnPropertyChanged("Amount"); } }


     


    }
}
