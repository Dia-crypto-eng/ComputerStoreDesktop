
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
using MaterialDesignThemes.Wpf;
using ComputerStore.Views.Clients;

namespace ComputerStore.Views
{
    /// <summary>
    /// Interaction logic for addFacture.xaml
    /// </summary>
    public partial class addFacture : UserControl
    {
        private BuyInvoiceItemViewModel buyInvoiceItemViewModel;
        internal addFacture(BuyInvoiceViewModel buyInvoiceViewModel)
        {
            InitializeComponent();
            this.buyInvoiceItemViewModel = new BuyInvoiceItemViewModel(buyInvoiceViewModel);
            this.DataContext = this.buyInvoiceItemViewModel;
            FactureDetail factureDetail = new FactureDetail(this.buyInvoiceItemViewModel);
            factureDetail.Margin = new Thickness(25, 20, 25, 20);
            factureShow.Children.Add(factureDetail);  
        }
        private void AddContentModal(object sender, RoutedEventArgs e)
        {
            
            if (((Button)sender).Name == "addFamily")
            {
                var addContentControl = new Addfamily();
                addContentControl.CloseModal += Add_CloseModal;
                ModalGrid.Children.Clear();
                ModalGrid.Children.Add(addContentControl);
            }
            else {
                var addContentControl = new AddProvider();
                addContentControl.CloseModal += Add_CloseModal;
                ModalGrid.Children.Clear();
                ModalGrid.Children.Add(addContentControl);
            }

        
            
            // عرض الـ Modal والطبقة الشفافة
            ModalGrid.Visibility = Visibility.Visible;
            OverlayGrid.Visibility = Visibility.Visible;

        }
          
        private void AddProduct(object sender, RoutedEventArgs e)
            {
             if (add_product.Children.Add(new AddProduct( )) != 0)
                   {
                    add_product.Children.Clear();
                   }

            }

        private void Add_CloseModal(object sender, EventArgs e)
        {
            // إخفاء الـ Modal والطبقة الشفافة
            ModalGrid.Visibility = Visibility.Collapsed;
            OverlayGrid.Visibility = Visibility.Collapsed;
        }
    }

}


 