using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace TrelloA
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void SaveUserDB(object sender, RoutedEventArgs e)
        {
            string connectionString= @"Data Source=.\SQLEXPRESS;Initial Catalog=trello;Integrated Security=True";
            string sqlExpression = $"INSERT INTO [User] VALUES('{nameTB.Text}','{lastNameTB.Text}','{nikTB.Text}','{passwordTB.Text}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression,connection);
                try
                {
                    if(String.IsNullOrEmpty(nameTB.Text)|| String.IsNullOrEmpty(lastNameTB.Text)|| String.IsNullOrEmpty(nikTB.Text)|| String.IsNullOrEmpty(passwordTB.Text))
                    {
                        MessageBox.Show("Один из полей пуст!Повторите попытку.");
                    }
                    else
                    {
                         command.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно сохранены");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}