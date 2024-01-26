using System;
using System.Collections.Generic;
using System.Linq;
using ComputerStore.DATA;
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
using ComputerStore.ENTITY;

namespace ComputerStore.CONTROLLERS
{
    /// <summary>
    /// Interaction logic for familyDetail.xaml
    /// </summary>
    public partial class FamilyDetail : UserControl
    {
        public List<ProductList> ListProduct { get; set; }
        int Id_family;
        private string[] nameProduct;
        private readonly string nbtn;
        


        public FamilyDetail(int Id_family)
        {
            this.Id_family = Id_family;
            ListProduct = new List<ProductList>();
         //   this.nbtn = familyData.getAllFamily(firebaseClient).Result.ElementAt(Id_family);
            InitializeComponent();
           // mop(prot);
            Lip();
            this.DataContext = this;

          

        }
    /*    private void mop(List<Product> proto)
        {
            nameProduct = new string[proto.Count];
            for (int i = proto.Count - 1; i >= 0; i--)
            {
               // nameProduct[i] = proto.ElementAt(i).NAME;
                Console.WriteLine(nameProduct[i]);
            }
        }*/
        private void Lip()
        {
            ryra.Content = this.nbtn;
            int i = 0;
            foreach (string S in this.nameProduct)
            {
                ListProduct.Add(new ProductList() { Name = S });
                i++;
            }

        }
        public class ProductList
        {
            public string Name { get; set; }
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
