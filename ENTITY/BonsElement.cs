using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ENTITY
{
    class BonsElement
    {

        private byte idBonsElement;
        private string familyProduct;
        private string codeProduct;
        private string nameProduct;
        private float priceSell;
        private byte quantity;
        private float amount;

        public byte Id { get => idBonsElement; set => idBonsElement = value; }
        public string FamilyProduct { get => familyProduct; set => familyProduct = value; }
        public string CodeProduct { get => codeProduct; set => codeProduct = value; }
        public string Product { get => nameProduct; set => nameProduct = value; }
        public float PriceSell { get => priceSell; set => priceSell = value; }
        public byte Quantity { get => quantity; set => quantity = value; }
        public float Amount { get => amount; set => amount = value; }




    }
}
