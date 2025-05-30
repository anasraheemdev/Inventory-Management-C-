﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents; // Required for Printing
using System.Windows.Media.Imaging; // Required for Product.DisplayImageSource
using System.Printing; // Required for PrintDialog
using System.Windows.Markup; // Required for XamlWriter
using System.Collections.Generic; // Required for EqualityComparer
using System.Data; // Required for MySql.Data.MySqlClient

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window, INotifyPropertyChanged
    {
        // --- Nested Data Models (as per 'Do not create anyother file like in Model' constraint) ---
        // This is generally NOT recommended for larger applications.
        // For better maintainability and separation of concerns, these classes should be in separate files in a 'Models' folder.

        public class Product : INotifyPropertyChanged
        {
            private int _productId;
            public int ProductId
            {
                get => _productId;
                set => SetProperty(ref _productId, value);
            }

            private string _productName = string.Empty;
            public string ProductName
            {
                get => _productName;
                set => SetProperty(ref _productName, value);
            }

            private string _productCode = string.Empty;
            public string ProductCode
            {
                get => _productCode;
                set => SetProperty(ref _productCode, value);
            }

            private string? _barcode;
            public string? Barcode
            {
                get => _barcode;
                set => SetProperty(ref _barcode, value);
            }

            private int _categoryId;
            public int CategoryId
            {
                get => _categoryId;
                set => SetProperty(ref _categoryId, value);
            }

            private string _categoryName = string.Empty;
            public string CategoryName
            {
                get => _categoryName;
                set => SetProperty(ref _categoryName, value);
            }

            private int? _brandId;
            public int? BrandId
            {
                get => _brandId;
                set => SetProperty(ref _brandId, value);
            }

            private string? _brandName;
            public string? BrandName
            {
                get => _brandName;
                set => SetProperty(ref _brandName, value);
            }

            private string? _description;
            public string? Description
            {
                get => _description;
                set => SetProperty(ref _description, value);
            }

            private decimal _purchasePrice;
            public decimal PurchasePrice
            {
                get => _purchasePrice;
                set => SetProperty(ref _purchasePrice, value);
            }

            private decimal _sellingPrice;
            public decimal SellingPrice
            {
                get => _sellingPrice;
                set => SetProperty(ref _sellingPrice, value);
            }

            private decimal _taxPercentage;
            public decimal TaxPercentage
            {
                get => _taxPercentage;
                set => SetProperty(ref _taxPercentage, value);
            }

            private decimal _discountPercentage;
            public decimal DiscountPercentage
            {
                get => _discountPercentage;
                set => SetProperty(ref _discountPercentage, value);
            }

            private int _stockQuantity;
            public int StockQuantity
            {
                get => _stockQuantity;
                set => SetProperty(ref _stockQuantity, value);
            }

            private int _alertQuantity;
            public int AlertQuantity
            {
                get => _alertQuantity;
                set => SetProperty(ref _alertQuantity, value);
            }

            private string _unit = string.Empty;
            public string Unit
            {
                get => _unit;
                set => SetProperty(ref _unit, value);
            }

            private string _status = string.Empty;
            public string Status
            {
                get => _status;
                set => SetProperty(ref _status, value);
            }

            private string? _productImageUrl;
            public string? ProductImageUrl
            {
                get => _productImageUrl;
                set
                {
                    if (SetProperty(ref _productImageUrl, value))
                    {
                        OnPropertyChanged(nameof(DisplayImageSource));
                    }
                }
            }

            public BitmapImage? DisplayImageSource
            {
                get
                {
                    if (!string.IsNullOrEmpty(ProductImageUrl))
                    {
                        try
                        {
                            if (Uri.TryCreate(ProductImageUrl, UriKind.Absolute, out Uri? uriResult) &&
                                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                            {
                                return new BitmapImage(uriResult);
                            }
                            else
                            {
                                string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ProductImageUrl);
                                if (System.IO.File.Exists(imagePath))
                                {
                                    BitmapImage bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                    bitmap.EndInit();
                                    return bitmap;
                                }
                            }
                        }
                        catch (Exception) { /* Handle error or return null */ }
                    }
                    return null;
                }
            }

            public event PropertyChangedEventHandler? PropertyChanged;
            protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
            {
                if (EqualityComparer<T>.Default.Equals(storage, value)) return false;
                storage = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class Customer : INotifyPropertyChanged
        {
            private int _customerId;
            public int CustomerId
            {
                get => _customerId;
                set => SetProperty(ref _customerId, value);
            }

            private string _customerName = string.Empty;
            public string CustomerName
            {
                get => _customerName;
                set => SetProperty(ref _customerName, value);
            }

            private string? _phoneNumber;
            public string? PhoneNumber
            {
                get => _phoneNumber;
                set => SetProperty(ref _phoneNumber, value);
            }

            private string? _emailAddress;
            public string? EmailAddress
            {
                get => _emailAddress;
                set => SetProperty(ref _emailAddress, value);
            }

            private string? _address;
            public string? Address
            {
                get => _address;
                set => SetProperty(ref _address, value);
            }

            private bool _isWalkIn;
            public bool IsWalkIn
            {
                get => _isWalkIn;
                set => SetProperty(ref _isWalkIn, value);
            }

            public event PropertyChangedEventHandler? PropertyChanged;
            protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
            {
                if (EqualityComparer<T>.Default.Equals(storage, value)) return false;
                storage = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class User
        {
            public int UserId { get; set; }
            public string Username { get; set; } = string.Empty;
            public string FullName { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
        }

        public class InvoiceItem : INotifyPropertyChanged
        {
            private int _productId;
            private string _productCode = string.Empty;
            private string _description = string.Empty;
            private int _quantity;
            private decimal _unitPrice;
            private decimal _itemDiscountPercentage;
            private decimal _itemTaxPercentage;
            private decimal _lineTotal;

            public int ProductId
            {
                get => _productId;
                set => SetProperty(ref _productId, value);
            }

            public string ProductCode
            {
                get => _productCode;
                set => SetProperty(ref _productCode, value);
            }

            public string Description
            {
                get => _description;
                set => SetProperty(ref _description, value);
            }

            public int Quantity
            {
                get => _quantity;
                set
                {
                    if (SetProperty(ref _quantity, value))
                    {
                        CalculateLineTotal();
                    }
                }
            }

            public decimal UnitPrice
            {
                get => _unitPrice;
                set
                {
                    if (SetProperty(ref _unitPrice, value))
                    {
                        CalculateLineTotal();
                    }
                }
            }

            public decimal ItemDiscountPercentage
            {
                get => _itemDiscountPercentage;
                set
                {
                    if (SetProperty(ref _itemDiscountPercentage, value))
                    {
                        CalculateLineTotal();
                    }
                }
            }

            public decimal ItemTaxPercentage
            {
                get => _itemTaxPercentage;
                set
                {
                    if (SetProperty(ref _itemTaxPercentage, value))
                    {
                        CalculateLineTotal();
                    }
                }
            }

            public decimal LineTotal
            {
                get => _lineTotal;
                private set => SetProperty(ref _lineTotal, value);
            }

            public void CalculateLineTotal()
            {
                decimal basePrice = Quantity * UnitPrice;
                decimal discountAmount = basePrice * (ItemDiscountPercentage / 100);
                decimal priceAfterDiscount = basePrice - discountAmount;
                decimal taxAmount = priceAfterDiscount * (ItemTaxPercentage / 100);
                LineTotal = priceAfterDiscount + taxAmount;
            }

            public event PropertyChangedEventHandler? PropertyChanged;
            protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
            {
                if (EqualityComparer<T>.Default.Equals(storage, value)) return false;
                storage = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        // --- End of Nested Data Models ---


        // --- Database Connection String ---
        private const string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=sultani;" +
            "Uid=root;" +
            "Pwd=anas786MALIK@;";

        // --- Observable Collections for UI Binding ---
        public ObservableCollection<InvoiceItem> InvoiceItems { get; set; }
        public ObservableCollection<Customer> Customers { get; set; } // Stores all customers for lookup
        public ObservableCollection<User> SalesPersons { get; set; }

        // --- Invoice Header Properties (for Data Binding) ---
        private string _invoiceNumber = string.Empty;
        public string InvoiceNumber
        {
            get => _invoiceNumber;
            set => SetProperty(ref _invoiceNumber, value);
        }

        private DateTime _invoiceDate;
        public DateTime InvoiceDate
        {
            get => _invoiceDate;
            set => SetProperty(ref _invoiceDate, value);
        }

        private string _customerNameInput = string.Empty;
        public string CustomerNameInput
        {
            get => _customerNameInput;
            set => SetProperty(ref _customerNameInput, value);
        }

        private Customer? _selectedCustomer; // This will hold the actual customer object used for the invoice
        public Customer? SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }

        private User? _selectedSalesPerson;
        public User? SelectedSalesPerson
        {
            get => _selectedSalesPerson;
            set => SetProperty(ref _selectedSalesPerson, value);
        }

        private string _paymentMethod = "Cash";
        public string PaymentMethod
        {
            get => _paymentMethod;
            set => SetProperty(ref _paymentMethod, value);
        }

        private string _status = "Paid";
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        // --- Invoice Totals (Calculated) ---
        private decimal _subtotalAmount;
        public decimal SubtotalAmount
        {
            get => _subtotalAmount;
            set => SetProperty(ref _subtotalAmount, value);
        }

        private decimal _discountAmount;
        public decimal DiscountAmount
        {
            get => _discountAmount;
            set => SetProperty(ref _discountAmount, value);
        }

        private decimal _taxAmount;
        public decimal TaxAmount
        {
            get => _taxAmount;
            set => SetProperty(ref _taxAmount, value);
        }

        private decimal _totalAmount;
        public decimal TotalAmount
        {
            get => _totalAmount;
            set => SetProperty(ref _totalAmount, value);
        }

        // --- Properties for adding new items to invoice (for input fields) ---
        private string _newItemProductCode = string.Empty;
        public string NewItemProductCode
        {
            get => _newItemProductCode;
            set => SetProperty(ref _newItemProductCode, value);
        }

        private int _newItemQuantity = 1;
        public int NewItemQuantity
        {
            get => _newItemQuantity;
            set => SetProperty(ref _newItemQuantity, value);
        }

        // INotifyPropertyChanged event implementation for the Invoice window itself
        public event PropertyChangedEventHandler? PropertyChanged;

        public Invoice()
        {
            InitializeComponent();
            this.DataContext = this;

            InvoiceItems = new ObservableCollection<InvoiceItem>();
            Customers = new ObservableCollection<Customer>();
            SalesPersons = new ObservableCollection<User>();

            InvoiceDate = DateTime.Today;

            // Attach event handler for collection changes to recalculate totals
            InvoiceItems.CollectionChanged += (s, e) => CalculateTotals();

            LoadInitialData();
        }

        private void LoadInitialData()
        {
            GenerateNewInvoiceNumber();
            LoadCustomers(); // Loads customers, and ensures 'Walk-in Customer' exists
            LoadSalesPersons(); // Now loads static data
            CalculateTotals(); // Initial calculation (should be 0)

            // SelectedCustomer and CustomerNameInput are set within LoadCustomers() now
            // To ensure it's always the 'Walk-in Customer' initially unless changed by user input later.
        }

        private void GenerateNewInvoiceNumber()
        {
            // In a real application, query DB for last invoice number or use a robust generation strategy.
            InvoiceNumber = $"INV-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString()[..4].ToUpperInvariant()}";
        }

        private void LoadCustomers()
        {
            Customers.Clear();
            bool walkInCustomerFound = false;
            int walkInCustomerId = -1; // Initialize with an invalid ID

            const string selectCustomersQuery = "SELECT customer_id, customer_name, phone_number, email_address, address, is_walk_in FROM customers";

            using (MySqlConnection connection = new(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using MySqlCommand command = new(selectCustomersQuery, connection);
                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer c = new()
                        {
                            CustomerId = reader.GetInt32("customer_id"),
                            CustomerName = reader.GetString("customer_name"),
                            PhoneNumber = reader.IsDBNull(reader.GetOrdinal("phone_number")) ? null : reader.GetString("phone_number"),
                            EmailAddress = reader.IsDBNull(reader.GetOrdinal("email_address")) ? null : reader.GetString("email_address"),
                            Address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString("address"),
                            IsWalkIn = reader.GetBoolean("is_walk_in")
                        };
                        Customers.Add(c);
                        if (c.IsWalkIn)
                        {
                            walkInCustomerFound = true;
                            walkInCustomerId = c.CustomerId; // Store the ID of the walk-in customer
                        }
                    }
                    reader.Close(); // Close the reader before executing another command on the same connection
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database error while loading customers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    // Do not return here, attempt to create Walk-in customer if not found.
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while loading customers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    // Do not return here, attempt to create Walk-in customer if not found.
                }

                // If 'Walk-in Customer' was not found, create it
                if (!walkInCustomerFound)
                {
                    try
                    {
                        // Ensure connection is still open or reopen if it closed due to an earlier error
                        if (connection.State != ConnectionState.Open) connection.Open();

                        string insertWalkInQuery = @"
                            INSERT INTO customers (customer_name, is_walk_in, created_at, updated_at)
                            VALUES ('Walk-in Customer', 1, NOW(), NOW());
                            SELECT LAST_INSERT_ID();";

                        using MySqlCommand insertCommand = new(insertWalkInQuery, connection);
                        walkInCustomerId = Convert.ToInt32(insertCommand.ExecuteScalar());

                        // Add the newly created walk-in customer to the ObservableCollection
                        Customer newWalkIn = new Customer
                        {
                            CustomerId = walkInCustomerId,
                            CustomerName = "Walk-in Customer",
                            IsWalkIn = true
                        };
                        Customers.Add(newWalkIn);
                        MessageBox.Show("Automatically created 'Walk-in Customer' in the database.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"Database error creating 'Walk-in Customer': {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An unexpected error occurred creating 'Walk-in Customer': {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            // Now, after ensuring 'Walk-in Customer' exists and is loaded:
            SelectedCustomer = Customers.FirstOrDefault(c => c.IsWalkIn) ?? Customers.FirstOrDefault();
            CustomerNameInput = SelectedCustomer?.CustomerName ?? string.Empty;
        }


        private void LoadSalesPersons()
        {
            SalesPersons.Clear();
            // Statically add the sales persons as requested
            SalesPersons.Add(new User { UserId = 1, Username = "anas.r", FullName = "Anas Raheem", Role = "Cashier" });
            SalesPersons.Add(new User { UserId = 2, Username = "swail.k", FullName = "Swail Kashar", Role = "Cashier" });
            SalesPersons.Add(new User { UserId = 3, Username = "muhammad.i", FullName = "Muhammad Ibrahim", Role = "Cashier" });

            // Select "Anas Raheem" by default if available, otherwise select the first person in the list
            SelectedSalesPerson = SalesPersons.FirstOrDefault(sp => sp.FullName == "Anas Raheem") ?? SalesPersons.FirstOrDefault();
        }

        private void CalculateTotals()
        {
            SubtotalAmount = InvoiceItems.Sum(item => item.Quantity * item.UnitPrice);
            DiscountAmount = InvoiceItems.Sum(item => (item.Quantity * item.UnitPrice) * (item.ItemDiscountPercentage / 100));
            TaxAmount = InvoiceItems.Sum(item => (item.Quantity * item.UnitPrice - (item.Quantity * item.UnitPrice) * (item.ItemDiscountPercentage / 100)) * (item.ItemTaxPercentage / 100));
            TotalAmount = InvoiceItems.Sum(item => item.LineTotal);
        }

        private void AddNewItemToInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewItemProductCode) || NewItemQuantity <= 0)
            {
                MessageBox.Show("Please enter a valid Product Code and Quantity.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Product? product = GetProductByCode(NewItemProductCode);

            if (product is null)
            {
                MessageBox.Show($"Product with code '{NewItemProductCode}' not found.", "Product Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            InvoiceItem? existingItem = InvoiceItems.FirstOrDefault(item => item.ProductId == product.ProductId);

            if (existingItem is not null)
            {
                existingItem.Quantity += NewItemQuantity;
            }
            else
            {
                InvoiceItem newItem = new()
                {
                    ProductId = product.ProductId,
                    ProductCode = product.ProductCode,
                    Description = product.ProductName,
                    Quantity = NewItemQuantity,
                    UnitPrice = product.SellingPrice,
                    ItemDiscountPercentage = product.DiscountPercentage,
                    ItemTaxPercentage = product.TaxPercentage
                };
                newItem.CalculateLineTotal();
                InvoiceItems.Add(newItem);
            }

            NewItemProductCode = string.Empty;
            NewItemQuantity = 1;
        }

        private Product? GetProductByCode(string productCode)
        {
            Product? product = null;
            const string query = "SELECT product_id, product_name, product_code, selling_price, tax_percentage, discount_percentage FROM products WHERE product_code = @productCode OR barcode = @productCode LIMIT 1";

            using (MySqlConnection connection = new(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using MySqlCommand command = new(query, connection);
                    command.Parameters.AddWithValue("@productCode", productCode);
                    using MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        product = new()
                        {
                            ProductId = reader.GetInt32("product_id"),
                            ProductName = reader.GetString("product_name"),
                            ProductCode = reader.GetString("product_code"),
                            SellingPrice = reader.GetDecimal("selling_price"),
                            TaxPercentage = reader.GetDecimal("tax_percentage"),
                            DiscountPercentage = reader.GetDecimal("discount_percentage")
                        };
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database error while fetching product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while fetching product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return product;
        }

        private void DeleteInvoiceItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button deleteButton && deleteButton.DataContext is InvoiceItem itemToDelete)
            {
                InvoiceItems.Remove(itemToDelete);
            }
        }

        private void SaveAndPrintButton_Click(object sender, RoutedEventArgs e)
        {
            SaveInvoiceToDatabase();
        }

        private void SaveInvoiceToDatabase()
        {
            // Initial validation for customer name input
            if (string.IsNullOrWhiteSpace(CustomerNameInput) && (SelectedCustomer == null || SelectedCustomer.IsWalkIn == false))
            {
                MessageBox.Show("Please enter a customer name or ensure 'Walk-in Customer' is selected.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Other general validations
            if (SelectedSalesPerson is null || InvoiceItems.Count == 0)
            {
                MessageBox.Show("Please ensure sales person is selected and there are items in the invoice.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Safeguard: Ensure SelectedCustomer is not null and has a valid ID before proceeding
            // This is a critical check to prevent the foreign key error before even touching the DB
            if (SelectedCustomer == null || SelectedCustomer.CustomerId <= 0)
            {
                MessageBox.Show("A valid customer could not be identified for this invoice. Please ensure 'Walk-in Customer' is correctly configured or enter a new customer name.", "Customer Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // --- TEMPORARY DEBUG MESSAGE START ---
            // This will help us confirm what customer ID the app is using just before the DB operation.
            if (SelectedCustomer != null)
            {
                MessageBox.Show($"DEBUG INFO:\nCustomer Name Input: '{CustomerNameInput}'\nSelected Customer ID: {SelectedCustomer.CustomerId}\nSelected Customer Name: '{SelectedCustomer.CustomerName}'\nIs Walk-in: {SelectedCustomer.IsWalkIn}", "Customer Debugging", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            // --- TEMPORARY DEBUG MESSAGE END ---


            MySqlConnection connection = new(ConnectionString);
            MySqlTransaction? transaction = null; // Declare transaction here, initialized to null

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction(); // Assign transaction here

                int currentCustomerId;

                // Handle Customer Logic: Prioritize existing or create new based on CustomerNameInput
                if (!string.IsNullOrWhiteSpace(CustomerNameInput))
                {
                    // Attempt to find an existing customer by the entered name
                    Customer? existingCustomer = Customers.FirstOrDefault(c => c.CustomerName.Equals(CustomerNameInput.Trim(), StringComparison.OrdinalIgnoreCase));

                    if (existingCustomer != null)
                    {
                        currentCustomerId = existingCustomer.CustomerId;
                        SelectedCustomer = existingCustomer; // Update SelectedCustomer to the found customer
                    }
                    else
                    {
                        // Insert a new customer if name is provided and not found
                        string insertCustomerQuery = @"
                    INSERT INTO customers (customer_name, phone_number, email_address, address, is_walk_in, created_at, updated_at)
                    VALUES (@customerName, NULL, NULL, NULL, 0, NOW(), NOW());
                    SELECT LAST_INSERT_ID();";

                        using MySqlCommand customerCommand = new(insertCustomerQuery, connection, transaction);
                        customerCommand.Parameters.AddWithValue("@customerName", CustomerNameInput.Trim());

                        currentCustomerId = Convert.ToInt32(customerCommand.ExecuteScalar());

                        // Add the new customer to the ObservableCollection and set as selected
                        Customer newCustomer = new Customer
                        {
                            CustomerId = currentCustomerId,
                            CustomerName = CustomerNameInput.Trim(),
                            IsWalkIn = false
                        };
                        Customers.Add(newCustomer);
                        SelectedCustomer = newCustomer;
                    }
                }
                else // CustomerNameInput is empty, use the currently selected customer (expected to be 'Walk-in Customer')
                {
                    currentCustomerId = SelectedCustomer.CustomerId;
                }

                // 2. Insert Invoice Header
                string invoiceInsertQuery = @"
            INSERT INTO invoices (invoice_number, invoice_date, customer_id, sales_person_id, payment_method, status, subtotal_amount, discount_amount, tax_amount, total_amount, created_at, updated_at)
            VALUES (@invoiceNumber, @invoiceDate, @customerId, @salesPersonId, @paymentMethod, @status, @subtotal, @discount, @tax, @total, NOW(), NOW());
            SELECT LAST_INSERT_ID();";

                using MySqlCommand invoiceCommand = new(invoiceInsertQuery, connection, transaction);
                invoiceCommand.Parameters.AddWithValue("@invoiceNumber", InvoiceNumber);
                invoiceCommand.Parameters.AddWithValue("@invoiceDate", InvoiceDate);
                invoiceCommand.Parameters.AddWithValue("@customerId", currentCustomerId);
                invoiceCommand.Parameters.AddWithValue("@salesPersonId", SelectedSalesPerson.UserId);
                invoiceCommand.Parameters.AddWithValue("@paymentMethod", PaymentMethod);
                invoiceCommand.Parameters.AddWithValue("@status", Status);
                invoiceCommand.Parameters.AddWithValue("@subtotal", SubtotalAmount);
                invoiceCommand.Parameters.AddWithValue("@discount", DiscountAmount);
                invoiceCommand.Parameters.AddWithValue("@tax", TaxAmount);
                invoiceCommand.Parameters.AddWithValue("@total", TotalAmount);

                // Retrieve the newly inserted invoice ID using ulong to handle BIGINT UNSIGNED correctly
                ulong invoiceId = (ulong)invoiceCommand.ExecuteScalar();

                // 3. Insert Invoice Items
                string itemInsertQuery = @"
            INSERT INTO invoice_items (invoice_id, product_id, quantity, unit_price, item_discount_percentage, item_tax_percentage, line_total)
            VALUES (@invoiceId, @productId, @quantity, @unitPrice, @itemDiscountPercentage, @itemTaxPercentage, @lineTotal);";

                foreach (var item in InvoiceItems)
                {
                    using MySqlCommand itemCommand = new(itemInsertQuery, connection, transaction);
                    itemCommand.Parameters.AddWithValue("@invoiceId", invoiceId);
                    itemCommand.Parameters.AddWithValue("@productId", item.ProductId);
                    itemCommand.Parameters.AddWithValue("@quantity", item.Quantity);
                    itemCommand.Parameters.AddWithValue("@unitPrice", item.UnitPrice);
                    itemCommand.Parameters.AddWithValue("@itemDiscountPercentage", item.ItemDiscountPercentage);
                    itemCommand.Parameters.AddWithValue("@itemTaxPercentage", item.ItemTaxPercentage);
                    itemCommand.Parameters.AddWithValue("@lineTotal", item.LineTotal);
                    itemCommand.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Invoice saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                PrintInvoiceContent(); // Call printing after successful save
                ClearInvoice();
            }
            catch (MySqlException ex)
            {
                transaction?.Rollback(); // Use null-conditional operator to safely call Rollback if transaction was initialized
                MessageBox.Show($"Database error while saving invoice: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                transaction?.Rollback(); // Use null-conditional operator
                MessageBox.Show($"An unexpected error occurred while saving invoice: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close(); // Ensure connection is always closed
                connection.Dispose(); // Release resources
            }
        }


        private void ClearInvoice()
        {
            InvoiceItems.Clear();
            GenerateNewInvoiceNumber();
            InvoiceDate = DateTime.Today;
            // Reset CustomerNameInput to the Walk-in customer's name if available, otherwise empty
            CustomerNameInput = Customers.FirstOrDefault(c => c.IsWalkIn)?.CustomerName ?? string.Empty;
            // Re-select the "Walk-in" customer for internal tracking if exists, otherwise null
            SelectedCustomer = Customers.FirstOrDefault(c => c.IsWalkIn) ?? null;

            SelectedSalesPerson = SalesPersons.FirstOrDefault(sp => sp.FullName == "Anas Raheem") ?? SalesPersons.FirstOrDefault(); // Reset to default sales person
            PaymentMethod = "Cash";
            Status = "Paid";
            NewItemProductCode = string.Empty;
            NewItemQuantity = 1;
            CalculateTotals();
        }

        private void PrintInvoiceContent()
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                FlowDocument doc = new FlowDocument();
                doc.PagePadding = new Thickness(50);
                doc.ColumnWidth = printDialog.PrintableAreaWidth;

                doc.Blocks.Add(new Paragraph(new Run("SULTANI POS - INVOICE")) { FontSize = 20, FontWeight = FontWeights.Bold, TextAlignment = TextAlignment.Center });
                doc.Blocks.Add(new Paragraph(new Run($"Invoice No: {InvoiceNumber}")) { Margin = new Thickness(0, 10, 0, 0) });
                doc.Blocks.Add(new Paragraph(new Run($"Date: {InvoiceDate:dd-MMM-yyyy}")));
                // Use the CustomerNameInput for printing, as it's the current user-entered value
                doc.Blocks.Add(new Paragraph(new Run($"Customer: {CustomerNameInput}")));
                doc.Blocks.Add(new Paragraph(new Run($"Sales Person: {SelectedSalesPerson?.FullName}")));
                doc.Blocks.Add(new Paragraph(new Run($"Payment Method: {PaymentMethod}")));
                doc.Blocks.Add(new Paragraph(new Run($"Status: {Status}")));

                doc.Blocks.Add(new Paragraph(new LineBreak()));

                Table invoiceTable = new Table();
                invoiceTable.CellSpacing = 0;
                invoiceTable.BorderBrush = System.Windows.Media.Brushes.Black;
                invoiceTable.BorderThickness = new Thickness(0.5);
                invoiceTable.Columns.Add(new TableColumn() { Width = new GridLength(1, GridUnitType.Star) });
                invoiceTable.Columns.Add(new TableColumn() { Width = new GridLength(2, GridUnitType.Star) });
                invoiceTable.Columns.Add(new TableColumn() { Width = new GridLength(0.7, GridUnitType.Star) });
                invoiceTable.Columns.Add(new TableColumn() { Width = new GridLength(1, GridUnitType.Star) });
                invoiceTable.Columns.Add(new TableColumn() { Width = new GridLength(0.8, GridUnitType.Star) });
                invoiceTable.Columns.Add(new TableColumn() { Width = new GridLength(0.8, GridUnitType.Star) });
                invoiceTable.Columns.Add(new TableColumn() { Width = new GridLength(1, GridUnitType.Star) });

                TableRowGroup headerGroup = new TableRowGroup();
                TableRow headerRow = new TableRow();
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Code"))) { FontWeight = FontWeights.Bold, BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Description"))) { FontWeight = FontWeights.Bold, BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Qty"))) { FontWeight = FontWeights.Bold, BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Unit Price"))) { FontWeight = FontWeights.Bold, BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Disc (%)"))) { FontWeight = FontWeights.Bold, BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Tax (%)"))) { FontWeight = FontWeights.Bold, BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Total"))) { FontWeight = FontWeights.Bold, BorderThickness = new Thickness(0, 0, 0, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                headerGroup.Rows.Add(headerRow);
                invoiceTable.RowGroups.Add(headerGroup);

                TableRowGroup bodyGroup = new TableRowGroup();
                foreach (var item in InvoiceItems)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell(new Paragraph(new Run(item.ProductCode))) { BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                    row.Cells.Add(new TableCell(new Paragraph(new Run(item.Description))) { BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                    row.Cells.Add(new TableCell(new Paragraph(new Run(item.Quantity.ToString()))) { BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                    row.Cells.Add(new TableCell(new Paragraph(new Run(item.UnitPrice.ToString("N2")))) { BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                    row.Cells.Add(new TableCell(new Paragraph(new Run(item.ItemDiscountPercentage.ToString("N2")))) { BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                    row.Cells.Add(new TableCell(new Paragraph(new Run(item.ItemTaxPercentage.ToString("N2")))) { BorderThickness = new Thickness(0, 0, 0.5, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                    row.Cells.Add(new TableCell(new Paragraph(new Run(item.LineTotal.ToString("N2")))) { BorderThickness = new Thickness(0, 0, 0, 0.5), BorderBrush = System.Windows.Media.Brushes.Black, Padding = new Thickness(5) });
                    bodyGroup.Rows.Add(row);
                }
                invoiceTable.RowGroups.Add(bodyGroup);
                doc.Blocks.Add(invoiceTable);

                doc.Blocks.Add(new Paragraph(new LineBreak()));
                doc.Blocks.Add(new Paragraph(new Run($"Subtotal: Rs. {SubtotalAmount:N2}")) { TextAlignment = TextAlignment.Right });
                doc.Blocks.Add(new Paragraph(new Run($"Discount: Rs. {DiscountAmount:N2}")) { TextAlignment = TextAlignment.Right });
                doc.Blocks.Add(new Paragraph(new Run($"Tax (VAT): Rs. {TaxAmount:N2}")) { TextAlignment = TextAlignment.Right });
                doc.Blocks.Add(new Paragraph(new Run($"Total: Rs. {TotalAmount:N2}")) { TextAlignment = TextAlignment.Right, FontWeight = FontWeights.Bold, FontSize = 14 });

                doc.PageHeight = printDialog.PrintableAreaHeight;
                doc.PageWidth = printDialog.PrintableAreaWidth;
                doc.ColumnGap = 0;
                doc.PagePadding = new Thickness(50);

                printDialog.PrintDocument(((IDocumentPaginatorSource)doc).DocumentPaginator, "SULTANI POS Invoice");
            }
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // --- Sidebar Navigation Event Handlers ---

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming MainWindow exists in the same namespace
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void MakeInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            ClearInvoice();
        }

        private void TransactionButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Transaction window functionality to be implemented.", "Navigation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming AddProductPage exists in the same namespace
            AddProductPage addProductPage = new AddProductPage();
            addProductPage.Show();
            Close();
        }

        private void ProductsListButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming ProductsPage exists in the same namespace
            ProductsPage productsPage = new ProductsPage();
            productsPage.Show();
            Close();
        }

        private void PurchaseOrderButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Purchase Order window/functionality to be implemented.", "Navigation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void PurchaseRecordButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming PurchaseRecordWindow exists in the same namespace
            PurchaseRecordWindow purchaseRecordWindow = new PurchaseRecordWindow();
            purchaseRecordWindow.Show();
            Close();
        }

        private void StockTrackingButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming StockTrackingWindow exists in the same namespace
            StockTrackingWindow stockTrackingWindow = new StockTrackingWindow();
            stockTrackingWindow.Show();
            Close();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Category management window to be implemented.", "Navigation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BrandButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Brand management window to be implemented.", "Navigation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UnitsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Units management window to be implemented.", "Navigation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SupplierButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Supplier management window to be implemented.", "Navigation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void IssuedButton_Click(object sender, RoutedEventArgs e)
        {
            StockTrackingWindow stockTrackingWindow = new StockTrackingWindow();
            stockTrackingWindow.Show();
            Close();
        }

        private void MasterPriceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Master Price window to be implemented.", "Navigation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddCashierButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming AddCashier exists in the same namespace
            AddCashier addCashierWindow = new AddCashier();
            addCashierWindow.Show();
            Close();
        }

        private void CashiersButton_Click(object sender, RoutedEventArgs e)
        {
            AddCashier addCashierWindow = new AddCashier();
            addCashierWindow.Show();
            Close();
        }

        private void AdministratorsButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming LoginAsAdmin exists in the same namespace
            LoginAsAdmin loginAsAdminWindow = new LoginAsAdmin();
            loginAsAdminWindow.Show();
            Close();
        }

        private void UserManagerButton_Click(object sender, RoutedEventArgs e)
        {
            LoginAsAdmin loginAsAdminWindow = new LoginAsAdmin();
            loginAsAdminWindow.Show();
            Close();
        }

        private void LoginAsAdminButton_Click(object sender, RoutedEventArgs e)
        {
            LoginAsAdmin loginAsAdminWindow = new LoginAsAdmin();
            loginAsAdminWindow.Show();
            Close();
        }

        private void LoginPageButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming LoginPage exists in the same namespace
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            Close();
        }

        private void HomeLoginAsButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming HomeLoginAs exists in the same namespace
            HomeLoginAs homeLoginAsWindow = new HomeLoginAs();
            homeLoginAsWindow.Show();
            Close();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming EditProduct exists in the same namespace
            EditProduct editProductWindow = new EditProduct();
            editProductWindow.Show();
            Close();
        }

        private void PreviewInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            PrintInvoiceContent(); // For now, preview directly triggers print
        }

        private void SaveDraftButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save Draft functionality triggered.", "Invoice Action", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CancelInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cancel Invoice functionality triggered.", "Invoice Action", MessageBoxButton.OK, MessageBoxImage.Information);
            ClearInvoice();
        }

        private void FinalPrintInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            PrintInvoiceContent();
        }

        private void EmailInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Email Invoice functionality triggered.", "Invoice Action", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}