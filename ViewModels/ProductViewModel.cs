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

namespace ComputerStore.ViewModels
{
    internal class ProductViewModel : BaseViewModel
    {
        private List<FamilyModel> listFamily = new List<FamilyModel>();
        private List<ProductModel> listProduct = new List<ProductModel>();
        private FamilyModel selectFamily = new FamilyModel();
        private ProductModel selectProduct = new ProductModel();
        private ObservableCollection<ProductDetailModel> specifications;
        private string selectPropriety = "";
        
        private readonly ProductCache _productCache;

        public List<FamilyModel> ListFamily { get { return listFamily; } set { listFamily = value; OnPropertyChanged("ListFamily"); } }
        public List<ProductModel> ListProduct { get { return listProduct; } set { listProduct = value; OnPropertyChanged("ListProduct"); } }        
        public FamilyModel SelectFamily { get { return selectFamily; } set { selectFamily = value; OnPropertyChanged("SelectFamily"); } }
        public ProductModel SelectProduct { get { return selectProduct; } set { selectProduct = value; OnPropertyChanged("SelectProduct"); } }
        public string SelectPropriety { get { return selectPropriety; } set { selectPropriety = value; OnPropertyChanged("SelectPropriety"); } }
        public ObservableCollection<ProductDetailModel> Specifications { get { return specifications; } set { specifications = value; OnPropertyChanged("Specifications"); } }

        public ICommand chooseFamily { get; }
        public ICommand addPropriety { get; }
        public ICommand clearFamily { get; }

        public ProductViewModel() {
            _productCache = CreateCache.Instance.ProductCache;
            getListFamily();
            chooseFamily = new RelayCommand(ShowProd);
            addPropriety = new RelayCommand(AddPropriety);
            _productCache.InitializeValues();

            // إنشاء Dictionary يحتوي على المفاتيح والقيم فارغة
            //Properties =  new ObservableCollection<string>()
            //{
            //    "Product Name", "Brand", "Brand", "Speed","Product Name",  "Size",  "Size", "Price",  
            //};
            Specifications = new ObservableCollection<ProductDetailModel>();

        }

     

        private void AddPropriety()
        {
            _productCache.AddPropriety(SelectPropriety);
            if (_productCache.getProperties().LastOrDefault() is string lastProperty && lastProperty != null)
                Specifications.Add(new ProductDetailModel { Key = lastProperty, Value = "" });

            //  Specifications = new ObservableCollection<ProductDetailModel>(
            //_productCache.getProperties().Select(p => new ProductDetailModel { Key = p, Value = "" }));

            //Properties.Add(SelectPropriety);
            // إضافة عنصر جديد إلى Specifications
            //Specifications.Add(new ProductDetailModel { Key = SelectPropriety, Value = "" });
        }

        private void ShowProd()
        {
            _productCache.selectFamily(SelectFamily);
            //Specifications = new ObservableCollection<ProductDetailModel>(
            //   _productCache.getProperties().Select(p => new ProductDetailModel { Key = p, Value = "" }));
            Specifications.Clear();
            foreach (var property in _productCache.getProperties())
            Specifications.Add(new ProductDetailModel { Key = property, Value = "" });
            ListProduct = _productCache.getProductCategory().Result;
        }

        private void getListFamily()
        {
            ListFamily = _productCache.getAllFamily().Result;
        }

       

    }
}
