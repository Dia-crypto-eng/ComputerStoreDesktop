using ComputerStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComputerStore.Views.Clients
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
  
    public partial class Clients : UserControl
    {
        ProviderViewModel provider;
        public Clients()
        {
            InitializeComponent();
            provider = new ProviderViewModel();
            this.DataContext = this.provider;
        }
    }
}
