using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PRACTA
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void Animals_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new animalsUSER();
        }

        private void Food_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new fodUSER();
        }

        private void Toys_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new toysssUSER();
        }

        private void Aquariums_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new aquariumsssUSER();
        }

        private void Collars_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new collarsssUSER();
        }

        private void Reviews_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new ReviewsssUSER();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            
        }
    }
}
