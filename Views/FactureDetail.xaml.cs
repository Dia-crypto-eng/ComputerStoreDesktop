using ComputerStore.DATA;
using ComputerStore.ENTITY;
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


namespace ComputerStore.CONTROLLERS
{
 
    public partial class FactureDetail : UserControl
    {
        BuyInvoiceViewModel buyInvoiceViewModel;
        public FactureDetail(byte id)
        {
            InitializeComponent();
            buyInvoiceViewModel = new BuyInvoiceViewModel(id);
            this.DataContext = this.buyInvoiceViewModel;


            // this.factureEntity = this.facturedata.getInvoice().Result;
            // factureTable.ItemsSource = this.factureEntity.FactureElement;
            //DateTime Date = this.factureEntity.date;





            /* id.Text = (I + 1).ToString();
             totalAmount.Text = this.factureEntity.totalAmount.ToString() ;
             TVA.Text = (this.factureEntity.totalAmount * 0.19).ToString();
             TTC.Text = (this.factureEntity.totalAmount * 1.19).ToString();*/


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
