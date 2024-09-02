using ComputerStore.ViewModels;
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

namespace ComputerStore.Views.Clients
{
    /// <summary>
    /// Interaction logic for ClientInformation.xaml
    /// </summary>
    public partial class ClientInformation : UserControl
    {
        ProviderViewModel provider;
        public ClientInformation()
        {
            InitializeComponent();
            provider = new ProviderViewModel();
            this.DataContext = this.provider;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock1 = new TextBlock() ;
            TextBlock textBlock2 = new TextBlock();

            // الحصول على المعلومات المتعلقة بالخلية الحالية

            DataGridColumn column = Adds.GetParent<DataGridCell>(sender as TextBlock).Column;
            // للحصول على جميع الصفوف في DataGrid
            foreach (var item in InfoDataGrid.Items)
            {
                // الحصول على DataGridRow من item
                var row = (DataGridRow)InfoDataGrid.ItemContainerGenerator.ContainerFromItem(item);
                if (row != null)
                {
                    // البحث داخل هذا الصف فقط
                    textBlock1 = Adds.FindVisualChild<TextBlock>(row, "FirstName");
                    textBlock2 = Adds.FindVisualChild<TextBlock>(row, "CompanyName");
                    if (column == Adds.GetParent<DataGridCell>(textBlock1).Column)
                    {
                        textBlock1.Background = Brushes.White;
                        textBlock1.Foreground = Brushes.Black;
                        textBlock2.Background = Brushes.Black;
                        textBlock2.Foreground = Brushes.White;
                    }
                    else
                    {
                        textBlock2.Background = Brushes.White;
                        textBlock2.Foreground = Brushes.Black;
                        textBlock1.Background = Brushes.Black;
                        textBlock1.Foreground = Brushes.White;
                    }

                }
            }

            if (column != null)
            {
                // إذا تم اختيار عمود "اسم الشركة"
                if (column.Header.ToString() == "First Name")
                   {

                    //    //    // إظهار أعمدة الزبون وإخفاء أعمدة الشركة
                   
                    CRNColumn.Visibility = Visibility.Collapsed;
                    NIFColumn.Visibility = Visibility.Collapsed;
                    NISColumn.Visibility = Visibility.Collapsed;
                    LastNameColumn.Visibility = Visibility.Visible;
                    ClientEmailColumn.Visibility = Visibility.Visible;
                    ClientPhoneColumn.Visibility = Visibility.Visible;

            //    //    // لتغيير رؤية صورة الزبون أيضًا
            //    //    //var imageColumn = InfoDataGrid.Columns.OfType<DataGridTemplateColumn>().FirstOrDefault(c => c.Header.ToString() == "Client Image");
            //    //    //if (imageColumn != null)
            //    //    //{
            //    //    //    ((DataTemplate)imageColumn.CellTemplate).VisualTree.SetValue(Image.VisibilityProperty, Visibility.Visible);
            //    //    //}
                   }
                 else
                    {
                      if (column.Header.ToString() == "Company Name")
                          {
            //    //        // إظهار أعمدة الشركة وإخفاء أعمدة الزبون
                            CRNColumn.Visibility = Visibility.Visible;
                            NIFColumn.Visibility = Visibility.Visible;
                            NISColumn.Visibility = Visibility.Visible;
                            LastNameColumn.Visibility = Visibility.Collapsed;
                            ClientEmailColumn.Visibility = Visibility.Collapsed;
                            ClientPhoneColumn.Visibility = Visibility.Collapsed;

            //    //        // لتغيير رؤية صورة الزبون أيضًا
            //    //        //var imageColumn = InfoDataGrid.Columns.OfType<DataGridTemplateColumn>().FirstOrDefault(c => c.Header.ToString() == "Client Image");
            //    //        //if (imageColumn != null)
            //    //        //{
            //    //        //    ((DataTemplate)imageColumn.CellTemplate).VisualTree.SetValue(Image.VisibilityProperty, Visibility.Collapsed);
                           }
                      }
                 }
            //}

        }

     
    }
}
