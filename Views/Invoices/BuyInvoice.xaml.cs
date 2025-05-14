using ComputerStore.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using HexInnovation;
using MaterialDesignThemes.Wpf;
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
            Messenger.Default.Register<string>(this, Show);
        }
        //object sender, RoutedEventArgs e
       
        void Show(string message)
        {
            Grid D = Adds.GetParent<Grid>(HeadPage);
            D.Children.RemoveAt(0);
            BodyPage.Children.Clear();

            Viewbox factureDetail = new Viewbox
            {
                Width = 371,  // العرض المصغر
                Height = 526, // الارتفاع المصغر
                Child = new FactureDetail() // إضافة الـ UserControl إلى الـ Viewbox
            };
            //factureDetail.Margin = new Thickness(200, 20, 200, 20);
            BodyPage.Children.Add(factureDetail);
        }

        private void Add_facture(object sender, RoutedEventArgs e)
        {
            PackIcon iconCase = Adds.FindVisualChild<PackIcon>((Button)sender, "AddFactureCase");
            if (iconCase.Kind == PackIconKind.PaperAdd)
            {
                HeadPage.Children.RemoveAt(1);
                BodyPage.Children.Clear();
                BodyPage.Children.Add(new addFacture());
                iconCase.Kind = PackIconKind.ArrowLeftBold;
            }
            else
            {  
                Grid home = Adds.GetParent<Grid>(Adds.GetParent<UserControl>(Adds.GetParent<Grid>(BodyPage)));
                home.Children.Clear();
                home.Children.Add(new BuyInvoice());
            }

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
