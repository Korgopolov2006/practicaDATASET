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
    /// Логика взаимодействия для fod.xaml
    /// </summary>
    public partial class fod : Page
    {
        FoodTableAdapter food = new FoodTableAdapter();
        Food_CategoriesTableAdapter Food_Categories = new Food_CategoriesTableAdapter();
        public fod()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = food.GetData();
            ComboBox2.ItemsSource = Food_Categories.GetData();
            ComboBox1.ItemsSource = Food_Categories.GetData();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
            var data = (DataGrid1.SelectedItem as DataRowView).Row;
            TextBox1.Text = data[1].ToString();
            TextBox2.Text = data[2].ToString();
            TextBox3.Text = data[3].ToString();
            TextBox3.Text = data[4].ToString();
            ComboBox1.Text = data[5].ToString();
            }
        }


        private bool IsValidInput(string input)
        {
            string pattern = @"^[\p{L}0-9_ ]*$"; 

            return Regex.IsMatch(input, pattern);
        }



        private void Cleaning(object sender, RoutedEventArgs e)
        {

            DataGrid1.ItemsSource = food.GetData();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            var text = TextBox6.Text;
            DataGrid1.ItemsSource = food.SearchFood(text);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput(TextBox1.Text) && !IsValidInput(TextBox3.Text) && !IsValidInput(TextBox2.Text))
            {
                MessageBox.Show("Поля не должны содержать специальные символы.");
                return;
            }
            if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text) && string.IsNullOrEmpty(TextBox3.Text) && ComboBox1.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все данные перед добавлением.");
                return;
            }

            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text) || string.IsNullOrWhiteSpace(TextBox3.Text))
            {
                MessageBox.Show("Пожалуйста, уберите пробелы.");
                return;
            }

            if (TextBox1.Text.Any(char.IsDigit) || TextBox2.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Пожалуйста, введите только буквенные символы в поля 'TextBox1' и 'TextBox2'.");
                return;
            }

            if (decimal.TryParse(TextBox3.Text, out decimal price))
            {
                if (food.GetData().Any(f => f.food_name == TextBox1.Text && f.manufacturer == TextBox2.Text && f.price == price && f.Food_Categories_id == Convert.ToInt32(ComboBox1.SelectedValue)))
                {
                    MessageBox.Show("Данные уже существуют, введите уникальные значения.");
                    return;
                }

                food.InsertQuery(TextBox1.Text, TextBox2.Text, price, Convert.ToInt32(ComboBox1.SelectedValue));
                DataGrid1.ItemsSource = food.GetData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для цены продукта.");
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
                        food.DeleteQuery(id);
                        DataGrid1.ItemsSource = food.GetData();
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
                    food.UpdateQuery(TextBox1.Text, TextBox2.Text, Convert.ToInt32(TextBox3.Text), Convert.ToInt32(ComboBox1.SelectedValue), id);
                    DataGrid1.ItemsSource = food.GetData();
                }
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = Convert.ToInt32(ComboBox2.SelectedValue);
            DataGrid1.ItemsSource = food.FiltrFood(a);
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid1.Columns[4].Visibility = Visibility.Hidden;
        }
    }
}
