using PRACTA;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PRACTA.ZooMagazinDataSet1TableAdapters;


namespace PRACTA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        EmployeesTableAdapter Employees = new EmployeesTableAdapter();
        public MainWindow()
        {
            InitializeComponent();

        }



        private void Autorizet(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.");
                return;
            }
            var AllLogins = Employees.GetData().Rows;
            bool foundUser = false;


            for (int i = 0; i < AllLogins.Count; i++)
            {
                if (AllLogins[i][4].ToString() == TextBox1.Text && AllLogins[i][5].ToString() == TextBox2.Password)
                {
                    int role_id = (int)AllLogins[i][6];
                    foundUser = true;

                    switch (role_id)
                    {
                        case 1:
                            AdminWindow1 AdminWindow1 = new AdminWindow1();
                            AdminWindow1.Show();
                            this.Close();
                            break;
                        case 2:
                            UserWindow UserWindow = new UserWindow();
                            UserWindow.Show();
                            this.Close();
                            break;

                    }
                }

            }
            if (!foundUser)
            {
                MessageBox.Show("Неверный логин или пароль.");
            }

        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}


