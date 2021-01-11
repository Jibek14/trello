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
    /// <summary>
    /// Логика взаимодействия для NewTask.xaml
    /// </summary>
    public partial class NewTask : Window
    {
        string connectionString=ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public NewTask()
        {
            InitializeComponent();
        }
        private void CreateTask_Click(object sender, RoutedEventArgs e)
        { int userMarker;bool userInDB = false;
           List<int> userId = new List<int>();
            string sqlExpression = "Select * FROM [User]";
            using (SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    // int id = reader.GetInt32(0);
                    int id = reader.GetInt32(0);
                    userId.Add(id);
                  
                    if (Convert.ToInt32(creatorIdTB.Text) == reader.GetInt32(0))
                    {
                        userInDB = true; 
                    }
                }
            }
           
            if (red.IsChecked == true)
            {
                userMarker = 1;
            }
            else if (green.IsChecked == true)
            {
                userMarker = 2;
            }
            else if (yellow.IsChecked == true)
            {
                userMarker = 3;
            }
            else
            {
                userMarker = 4;
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
          
            // Table<Task> tasks = db.GetTable<Task>();
           // bool check = DateTime.TryParse( ,out result);
          //  MessageBox.Show(check.ToString());
            if (userInDB)
            {  DataContext db = new DataContext(connectionString);
                Task userTask = new Task
                {
                    Title = titleTB.Text,
                    Description = descriptionTB.Text,
                    MarkerId = userMarker,
                    StatusId = userStatus,
                 //   CreateTime =result,
                    CreatorUserId = Convert.ToInt32(creatorIdTB.Text),
               //     UserDeletedTime=result,
                  //  UserId=default,
                  //  UserInsertedTime=result
                };
              
                db.GetTable<Task>().InsertOnSubmit(userTask);
                db.SubmitChanges();
                MessageBox.Show("данные сохранены");
                red.IsChecked = false; green.IsChecked = false;
                yellow.IsChecked = false; blue.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Пользователь с таким id не найден в базе");
            }
        }
    }
}