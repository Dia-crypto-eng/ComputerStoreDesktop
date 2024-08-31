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

        public List<ClientModel> ListClient { get { return listClient; } set { listClient = value; OnPropertyChanged("ListClient"); } }
        public ProviderViewModel()
        {
            getListClient();
        }

        private void getListClient()
        {
            clientData = new ClientData();
            ListClient = clientData.getAllClient().Result;
        }

    }
}
