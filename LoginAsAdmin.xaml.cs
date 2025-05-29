using MySql.Data.MySqlClient;
using System;
using System.Windows;
using BCrypt.Net; // Add this using directive for BCrypt.Net

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for LoginAsAdmin.xaml
    /// </summary>
    public partial class LoginAsAdmin : Window
    {
        // Database connection string
        private const string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=sultani;" +
            "Uid=root;" +
            "Pwd=anas786MALIK@;";

        public LoginAsAdmin()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string enteredPassword = PasswordBox.Password.Trim(); // Get the plain-text password entered by the user

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string storedPasswordHash = string.Empty;
            bool isAdmin = false;

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    // Query to retrieve the password hash and role for the given username
                    // We retrieve the hash and role first, then verify the password in application memory
                    string query = "SELECT password_hash, role FROM users WHERE username = @username LIMIT 1"; 
                    
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                storedPasswordHash = reader.GetString("password_hash");
                                isAdmin = reader.GetString("role").Equals("Admin", StringComparison.OrdinalIgnoreCase);
                            }
                            else
                            {
                                // User not found
                                MessageBox.Show("Invalid username or password, or user is not an administrator.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }
                    }

                    // Now, verify the entered password against the stored hash
                    // BCrypt.Net.BCrypt.Verify() handles comparing the plain text password with the hash
                    if (BCrypt.Net.BCrypt.Verify(enteredPassword, storedPasswordHash) && isAdmin)
                    {
                        // Login successful and user is an Admin
                        MessageBox.Show("Admin login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                        // Navigate to the Admin Dashboard or main window
                        // Assuming you have an AdminDashboard window. If not, change to MainWindow or appropriate window.
                        MainWindow mainWindow = new MainWindow(); // Replace with your actual admin dashboard/main window
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        // Password mismatch or not an Admin
                        MessageBox.Show("Invalid username or password, or user is not an administrator.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}