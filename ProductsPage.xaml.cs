using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using FinalDB.Models;
using System.Linq; // Added for FirstOrDefault

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Window
    {
        // --- Database Connection String ---
        private const string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=sultani;" +
            "Uid=root;" +
            "Pwd=anas786MALIK@;";

        public ObservableCollection<Product> Products { get; set; }

        public ProductsPage()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>();
            this.DataContext = this; 
            LoadProducts();
        }

        private void LoadProducts()
        {
            Products.Clear(); // Clear existing data before loading new
            string query = @"
                SELECT
                    p.product_id,
                    p.product_name,
                    p.product_code,
                    p.barcode,
                    p.category_id,
                    c.category_name,
                    p.brand_id,
                    b.brand_name,
                    p.description,
                    p.purchase_price,
                    p.selling_price,
                    p.tax_percentage,
                    p.discount_percentage,
                    p.stock_quantity,
                    p.alert_quantity,
                    p.unit,
                    p.status,
                    p.product_image_url
                FROM products p
                LEFT JOIN categories c ON p.category_id = c.category_id
                LEFT JOIN brands b ON p.brand_id = b.brand_id";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products.Add(new Product
                            {
                                ProductId = reader.GetInt32("product_id"),
                                ProductName = reader.GetString("product_name"),
                                ProductCode = reader.GetString("product_code"),
                                Barcode = reader.IsDBNull(reader.GetOrdinal("barcode")) ? null : reader.GetString("barcode"),
                                CategoryId = reader.GetInt32("category_id"),
                                CategoryName = reader.GetString("category_name"), // Fetch category name
                                BrandId = reader.IsDBNull(reader.GetOrdinal("brand_id")) ? (int?)null : reader.GetInt32("brand_id"),
                                BrandName = reader.IsDBNull(reader.GetOrdinal("brand_name")) ? null : reader.GetString("brand_name"), // Fetch brand name
                                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString("description"),
                                PurchasePrice = reader.GetDecimal("purchase_price"),
                                SellingPrice = reader.GetDecimal("selling_price"),
                                TaxPercentage = reader.GetDecimal("tax_percentage"),
                                DiscountPercentage = reader.GetDecimal("discount_percentage"),
                                StockQuantity = reader.GetInt32("stock_quantity"),
                                AlertQuantity = reader.GetInt32("alert_quantity"),
                                Unit = reader.GetString("unit"),
                                Status = reader.GetString("status"),
                                ProductImageUrl = reader.IsDBNull(reader.GetOrdinal("product_image_url")) ? null : reader.GetString("product_image_url")
                            });
                        }
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
            Invoice transactionWindow = new Invoice(); // Placeholder if no dedicated TransactionWindow
            transactionWindow.Show();
            this.Close();
        }

        private void ProductsList_Click(object sender, RoutedEventArgs e)
        {
            LoadProducts(); // Optional: Re-load products if user clicks this while on the page
        }

        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            PurchaseRecordWindow purchaseOrderWindow = new PurchaseRecordWindow(); // Assuming this is for purchase order
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
            ProductsPage categoryWindow = new ProductsPage(); // Placeholder for Category
            categoryWindow.Show();
            this.Close();
        }

        private void Brand_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage brandWindow = new ProductsPage(); // Placeholder for Brand
            brandWindow.Show();
            this.Close();
        }

        private void Units_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage unitsWindow = new ProductsPage(); // Placeholder for Units
            unitsWindow.Show();
            this.Close();
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage supplierWindow = new ProductsPage(); // Placeholder for Supplier
            supplierWindow.Show();
            this.Close();
        }

        private void Issued_Click(object sender, RoutedEventArgs e)
        {
            StockTrackingWindow issuedWindow = new StockTrackingWindow(); // Assuming this handles 'Issued'
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
            LoginAsAdmin userManagerWindow = new LoginAsAdmin(); // Or a dedicated UserManagerWindow
            userManagerWindow.Show();
            this.Close();
        }

        // --- New Handlers for ProductsPage ---

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductPage addProductWindow = new AddProductPage();
            addProductWindow.Show();
            this.Close();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            Button editButton = sender as Button;
            if (editButton != null && editButton.Tag is int productId)
            {
                // Find the product in the ObservableCollection
                Product selectedProduct = Products.FirstOrDefault(p => p.ProductId == productId);

                if (selectedProduct != null)
                {
                    EditProduct editProductWindow = new EditProduct(selectedProduct); // Pass the product object
                    editProductWindow.Show();
                    this.Close(); // Close the current ProductsPage
                }
                else
                {
                    MessageBox.Show("Product not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}