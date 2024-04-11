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
    /// Логика взаимодействия для Rolesss.xaml
    /// </summary>
    public partial class Rolesss : Page
    {
        RolesTableAdapter Roles = new RolesTableAdapter();
        public Rolesss()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = Roles.GetData();
            //ComboBox1.ItemsSource = Roles.GetData();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
            var data = (DataGrid1.SelectedItem as DataRowView).Row;
            TextBox1.Text = data[1].ToString();
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

            DataGrid1.ItemsSource = Roles.GetData();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            //var text = TextBox6.Text;
            //DataGrid1.ItemsSource = Roles.SearchRoles(text);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput(TextBox1.Text))
            {
                MessageBox.Show("Поля не должны содержать специальные символы.");
                return;
            }
            if (string.IsNullOrEmpty(TextBox1.Text))
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
                string roleName = TextBox1.Text;

                // Проверка на существующие записи
                if (Roles.GetData().Any(r => r.role_name == roleName))
                {
                    MessageBox.Show("Данная роль уже существует, введите уникальное значение.");
                    return;
                }

                Roles.InsertQuery(roleName);
                DataGrid1.ItemsSource = Roles.GetData();
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
                        Roles.DeleteQuery(id);
                        DataGrid1.ItemsSource = Roles.GetData();
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
                    var id = Convert.ToInt32(dataRowView.Row[0]);
                    Roles.UpdateQuery(TextBox1.Text, id);
                    DataGrid1.ItemsSource = Roles.GetData();
                }
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var a = Convert.ToInt32(ComboBox2.SelectedValue);
            //DataGrid1.ItemsSource = Roles.FiltrRoles(a);
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            //DataGrid1.Columns[2].Visibility = Visibility.Hidden;
            //DataGrid1.Columns[3].Visibility = Visibility.Hidden;
        }
    }
}
