using MySql.Data.MySqlClient; // Required for MySQL connection
using System;
using System.IO; // For file operations
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging; // For displaying images
using Microsoft.Win32; // For OpenFileDialog
using BCrypt.Net; // Required for BCrypt password hashing (install via NuGet)

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for AddCashier.xaml
    /// </summary>
    public partial class AddCashier : Window
    {
        // --- Database Connection String ---
        // IMPORTANT: Using 'root' with a password directly in code is NOT recommended for production apps.
        // Create a dedicated MySQL user with minimal required privileges for your application.
        private const string ConnectionString =
            "Server=localhost;" +          // Your MySQL server address (e.g., localhost, IP address)
            "Port=3306;" +                 // MySQL port (default is 3306)
            "Database=sultani;" +          // The database name you provided: 'sultani'
            "Uid=root;" +                  // Your MySQL user (e.g., root)
            "Pwd=anas786MALIK@;";          // Your MySQL user's password (replace with your actual strong password)

        private string _selectedLocalImagePath; // Stores the relative path to the image saved locally.

        public AddCashier()
        {
            InitializeComponent();
            // Optionally set initial ComboBox selections if not handled by XAML IsSelected=True
            // cmbUserRole.SelectedIndex = 0; // "Select Role" or first actual item
            // cmbGender.SelectedIndex = 0;    // "Select Gender" or first actual item
            // cmbStatus.SelectedIndex = 0;    // "Active" or first actual item
        }

        // --- Original Sidebar Navigation Handlers (FULLY RESTORED) ---

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a MainWindow that serves as the dashboard.
            // Ensure MainWindow.xaml and MainWindow.xaml.cs exist and are Window types.
            // Replace 'MainWindow' with the actual class name of your dashboard window if different.
            try
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close(); // Close the current AddCashier window
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Dashboard: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MakeInvoice_Click(object sender, RoutedEventArgs e)
        {
            // Assuming 'Invoice' is the class name for your Make Invoice window.
            try
            {
                Invoice invoiceWindow = new Invoice();
                invoiceWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Make Invoice: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Transaction_Click(object sender, RoutedEventArgs e)
        {
            // Assuming 'TransactionWindow' (or similar) exists. If not, create it.
            // As a placeholder, I'll keep the Invoice reference from your original code comment,
            // but you should replace it with your actual Transaction window.
            try
            {
                // TransactionWindow transactionWindow = new TransactionWindow(); // Uncomment and use your actual TransactionWindow
                // transactionWindow.Show();
                Invoice transactionWindow = new Invoice(); // Placeholder as per your original code
                transactionWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Transaction: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            // Assuming 'AddProductPage' is the class name for your Add Item window.
            try
            {
                AddProductPage addProductPageWindow = new AddProductPage();
                addProductPageWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Add Item: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            // Assuming 'PurchaseRecordWindow' handles purchase orders or is the relevant window.
            try
            {
                PurchaseRecordWindow purchaseOrderWindow = new PurchaseRecordWindow();
                purchaseOrderWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Purchase Order: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

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

        private void Administrators_Click(object sender, RoutedEventArgs e)
        {
            // Assuming 'LoginAsAdmin' or a dedicated Admin window for managing administrators.
            try
            {
                LoginAsAdmin loginAsAdminWindow = new LoginAsAdmin();
                loginAsAdminWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Administrators: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UserManager_Click(object sender, RoutedEventArgs e)
        {
            // This button might lead to a more comprehensive user management window.
            // Using 'LoginAsAdmin' as a placeholder if no dedicated 'UserManagerWindow' exists.
            try
            {
                // UserManagerWindow userManagerWindow = new UserManagerWindow(); // Use your actual UserManagerWindow
                // userManagerWindow.Show();
                LoginAsAdmin userManagerWindow = new LoginAsAdmin(); // Placeholder
                userManagerWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to User Manager: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // --- NEW: Handler for "View All Users" button ---
        private void ViewAllUsers_Click(object sender, RoutedEventArgs e)
        {
            // You need to replace 'ViewAllUsersWindow' with the actual name of your window
            // that displays all users. If you don't have one, create a new WPF Window
            // named, for example, 'ViewAllUsersWindow.xaml' and 'ViewAllUsersWindow.xaml.cs'.
            try
            {
                // This is a placeholder. Replace 'ViewAllUsersWindow' with your actual window class.
                ViewAllUsersWindow viewAllUsersWindow = new ViewAllUsersWindow();
                viewAllUsersWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to View All Users: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // --- Image Selection Logic (NEW/UPDATED) ---
        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Filter for common image file types
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
            openFileDialog.Title = "Select Profile Image";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string sourceFilePath = openFileDialog.FileName;
                    string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string profileImagesFolder = Path.Combine(appDirectory, "ProfileImages");

                    // Ensure the ProfileImages directory exists
                    if (!Directory.Exists(profileImagesFolder))
                    {
                        Directory.CreateDirectory(profileImagesFolder);
                    }

                    // Create a unique file name to avoid conflicts
                    string fileName = Path.GetFileName(sourceFilePath);
                    string uniqueFileName = $"{Guid.NewGuid().ToString()}_{fileName}";
                    string destinationFilePath = Path.Combine(profileImagesFolder, uniqueFileName);

                    // Copy the file to the local application folder
                    File.Copy(sourceFilePath, destinationFilePath, true);

                    // Store the relative path to be saved in the database
                    // This path will be "ProfileImages\unique_file_name.ext"
                    _selectedLocalImagePath = Path.Combine("ProfileImages", uniqueFileName);

                    // Display the image in the UI
                    Uri fileUri = new Uri(destinationFilePath);
                    imgProfile.Source = new BitmapImage(fileUri);
                    imgProfile.Visibility = Visibility.Visible;       // Show the Image control
                    txtProfileIcon.Visibility = Visibility.Collapsed; // Hide the default icon

                    MessageBox.Show("Image selected and saved locally!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting or saving image: {ex.Message}", "Image Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    _selectedLocalImagePath = null; // Clear path on error
                    imgProfile.Source = null; // Clear displayed image
                    imgProfile.Visibility = Visibility.Collapsed; // Hide image
                    txtProfileIcon.Visibility = Visibility.Visible; // Show the icon again
                }
            }
        }

        // --- User Saving Logic (UPDATED) ---
        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            // 1. Get data from input fields and trim whitespace
            string employeeId = txtUserId.Text.Trim(); // Mapping txtUserId to employee_id
            string fullName = txtFullName.Text.Trim();
            string emailAddress = txtEmailAddress.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string username = txtUsername.Text.Trim();
            string plainPassword = pwdPassword.Password;
            string confirmPassword = pwdConfirmPassword.Password;

            // Get selected items from ComboBoxes. Handle null if nothing selected.
            // Using a safe cast to ComboBoxItem and then checking its Content.
            string userRole = (cmbUserRole.SelectedItem as ComboBoxItem)?.Content.ToString();
            string gender = (cmbGender.SelectedItem as ComboBoxItem)?.Content.ToString();
            string status = (cmbStatus.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime? dateOfBirth = dpDateOfBirth.SelectedDate; // Nullable DateTime
            string address = txtAddress.Text.Trim();

            // Use the path from the selected image, if any
            string profileImageUrl = _selectedLocalImagePath;

            // 2. Basic Validation
            // Check required fields (marked with *) - corresponds to NOT NULL in DB schema
            if (string.IsNullOrWhiteSpace(employeeId) ||
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(emailAddress) ||
                string.IsNullOrWhiteSpace(phoneNumber) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(plainPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all required text fields marked with *.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate ComboBox selections for 'role' and 'status' as they are NOT NULL in DB
            if (userRole == "Select Role" || string.IsNullOrWhiteSpace(userRole))
            {
                MessageBox.Show("Please select a valid User Role (Cashier or Admin).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (status == null || (status != "Active" && status != "Inactive" && status != "Suspended"))
            {
                // This check assumes cmbStatus contains only "Active", "Inactive", "Suspended" or a default "Select Status"
                MessageBox.Show("Please select a valid Status (Active, Inactive, or Suspended).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Gender is nullable in DB, so 'Select Gender' or empty string can be treated as null.
            if (gender == "Select Gender" || string.IsNullOrWhiteSpace(gender))
            {
                gender = null; // Set to null for DB if "Select Gender" was selected or field was empty
            }

            // Password matching validation
            if (plainPassword != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                pwdPassword.Clear(); // Clear passwords for security
                pwdConfirmPassword.Clear();
                pwdPassword.Focus(); // Set focus back to password field
                return;
            }

            // Basic email format validation (can be more robust with Regex)
            if (!emailAddress.Contains("@") || !emailAddress.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 3. Hash the password before storing (BCrypt.Net-Core)
            // Using a work factor of 12 for good security, adjust if performance is an issue on slower systems.
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword, workFactor: 12);

            // 4. Prepare SQL INSERT statement with parameters
            string query = @"
                INSERT INTO users (
                    employee_id, full_name, email_address, phone_number,
                    username, password_hash, gender, date_of_birth,
                    address, role, status, profile_image_url
                ) VALUES (
                    @EmployeeId, @FullName, @EmailAddress, @PhoneNumber,
                    @Username, @PasswordHash, @Gender, @DateOfBirth,
                    @Address, @Role, @Status, @ProfileImageUrl
                )";

            // 5. Establish connection and execute command
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open(); // Open the database connection

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to the command. Use DBNull.Value for nullable fields if they are empty.
                        command.Parameters.AddWithValue("@EmployeeId", employeeId);
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@EmailAddress", emailAddress);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                        // Handle nullable fields (Gender, DateOfBirth, Address, ProfileImageUrl)
                        command.Parameters.AddWithValue("@Gender", gender == null ? DBNull.Value : (object)gender);
                        command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth.HasValue ? (object)dateOfBirth.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(address) ? DBNull.Value : (object)address);
                        command.Parameters.AddWithValue("@Role", userRole); // role is NOT NULL in DB
                        command.Parameters.AddWithValue("@Status", status); // status is NOT NULL in DB
                        command.Parameters.AddWithValue("@ProfileImageUrl", string.IsNullOrWhiteSpace(profileImageUrl) ? DBNull.Value : (object)profileImageUrl);

                        int rowsAffected = command.ExecuteNonQuery(); // Execute the INSERT command

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"User '{fullName}' ({userRole}) added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            ClearFormFields(); // Clear the form after successful insertion
                        }
                        else
                        {
                            MessageBox.Show("Failed to add user. No rows affected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Handle specific MySQL errors for unique constraints (Error Code 1062)
                    if (ex.Number == 1062)
                    {
                        if (ex.Message.ToLower().Contains("employee_id"))
                        {
                            MessageBox.Show("Error: Employee ID already exists. Please use a unique ID.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if (ex.Message.ToLower().Contains("email_address"))
                        {
                            MessageBox.Show("Error: Email address already exists. Please use a unique email.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if (ex.Message.ToLower().Contains("username"))
                        {
                            MessageBox.Show("Error: Username already exists. Please choose a different username.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            // Catch-all for other unique constraint violations
                            MessageBox.Show($"Database Error: Duplicate entry detected. Details: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        // Handle other types of MySQL errors (e.g., connection issues, table not found)
                        MessageBox.Show($"Database Error: An unexpected database error occurred. Details: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Catch-all for any other unexpected application errors
                    MessageBox.Show($"An unexpected application error occurred: {ex.Message}", "Application Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } // The 'using' statement ensures the connection is closed automatically
        }

        // --- Form Reset Logic (UPDATED) ---
        private void ClearFormFields()
        {
            txtUserId.Clear();
            txtFullName.Clear();
            txtEmailAddress.Clear();
            txtPhoneNumber.Clear();
            txtUsername.Clear();
            pwdPassword.Clear();
            pwdConfirmPassword.Clear();

            // Reset ComboBoxes to initial state (e.g., first item or specific default)
            cmbUserRole.SelectedIndex = 0; // Assuming "Select Role" is at index 0 or first actual item
            cmbGender.SelectedIndex = 0;    // Assuming "Select Gender" is at index 0 or first actual item
            cmbStatus.SelectedIndex = 0;    // Assuming "Active" is at index 0 or first actual item

            dpDateOfBirth.SelectedDate = null; // Clear selected date
            txtAddress.Clear();

            // Clear the selected image and show the default icon
            _selectedLocalImagePath = null; // Clear the stored image path
            imgProfile.Source = null; // Clear the displayed image
            imgProfile.Visibility = Visibility.Collapsed; // Hide the Image control
            txtProfileIcon.Visibility = Visibility.Visible; // Show the default icon
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // As per your original logic, navigating to Dashboard upon Cancel.
            Dashboard_Click(sender, e);
        }
    }
}