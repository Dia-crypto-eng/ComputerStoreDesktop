using ComputerStore.Views.Clients;
using ComputerStore.Views.Inventory;
using ComputerStore.Views.Invoices;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
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
using System.Xml.XPath;

namespace ComputerStore
{
    /// <summary>
    /// Interaction logic for MenuControl.xaml
    /// </summary>
    public partial class MenuControl : UserControl
    {
        private UserControl page = new UserControl();
        private List<itemHome> listHome1;
        public MenuControl()
        {
            InitializeComponent();

            listHome1 = new List<itemHome>(){
                                           new itemHome{ Icon="ChartBar",Name="analysis" ,
                                                          SubItems={ "Dashboard", "Operating Expenses" }},
                                           new itemHome { Icon = "FileTableOutline", Name = "Invoices" ,
                                                          SubItems={ "View Invoices", "View Returns" }
                                                        },
                                           new itemHome { Icon = "Finance", Name = "Reports" ,
                                                          SubItems={ "Sales", "Purchase", "Inventory" , "Customer" } 
                                                        } ,
                                           new itemHome { Icon = "AccountGroup", Name = "Clients",
                                                          SubItems={ "Financial Status", "Information" } 
                                                        },
                                           new itemHome { Icon = "PackageVariantClosed", Name = "Inventory",
                                                          SubItems={ "View Inventory", "Damaged Goods" } 
                                                        } ,
                                           
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
            // احفظ العنصر المحدد الحالي قبل إعادة تعيين ItemsSource
            var selectedItem = ((ListView)sender).SelectedItem;

            // تأكد أن العنصر المحدد ليس null قبل محاولة الوصول إلى خصائصه
            if (selectedItem != null)
            {
                switch (selectedItem)
                {
                    case "View Invoices":
                        { page = new BuyInvoice(); }
                    break;
                    case "View Returns":
                        { page = new SellInvoice(); }
                    break;
                    case "Financial Status":
                        { page = new  Clients(); }
                        break;
                    case "View Inventory":
                        { page = new Inventory(); }
                        break;
                    case "Damaged Goods":
                        { page = new Damaged(); }
                        break;
                    case "Information":
                        { page = new ClientInformation(); }
                        break;




                        
                }
               
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
                foreach (var item in HomeMenu.Items)
                {
                    ListViewItem listViewItem = HomeMenu.ItemContainerGenerator.ContainerFromItem(item) as ListViewItem;
                    if (listViewItem != null)
                    {
                        StackPanel panel = Adds.FindVisualChild<StackPanel>(listViewItem, "header");
                        Grid expandersGrid = Adds.FindVisualChild<Grid>(listViewItem, "expander");
                        PackIcon icons = Adds.FindVisualChild<PackIcon>(panel, "StateButton");

                        if (expandersGrid != null  && expandersGrid.Visibility == Visibility.Visible)
                        {
                            expandersGrid.Visibility = Visibility.Collapsed;
                            icons.Kind = PackIconKind.ChevronDown;
                        }
                    }
                }

            }
        }
    }

    public class itemHome
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public List<string> SubItems { get; set; }
        public itemHome() { 
        SubItems = new List<string>();
        }
    }


}
