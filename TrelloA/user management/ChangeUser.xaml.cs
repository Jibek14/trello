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
        public DataSet dataSet = new DataSet();
        string connectionString; string sqlExpression;bool dataIsShowed = false;
        public ChangeUser()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
   
        }
        private void SearchByUserEnterData_Click(object sender, RoutedEventArgs e)
        {  sqlExpression = $"SELECT * FROM [User] WHERE FirstName LIKE '%{findInfoTB.Text}%' or LastName LIKE '%{findInfoTB.Text}%' or id LIKE '%{findInfoTB.Text}%' or UserName LIKE '%{findInfoTB.Text}%'";         
           dataSet.Clear();
            if (!String.IsNullOrWhiteSpace(findInfoTB.Text))
            {   
                MainConnection(sqlExpression,"[User]");dataIsShowed = true;
            }else
            {
                MessageBox.Show("введите данные для поиска");
            }
        }
        private void MainConnection(string sqlQuery, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                adapter.Fill(dataSet, tableName);
                usersGrid.ItemsSource = new DataView(dataSet.Tables[tableName]);
                //нельзя изменить id->[0] и password->[4]
                usersGrid.Columns[0].IsReadOnly = true; 
                usersGrid.Columns[4].IsReadOnly = true;
            }
        }
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
           
            if (dataIsShowed)
            {
            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connectionString);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables["[user]"]);MessageBox.Show("готово");
            }
            else
            {
                MessageBox.Show("изменения не найдены");
            }
        }
    }
}