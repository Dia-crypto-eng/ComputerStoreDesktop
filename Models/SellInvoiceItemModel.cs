using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    internal class SellInvoiceItemModel:BaseModel
    {

        private byte idBonsElement;
        private string familyProduct;
        private string codeProduct;
        private string nameProduct;
        private float priceSell;
        private byte quantity;
        private float amount;
        public SellInvoiceItemModel()
        {



        }
        public byte IdBonsElement { get { return idBonsElement; } set { idBonsElement = value; OnPropertyChanged("IdBonsElement"); } }
        public string FamilyProduct { get { return familyProduct; } set { familyProduct = value; OnPropertyChanged("FamilyProduct"); } }
        public string CodeProduct { get { return codeProduct; } set { codeProduct = value; OnPropertyChanged("CodeProduct"); } }
        public string NameProduct { get { return nameProduct; } set { codeProduct = value; OnPropertyChanged("NameProduct"); } }
        public float PriceSell { get { return priceSell; } set { priceSell = value; OnPropertyChanged("PriceSell"); } }
        public byte Quantity { get { return quantity; } set { quantity = value; OnPropertyChanged("Quantity"); } }
        public float Amount { get { return amount; } set { amount = value; OnPropertyChanged("Amount"); } }

    }
}
