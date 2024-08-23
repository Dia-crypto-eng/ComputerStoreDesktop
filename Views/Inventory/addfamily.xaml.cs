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
        public ObservableCollection<string> Properties { get; set; }
        public Addfamily()
        {     
            InitializeComponent();
            // Initialize the collection and bind it to the ListView
            Properties = new ObservableCollection<string>();
            ItemsListView.ItemsSource = Properties;
        }

        // Event handler for the KeyDown event
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Add the text to the ListView and clear the TextBox
                Properties.Add(InputTextBox.Text);
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
