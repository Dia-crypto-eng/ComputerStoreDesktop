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
using System.Windows.Shapes;

namespace ComputerStore.CONTROLLERS
{
    /// <summary>
    /// Interaction logic for BonsDetail.xaml
    /// </summary>
    public partial class BonsDetail : Window
    {
        BonsData Bnsdata = new BonsData();
        public BonsDetail()
        {
            InitializeComponent();
            BonTable.ItemsSource = Bnsdata.GetBons();
        }
       /* void ShowbOn(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var row = GetParent<DataGridRow>((Button)sender);
            var index = BonTable.Items.IndexOf(row.Item);

            BonsDetail factureDetail = new BonsDetail();
            BonsDetail.ShowDialog();

        }*/
    }
}
