using PRACTA.ZooMagazinDataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для animals.xaml
    /// </summary>
    public partial class animals : Page
    {
        AnimalsTableAdapter animalss = new AnimalsTableAdapter();
        Animals_CategoriesTableAdapter Animals_Categories = new Animals_CategoriesTableAdapter();
        public animals()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = animalss.View();
            ComboBox2.ItemsSource = Animals_Categories.GetData();
            ComboBox1.ItemsSource = Animals_Categories.GetData();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
            var data = (DataGrid1.SelectedItem as DataRowView).Row;
            TextBox1.Text = data[1].ToString();
            TextBox2.Text = data[2].ToString();
            TextBox3.Text = data[3].ToString();
            ComboBox1.Text = data[5].ToString();
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

            DataGrid1.ItemsSource = animalss.View();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            var text = TextBox6.Text;
            DataGrid1.ItemsSource = animalss.Search(text);
        }

        //private bool CheckIfCategoryExists(int Animals_Categories_id)
        //{
        //    bool categoryExists = false;

        //    // Соединяемся с базой данных
        //    using (SqlConnection connection = new SqlConnection("LAPTOP-US6QNDJV\\SQLEXPRESS02"))
        //    {
        //        // Открываем соединение
        //        connection.Open();

        //        // Создаем SQL команду для запроса к таблице Animals_Categories
        //        string sql = "SELECT COUNT(*) FROM Animals_Categories WHERE Id = @Animals_Categories_id";
        //        using (SqlCommand command = new SqlCommand(sql, connection))
        //        {
        //            // Добавляем параметр Animals_Categories_id к запросу
        //            command.Parameters.AddWithValue("@Animals_Categories_id", Animals_Categories_id);

        //            // Получаем количество записей с указанным Animals_Categories_id
        //            int count = (int)command.ExecuteScalar();

        //            // Если количество записей больше нуля, значит Animals_Categories_id существует
        //            if (count > 0)
        //            {
        //                categoryExists = true;
        //            }
        //        }
        //    }

        //    return categoryExists;
        //}

        private void Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text) || string.IsNullOrEmpty(TextBox3.Text) || ComboBox1.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все данные перед добавлением.");
                return;
            }
            if (!IsValidInput(TextBox1.Text) && !IsValidInput(TextBox3.Text) && !IsValidInput(TextBox2.Text) )
            {
                MessageBox.Show("Поля не должны содержать специальные символы.");
                return;
            }

            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text) || string.IsNullOrWhiteSpace(TextBox3.Text))
            {
                MessageBox.Show("Пожалуйста, уберите пробелы.");
                return;
            }

            if (TextBox2.Text.All(char.IsDigit) && TextBox3.Text.All(char.IsDigit)) // Проверка на числа в TextBox2 и TextBox3
            {
                if (int.TryParse(TextBox2.Text, out int value2) && int.TryParse(TextBox3.Text, out int value3))
                {
                    if (!string.IsNullOrWhiteSpace(TextBox1.Text) && TextBox1.Text.All(char.IsLetter)) // Проверка на буквы в TextBox1
                    {
                        animalss.InsertQuery(TextBox1.Text, Convert.ToInt32(TextBox2.Text), Convert.ToInt32(TextBox3.Text), Convert.ToInt32(ComboBox1.SelectedValue));
                        DataGrid1.ItemsSource = animalss.View();
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите только буквы в поле 'TextBox1'.");
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите только числа в поля 'TextBox2' и 'TextBox3'.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите только числа в поля 'TextBox2' и 'TextBox3'.");
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
                        animalss.DeleteQuery(id);
                        DataGrid1.ItemsSource = animalss.View();
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
                    animalss.UpdateQuery1(TextBox1.Text, Convert.ToInt32(TextBox2.Text), Convert.ToInt32(TextBox3.Text), Convert.ToInt32(ComboBox1.SelectedValue), id);
                    DataGrid1.ItemsSource = animalss.View();
                }
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox2.SelectedValue != null)
            {
                DataRowView row = ComboBox2.SelectedValue as DataRowView;
                if (row != null)
                {
                    int Animals_Categories_id;
                    if (int.TryParse(row["Animals_Categories_id"].ToString(), out Animals_Categories_id))
                    {
                        DataGrid1.ItemsSource = animalss.FiltrAnimals(Animals_Categories_id);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось получить идентификатор категории из выбранной строки.");
                    }
                }
            }
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid1.Columns[4].Visibility = Visibility.Hidden;
        }
    }
}
