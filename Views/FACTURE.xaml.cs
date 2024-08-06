using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Button = System.Windows.Controls.Button;
using ComputerStore.Views;
using ComputerStore.DATA;
using ComputerStore.Models;
using ComputerStore.ViewModels;


namespace ComputerStore.Views
{

    public partial class FACTURE : System.Windows.Controls.Page
    {
        BuyInvoiceViewModel buyInvoiceViewModel;

        public FACTURE()
        {
            InitializeComponent();
            buyInvoiceViewModel = new BuyInvoiceViewModel();
            this.DataContext = this.buyInvoiceViewModel;
        }
        void Show(object sender, RoutedEventArgs e)
        {
            byte numberPage = (byte)Dtgd.Items.IndexOf(Adds.GetParent<DataGridRow>((Button)sender).Item);
            Grid D = (Grid)VisualTreeHelper.GetParent(HeadPage);
            D.Children.RemoveAt(1);
            HeadPage.Children.Clear();
            FactureDetail factureDetail  = new FactureDetail(numberPage);
            factureDetail.Margin = new Thickness(250, 60,250,60) ;
            HeadPage.Children.Add(factureDetail);

        }

        private void Add_facture(object sender, RoutedEventArgs e)
        {
            HeadPage.Children.RemoveAt(1);
            BodyPage.Children.Clear();
            BodyPage.Children.Add(new addFacture());
        }


    }
}