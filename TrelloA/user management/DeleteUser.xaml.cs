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
using System.Windows.Shapes;

namespace TrelloA.user_management
{
    /// <summary>
    /// Логика взаимодействия для DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        public DataSet dataSet = new DataSet();
        string connectionString; string sqlExpression;
        public DeleteUser()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        DataTable dt = new DataTable();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;

                SqlCommand com = new SqlCommand("SELECT * from [user]", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(com);
                dt = new DataTable();
                sda.Fill(dt);

                gridPosts.ItemsSource = dt.DefaultView;
                gridPosts.AutoGenerateColumns = true;
                gridPosts.CanUserAddRows = false;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)gridPosts.SelectedItem;
            dt.Rows.Remove(row.Row);
        }
        private void MainConnection(string sqlQuery, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                adapter.Fill(dataSet, tableName);
                gridPosts.ItemsSource = new DataView(dataSet.Tables[tableName]);
            }
        }
        private void SearchByUserEnterData_Click(object sender, RoutedEventArgs e)
        {
            sqlExpression = $"SELECT * FROM [User] WHERE FirstName LIKE '%{findInfoTB.Text}%' or LastName LIKE '%{findInfoTB.Text}%' or id LIKE '%{findInfoTB.Text}%' or UserName LIKE '%{findInfoTB.Text}%'";
            dataSet.Clear();
            if (!String.IsNullOrWhiteSpace(findInfoTB.Text))
            {
                MainConnection(sqlExpression, "[User]"); 
                //нельзя изменить id->[0] и password->[4]
                //usersGrid.Columns[0].IsReadOnly = true;
                //usersGrid.Columns[4].IsReadOnly = true;
               
            }
            else
            {
                MessageBox.Show("введите данные для поиска");
            }
        }
    }
}