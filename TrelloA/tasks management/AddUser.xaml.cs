using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace TrelloA.tasks_management
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {    string sqlExpTaskMarker;
        private readonly string connectionString;
        public AddUser()
        {
            InitializeComponent();
        connectionString= ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; 
            
        }
        private void MainConnection(string sqlExpression)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("good");
        }
        private void AddUserToTask_Click(object sender, RoutedEventArgs e)
        { sqlExpTaskMarker = $"INSERT INTO TaskUser (taskId,userId) VALUES({taskIdTB.Text},{userIdTB.Text});";  
            MainConnection(sqlExpTaskMarker);                                      
        }

        private void DeleteUserFromTask_Click(object sender, RoutedEventArgs e)
        {string  sqlExpTaskUser = $"delete  FROM taskUser WHERE taskId = {taskIdTB.Text} AND USERID={userIdTB.Text}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpTaskUser, connection);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("good");
        }
    }
}