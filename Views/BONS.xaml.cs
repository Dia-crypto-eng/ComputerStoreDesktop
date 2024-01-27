using ComputerStore.CONTROLLERS;
using ComputerStore.DATA;
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
    /// Interaction logic for BONS.xaml
    /// </summary>
    public partial class BONS : Page
    {
       
        BonsData bn = new BonsData();
        public BONS()
        {
         
            InitializeComponent();
            Bndtgd.ItemsSource = bn.GetAllBons();
        }

        public void SHOWBN (object sender , RoutedEventArgs e)
        {

            new BonsDetail().Show();

        }
        public void Show(object sender, RoutedEventArgs e)
        {

            new BonsDetail().Show();

        }

    }
}
