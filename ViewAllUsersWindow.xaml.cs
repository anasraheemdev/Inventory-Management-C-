using MySql.Data.MySqlClient; // Required for MySQL connection
using System;
using System.Data; // For DataTable
using System.Windows;
using System.Windows.Controls;

namespace FinalDB
{

    public partial class ViewAllUsersWindow : Window
    {
        // --- Database Connection String 
        private const string ConnectionString =
            "Server=localhost;" +          
            "Port=3306;" +                 
            "Database=sultani;" +          
            "Uid=root;" +                  
            "Pwd=anas786MALIK@;";         

        public ViewAllUsersWindow()
        {
            InitializeComponent();
            PageTitle.Text = "VIEW ALL USERS"; // Set initial title for this specific window
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUsersData();
        }


        private void LoadUsersData()
        {
            DataTable usersDataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT employee_id, full_name, email_address, phone_number, username, gender, date_of_birth, address, role, status, profile_image_url FROM users";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(usersDataTable);
                        UsersDataGrid.ItemsSource = usersDataTable.DefaultView;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database Error: Could not load user data. Details: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while loading user data: {ex.Message}", "Application Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // --- Navigation Handlers (Copied from MainWindow and AddCashier) ---

        private void OpenWindowAndCloseCurrent(Window newWindow)
        {
            try
            {
                newWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new MainWindow());
        }

        private void MakeInvoice_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new Invoice());
        }

        private void Transaction_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for Transaction window. Replace with actual if you create it.
            OpenWindowAndCloseCurrent(new Invoice()); // Using Invoice as placeholder
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new AddProductPage());
        }

        private void ProductsPage_Click(object sender, RoutedEventArgs e)
        {
            // Assuming ProductsPage is your dedicated Products List/View window.
            OpenWindowAndCloseCurrent(new ProductsPage());
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new EditProduct());
        }

        private void Cashiers_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new AddCashier());
        }

        // Renamed from original AddCashier's Administrators_Click for clarity based on MainWindow context
        private void AddCashier_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new AddCashier());
        }

        // This is the current window, so it doesn't need to re-open itself, just ensure it's loaded.
        // It's included for completeness, but the button for this page is already highlighted in XAML.
        // private void ViewAllUsers_Click(object sender, RoutedEventArgs e)
        // {
        //     // Already on this page. Could refresh data if needed:
        //     // LoadUsersData();
        // }

        private void Administrators_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new LoginAsAdmin()); // Assuming LoginAsAdmin manages administrators
        }

        private void UserManager_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for a more comprehensive User Manager.
            OpenWindowAndCloseCurrent(new LoginAsAdmin()); // Using LoginAsAdmin as placeholder
        }

        private void MasterPrice_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for MasterPrice window.
            OpenWindowAndCloseCurrent(new ProductsPage()); // Using ProductsPage as placeholder
        }

        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new PurchaseRecordWindow());
        }

        // --- ADDED THIS MISSING METHOD ---
        private void PurchaseRecord_Click(object sender, RoutedEventArgs e)
        {
            // Assuming 'PurchaseRecordWindow' is the class name for your Purchase Record window.
            try
            {
                PurchaseRecordWindow purchaseRecordWindow = new PurchaseRecordWindow();
                purchaseRecordWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Purchase Record: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // --- END OF ADDED METHOD ---

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for Supplier window.
            OpenWindowAndCloseCurrent(new ProductsPage()); // Using ProductsPage as placeholder
        }

        private void StockTrackingWindow_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new StockTrackingWindow());
        }

        private void LoginAsAdmin_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new LoginAsAdmin());
        }

        private void LoginPage_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new LoginPage());
        }
    }
}