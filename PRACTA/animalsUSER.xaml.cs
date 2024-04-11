using PRACTA.ZooMagazinDataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRACTA
{
    /// <summary>
    /// Логика взаимодействия для animalsUSER.xaml
    /// </summary>
    public partial class animalsUSER : Page
    {
            AnimalsTableAdapter animalss = new AnimalsTableAdapter();
            Animals_CategoriesTableAdapter Animals_Categories = new Animals_CategoriesTableAdapter();
        public animalsUSER()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = animalss.View();
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

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add(object sender, RoutedEventArgs e)
        {

        }
        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid1.Columns[4].Visibility = Visibility.Hidden;
        }
    }
}
