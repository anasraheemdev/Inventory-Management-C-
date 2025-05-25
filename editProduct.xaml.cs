using Microsoft.Win32;
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
using FinalDB.Models; // Add this using statement
using MySql.Data.MySqlClient; // Add for database interaction

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        private Product _currentProduct; // To hold the product being edited

        // --- Database Connection String ---
        private const string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=sultani;" +
            "Uid=root;" +
            "Pwd=anas786MALIK@;";

        private string _selectedLocalImagePath; // Stores the relative path to the image saved locally.

        // Default constructor (if needed, e.g., for direct navigation without a specific product)
        public EditProduct()
        {
            InitializeComponent();
            // Optionally, handle if no product is passed (e.g., disable fields or show message)
        }

        // Constructor to receive the product to be edited
        public EditProduct(Product productToEdit) : this() // Call the default constructor
        {
            _currentProduct = productToEdit;
            LoadProductDataIntoForm();
            LoadCategoriesAndBrands(); // Load combo box data
        }

        private void LoadProductDataIntoForm()
        {
            if (_currentProduct != null)
            {
                ProductNameTextBox.Text = _currentProduct.ProductName;
                ProductCodeTextBox.Text = _currentProduct.ProductCode;
                BarcodeTextBox.Text = _currentProduct.Barcode;
                DescriptionTextBox.Text = _currentProduct.Description;
                PurchasePriceTextBox.Text = _currentProduct.PurchasePrice.ToString("N2");
                SellingPriceTextBox.Text = _currentProduct.SellingPrice.ToString("N2");
                TaxTextBox.Text = _currentProduct.TaxPercentage.ToString();
                DiscountTextBox.Text = _currentProduct.DiscountPercentage.ToString();
                StockQuantityTextBox.Text = _currentProduct.StockQuantity.ToString();
                AlertQuantityTextBox.Text = _currentProduct.AlertQuantity.ToString();

                // Load Product Image
                if (!string.IsNullOrEmpty(_currentProduct.ProductImageUrl))
                {
                    try
                    {
                        // Check if it's an absolute URL or local path
                        if (Uri.TryCreate(_currentProduct.ProductImageUrl, UriKind.Absolute, out Uri uriResult) &&
                            (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                        {
                            ProductImage.Source = new BitmapImage(uriResult);
                        }
                        else // Assume it's a local relative path
                        {
                            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _currentProduct.ProductImageUrl);
                            if (System.IO.File.Exists(imagePath))
                            {
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                bitmap.EndInit();
                                ProductImage.Source = bitmap;
                            }
                            else
                            {
                                ProductImage.Source = new BitmapImage(new Uri("https://via.placeholder.com/150/AAAAAA/FFFFFF?text=No+Image", UriKind.Absolute));
                            }
                        }
                        _selectedLocalImagePath = _currentProduct.ProductImageUrl; // Keep track of the current image URL
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading product image: {ex.Message}", "Image Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        ProductImage.Source = new BitmapImage(new Uri("https://via.placeholder.com/150/AAAAAA/FFFFFF?text=Error+Loading", UriKind.Absolute));
                    }
                }
                else
                {
                    ProductImage.Source = new BitmapImage(new Uri("https://via.placeholder.com/150/AAAAAA/FFFFFF?text=No+Image", UriKind.Absolute));
                }
            }
        }

        private void LoadCategoriesAndBrands()
        {
            // Load Categories
            CategoryComboBox.Items.Clear();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT category_id, category_name FROM categories ORDER BY category_name";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader.GetString("category_name"),
                                Tag = reader.GetInt32("category_id")
                            };
                            CategoryComboBox.Items.Add(item);
                            if (_currentProduct != null && _currentProduct.CategoryId == (int)item.Tag)
                            {
                                CategoryComboBox.SelectedItem = item;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error loading categories: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            // Load Brands
            BrandComboBox.Items.Clear();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT brand_id, brand_name FROM brands ORDER BY brand_name";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Add a "None" or "Select Brand" option
                        BrandComboBox.Items.Add(new ComboBoxItem { Content = "None", Tag = null });

                        while (reader.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader.GetString("brand_name"),
                                Tag = reader.GetInt32("brand_id")
                            };
                            BrandComboBox.Items.Add(item);
                            if (_currentProduct != null && _currentProduct.BrandId.HasValue && _currentProduct.BrandId.Value == (int)item.Tag)
                            {
                                BrandComboBox.SelectedItem = item;
                            }
                        }
                        // If no brand was selected, ensure "None" is selected
                        if (_currentProduct != null && !_currentProduct.BrandId.HasValue && BrandComboBox.Items.Count > 0)
                        {
                            BrandComboBox.SelectedIndex = 0; // Select "None"
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error loading brands: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            // Set selected Unit and Status
            if (_currentProduct != null)
            {
                foreach (ComboBoxItem item in UnitComboBox.Items)
                {
                    if (item.Content.ToString() == _currentProduct.Unit)
                    {
                        UnitComboBox.SelectedItem = item;
                        break;
                    }
                }
                foreach (ComboBoxItem item in StatusComboBox.Items)
                {
                    if (item.Content.ToString() == _currentProduct.Status)
                    {
                        StatusComboBox.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        // --- Sidebar Navigation Handlers (Keep as is, ensure correct window names) ---

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void MakeInvoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice invoiceWindow = new Invoice();
            invoiceWindow.Show();
            this.Close();
        }

        private void Transaction_Click(object sender, RoutedEventArgs e)
        {
            Invoice transactionWindow = new Invoice();
            transactionWindow.Show();
            this.Close();
        }

        private void ProductsList_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage productsPageWindow = new ProductsPage();
            productsPageWindow.Show();
            this.Close();
        }

        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            PurchaseRecordWindow purchaseOrderWindow = new PurchaseRecordWindow();
            purchaseOrderWindow.Show();
            this.Close();
        }

        private void PurchaseRecord_Click(object sender, RoutedEventArgs e)
        {
            PurchaseRecordWindow purchaseRecordWindow = new PurchaseRecordWindow();
            purchaseRecordWindow.Show();
            this.Close();
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage categoryWindow = new ProductsPage();
            categoryWindow.Show();
            this.Close();
        }

        private void Brand_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage brandWindow = new ProductsPage();
            brandWindow.Show();
            this.Close();
        }

        private void Units_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage unitsWindow = new ProductsPage();
            unitsWindow.Show();
            this.Close();
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage supplierWindow = new ProductsPage();
            supplierWindow.Show();
            this.Close();
        }

        private void Issued_Click(object sender, RoutedEventArgs e)
        {
            StockTrackingWindow issuedWindow = new StockTrackingWindow();
            issuedWindow.Show();
            this.Close();
        }

        private void Cashiers_Click(object sender, RoutedEventArgs e)
        {
            AddCashier addCashierWindow = new AddCashier();
            addCashierWindow.Show();
            this.Close();
        }

        private void Administrators_Click(object sender, RoutedEventArgs e)
        {
            LoginAsAdmin loginAsAdminWindow = new LoginAsAdmin();
            loginAsAdminWindow.Show();
            this.Close();
        }

        private void UserManager_Click(object sender, RoutedEventArgs e)
        {
            LoginAsAdmin userManagerWindow = new LoginAsAdmin();
            userManagerWindow.Show();
            this.Close();
        }

        // --- Form Action Buttons ---

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (_currentProduct == null)
            {
                MessageBox.Show("No product selected for update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Input Validation
            if (string.IsNullOrWhiteSpace(ProductNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(ProductCodeTextBox.Text) ||
                CategoryComboBox.SelectedItem == null ||
                !decimal.TryParse(PurchasePriceTextBox.Text, out decimal purchasePrice) ||
                !decimal.TryParse(SellingPriceTextBox.Text, out decimal sellingPrice) ||
                !int.TryParse(StockQuantityTextBox.Text, out int stockQuantity))
            {
                MessageBox.Show("Please fill in all required fields (Product Name, Product Code, Category, Purchase Price, Selling Price, Stock Quantity) with valid data.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(TaxTextBox.Text, out decimal taxPercentage)) taxPercentage = 0.00m;
            if (!decimal.TryParse(DiscountTextBox.Text, out decimal discountPercentage)) discountPercentage = 0.00m;
            if (!int.TryParse(AlertQuantityTextBox.Text, out int alertQuantity)) alertQuantity = 0;


            string query = @"
                UPDATE products
                SET
                    product_name = @product_name,
                    product_code = @product_code,
                    barcode = @barcode,
                    category_id = @category_id,
                    brand_id = @brand_id,
                    description = @description,
                    purchase_price = @purchase_price,
                    selling_price = @selling_price,
                    tax_percentage = @tax_percentage,
                    discount_percentage = @discount_percentage,
                    stock_quantity = @stock_quantity,
                    alert_quantity = @alert_quantity,
                    unit = @unit,
                    status = @status,
                    product_image_url = @product_image_url
                WHERE product_id = @product_id";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@product_name", ProductNameTextBox.Text);
                    command.Parameters.AddWithValue("@product_code", ProductCodeTextBox.Text);
                    command.Parameters.AddWithValue("@barcode", string.IsNullOrWhiteSpace(BarcodeTextBox.Text) ? DBNull.Value : (object)BarcodeTextBox.Text);

                    // Get Category ID
                    int selectedCategoryId = (int)((ComboBoxItem)CategoryComboBox.SelectedItem).Tag;
                    command.Parameters.AddWithValue("@category_id", selectedCategoryId);

                    // Get Brand ID (can be NULL)
                    int? selectedBrandId = null;
                    if (BrandComboBox.SelectedItem is ComboBoxItem selectedBrandItem && selectedBrandItem.Tag != null)
                    {
                        selectedBrandId = (int?)selectedBrandItem.Tag;
                    }
                    command.Parameters.AddWithValue("@brand_id", selectedBrandId.HasValue ? (object)selectedBrandId.Value : DBNull.Value);

                    command.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ? DBNull.Value : (object)DescriptionTextBox.Text);
                    command.Parameters.AddWithValue("@purchase_price", purchasePrice);
                    command.Parameters.AddWithValue("@selling_price", sellingPrice);
                    command.Parameters.AddWithValue("@tax_percentage", taxPercentage);
                    command.Parameters.AddWithValue("@discount_percentage", discountPercentage);
                    command.Parameters.AddWithValue("@stock_quantity", stockQuantity);
                    command.Parameters.AddWithValue("@alert_quantity", alertQuantity);
                    command.Parameters.AddWithValue("@unit", ((ComboBoxItem)UnitComboBox.SelectedItem).Content.ToString());
                    command.Parameters.AddWithValue("@status", ((ComboBoxItem)StatusComboBox.SelectedItem).Content.ToString());
                    command.Parameters.AddWithValue("@product_image_url", string.IsNullOrWhiteSpace(_selectedLocalImagePath) ? DBNull.Value : (object)_selectedLocalImagePath);
                    command.Parameters.AddWithValue("@product_id", _currentProduct.ProductId); // Where clause

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product data updated successfully!", "Update Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                        ProductsList_Click(sender, e); // Navigate back to product list
                    }
                    else
                    {
                        MessageBox.Show("No product found with the given ID or no changes were made.", "Update Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ProductsList_Click(sender, e); // Re-use the ProductsList navigation
        }

        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif)|*.png;*.jpeg;*.jpg;*.gif|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // For now, we'll store the full path. In a real app, you'd copy to a local folder
                    // and store the relative path to that folder.
                    _selectedLocalImagePath = System.IO.Path.GetFileName(openFileDialog.FileName); // Store just the filename
                    // OR copy the file to a specific application folder:
                    // string destinationFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductImages");
                    // if (!System.IO.Directory.Exists(destinationFolder))
                    //     System.IO.Directory.CreateDirectory(destinationFolder);
                    // string destinationPath = System.IO.Path.Combine(destinationFolder, _selectedLocalImagePath);
                    // System.IO.File.Copy(openFileDialog.FileName, destinationPath, true); // Overwrite if exists

                    ProductImage.Source = new BitmapImage(new System.Uri(openFileDialog.FileName));
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Image Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}