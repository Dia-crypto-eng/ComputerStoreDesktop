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

namespace ComputerStore.Views
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : UserControl
    {   private byte id_family;
        
        public AddProduct()
        {
            this.id_family = 0;
            InitializeComponent();
        }

     

        private void SAVE(object sender, RoutedEventArgs e)
        {
            
         /*   product.ID_FAMILY = this.id_family;
            product.NAME = NAME.Text;
            product.CODE = CODE.Text;
            product.PRICE_BUY = (int)Int32.Parse( PRICE_BUY.Text);
            product.PRICE_SELL = (int)Int32.Parse(PRICE_SELL.Text);*/
            //productData.addProduct(product);
            ((StackPanel)Adds.GetParent<UserControl>((Button)sender).Parent).Children.Add(new AddProduct());
            ((StackPanel)Adds.GetParent<UserControl>((Button)sender).Parent).Children.RemoveAt(0);
        }
      

        private void FINISH(object sender, RoutedEventArgs e)
        {
            if (((Window)Adds.GetParent<Window>((Button)sender)).Name == "addfml") Adds.GetParent<Window>((Button)sender).Close();
            ((StackPanel)Adds.GetParent<UserControl>((Button)sender).Parent).Children.Clear() ;
            
        }
        
        
    }
}
