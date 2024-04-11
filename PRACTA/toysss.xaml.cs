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
    /// Логика взаимодействия для toysss.xaml
    /// </summary>
    public partial class toysss : Page
    {
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        ToysTableAdapter toys = new ToysTableAdapter();
        Animals_CategoriesTableAdapter Animals_Categories = new Animals_CategoriesTableAdapter();
        public toysss()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = toys.GetData();
            ComboBox1.ItemsSource = animals.View();

        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                var data = (DataGrid1.SelectedItem as DataRowView).Row;
                TextBox1.Text = data[1].ToString();
                TextBox2.Text = data[3].ToString();
                ComboBox1.Text = data[6].ToString();
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

            DataGrid1.ItemsSource = toys.GetData();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            //var text = TextBox6.Text;
            //DataGrid1.ItemsSource = toys.Searchtoys(text);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput(TextBox1.Text))
            {
                MessageBox.Show("Поля не должны содержать специальные символы.");
                return;
            }
            if (string.IsNullOrEmpty(TextBox1.Text) || ComboBox1.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все данные перед добавлением.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                MessageBox.Show("Пожалуйста, уберите пробелы.");
                return;
            }
            else if (int.TryParse(TextBox2.Text, out int result))
            {
                if (toys.GetData().Any(t => t.toy_name == TextBox1.Text || t.Animals_Categories_id == Convert.ToInt32(ComboBox1.SelectedValue)))
                {
                    MessageBox.Show("Данные уже существуют, введите уникальные значения.");
                    return;
                }

                toys.InsertQuery(TextBox1.Text, Convert.ToInt32(ComboBox1.SelectedValue), Convert.ToInt32(TextBox2.Text));
                DataGrid1.ItemsSource = toys.GetData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные значения.");
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
                        toys.DeleteQuery(id);
                        DataGrid1.ItemsSource = toys.GetData();
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
                    toys.UpdateQuery(TextBox1.Text, Convert.ToInt32(ComboBox1.SelectedValue), Convert.ToInt32(TextBox2.Text), id);
                    DataGrid1.ItemsSource = toys.GetData();
                }
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var a = Convert.ToInt32(ComboBox2.SelectedValue);
            //DataGrid1.ItemsSource = toys.Filtrtoys(a);
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {

            DataGrid1.Columns[5].Visibility = Visibility.Hidden;
            DataGrid1.Columns[4].Visibility = Visibility.Hidden;
            DataGrid1.Columns[2].Visibility = Visibility.Hidden;

        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (char c in TextBox1.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (char c in TextBox2.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
    }
}
