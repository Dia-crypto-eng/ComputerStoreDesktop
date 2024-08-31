using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    internal class CompanyStatusModel:BaseModel
    {
        private byte customer_id;
        private string customer_name;
        private float total_purchases;
        private float total_payments;
        private float outstanding_balance;
        

        public CompanyStatusModel()
        {
        }

        public byte Customer_id { get { return customer_id; } set { customer_id = value; OnPropertyChanged("Customer_id"); } }
        public string Customer_name { get { return customer_name; } set { customer_name = value; OnPropertyChanged("Customer_name"); } }
        public float Total_purchases { get { return total_purchases; } set { total_purchases = value; OnPropertyChanged("Total_purchases"); } }
        public float Total_payments { get { return total_payments; } set { total_payments = value; OnPropertyChanged("Total_payments"); } }
        public float Outstanding_balance { get { return outstanding_balance; } set { outstanding_balance = value; OnPropertyChanged("Outstanding_balance"); } }
       

        
    }
}
