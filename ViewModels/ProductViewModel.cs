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
using ComputerStore.Cache;
using System.Collections.ObjectModel;
using ComputerStore.Views.Invoices;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;

namespace ComputerStore.ViewModels
{
    internal class ProductViewModel : BaseViewModel
    {
        private bool isFamilyView ;
        private bool isFamilySelected = false;
        private ObservableCollection<FamilyModel> listFamily = new ObservableCollection<FamilyModel>();
        private ObservableCollection<ProductModel> listProduct = new ObservableCollection<ProductModel>();
        private FamilyModel selectFamily = new FamilyModel();
        private ProductModel selectProduct = new ProductModel();
        //private ProductModel newProduct = new ProductModel();
        private ProductPostModel newProduct = new ProductPostModel();
        public ProductPostModel NewProduct { get { return newProduct; } set { newProduct = value; OnPropertyChanged("NewProduct"); } }
        private string selectPropriety = "";
        
        private readonly ProductCache _productCache;

        public bool IsFamilyView { get { return isFamilyView; } set { isFamilyView = value; OnPropertyChanged("IsFamilyView"); } }
        public bool IsFamilySelected { get { return isFamilySelected; } set { isFamilySelected = value; OnPropertyChanged("IsFamilySelected"); } }
        public ObservableCollection<FamilyModel> ListFamily { get { return listFamily; } set { listFamily = value; OnPropertyChanged("ListFamily"); } }
        public ObservableCollection<ProductModel> ListProduct { get { return listProduct; } set { listProduct = value; OnPropertyChanged("ListProduct"); } }        
        public FamilyModel SelectFamily { get { return selectFamily; } set { selectFamily = value; OnPropertyChanged("SelectFamily"); } }
        public ProductModel SelectProduct { get { return selectProduct; } set { selectProduct = value; OnPropertyChanged("SelectProduct"); } }
        public string SelectPropriety { get { return selectPropriety; } set { selectPropriety = value; OnPropertyChanged("SelectPropriety"); } }
        //public ProductModel NewProduct { get { return newProduct; } set { newProduct = value; OnPropertyChanged("NewProduct"); } }

        public ICommand chooseFamily { get; }
        public ICommand addPropriety { get; }
        public ICommand saveProduct { get; }

        public ProductViewModel() {
            _productCache = CreateCache.Instance.ProductCache;
            getListFamily();
            chooseFamily = new RelayCommand(ShowProd);
            addPropriety = new RelayCommand(AddPropriety);
            saveProduct = new RelayCommand(SaveProducts);
            //_productCache.InitializeValues();
            IsFamilyView = false;
        }

        private ProductPostModel NewProductFor(FamilyModel family)
        {
            return new ProductPostModel
            {
                Family = family,
                Specifications = new ObservableCollection<ProductDetailModel>(
                    family.Properties.Select(p => new ProductDetailModel { Key = p, Value = "" }))
            };
        }
        private async void SaveProducts()
        {
            if (!await _productCache.addProduct(NewProduct)) return;
            NewProduct = NewProductFor(NewProduct.Family);
            ListProduct = _productCache.getProductCategory(SelectFamily).Result;

            //NewProduct.Family = selectFamily.Name;
            //_productCache.addProduct(NewProduct);
            // Console.WriteLine(JsonConvert.SerializeObject(NewProduct).ToString()) ;
            //NewProduct = new ProductModel();
            //_productCache.selectFamily(selectFamily);
            //ResetSpecifications();

        }

        private void AddNewProduct()
        {
           
        }

        private void AddPropriety()
        {
            NewProduct.Family.Properties.Add(SelectPropriety);
            NewProduct.Specifications.Add(new ProductDetailModel { Key = SelectPropriety, Value = "" });

            //_productCache.AddPropriety(SelectPropriety);
            //if (_productCache.getProperties().LastOrDefault() is string lastProperty && lastProperty != null)
            //    specifications.Add(new ProductDetailModel { Key = lastProperty, Value = "" });
            //NewProduct.Specifications = specifications;
        }

        private void ShowProd()
        {

            //_productCache.selectFamily(SelectFamily);
            IsFamilyView = true;
            IsFamilySelected = true;
            NewProduct = NewProductFor(SelectFamily);
            //NewProduct.Specifications = new ObservableCollection<ProductDetailModel>();
            //ResetSpecifications();
            ListProduct = _productCache.getProductCategory(SelectFamily).Result;
        }

        private void getListFamily()
        {
            ListFamily = _productCache.getAllFamily().Result;
        }

        //private void ResetSpecifications()
        //{
        //    specifications.Clear();
        //    foreach (var property in _productCache.getProperties())
        //        specifications.Add(new ProductDetailModel { Key = property, Value = "" });
        //    NewProduct.Specifications = specifications;
        //}


    }
}
