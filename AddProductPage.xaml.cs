using MySql.Data.MySqlClient; // Required for MySQL connection
using System;
using System.IO; // For file operations
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging; // For displaying images
using Microsoft.Win32; // For OpenFileDialog
using System.Text.RegularExpressions; // For input validation (e.g., numbers)
using System.Data; // For DataTable, if needed for ComboBox population
using System.Windows.Input;

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Window
    {
        // --- Database Connection String ---
        private const string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=sultani;" +
            "Uid=root;" +
            "Pwd=anas786MALIK@;";

        private string _selectedLocalImagePath; // Stores the relative path to the image saved locally.

        public AddProductPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populates the Category and Brand ComboBoxes when the window loads.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoriesIntoComboBox();
            LoadBrandsIntoComboBox();
        }

        /// <summary>
        /// Populates the cmbCategory ComboBox from the 'categories' table.
        /// </summary>
        private void LoadCategoriesIntoComboBox()
        {
            cmbCategory.Items.Clear(); // Clear existing items
            cmbCategory.Items.Add(new ComboBoxItem { Content = "Select Category", IsSelected = true, Tag = -1 }); // Default item

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT category_id, category_name FROM categories ORDER BY category_name";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbCategory.Items.Add(new ComboBoxItem
                        {
                            Content = reader["category_name"].ToString(),
                            Tag = reader["category_id"] // Store the ID in the Tag
                        });
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database Error loading categories: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred loading categories: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Populates the cmbBrand ComboBox from the 'brands' table.
        /// </summary>
        private void LoadBrandsIntoComboBox()
        {
            cmbBrand.Items.Clear(); // Clear existing items
            cmbBrand.Items.Add(new ComboBoxItem { Content = "Select Brand", IsSelected = true, Tag = -1 }); // Default item

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT brand_id, brand_name FROM brands ORDER BY brand_name";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbBrand.Items.Add(new ComboBoxItem
                        {
                            Content = reader["brand_name"].ToString(),
                            Tag = reader["brand_id"] // Store the ID in the Tag
                        });
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database Error loading brands: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred loading brands: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        // --- Image Selection Logic ---
        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
            openFileDialog.Title = "Select Product Image";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string sourceFilePath = openFileDialog.FileName;
                    string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string productImagesFolder = Path.Combine(appDirectory, "ProductImages");

                    if (!Directory.Exists(productImagesFolder))
                    {
                        Directory.CreateDirectory(productImagesFolder);
                    }

                    string fileName = Path.GetFileName(sourceFilePath);
                    string uniqueFileName = $"{Guid.NewGuid().ToString()}_{fileName}";
                    string destinationFilePath = Path.Combine(productImagesFolder, uniqueFileName);

                    File.Copy(sourceFilePath, destinationFilePath, true);

                    _selectedLocalImagePath = Path.Combine("ProductImages", uniqueFileName);

                    Uri fileUri = new Uri(destinationFilePath);
                    imgProduct.Source = new BitmapImage(fileUri);
                    imgProduct.Visibility = Visibility.Visible;
                    panelImagePlaceholder.Visibility = Visibility.Collapsed; // Hide the placeholder stack panel

                    MessageBox.Show("Image selected and saved locally!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting or saving image: {ex.Message}", "Image Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    _selectedLocalImagePath = null;
                    imgProduct.Source = null;
                    imgProduct.Visibility = Visibility.Collapsed;
                    panelImagePlaceholder.Visibility = Visibility.Visible;
                }
            }
        }

        // --- Data Saving Logic ---
        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            // 1. Get data from input fields and trim whitespace
            string productName = txtProductName.Text.Trim();
            string productCode = txtProductCode.Text.Trim();
            string barcode = txtBarcode.Text.Trim();
            string description = txtDescription.Text.Trim();
            string productImageUrl = _selectedLocalImagePath; // Use the path from the selected image

            // Get selected IDs from ComboBoxes
            int? categoryId = (cmbCategory.SelectedItem as ComboBoxItem)?.Tag as int?;
            int? brandId = (cmbBrand.SelectedItem as ComboBoxItem)?.Tag as int?;

            string unit = (cmbUnit.SelectedItem as ComboBoxItem)?.Content?.ToString();
            string status = (cmbStatus.SelectedItem as ComboBoxItem)?.Content?.ToString();

            // Parse numeric values with error handling
            decimal purchasePrice, sellingPrice, taxPercentage, discountPercentage;
            int stockQuantity, alertQuantity;

            // 2. Basic Validation
            if (string.IsNullOrWhiteSpace(productName) ||
                string.IsNullOrWhiteSpace(productCode) ||
                !decimal.TryParse(txtPurchasePrice.Text.Trim(), out purchasePrice) ||
                !decimal.TryParse(txtSellingPrice.Text.Trim(), out sellingPrice) ||
                !int.TryParse(txtStockQuantity.Text.Trim(), out stockQuantity))
            {
                MessageBox.Show("Please fill in all required fields (Product Name, Product Code, Purchase Price, Selling Price, Stock Quantity) with valid data.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (categoryId == null || categoryId == -1) // Check if a category was actually selected
            {
                MessageBox.Show("Please select a valid Category.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Optional fields validation (parse, but allow empty/default)
            decimal.TryParse(txtTaxPercentage.Text.Trim(), out taxPercentage);
            decimal.TryParse(txtDiscountPercentage.Text.Trim(), out discountPercentage);
            int.TryParse(txtAlertQuantity.Text.Trim(), out alertQuantity);


            // 3. Prepare SQL INSERT statement with parameters
            string query = @"
                INSERT INTO products (
                    product_name, product_code, barcode, category_id, brand_id,
                    description, purchase_price, selling_price, tax_percentage,
                    discount_percentage, stock_quantity, alert_quantity, unit,
                    status, product_image_url
                ) VALUES (
                    @ProductName, @ProductCode, @Barcode, @CategoryId, @BrandId,
                    @Description, @PurchasePrice, @SellingPrice, @TaxPercentage,
                    @DiscountPercentage, @StockQuantity, @AlertQuantity, @Unit,
                    @Status, @ProductImageUrl
                )";

            // 4. Establish connection and execute command
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", productName);
                        command.Parameters.AddWithValue("@ProductCode", productCode);
                        command.Parameters.AddWithValue("@Barcode", string.IsNullOrWhiteSpace(barcode) ? DBNull.Value : (object)barcode);
                        command.Parameters.AddWithValue("@CategoryId", categoryId.Value); // Category is NOT NULL
                        command.Parameters.AddWithValue("@BrandId", brandId == -1 || brandId == null ? DBNull.Value : (object)brandId.Value);
                        command.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(description) ? DBNull.Value : (object)description);
                        command.Parameters.AddWithValue("@PurchasePrice", purchasePrice);
                        command.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        command.Parameters.AddWithValue("@TaxPercentage", taxPercentage);
                        command.Parameters.AddWithValue("@DiscountPercentage", discountPercentage);
                        command.Parameters.AddWithValue("@StockQuantity", stockQuantity);
                        command.Parameters.AddWithValue("@AlertQuantity", alertQuantity);
                        command.Parameters.AddWithValue("@Unit", unit);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@ProductImageUrl", string.IsNullOrWhiteSpace(productImageUrl) ? DBNull.Value : (object)productImageUrl);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Product '{productName}' added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            ClearFormFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add product. No rows affected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062) // Duplicate entry error code for MySQL
                    {
                        if (ex.Message.ToLower().Contains("product_code"))
                        {
                            MessageBox.Show("Error: Product Code already exists. Please use a unique product code.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if (ex.Message.ToLower().Contains("barcode"))
                        {
                            MessageBox.Show("Error: Barcode already exists. Please use a unique barcode.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Database Error: Duplicate entry detected. Details: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Database Error: An unexpected database error occurred. Details: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected application error occurred: {ex.Message}", "Application Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // --- Form Reset Logic ---
        private void ClearFormFields()
        {
            txtProductName.Clear();
            txtProductCode.Clear();
            txtBarcode.Clear();
            txtDescription.Clear();
            txtPurchasePrice.Text = "0.00";
            txtSellingPrice.Text = "0.00";
            txtTaxPercentage.Text = "0";
            txtDiscountPercentage.Text = "0";
            txtStockQuantity.Text = "0";
            txtAlertQuantity.Text = "0";

            cmbCategory.SelectedIndex = 0; // "Select Category"
            cmbBrand.SelectedIndex = 0;    // "Select Brand"
            cmbUnit.SelectedIndex = 0;     // "Piece"
            cmbStatus.SelectedIndex = 0;   // "Active"

            _selectedLocalImagePath = null;
            imgProduct.Source = null;
            imgProduct.Visibility = Visibility.Collapsed;
            panelImagePlaceholder.Visibility = Visibility.Visible;
        }

        private void CancelProduct_Click(object sender, RoutedEventArgs e)
        {
            // When cancelled, navigate back to the Dashboard or a products list.
            Dashboard_Click(sender, e); // Re-use the Dashboard navigation
        }

        // --- Input Validation for Numeric Fields ---

        /// <summary>
        /// Prevents non-numeric input for integer-only fields (e.g., Stock Quantity, Alert Quantity).
        /// </summary>
        private void Integer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+"); // Regex that matches any non-digit character
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Prevents non-numeric input and allows only one decimal point for price fields.
        /// </summary>
        private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Allow digits and one decimal point
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != ".")
            {
                e.Handled = true; // Block non-numeric and non-dot input
            }
            // Block multiple decimal points
            if (e.Text == "." && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Prevents non-numeric input and allows only one decimal point for percentage fields.
        /// (Can be reused as Price_PreviewTextInput as percentages can have decimals)
        /// </summary>
        private void Percentage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Price_PreviewTextInput(sender, e); // Reuse the same logic as price, or implement specific percentage validation
        }


        // --- Sidebar Navigation Handlers (Copied from MainWindow) ---

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
            OpenWindowAndCloseCurrent(new Invoice()); // Placeholder
        }

        // Add Item is the current page, no navigation needed for this button click here.
        // private void AddItem_Click(object sender, RoutedEventArgs e) { /* Current Page */ }

        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new PurchaseRecordWindow());
        }

        private void PurchaseRecord_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new PurchaseRecordWindow());
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new ProductsPage()); // Placeholder. Create CategoryWindow.xaml if needed.
        }

        private void Brand_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new ProductsPage()); // Placeholder. Create BrandWindow.xaml if needed.
        }

        private void Units_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new ProductsPage()); // Placeholder. Create UnitsWindow.xaml if needed.
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new ProductsPage()); // Placeholder. Create SupplierWindow.xaml if needed.
        }

        private void Issued_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new StockTrackingWindow()); // Assuming StockTrackingWindow handles Issued.
        }

        private void Cashiers_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new AddCashier());
        }

        private void Administrators_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new LoginAsAdmin());
        }

        private void UserManager_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowAndCloseCurrent(new LoginAsAdmin()); // Placeholder
        }
    }
}