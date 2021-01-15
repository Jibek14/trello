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
using System.Configuration;
using System.Data.Linq;

namespace TrelloA.tasks_management
{
    /// <summary>
    /// Логика взаимодействия для ChangeTask.xaml
    /// </summary>
    public partial class ChangeTask : Window
    { string connectionString;
        int markerId = 4;
        int userStatus;
        string taskTtitle;
        int creatorUserId=0;DataContext db;
        int taskId;
        public ChangeTask()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            db  = new DataContext(connectionString); 
        }
        private void ChangeTask_Click(object sender, RoutedEventArgs e)
        {
            db.GetTable<Task>().DeleteOnSubmit(db.GetTable<Task>()
                .Where(c => c.Title == taskTtitle).Select(c => c).Single());
            Task changedUserTask = new Task
            { Id = taskId,
                Title = titleTB.Text,
                Description = descriptionTB.Text,
                StatusId = userStatus,
                CreatorUserId = creatorUserId
            };
            db.GetTable<Task>().InsertOnSubmit(changedUserTask);
            db.SubmitChanges();
            MessageBox.Show("данные сохранены");  
        }
        private void FindTask_Click(object sender, RoutedEventArgs e)
        {
            foundTaskBtn.Visibility = Visibility.Visible;
            db = new DataContext(connectionString);
            var taskTitleById = (from u in db.GetTable<Task>()
                           where u.Title == taskTitleTB.Text
                           select u);
            if (taskTitleById.Any())
            {
                var task = (from u in db.GetTable<Task>()
                            where u.Title == taskTitleTB.Text
                            select u);

                foreach (var userTask in task)
                {
                    taskTtitle = userTask.Title;
                    taskId = userTask.Id;
                    titleTB.Text = userTask.Title;
                    descriptionTB.Text = userTask.Description;
                    creatorUserId = userTask.CreatorUserId;
                    //if (userTask.MarkerId == 1)
                    //{
                    //    markerId = 1;
                    //    red.IsChecked = true;
                    //}
                    //else if (userTask.MarkerId == 2)
                    //{
                    //    markerId = 2;
                    //      green.IsChecked = true;
                    //}
                    //else if (userTask.MarkerId == 3)
                    //{
                    //    markerId = 3;
                    //      yellow.IsChecked = true;
                    //}
                    //else
                    //{
                    //    blue.IsChecked = true;
                    //}
                    if (userTask.StatusId == 1)
                    {
                        done.IsChecked = true;  userStatus = 1;
                    }
                    else
                    {
                        notDone.IsChecked = true;   userStatus = 2;
                    }
                }
            }
            else
            {
                MessageBox.Show("задача с таким названием не найдена");
            }
        }
    }
}