using System;
using System.ComponentModel; // For INotifyPropertyChanged
using System.Windows.Media.Imaging; // For BitmapImage

namespace FinalDB.Models
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    _productId = value;
                    OnPropertyChanged(nameof(ProductId));
                }
            }
        }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged(nameof(ProductName));
                }
            }
        }

        private string _productCode;
        public string ProductCode
        {
            get { return _productCode; }
            set
            {
                if (_productCode != value)
                {
                    _productCode = value;
                    OnPropertyChanged(nameof(ProductCode));
                }
            }
        }

        private string _barcode;
        public string Barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    OnPropertyChanged(nameof(Barcode));
                }
            }
        }

        private int _categoryId;
        public int CategoryId
        {
            get { return _categoryId; }
            set
            {
                if (_categoryId != value)
                {
                    _categoryId = value;
                    OnPropertyChanged(nameof(CategoryId));
                }
            }
        }

        private string _categoryName; // To store the category name for display
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                if (_categoryName != value)
                {
                    _categoryName = value;
                    OnPropertyChanged(nameof(CategoryName));
                }
            }
        }

        private int? _brandId; // Nullable int for optional brand
        public int? BrandId
        {
            get { return _brandId; }
            set
            {
                if (_brandId != value)
                {
                    _brandId = value;
                    OnPropertyChanged(nameof(BrandId));
                }
            }
        }

        private string _brandName; // To store the brand name for display
        public string BrandName
        {
            get { return _brandName; }
            set
            {
                if (_brandName != value)
                {
                    _brandName = value;
                    OnPropertyChanged(nameof(BrandName));
                }
            }
        }


        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private decimal _purchasePrice;
        public decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set
            {
                if (_purchasePrice != value)
                {
                    _purchasePrice = value;
                    OnPropertyChanged(nameof(PurchasePrice));
                }
            }
        }

        private decimal _sellingPrice;
        public decimal SellingPrice
        {
            get { return _sellingPrice; }
            set
            {
                if (_sellingPrice != value)
                {
                    _sellingPrice = value;
                    OnPropertyChanged(nameof(SellingPrice));
                }
            }
        }

        private decimal _taxPercentage;
        public decimal TaxPercentage
        {
            get { return _taxPercentage; }
            set
            {
                if (_taxPercentage != value)
                {
                    _taxPercentage = value;
                    OnPropertyChanged(nameof(TaxPercentage));
                }
            }
        }

        private decimal _discountPercentage;
        public decimal DiscountPercentage
        {
            get { return _discountPercentage; }
            set
            {
                if (_discountPercentage != value)
                {
                    _discountPercentage = value;
                    OnPropertyChanged(nameof(DiscountPercentage));
                }
            }
        }

        private int _stockQuantity;
        public int StockQuantity
        {
            get { return _stockQuantity; }
            set
            {
                if (_stockQuantity != value)
                {
                    _stockQuantity = value;
                    OnPropertyChanged(nameof(StockQuantity));
                }
            }
        }

        private int _alertQuantity;
        public int AlertQuantity
        {
            get { return _alertQuantity; }
            set
            {
                if (_alertQuantity != value)
                {
                    _alertQuantity = value;
                    OnPropertyChanged(nameof(AlertQuantity));
                }
            }
        }

        private string _unit;
        public string Unit
        {
            get { return _unit; }
            set
            {
                if (_unit != value)
                {
                    _unit = value;
                    OnPropertyChanged(nameof(Unit));
                }
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        private string _productImageUrl;
        public string ProductImageUrl
        {
            get { return _productImageUrl; }
            set
            {
                if (_productImageUrl != value)
                {
                    _productImageUrl = value;
                    OnPropertyChanged(nameof(ProductImageUrl));
                    OnPropertyChanged(nameof(DisplayImageSource)); // Notify change for UI display
                }
            }
        }

        // Property for displaying the image in UI (e.g., DataGrid)
        public BitmapImage DisplayImageSource
        {
            get
            {
                if (!string.IsNullOrEmpty(ProductImageUrl))
                {
                    try
                    {
                        // Assuming images are stored locally relative to the application's executable
                        // You might need to adjust this path based on where your images are actually stored.
                        string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ProductImageUrl);

                        // If the image is stored as a full URL, use it directly
                        if (Uri.TryCreate(ProductImageUrl, UriKind.Absolute, out Uri uriResult) &&
                            (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                        {
                            return new BitmapImage(uriResult);
                        }
                        // Otherwise, assume it's a local path
                        else if (System.IO.File.Exists(imagePath))
                        {
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                            bitmap.CacheOption = BitmapCacheOption.OnLoad; // Crucial for releasing file handle
                            bitmap.EndInit();
                            return bitmap;
                        }
                    }
                    catch (Exception)
                    {
                        // Handle error loading image (e.g., log it, return a placeholder)
                        // For now, return null or a default image
                    }
                }
                return null; // Or return a default placeholder image if no image or error
            }
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}