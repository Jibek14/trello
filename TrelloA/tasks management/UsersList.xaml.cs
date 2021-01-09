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
            foreach(var task in tasks)
            {
                usersListTB.Text += $"\n\t№:{task.Id}\nназвание:{task.Title}\nописание:{task.Description}\nважность:{task.MarkerId}\nстатус: {task.StatusId}\nпользователь{task.UserId}\n\t";
            }
        }
    }
}
