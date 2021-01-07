using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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
    /// Логика взаимодействия для ChangeUser.xaml
    /// </summary>
    public partial class ChangeUser : Window
    {
        string connectionString; SqlConnection connection;
        SqlDataAdapter dataAdapter;bool isGridFull = false;
        public ChangeUser()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
   
        }
        private void MainConnect(string sql)
        {

        }
        private void FindByUserEnterData_Click(object sender, RoutedEventArgs e)
        { 
            string cmd = $"SELECT * FROM [User] WHERE FirstName LIKE '%{findInfoTB.Text}%' or LastName LIKE '%{findInfoTB.Text}%' or id LIKE '%{findInfoTB.Text}%' or UserName LIKE '%{findInfoTB.Text}%'";
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("user");
            dataAdapter.Fill(dt);
            usersGrid.ItemsSource = dt.DefaultView;           
            connection.Close();
            usersGrid.Columns[0].IsReadOnly = true;
            isGridFull = true;
        }
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (isGridFull)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = $"Update [User] set firstName='{usersGrid.Columns[1]}',lastName='{usersGrid.Columns[2]}', userName ='{usersGrid.Columns[3]}' where id = {usersGrid.Columns[0]} ";
                using(SqlCommand cmd=new SqlCommand(sql, this.connection))
                {
                    cmd.ExecuteNonQuery(); isGridFull = false;
                    MessageBox.Show("изменения внесены"); 
                }
            }
            else
            {
                MessageBox.Show("изменения не найдены");
            }
        }
    }
}