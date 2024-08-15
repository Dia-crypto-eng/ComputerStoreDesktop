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

namespace ComputerStore.Views.Invoices
{
    /// <summary>
    /// Interaction logic for SellInvoice.xaml
    /// </summary>
    public partial class SellInvoice : UserControl
    {
        SellInoiceViewModel sellInoiceViewModel;
        public SellInvoice()
        {
            InitializeComponent();
            sellInoiceViewModel = new SellInoiceViewModel();
            this.DataContext = this.sellInoiceViewModel;
        }

        public void SHOWBN(object sender, RoutedEventArgs e)
        {

            new BonsDetail().Show();

        }
        public void Show(object sender, RoutedEventArgs e)
        {

            new BonsDetail().Show();

        }

    }
}
