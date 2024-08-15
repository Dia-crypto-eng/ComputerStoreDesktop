using ComputerStore.Views.Clients;
using ComputerStore.Views.Invoices;
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

namespace ComputerStore
{
    /// <summary>
    /// Interaction logic for MenuControl.xaml
    /// </summary>
    public partial class MenuControl : UserControl
    {
        private List<itemHome> listHome1;
        public MenuControl()
        {
            InitializeComponent();

            listHome1 = new List<itemHome>(){
                                           new itemHome { Icon = "Home", Name = "Home" },
                                           new itemHome { Icon = "FileTableOutline", Name = "Invoices" ,
                                                          SubItems=new List<subItem> (){new subItem{ Name = "buy",User =new BuyInvoice() },
                                                                                         new subItem{ Name = "sell" ,User =new SellInvoice()} }
                                                        },
                                           new itemHome { Icon = "AccountGroup", Name = "Clients",
                                                          SubItems=new List<subItem> (){new subItem{ Name = "customer" , User =new Clients() },
                                                                                         new subItem{ Name = "provider" },
                                                                                         new subItem{ Name = "notice" } }
                                                        },
                                           new itemHome { Icon = "PackageVariantClosed", Name = "Inventory"} ,
                                           new itemHome { Icon = "Finance", Name = "Reports"} ,
                                           new itemHome { Icon = "Truck", Name = "Delivery"},
                                        
            };

            HomeMenu.ItemsSource = listHome1;

        }

        public static readonly DependencyProperty MyGridProperty =
            DependencyProperty.Register("MyGrid", typeof(Grid), typeof(MenuControl), new PropertyMetadata(null));

        public Grid MyGrid
        {
            get { return (Grid)GetValue(MyGridProperty); }
            set { SetValue(MyGridProperty, value); }
        }

        private void ChoosePage(object sender, SelectionChangedEventArgs e)
        {
            UserControl page = ((subItem)((ListView)sender).SelectedItem).User;
            if (page != null)
            {
                MyGrid.Children.Clear();
                MyGrid.Children.Add(page);
            }

        }
        private void HomeMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg.IsChecked = false;

            // العثور على الـ Grid في الـ StackPanel
            StackPanel stackPanel = sender as StackPanel;
            Grid expanderGrid = stackPanel.FindName("expander") as Grid;
            StackPanel headerGrid = stackPanel.FindName("header") as StackPanel;
            PackIcon icon = (PackIcon)headerGrid.FindName("StateButton");
            // إغلاق جميع العناصر الأخرى في الـ ListView
            foreach (var item in HomeMenu.Items)
            {
                ListViewItem listViewItem = HomeMenu.ItemContainerGenerator.ContainerFromItem(item) as ListViewItem;
                if (listViewItem != null)
                {
                    StackPanel panel = Adds.FindVisualChild<StackPanel>(listViewItem, "header");
                    Grid expandersGrid = Adds.FindVisualChild<Grid>(listViewItem, "expander");
                    PackIcon icons = Adds.FindVisualChild<PackIcon>(panel, "StateButton");

                    if (expandersGrid != null && expandersGrid != expanderGrid && expandersGrid.Visibility == Visibility.Visible)
                    {
                        expandersGrid.Visibility = Visibility.Collapsed;
                        icons.Kind = PackIconKind.ChevronDown;
                    }
                }
            }
           
            if (expanderGrid != null)
            {
                // تغيير الـ Visibility الخاص بالـ Grid
                expanderGrid.Visibility = expanderGrid.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
                icon.Kind = icon.Kind == PackIconKind.ChevronDown ? PackIconKind.ChevronUp : PackIconKind.ChevronDown;
            }
          
        }

        private void Tg_Click(object sender, RoutedEventArgs e)
        {
            if(Tg.IsChecked == true)
            {
                HomeMenu.ItemsSource = null;
                HomeMenu.ItemsSource = listHome1;

            }
        }
    }

    public class itemHome
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public List<subItem> SubItems { get; set; }
    }

    public class subItem
    {
        public string Name { get; set; }
        public UserControl User { get; set; }
    }
}
