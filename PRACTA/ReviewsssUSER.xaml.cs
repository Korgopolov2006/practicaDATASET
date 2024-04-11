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
    /// Логика взаимодействия для ReviewsssUSER.xaml
    /// </summary>
    public partial class ReviewsssUSER : Page
    {
        ReviewsTableAdapter reviews = new ReviewsTableAdapter();
        public ReviewsssUSER()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = reviews.GetData();
            ComboBox1.ItemsSource = reviews.GetData();
            ComboBox2.ItemsSource = reviews.GetData();
            List<int> values = new List<int>() { 1, 2, 3, 4, 5 };
            ComboBox3.ItemsSource = values;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text) || ComboBox1.SelectedValue == null || ComboBox2.SelectedValue == null || ComboBox3.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все данные перед добавлением.");
                return;
            }
            else
            {
                reviews.InsertQuery(Convert.ToInt32(ComboBox1.SelectedValue), Convert.ToInt32(ComboBox2.SelectedValue), TextBox1.Text, Convert.ToInt32(ComboBox3.SelectedValue));
                DataGrid1.ItemsSource = reviews.GetData();
            }
        }
        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid1.Columns[5].Visibility = Visibility.Hidden;
            DataGrid1.Columns[6].Visibility = Visibility.Hidden;
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
    }
}
