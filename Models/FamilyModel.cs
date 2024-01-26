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
        private string family;
        public FamilyModel()
        {
            
        }

    public byte Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
    public string Family { get { return family; } set { family = value; OnPropertyChanged("Family"); } }

}
}
