using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    internal class SellInoiceModel:BaseModel
    {
        private byte id;
        private string bnDate;
        private float montant;
        private string nameClient;
        private string sold;

        public SellInoiceModel()
        {

        }

        public byte Id { get { return id; } set {  id = value; OnPropertyChanged("Id"); } }
        public string BnDate { get {  return bnDate; } set { bnDate = value; OnPropertyChanged("BnDate"); } }
        public float Montant { get {  return montant; } set { montant = value; OnPropertyChanged("Montant"); } }
        public string NameClient { get {  return nameClient; } set {  nameClient = value; OnPropertyChanged("NameClient");} }
        public string Sold { get {  return sold; } set { sold = value; OnPropertyChanged("Sold"); } }


       }
}
