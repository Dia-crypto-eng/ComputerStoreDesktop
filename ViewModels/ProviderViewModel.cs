using ComputerStore.DATA;
using ComputerStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ViewModels
{
    internal class ProviderViewModel:BaseViewModel
    {
        private ClientData clientData;
        private List<ClientModel> listClient = new List<ClientModel>();
        private List<CompanyStatusModel> listClientStatus = new List<CompanyStatusModel>();

        public List<ClientModel> ListClient { get { return listClient; } set { listClient = value; OnPropertyChanged("ListClient"); } }
        public List<CompanyStatusModel> ListClientStatus { get { return listClientStatus; } set { listClientStatus = value; OnPropertyChanged("ListClientStatus"); } }

        public ProviderViewModel()
        {
            clientData = new ClientData();
            getListClient();
            getListClientStatus();
        }

        private void getListClient()
        {
            ListClient = clientData.getAllClient().Result;
        }

        private void getListClientStatus()
        {
            ListClientStatus = clientData.getAllFinancialStatus().Result;
        }

    }
}
