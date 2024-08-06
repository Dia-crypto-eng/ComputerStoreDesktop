using ComputerStore.Views;
using ComputerStore.DATA;
using ComputerStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ComputerStore.ViewModels
{
    internal class ProductViewModel : BaseViewModel
    {
       
        private List<FamilyModel> listFamily = new List<FamilyModel>();
        private List<ProductModel> listProduct = new List<ProductModel>();
        private FamilyModel selectFamily = new FamilyModel();
        private ProductModel selectProduct = new ProductModel();
        private ProductData productData;

        public List<FamilyModel> ListFamily { get { return listFamily; } set { listFamily = value; OnPropertyChanged("ListFamily"); } }
        public List<ProductModel> ListProduct { get { return listProduct; } set { listProduct = value; OnPropertyChanged("ListProduct"); } }
        public FamilyModel SelectFamily { get { return selectFamily; } set { selectFamily = value; OnPropertyChanged("SelectFamily"); } }
        public ProductModel SelectProduct { get { return selectProduct; } set { selectProduct = value; OnPropertyChanged("SelectProduct"); } }
        public ICommand chooseFamily { get; }
       

        public ProductViewModel() {
            productData = new ProductData();
            getListFamily();
            chooseFamily = new RelayCommand(ShowProd);
        }

        private void ShowProd()
        {
            getListProduct();
        }

        private void getListFamily()
        {
            ListFamily = productData.getAllFamily().Result;
        }

        private void getListProduct()
        {
            ListProduct = productData.getProductCategory(selectFamily.Name).Result;
        }

    }
}
