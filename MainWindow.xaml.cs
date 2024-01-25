using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
        public partial class MainWindow : Window
        {






            private List<itemHome> listHome;
            public MainWindow()
            {

                InitializeComponent();

                listHome = new List<itemHome>(){new itemHome { Icon = "NoteOutline", Name = "Facture" },
                                            new itemHome { Icon = "FileAccount", Name = "Bon" },
                                            new itemHome { Icon = "User", Name = "Client"},
                                            new itemHome { Icon = "Storage", Name = "Stock"} ,
                                            new itemHome { Icon = "Tools", Name = "Panne"},
                                            new itemHome { Icon = "ExitToApp", Name = "Exit"}  };
                this.DataContext = this;
            }
            public List<itemHome> ListHome
            {
                get
                { return listHome; }
            }
            public class itemHome
            {
                public string Icon { get; set; }
                public string Name { get; set; }
            }


            public int derat(int a)
            {
                if (a > 3) return 0;
                return 1;
            }



            private void Call(object sender, RoutedEventArgs e)
            {
                string S = ((TextBlock)VisualTreeHelper.GetChild((StackPanel)sender, 1)).Text;
                /*switch (s)
                {
                    case "facture":
                        home.content = new facture();

                        break;
                    case "bon":
                        home.content = new bons();
                        break;
                    case "client":
                        home.content = new client();
                        break;
                    case "stock":
                        home.content = new stock();
                        break;
                    case "panne":
                        home.content = new panne();
                        break;
                    case "exit":
                        close();
                        break;

                }*/



            }

        }
    }

