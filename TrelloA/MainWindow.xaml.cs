using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using TrelloA.tasks_management;
using TrelloA.user_management;

namespace TrelloA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string connectionString;
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
           dt.Clear();  dataAdapter.Fill(dt);
            usersGrid.ItemsSource = dt.DefaultView;
            connection.Close();  usersGrid.Columns[0].IsReadOnly = true;
            usersGrid.Columns[1].IsReadOnly = true;
            usersGrid.Columns[2].IsReadOnly = true;
            usersGrid.Columns[3].IsReadOnly = true;
            usersGrid.CanUserDeleteRows = false;
        }
        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser deleteUser = new DeleteUser();
            deleteUser.Show();
        }
        private void CreateTask_Click(object sender, RoutedEventArgs e)
        {
           NewTask newTask = new NewTask();
            newTask.Show();
        }
        private void GetTasksList_Click(object sender, RoutedEventArgs e)
        {
            UsersList usersList = new UsersList();
            usersList.Show();
        }

        private void ChangeTask_Click(object sender, RoutedEventArgs e)
        {
            ChangeTask changeTask = new ChangeTask();
            changeTask.Show();
        }

        private void GetMarkersListOfTask_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}