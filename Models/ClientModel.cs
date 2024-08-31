using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    internal class ClientModel :BaseModel
    {
        private byte LinkID;
        private string companyName;
        private string crn;
        private string nis;
        private string nif;
        //private MailAddress email;
        private string phoneNumber;
        private string firstName;
        private string lastName;

        public ClientModel()
        {
        }

        public byte ID { get { return LinkID; } set { LinkID = value; OnPropertyChanged("ID"); } }
        public string CompanyName { get { return companyName; } set { companyName = value; OnPropertyChanged("CompanyName"); } }
        public string CRN { get { return crn; } set { crn = value; OnPropertyChanged("CRN"); } }
        public string NIS { get { return nis; } set { nis = value; OnPropertyChanged("NIS"); } }
        public string NIF { get { return nif; } set { nif = value; OnPropertyChanged("NIF"); } }
        //public MailAddress Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; OnPropertyChanged("PhoneNumber"); } }
        public string FirstName { get { return firstName; } set { firstName = value; OnPropertyChanged("FirstName"); } }
        public string LastName { get { return lastName; } set { lastName = value; OnPropertyChanged("LastName"); } }
     


    }
}
