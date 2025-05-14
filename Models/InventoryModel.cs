using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ComputerStore.Models
{
    internal class InventoryModel : BaseModel
    {
  

        private int id;
        private byte product;
        private int quantity;
        private string location;
        private int minimum_quantity;
        public InventoryModel() { }
        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public byte Product { get { return product; } set { product = value; OnPropertyChanged("Product"); } }

        public int Quantity { get { return quantity; } set { quantity = value; OnPropertyChanged("Quantity"); } }
        public string Location { get { return location; } set { location = value; OnPropertyChanged("Location"); } }
        public int Minimum_quantity { get { return minimum_quantity; } set { minimum_quantity = value; OnPropertyChanged("Minimum_quantity"); } }
    }
}
