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
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        RolesTableAdapter rolesTable = new RolesTableAdapter();
        public Employees()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = employees.GetData();
            ComboBox2.ItemsSource = rolesTable.GetData();
            ComboBox1.ItemsSource = rolesTable.GetData();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
            var data = (DataGrid1.SelectedItem as DataRowView).Row;
            TextBox1.Text = data[1].ToString();
            TextBox2.Text = data[2].ToString();
            TextBox3.Text = data[3].ToString();           
            TextBox4.Text = data[4].ToString();
            TextBox5.Text = data[5].ToString();
            ComboBox1.Text = data[7].ToString();
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

            DataGrid1.ItemsSource = employees.GetData();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            var text = TextBox6.Text;
            DataGrid1.ItemsSource = employees.Search(text);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput(TextBox1.Text) && !IsValidInput(TextBox3.Text) && !IsValidInput(TextBox2.Text) && !IsValidInput(TextBox4.Text) && !IsValidInput(TextBox5.Text) )
            {
                MessageBox.Show("Поля не должны содержать специальные символы.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(TextBox1.Text) && !string.IsNullOrWhiteSpace(TextBox2.Text) && !string.IsNullOrWhiteSpace(TextBox3.Text) && !string.IsNullOrWhiteSpace(TextBox4.Text) && !string.IsNullOrWhiteSpace(TextBox5.Text) && ComboBox1.SelectedValue != null)
            {
                if (employees.GetData().Any(emp => emp.employee_name == TextBox1.Text && emp.employee_Surname == TextBox2.Text && emp.employee_patronymic == TextBox3.Text && emp.employee_password == TextBox4.Text || emp.employee_login == TextBox5.Text))
                {
                    // Данные уже существуют, ничего не делаем
                    return;
                }

                employees.InsertQuery(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, Convert.ToInt32(ComboBox1.SelectedValue));
                DataGrid1.ItemsSource = employees.GetData();
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
                        employees.DeleteQuery(id);
                        DataGrid1.ItemsSource = employees.GetData();
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
                    employees.UpdateQuery(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, Convert.ToInt32(ComboBox1.SelectedValue), id);
                    DataGrid1.ItemsSource = employees.GetData();
                }
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = Convert.ToInt32(ComboBox2.SelectedValue);
            DataGrid1.ItemsSource = employees.Filtr(a);
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid1.Columns[6].Visibility = Visibility.Hidden;
        }
    }
}
