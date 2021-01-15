using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace TrelloA.stProcedures
{
    /// <summary>
    /// Логика взаимодействия для TaskTitleByStatus.xaml
    /// </summary>
    public partial class TaskTitleByStatus : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public TaskTitleByStatus()
        {
            InitializeComponent();
        }

        private void GetTaskTitleByStatus_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "sp_GetTasksByStatus";
            using (SqlConnection connection = new SqlConnection(connectionString))
            { int statusId;
                if (notDone.IsChecked == true)
                {
                    statusId = 2;
                }
                else
                {
                    statusId = 1;
                }
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idTaskParam = new SqlParameter
                {
                    ParameterName = "@statusId",
                    Value = statusId
                };
                command.Parameters.Add(idTaskParam);
                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    taskByStatusTB.Text = reader.GetName(0);
                    while (reader.Read())
                    {
                        taskByStatusTB.Text += $"\n\t{reader.GetString(0)}\n";
                    }
                }
            }
        }
    }
}
