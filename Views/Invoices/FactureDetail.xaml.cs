using ComputerStore.DATA;
using ComputerStore.Models;
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
using System.Windows.Shapes;


namespace ComputerStore.Views
{
 
    public partial class FactureDetail : UserControl
    {
        private BuyInvoiceItemViewModel buyInvoiceItemViewModel;
    
        internal FactureDetail()
        {
            InitializeComponent();
            this.buyInvoiceItemViewModel = new BuyInvoiceItemViewModel();
            this.DataContext = this.buyInvoiceItemViewModel;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                    printDialog.PrintVisual(BECH,"INVOICE") ;
            }
            finally
            {
                this.IsEnabled = true;

            }
        }

    }
}
