using ComputerStore.Cache;
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
        private List<ClientModel> listClient = new List<ClientModel>();
        private List<CompanyStatusModel> listClientStatus = new List<CompanyStatusModel>();
        private ClientModel selectClient = new ClientModel();
        private readonly ClientCache _clientCache;

        public List<ClientModel> ListClient { get { return listClient; } set { listClient = value; OnPropertyChanged("ListClient"); } }
        public List<CompanyStatusModel> ListClientStatus { get { return listClientStatus; } set { listClientStatus = value; OnPropertyChanged("ListClientStatus"); } }
        public ClientModel SelectClient { get { return selectClient; } set { selectClient = value; OnPropertyChanged("SelectClient"); } }
        public ProviderViewModel()
        {
            _clientCache = CreateCache.Instance.ClientCache;
            getListClient();
            getListClientStatus();
        }

        private void getListClient()
        {
            ListClient = _clientCache.getAllClient().Result;
        }

        private void getListClientStatus()
        {
            ListClientStatus = _clientCache.getAllFinancialStatus().Result;
        }

    }
}
