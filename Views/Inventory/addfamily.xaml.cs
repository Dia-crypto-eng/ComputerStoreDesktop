using ComputerStore.ViewModels;
using ComputerStore.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public event EventHandler CloseModal;
        private ProductViewModel productViewModel;
  
        public Addfamily()
        {     
            InitializeComponent();
            productViewModel = new ProductViewModel();
            DataContext = productViewModel;
            AddProductGrid.Children.Add(new AddProduct(productViewModel));
        }

        // Event handler for the KeyDown event
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Add the text to the ListView and clear the TextBox
                productViewModel.addPropriety.Execute(null);
                InputTextBox.Clear();
                // Optionally, you can set focus back to the TextBox
                InputTextBox.Focus();
            }
        }

        private void addFamily_Close(object sender, RoutedEventArgs e)
        {
            CloseModal?.Invoke(this, EventArgs.Empty);
        }

        
    }
}
