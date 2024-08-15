
using ComputerStore.Views;
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
using ComputerStore.ViewModels;
using ComputerStore.Models;

namespace ComputerStore.Views
{
    /// <summary>
    /// Interaction logic for addFacture.xaml
    /// </summary>
    public partial class addFacture : UserControl
    {
       
        private ProductViewModel productViewModel;
        private BuyInvoiceViewModel buyInvoiceViewModel;
        public addFacture()
        {
            InitializeComponent();
            productViewModel = new ProductViewModel();
            buyInvoiceViewModel = new BuyInvoiceViewModel(productViewModel);
            this.DataContext = this.buyInvoiceViewModel;
            FactureDetail factureDetail = new FactureDetail(buyInvoiceViewModel);
            factureDetail.Margin = new Thickness(25, 2, 25, 2);
            factureShow.Children.Add(factureDetail);
        }
        private void AddFamily(object sender, RoutedEventArgs e)
        {
            AddFami.Children.Add(new Addfamily());
        }
          

        private void AddProduct(object sender, RoutedEventArgs e)
            {
             if (add_product.Children.Add(new AddProduct( )) != 0)
                   {
                    add_product.Children.Clear();
                   }

            }

    }

}


 