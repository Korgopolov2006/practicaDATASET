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
    /// Логика взаимодействия для customer.xaml
    /// </summary>
    public partial class customer : Page
    {
        CustomersTableAdapter customers = new CustomersTableAdapter();
        public customer()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = customers.GetData();
            //ComboBox2.ItemsSource = customers.GetData();
            //ComboBox1.ItemsSource = customers.GetData();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                var data = (DataGrid1.SelectedItem as DataRowView).Row;
                TextBox1.Text = data[1].ToString();
                TextBox2.Text = data[2].ToString();
                TextBox3.Text = data[3].ToString();
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

            DataGrid1.ItemsSource = customers.GetData();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            var text = TextBox6.Text;
            DataGrid1.ItemsSource = customers.CustomersSearch(text);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput(TextBox1.Text) && !IsValidInput(TextBox3.Text) && !IsValidInput(TextBox2.Text))
            {
                MessageBox.Show("Поля не должны содержать специальные символы.");
                return;
            }
            if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text) && !string.IsNullOrEmpty(TextBox3.Text))
            {
                if (!string.IsNullOrWhiteSpace(TextBox1.Text) && !string.IsNullOrWhiteSpace(TextBox2.Text) && !string.IsNullOrWhiteSpace(TextBox3.Text))
                {
                    if (TextBox1.Text.All(char.IsLetter) && TextBox2.Text.All(char.IsLetter) && TextBox3.Text.All(char.IsLetter))
                    {
                        customers.InsertQuery(TextBox1.Text, TextBox2.Text, TextBox3.Text);
                        DataGrid1.ItemsSource = customers.GetData();
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите только буквы в полях.");
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, уберите пробелы.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все данные перед добавлением.");
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
                        customers.DeleteQuery(id);
                        DataGrid1.ItemsSource = customers.GetData();
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
                    customers.UpdateQuery(TextBox1.Text, TextBox2.Text,TextBox3.Text ,id);
                    DataGrid1.ItemsSource = customers.GetData();
                }
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var a = Convert.ToInt32(ComboBox2.SelectedValue);
            //DataGrid1.ItemsSource = customers.Filtrcustomers(a);
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
