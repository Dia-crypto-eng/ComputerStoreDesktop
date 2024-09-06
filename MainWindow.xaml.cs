using System;
using System.Collections.Generic;
using ComputerStore.Views;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using ComputerStore.Views.Invoices;
using MaterialDesignThemes.Wpf;
using ComputerStore.Views.Clients;
using ComputerStore.Views.Inventory;
using System.Windows.Media.Animation;
using System.Windows.Markup;
using System.Collections;
using ComputerStore.Cache;

namespace ComputerStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

       
        public MainWindow()
        {

            InitializeComponent();
            var cacheManager = CreateCache.Instance.InvoiceCache;

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left  )
            {
                this.DragMove();
            }

        }

        private bool isMaximized =false ;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2 ) 
            { 
                if(isMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    isMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    isMaximized = true;
                }
            
            }   

        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        
    }

  

}

