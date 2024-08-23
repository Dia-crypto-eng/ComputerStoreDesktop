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
using static System.Net.Mime.MediaTypeNames;

namespace ComputerStore.Views.Clients
{
    /// <summary>
    /// Interaction logic for AddProvider.xaml
    /// </summary>
    public partial class AddProvider : UserControl
    {
        public event EventHandler CloseModal;
  
        public AddProvider()
        {
            InitializeComponent();
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

        private void addProvider_Close(object sender, RoutedEventArgs e)
        {
            CloseModal?.Invoke(this, EventArgs.Empty);
        }


    }
}
