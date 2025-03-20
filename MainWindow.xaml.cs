using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalDB;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Invoice invoice = new Invoice();
        invoice.Show();
        this.Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        CategoriesPage categoriesPage = new CategoriesPage();
        categoriesPage.Show();
        this.Close();
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        AddProductPage addProductPage = new AddProductPage();
        addProductPage.Show();
        this.Close();
    }

    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        LoginPage loginPage = new LoginPage();
        loginPage.Show();
        this.Close();
    }
}