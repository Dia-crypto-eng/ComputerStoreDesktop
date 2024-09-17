using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ComputerStore.Models
{
    internal class ProductDetailModel : BaseModel
    {
        private string key;
        private string value;
        public ProductDetailModel()
        {
        }
        public string Key { get { return key; } set { key = value; OnPropertyChanged("Key"); } }
        public string Value { get { return value; } set { this.value = value; OnPropertyChanged("Value"); } }
    }
}
