using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    internal class FamilyProductModel : BaseModel
    {
        private string family;
        private List<ProductModel> listProductModel = new List<ProductModel>();

        public string Family { get { return family; } set { family = value; OnPropertyChanged("Family"); } }
        public List<ProductModel> Tab { get { return listProductModel; } set { listProductModel = value; OnPropertyChanged("Tab"); } }
    }
}
