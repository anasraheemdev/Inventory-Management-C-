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

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for HomeLoginAs.xaml
    /// </summary>
    public partial class HomeLoginAs : Window // THIS IS THE CRUCIAL CHANGE: Change from : Page to : Window
    {
        public HomeLoginAs()
        {
            InitializeComponent();
        }

        private void CashierLogin_Click(object sender, RoutedEventArgs e)
        {
            // Assuming 'LoginPage' is where general cashier login happens
            LoginPage loginPageWindow = new LoginPage();
            loginPageWindow.Show();
            this.Close(); // Close the current HomeLoginAs window
        }

        private void AdminLogin_Click(object sender, RoutedEventArgs e)
        {
            // Assuming 'LoginAsAdmin' is the specific admin login window
            LoginAsAdmin loginAsAdminWindow = new LoginAsAdmin();
            loginAsAdminWindow.Show();
            this.Close(); // Close the current HomeLoginAs window
        }
    }
}