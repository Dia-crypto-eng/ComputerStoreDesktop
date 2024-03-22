using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Button = System.Windows.Controls.Button;
using ComputerStore.CONTROLLERS;
using ComputerStore.DATA;
using ComputerStore.Models;
using ComputerStore.ViewModels;

namespace ComputerStore
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
            Console.WriteLine();
            byte numberPage = (byte)Dtgd.Items.IndexOf(Adds.GetParent<DataGridRow>((Button)sender).Item);
            Grid D = (Grid)VisualTreeHelper.GetParent(HeadPage);
            D.Children.RemoveAt(1);
            HeadPage.Children.Clear();
            HeadPage.Children.Add(new FactureDetail(numberPage));

        }


        private void Add_facture(object sender, RoutedEventArgs e)
        {
            HeadPage.Children.RemoveAt(1);
            BodyPage.Children.Clear();
            BodyPage.Children.Add(new addFacture());
        }


    }
}