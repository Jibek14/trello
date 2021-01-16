using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows;
using System.Data.Linq;
using System.Data.SqlClient;

namespace TrelloA.tasks_management
{
    public partial class NewTask : Window
    {
        string connectionString=ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public NewTask()
        {
            InitializeComponent();
        }
        private void InsertIntoTaskMarker(int markerId,int taskId)
        {
  string sqlExpTaskMarker = $"INSERT INTO taskMarker (idMarker,idTask) VALUES({markerId},{taskId});";
          using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpTaskMarker, connection);
                command.ExecuteNonQuery();
            }
        }
        private void CreateTask_Click(object sender, RoutedEventArgs e)
        {
            bool userInDB = false;
            List<int> userId = new List<int>();
            string sqlExpression = "Select * FROM [User]";
            using (SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    int id = reader.GetInt32(0);
                    userId.Add(id);
                    if (Convert.ToInt32(creatorIdTB.Text) == reader.GetInt32(0))
                    {
                        userInDB = true; 
                    }
                    }
            }
            int userStatus;
            if (notDone.IsChecked == true)
            {
                userStatus = 2;
            }
            else
            {
                userStatus = 1;
            }
            if (userInDB)
            {   DataContext db = new DataContext(connectionString);
                Task userTask = new Task
                {
                    Title = titleTB.Text,
                    Description = descriptionTB.Text,                   
                    StatusId = userStatus,
                    CreatorUserId = Convert.ToInt32(creatorIdTB.Text),
                };     
                db.GetTable<Task>().InsertOnSubmit(userTask);
                db.SubmitChanges();
                int taskId = userTask.Id;
                MessageBox.Show($"данные сохранены\nномер задачи{taskId}");
                if (red.IsChecked == true)
                {
                    InsertIntoTaskMarker(1, taskId);
                }
                if (green.IsChecked == true)
                {
                    InsertIntoTaskMarker(2, taskId);
                }
                if (yellow.IsChecked == true)
                {
                    InsertIntoTaskMarker(3, taskId);
                }
                if (blue.IsChecked == true)
                {
                    InsertIntoTaskMarker(4, taskId);
                }
                MessageBox.Show("markerTask ready too!");
            }
            else
            {
                MessageBox.Show("Пользователь с таким id не найден в базе");
            }
        }
    }
}