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
        private List<FamilyModel> listFamily = new List<FamilyModel>();
        private List<ProductModel> listProduct = new List<ProductModel>();
        private FamilyModel selectFamily = new FamilyModel();
        private ProductModel selectProduct = new ProductModel();
        private ProductModel newProduct = new ProductModel();
        private ObservableCollection<ProductDetailModel> specifications;
        private string selectPropriety = "";
        
        private readonly ProductCache _productCache;

        public bool IsFamilyView { get { return isFamilyView; } set { isFamilyView = value; OnPropertyChanged("IsFamilyView"); } }
        public bool IsFamilySelected { get { return isFamilySelected; } set { isFamilySelected = value; OnPropertyChanged("IsFamilySelected"); } }
        public List<FamilyModel> ListFamily { get { return listFamily; } set { listFamily = value; OnPropertyChanged("ListFamily"); } }
        public List<ProductModel> ListProduct { get { return listProduct; } set { listProduct = value; OnPropertyChanged("ListProduct"); } }        
        public FamilyModel SelectFamily { get { return selectFamily; } set { selectFamily = value; OnPropertyChanged("SelectFamily"); } }
        public ProductModel SelectProduct { get { return selectProduct; } set { selectProduct = value; OnPropertyChanged("SelectProduct"); } }
        public string SelectPropriety { get { return selectPropriety; } set { selectPropriety = value; OnPropertyChanged("SelectPropriety"); } }
        public ProductModel NewProduct { get { return newProduct; } set { newProduct = value; OnPropertyChanged("NewProduct"); } }

        public ICommand chooseFamily { get; }
        public ICommand addPropriety { get; }
        public ICommand addProduct { get; }
        public ICommand saveProduct { get; }

        public ProductViewModel() {
            _productCache = CreateCache.Instance.ProductCache;
            getListFamily();
            chooseFamily = new RelayCommand(ShowProd);
            addPropriety = new RelayCommand(AddPropriety);
            addProduct = new RelayCommand(AddNewProduct);
            saveProduct = new RelayCommand(SaveProducts);
            _productCache.InitializeValues();
            IsFamilyView = false;
            specifications = new ObservableCollection<ProductDetailModel>();
        }

        private void SaveProducts()
        {
            _productCache.saveProducts();
        }

        private void AddNewProduct()
        {
            NewProduct.Family = selectFamily.Name;
            Console.WriteLine(JsonConvert.SerializeObject(NewProduct).ToString()) ;
            _productCache.addProduct(NewProduct);
            NewProduct = new ProductModel();
            specifications.Clear();
            foreach (var property in _productCache.getProperties())
                specifications.Add(new ProductDetailModel { Key = property, Value = "" });
            NewProduct.Specifications = specifications;
        }

        private void AddPropriety()
        {
            _productCache.AddPropriety(SelectPropriety);
            if (_productCache.getProperties().LastOrDefault() is string lastProperty && lastProperty != null)
                specifications.Add(new ProductDetailModel { Key = lastProperty, Value = "" });
            NewProduct.Specifications = specifications;
        }

        private void ShowProd()
        {
            _productCache.selectFamily(SelectFamily);
            IsFamilyView = true;
            IsFamilySelected = true;
            NewProduct.Specifications = new ObservableCollection<ProductDetailModel>();
            specifications.Clear();
            foreach (var property in _productCache.getProperties())
                specifications.Add(new ProductDetailModel { Key = property, Value = "" });
            NewProduct.Specifications = specifications;
            ListProduct = _productCache.getProductCategory().Result;
        }

        private void getListFamily()
        {
            ListFamily = _productCache.getAllFamily().Result;
        }


    }
}
