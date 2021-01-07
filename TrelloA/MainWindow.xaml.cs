using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrelloA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void CreateUserInDB_Click(object sender, RoutedEventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
        }

        private void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            ChangeUser changeUser = new ChangeUser();
            changeUser.Show();
        }

        private void GetUserList_Click(object sender, RoutedEventArgs e)
        { 
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string cmd = "SELECT id,firstName,lastName,UserName FROM [user]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("user");
            dataAdapter.Fill(dt);
            usersGrid.ItemsSource = dt.DefaultView;
            connection.Close();  usersGrid.Columns[0].IsReadOnly = true;
            usersGrid.Columns[1].IsReadOnly = true;
            usersGrid.Columns[2].IsReadOnly = true;
            usersGrid.Columns[3].IsReadOnly = true;
        }
    }
}