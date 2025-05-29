using MySql.Data.MySqlClient;
using System;
using System.Windows;
using BCrypt.Net; // Add this using directive for BCrypt.Net

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        // Database connection string (ensure this matches your database setup)
        private const string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=sultani;" +
            "Uid=root;" +
            "Pwd=anas786MALIK@;"; // IMPORTANT: In a real application, avoid hardcoding passwords.

        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the Login button.
        /// Authenticates the user against the database and navigates to the MainWindow on success.
        /// </summary>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Get username and password from the input fields
            string username = UsernameTextBox.Text.Trim();
            string enteredPassword = PasswordBox.Password.Trim(); // Get the plain-text password

            // Basic input validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string storedPasswordHash = string.Empty;
            int loggedInUserId = -1; // To store the user_id if login is successful

            // Establish a database connection
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open(); // Open the database connection

                    // SQL query to retrieve password hash and user_id for the given username
                    // LIMIT 1 is used to ensure only one record is fetched, improving efficiency
                    string query = "SELECT user_id, password_hash FROM users WHERE username = @username LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@username", username);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if a user with the given username exists
                            if (reader.Read())
                            {
                                // Retrieve the stored hashed password from the database
                                loggedInUserId = reader.GetInt32("user_id");
                                storedPasswordHash = reader.GetString("password_hash");
                            }
                            else
                            {
                                // User not found in the database
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                                return; // Exit the method
                            }
                        }
                    }

                    // Now, verify the entered password against the stored hash using BCrypt
                    // BCrypt.Net.BCrypt.Verify handles the hashing and comparison internally
                    if (BCrypt.Net.BCrypt.Verify(enteredPassword, storedPasswordHash))
                    {
                        // Authentication successful
                        MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Navigate to the MainWindow
                        Invoice invoice = new Invoice();
                        invoice.Show();
                        this.Close(); // Close the current MainWindow
                    }
                    else
                    {
                        // Password mismatch
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    // Handle specific MySQL database errors
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    // Handle any other unexpected errors
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
