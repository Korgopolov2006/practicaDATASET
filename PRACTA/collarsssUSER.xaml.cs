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
    /// Логика взаимодействия для collarsssUSER.xaml
    /// </summary>
    public partial class collarsssUSER : Page
    {
        CollarsTableAdapter collars = new CollarsTableAdapter();
        public collarsssUSER()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = collars.GetData();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {

                var data = (DataGrid1.SelectedItem as DataRowView).Row;
                TextBox1.Text = data[1].ToString();

            }
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Add(object sender, RoutedEventArgs e)
        {

        }
        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            //DataGrid1.Columns[2].Visibility = Visibility.Hidden;
            //DataGrid1.Columns[3].Visibility = Visibility.Hidden;
        }
    }
}
