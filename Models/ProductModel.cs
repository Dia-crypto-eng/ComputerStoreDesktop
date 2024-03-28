using ComputerStore.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    internal class ProductModel :  BaseModel
    {
       
        private byte id;
        private string name;
        private string code;
        private string family;

        public ProductModel()
        {
        }

        public byte Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Code { get { return code; } set { code = value; OnPropertyChanged("Code"); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string Family { get { return family; } set { family = value; OnPropertyChanged("Family"); } }

    }
}
