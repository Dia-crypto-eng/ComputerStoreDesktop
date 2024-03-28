using ComputerStore.ENTITY;
using System;
using System.Collections.Generic;
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
        public FamilyModel()
        {
            
        }

    public byte Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
    public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }

}
}
