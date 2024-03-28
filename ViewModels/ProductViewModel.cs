using ComputerStore.CONTROLLERS;
using ComputerStore.DATA;
using ComputerStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ViewModels
{
    internal class ProductViewModel : BaseViewModel
    {
        private List<FamilyModel> listFamily = new List<FamilyModel>();
        private ProductData productData;

        public ProductViewModel() {
            productData = new ProductData();
            getListFamily();

        }

        private void getListFamily()
        {
            ListFamily = productData.getAllFamily().Result;
        }

        public List<FamilyModel> ListFamily { get { return listFamily; } set { listFamily = value; OnPropertyChanged("ListFamily"); } }







    }
}
