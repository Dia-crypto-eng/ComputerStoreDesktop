using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    internal class FamilyModel :  BaseModel
    {
        private byte id;
        private string name;
        private ObservableCollection<string> properties = new ObservableCollection<string>();
        public FamilyModel()
        {
            
        }

    public byte Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        [JsonProperty("name")]
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        [JsonProperty("properties")]
        public ObservableCollection<string> Properties { get { return properties; } set { properties = value; OnPropertyChanged("Properties"); } }

    }
}
