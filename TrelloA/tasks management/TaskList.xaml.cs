using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace TrelloA.tasks_management
{
    /// <summary>
    /// Логика взаимодействия для UsersList.xaml
    /// </summary>
    public partial class UsersList : Window
    {
        
        public UsersList()
        {
            InitializeComponent();   
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
    string    connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
         DataContext db = new DataContext(connectionString);
            Table<Task> tasks = db.GetTable<Task>();
            string status="не выполнено";
            foreach(var task in tasks)
            {
                switch (task.StatusId)
                {
                    case 2:
                        status = "выполнено";
                        break;
                }
                usersListTB.Text += $"\n\t№:{task.Id}\nназвание:{task.Title}\nописание:{task.Description}\nстатус: {status}\nавтор задачи(id):{task.CreatorUserId}";
            }
        }
    }
}