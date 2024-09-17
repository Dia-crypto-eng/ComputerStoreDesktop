using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string mark;
        private string code;
        private string family;
        private ObservableCollection<ProductDetailModel> specifications;
        //private JObject specifications = new JObject();
        //private ObservableCollection<ProductDetailModel> specs;
        public ProductModel()
        {
        }

        public byte Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Code { get { return code; } set { code = value; OnPropertyChanged("Code"); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string Family { get { return family; } set { family = value; OnPropertyChanged("Family"); } }
        public string Mark { get { return mark;  } set { mark = value; OnPropertyChanged("Mark"); } }

        public Object Specifications { 
          get { return specifications; } 
          set {
              ObservableCollection<ProductDetailModel> newValue = value is JObject JObjectValue 
              ? ConvertSpecifications(JObjectValue)
              : value is ObservableCollection<ProductDetailModel> DictionaryValue
                  ? DictionaryValue
                  : specifications;

                if (specifications != newValue)
                {
                    specifications = newValue;
                    OnPropertyChanged("Specifications");
                }} }


        //public JObject Specifications
        //{
        //   get {   return ConvertSpecifications(specifications); } 
        //   set { specifications = ConvertToJObject(value);  OnPropertyChanged("Specifications"); } }


        //public void SetSpecificationsFromJson(JObject jsonObject)
        //{
        //    var specs = jsonObject.ToObject<Dictionary<string, string>>(); // تحويل الكائن إلى Dictionary
        //    Console.WriteLine(specs.ToString()) ;
        //    Specifications = new ObservableCollection<ProductDetailModel>();

        //    //if (specs != null)
        //    //{
        //    //    foreach (var spec in specs)
        //    //    {
        //    //        Specifications.Add(new ProductDetailModel
        //    //        {
        //    //            Key = spec.Key,
        //    //            Value = spec.Value
        //    //        });
        //    //    }
        //    //}
        //}






        private ObservableCollection<ProductDetailModel> ConvertSpecifications(JObject jsonObject)
        {
            var specifications = new ObservableCollection<ProductDetailModel>();

            if (jsonObject != null)
            {
                foreach (var property in jsonObject.Properties()) // نمر على كل عنصر في الـ JObject
                {
                    specifications.Add(new ProductDetailModel
                    {
                        Key = property.Name, // اسم الخاصية كـ Key
                        Value = property.Value.ToString() // القيمة كـ Value
                    });
                }
            }

            return specifications;
        }

        private JObject ConvertToJObject(ObservableCollection<ProductDetailModel> collection)
        {
            var specsDict = new JObject();
            foreach (var item in collection)
            {
                specsDict[item.Key] = item.Value; // إضافة Key و Value إلى JObject
            }
            return specsDict;
        }

        /*
        private JObject ConvertSpecifications(JObject jsonObject)
        {
            Console.WriteLine(jsonObject); 
            return jsonObject;
        }

        private JObject ConvertToJObject(JObject jsonObject)
        {
            Console.WriteLine(jsonObject);
            return jsonObject;
        }*/

    }
}
