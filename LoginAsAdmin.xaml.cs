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
    /// Interaction logic for LoginAsAdmin.xaml
    /// </summary>
    public partial class LoginAsAdmin : Window
    {
        public LoginAsAdmin()
        {
            InitializeComponent();
        }

        // Event handler - no logic inside, just definition
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your login button click logic here
            // For example:
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Validate credentials and navigate to the next page if successful
            // if (IsValidUser(username, password))
            // {
            //     MainWindow mainWindow = new MainWindow(); // Replace MainWindow with your actual next window
            //     mainWindow.Show();
            //     this.Close();
            // }
            // else
            // {
            //     MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            // }
            MainWindow mainWindow = new MainWindow(); // Replace MainWindow with your actual next window
            mainWindow.Show();
            this.Close();
        }
    }
}