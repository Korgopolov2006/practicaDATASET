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
using System.Windows.Shapes;
using PRACTA.ZooMagazinDataSet1TableAdapters;

namespace PRACTA
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow1.xaml
    /// </summary>
    public partial class AdminWindow1 : Window
    {
        // Создать экземпляр страницы Employees

        

        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        FoodTableAdapter food = new FoodTableAdapter();
        CustomersTableAdapter customers = new CustomersTableAdapter();
        OrdersTableAdapter orders = new OrdersTableAdapter();
        ToysTableAdapter toys = new ToysTableAdapter();
        AquariumsTableAdapter aquariums = new AquariumsTableAdapter();
        CollarsTableAdapter collars = new CollarsTableAdapter();

        ReviewsTableAdapter reviews = new ReviewsTableAdapter();
        public AdminWindow1()
        {
            InitializeComponent();
        }

        public void Employees_Click(object sender, RoutedEventArgs e)
        {

            //Employees employeesPage = new Employees();
            //DataGrid DataGrid1 = employeesPage.FindName("DataGrid1") as DataGrid;
            Page.Content = new Employees();
            


        }

        public void Animals_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new animals();
            //DataGrid1.ItemsSource = animals.GetData();

        }

        public void Food_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new fod();
            //DataGrid1.ItemsSource = food.GetData();
        }

        public void Customers_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new customer();
            // DataGrid1.ItemsSource = customers.GetData();
        }

        public void Orders_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new ordersss();
            // DataGrid1.ItemsSource = orders.GetData();
        }

        public void Toys_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new toysss();
            // DataGrid1.ItemsSource = toys.GetData();
        }

        public void Aquariums_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new aquariumsss();
            // DataGrid1.ItemsSource = aquariums.GetData();
        }

        public void Collars_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new collarsss();
            //DataGrid1.ItemsSource = collars.GetData();
        }

        public void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {



        }

        private void Roles_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Rolesss();
        }

        private void Reviews_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Reviewsss();
        }

        private void Animals_Categories_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Animals_Categoriesss();
        }

        private void Food_Categories_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Food_Categoriesss();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
