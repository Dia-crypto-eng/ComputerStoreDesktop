
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
using GalaSoft.MvvmLight.Messaging;

namespace ComputerStore.Views
{
    /// <summary>
    /// Interaction logic for addFacture.xaml
    /// </summary>
    public partial class addFacture : UserControl
    {
        private BuyInvoiceViewModel buyInvoiceViewModel;
        internal addFacture()
        {
            InitializeComponent();
            this.buyInvoiceViewModel =new BuyInvoiceViewModel();
            this.DataContext = this.buyInvoiceViewModel;
            Viewbox factureDetail = new Viewbox
            {
                Width = 371,  // العرض المصغر
                Height = 526, // الارتفاع المصغر
                Child = new FactureDetail() // إضافة الـ UserControl إلى الـ Viewbox
            };
            factureShow.Child = factureDetail;
        }
        private void AddFamilyModal(object sender, RoutedEventArgs e)
        {
            var addContentControl = new Addfamily();
            addContentControl.CloseModal += Add_CloseModal;
            ModalGrid.Children.Clear();
            ModalGrid.Children.Add(addContentControl);
            // عرض الـ Modal والطبقة الشفافة
            ModalGrid.Visibility = Visibility.Visible;
            OverlayGrid.Visibility = Visibility.Visible;
        }
        private void AddProductModal(object sender, RoutedEventArgs e)
        {
            var addContentControl = new AddProduct(((BuyInvoiceViewModel)this.DataContext).Product);
            addContentControl.CloseModal += Add_CloseModal;
            ModalGrid.Children.Clear();
            ModalGrid.Children.Add(addContentControl);
            // عرض الـ Modal والطبقة الشفافة
            ModalGrid.Visibility = Visibility.Visible;
            OverlayGrid.Visibility = Visibility.Visible;
        }
        private void AddProviderModal(object sender, RoutedEventArgs e)
        {
            var addContentControl = new AddProvider();
            addContentControl.CloseModal += Add_CloseModal;
            ModalGrid.Children.Clear();
            ModalGrid.Children.Add(addContentControl);
            // عرض الـ Modal والطبقة الشفافة
            ModalGrid.Visibility = Visibility.Visible;
            OverlayGrid.Visibility = Visibility.Visible;
        }

        private void Add_CloseModal(object sender, EventArgs e)
        {
            // إخفاء الـ Modal والطبقة الشفافة
            ModalGrid.Visibility = Visibility.Collapsed;
            OverlayGrid.Visibility = Visibility.Collapsed;
        }

    }

}


 