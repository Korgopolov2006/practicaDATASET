using PRACTA.ZooMagazinDataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PRACTA
{
    /// <summary>
    /// Логика взаимодействия для ordersss.xaml
    /// </summary>
    public partial class ordersss : Page
    {


        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        FoodTableAdapter food = new FoodTableAdapter();
        CustomersTableAdapter customers = new CustomersTableAdapter();
        OrdersTableAdapter orders = new OrdersTableAdapter();
        public ordersss()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = orders.View();
            ComboBox1.ItemsSource = customers.GetData();
            ComboBox2.ItemsSource = employees.GetData();
            ComboBox3.ItemsSource = animals.View();
            ComboBox4.ItemsSource = food.GetData();

 
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                var data = (DataGrid1.SelectedItem as DataRowView).Row;
                ComboBox1.Text = data[2].ToString();
                ComboBox2.Text = data[3].ToString();
                ComboBox3.Text = data[4].ToString();
                ComboBox4.Text = data[5].ToString();

            }
        }

        private bool IsValidInput(string input)
        {
            // Паттерн для проверки наличия специальных символов или смайликов
            string pattern = @"^[\p{L}0-9_ ]*$"; // Позволяет буквы (включая английские и русские), цифры, подчеркивания и пробелы

            // Проверка с помощью регулярного выражения
            return Regex.IsMatch(input, pattern);
        }



        private void Cleaning(object sender, RoutedEventArgs e)
        {

            DataGrid1.ItemsSource = orders.View();
        }

        //private void Search(object sender, RoutedEventArgs e)
        //{
        //    var text = TextBox6.Text;
        //    DataGrid1.ItemsSource = orders.Searchorders(text);
        //}

        private void Add(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedValue == null && ComboBox2.SelectedValue == null&& ComboBox3.SelectedValue == null && ComboBox4.SelectedValue == null )
            {
                MessageBox.Show("Пожалуйста, заполните все данные перед добавлением.");
                return;
            }
            else
            {
                string dateStr = datePicker1.SelectedDate?.ToString("yyyy-MM-dd");
                if (!string.IsNullOrEmpty(dateStr))
                {
                    orders.InsertQuery(Convert.ToInt32(ComboBox1.SelectedValue), Convert.ToInt32(ComboBox2.SelectedValue), Convert.ToInt32(ComboBox3.SelectedValue), Convert.ToInt32(ComboBox4.SelectedValue), dateStr);
                    DataGrid1.ItemsSource = orders.View();
                }
                else
                {
                    MessageBox.Show("Please select a valid date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                var dataRowView = DataGrid1.SelectedItem as DataRowView;
                if (dataRowView != null)
                {
                    var row = dataRowView.Row;
                    if (row[0] != null)
                    {
                        var id = Convert.ToInt32((DataGrid1.SelectedItem as DataRowView).Row[0]);
                        orders.DeleteQuery(id);
                        DataGrid1.ItemsSource = orders.View();
                    }
                }
            }

        }
        private void Chose(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                var dataRowView = DataGrid1.SelectedItem as DataRowView;
                if (dataRowView != null)
                {
                    var id = Convert.ToInt32((DataGrid1.SelectedItem as DataRowView).Row[0]);
                    orders.UpdateQuery(Convert.ToInt32(ComboBox1.SelectedValue),Convert.ToInt32(ComboBox2.SelectedValue),Convert.ToInt32(ComboBox3.SelectedValue),Convert.ToInt32(ComboBox4.SelectedValue), Convert.ToString(datePicker1.SelectedDate), id);
                    DataGrid1.ItemsSource = orders.View();
                }
            }
        }

        //private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var a = Convert.ToInt32(ComboBox2.SelectedValue);
        //    DataGrid1.ItemsSource = orders.FiltrOrders(a);
        //}

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid1.Columns[3].Visibility = Visibility.Hidden;
            DataGrid1.Columns[6].Visibility = Visibility.Hidden;
            DataGrid1.Columns[7].Visibility = Visibility.Hidden;
            DataGrid1.Columns[8].Visibility = Visibility.Hidden;
            DataGrid1.Columns[9].Visibility = Visibility.Hidden;
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
