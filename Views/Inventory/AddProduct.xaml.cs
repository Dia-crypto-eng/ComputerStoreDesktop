using ComputerStore.DATA;
using ComputerStore.ViewModels;
using Microsoft.Win32;
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
    {  
        public event EventHandler CloseModal;
        internal AddProduct(ProductViewModel productViewModel)
        {
            InitializeComponent();
            this.DataContext = productViewModel;
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files(*.jpg; *.jpeg; *.png; *.bmp; *.gif)| *.jpg; *.jpeg; *.png; *.bmp; *.gif";

            // All files(*.*)| *.*| Text files(*.txt) | *.txt
            // عرض مربع الحوار للمستخدم
            if (openFileDialog.ShowDialog() == true)
            {
                // الحصول على مسار الملف الذي اختاره المستخدم
                string filePath = openFileDialog.FileName;

                // إنشاء مصدر صورة من مسار الملف
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(filePath, UriKind.Absolute);
                bitmapImage.EndInit();

                // تعيين مصدر الصورة للعنصر Image
                image1.Source = bitmapImage;

            }
        }
        private void addProduct_Close(object sender, RoutedEventArgs e)
        {
            CloseModal?.Invoke(this, EventArgs.Empty);
        }










        //private void SAVE(object sender, RoutedEventArgs e)
        //{

        // /*   product.ID_FAMILY = this.id_family;
        //    product.NAME = NAME.Text;
        //    product.CODE = CODE.Text;
        //    product.PRICE_BUY = (int)Int32.Parse( PRICE_BUY.Text);
        //    product.PRICE_SELL = (int)Int32.Parse(PRICE_SELL.Text);*/
        //    //productData.addProduct(product);
        //    //((StackPanel)Adds.GetParent<UserControl>((Button)sender).Parent).Children.Add(new AddProduct());
        //    //((StackPanel)Adds.GetParent<UserControl>((Button)sender).Parent).Children.RemoveAt(0);
        //}



    }
}
