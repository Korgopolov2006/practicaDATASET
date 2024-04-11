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
    /// Логика взаимодействия для aquariumsss.xaml
    /// </summary>
    public partial class aquariumsss : Page
    {
        AquariumsTableAdapter aquariums = new AquariumsTableAdapter();
        Animals_CategoriesTableAdapter Animals_Categories = new Animals_CategoriesTableAdapter();
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        public aquariumsss()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = aquariums.GetData();
            ComboBox1.ItemsSource = Animals_Categories.GetData();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
            var data = (DataGrid1.SelectedItem as DataRowView).Row;
            TextBox1.Text = data[1].ToString();

            ComboBox1.Text = data[3].ToString();
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

            DataGrid1.ItemsSource = aquariums.GetData();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            //var text = TextBox6.Text;
            //DataGrid1.ItemsSource = aquariums.Searchaquariums(text);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput(TextBox1.Text) )
            {
                MessageBox.Show("Поля не должны содержать специальные символы.");
                return;
            }
            if (string.IsNullOrEmpty(TextBox1.Text) && ComboBox1.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все данные перед добавлением.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(TextBox1.Text) )
            {
                MessageBox.Show("Пожалуйста, уберите пробелы.");
                return;
            }
            else
            {
                string size = TextBox1.Text;
                int animalId = Convert.ToInt32(ComboBox1.SelectedValue);

                // Проверка на существующие записи
                if (aquariums.GetData().Any(a => a.size == size && a.animal_id == animalId))
                {
                    MessageBox.Show("Данные уже существуют, введите уникальные значения.");
                    return;
                }

                aquariums.InsertQuery(size, animalId);
                DataGrid1.ItemsSource = aquariums.GetData();
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
                        aquariums.DeleteQuery(id);
                        DataGrid1.ItemsSource = aquariums.GetData();
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
                    aquariums.UpdateQuery(TextBox1.Text, Convert.ToInt32(ComboBox1.SelectedValue), id);
                    DataGrid1.ItemsSource = aquariums.GetData();
                }
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var a = Convert.ToInt32(ComboBox2.SelectedValue);
            //DataGrid1.ItemsSource = aquariums.Filtraquariums(a);
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid1.Columns[2].Visibility = Visibility.Hidden;
            //DataGrid1.Columns[3].Visibility = Visibility.Hidden;
        }
    }
}
