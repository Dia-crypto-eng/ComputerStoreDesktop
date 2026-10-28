using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    internal class ProductPostModel : BaseModel
    {
        private string name, mark, code;
        private FamilyModel family = new FamilyModel();
        private ObservableCollection<ProductDetailModel> specifications = new ObservableCollection<ProductDetailModel>();

        // تملؤها الواجهة (XAML)
        [JsonProperty("name")] public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        [JsonProperty("mark")] public string Mark { get { return mark; } set { mark = value; OnPropertyChanged("Mark"); } }
        [JsonProperty("code")] public string Code { get { return code; } set { code = value; OnPropertyChanged("Code"); } }

        // الفئة بخصائصها: تُرسَل باسم category
        [JsonProperty("category")]
        public FamilyModel Family { get { return family; } set { family = value; OnPropertyChanged("Family"); } }

        // قائمة Key/Value للواجهة فقط، لا تُرسَل
        [JsonIgnore]
        public ObservableCollection<ProductDetailModel> Specifications
        { get { return specifications; } set { specifications = value; OnPropertyChanged("Specifications"); } }

        // للإرسال فقط: تُحسب من القائمة (get فقط)
        [JsonProperty("specifications")]
        public JObject SpecificationsJson { get { return ConvertToJObject(specifications); } }

        private static JObject ConvertToJObject(ObservableCollection<ProductDetailModel> collection)
        {
            var result = new JObject();
            if (collection == null) return result;
            foreach (var item in collection.Where(i => !string.IsNullOrWhiteSpace(i.Key)))
                result[item.Key] = item.Value ?? "";
            return result;
        }
    }
}
