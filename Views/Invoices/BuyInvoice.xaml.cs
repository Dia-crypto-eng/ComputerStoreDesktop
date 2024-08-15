using ComputerStore.ViewModels;
using HexInnovation;
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
    /// Interaction logic for BuyInvoice.xaml
    /// </summary>
    public partial class BuyInvoice : UserControl
    {
        BuyInvoiceViewModel buyInvoiceViewModel;
        public BuyInvoice()
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
            FactureDetail factureDetail = new FactureDetail(numberPage);
            factureDetail.Margin = new Thickness(250, 60, 250, 60);
            HeadPage.Children.Add(factureDetail);

        }

        private void Add_facture(object sender, RoutedEventArgs e)
        {
            HeadPage.Children.RemoveAt(1);
            BodyPage.Children.Clear();
            BodyPage.Children.Add(new addFacture());
        }

        private void ButtonInvoice(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            // استخدام تعبير شرطي لتبديل الألوان
            bool isBuyButton = clickedButton == BuyButton;

            BuyButtonBorder.Background = isBuyButton ? Brushes.Black : Brushes.White;
            BuyButton.Foreground = isBuyButton ? Brushes.White : Brushes.Black;

            SellButtonBorder.Background = isBuyButton ? Brushes.White : Brushes.Black;
            SellButton.Foreground = isBuyButton ? Brushes.Black : Brushes.White;

            // تعيين DataContext باستخدام تعبير شرطي
            if (isBuyButton)
            {
                this.DataContext = new BuyInvoiceViewModel();
            }
            else
            {
                this.DataContext = new SellInoiceViewModel();
            }

        }
    }
}
