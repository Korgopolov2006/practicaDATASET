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
    /// Логика взаимодействия для Reviewsss.xaml
    /// </summary>
    public partial class Reviewsss : Page
    {
        ReviewsTableAdapter reviews = new ReviewsTableAdapter();
        public Reviewsss()
        {

            InitializeComponent();
            DataGrid1.ItemsSource = reviews.GetData();
            ComboBox1.ItemsSource = reviews.GetData();
            ComboBox2.ItemsSource = reviews.GetData();
            //ComboBox4.ItemsSource = reviews.GetData();
            List<int> values = new List<int>() { 1, 2, 3, 4, 5 };
            ComboBox3.ItemsSource = values;

        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
            var data = (DataGrid1.SelectedItem as DataRowView).Row;
            TextBox1.Text = data[1].ToString();
            ComboBox1.Text = data[2].ToString();
            ComboBox2.Text = data[3].ToString();
            ComboBox3.Text = data[4].ToString();
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

            DataGrid1.ItemsSource = reviews.GetData();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            //var text = TextBox6.Text;
            //DataGrid1.ItemsSource = reviews.Searchreviews(text);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput(TextBox1.Text))
            {
                MessageBox.Show("Поля не должны содержать специальные символы.");
                return;
            }
            if (string.IsNullOrEmpty(TextBox1.Text) && ComboBox1.SelectedValue == null && ComboBox2.SelectedValue == null && ComboBox3.SelectedValue == null )
            {
                MessageBox.Show("Пожалуйста, заполните все данные перед добавлением.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                MessageBox.Show("Пожалуйста, уберите пробелы.");
                return;
            }
            else
            {
                reviews.InsertQuery(Convert.ToInt32(ComboBox1.SelectedValue), Convert.ToInt32(ComboBox2.SelectedValue), TextBox1.Text, Convert.ToInt32(ComboBox3.SelectedValue));
                DataGrid1.ItemsSource = reviews.GetData();
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
                            var id = Convert.ToInt32(row[0]);
                            reviews.DeleteQuery(id);
                            DataGrid1.ItemsSource = reviews.GetData();
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
                    reviews.UpdateQuery(Convert.ToInt32(ComboBox1.SelectedValue), Convert.ToInt32(ComboBox2.SelectedValue), TextBox1.Text, Convert.ToInt32(ComboBox3.SelectedValue), id);
                    DataGrid1.ItemsSource = reviews.GetData();
                }
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var a = Convert.ToInt32(ComboBox2.SelectedValue);
            //DataGrid1.ItemsSource = reviews.Filtrreviews(a);
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid1.Columns[5].Visibility = Visibility.Hidden;
            DataGrid1.Columns[6].Visibility = Visibility.Hidden;
        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
