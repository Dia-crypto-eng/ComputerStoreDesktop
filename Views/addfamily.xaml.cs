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

namespace ComputerStore.Views
{
    /// <summary>
    /// Interaction logic for addfamily.xaml
    /// </summary>
    public partial class Addfamily : UserControl
    {
        public Addfamily()
        {     
            InitializeComponent();
        }

        private void AddFamily(object sender, RoutedEventArgs e)
        {
            if (stt.Children.Add(new AddProduct()) != 0)
            {
                stt.Children.Clear();
            }
        }
    }
}
