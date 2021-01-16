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
    /// Логика взаимодействия для MarkersById.xaml
    /// </summary>
    public partial class MarkersById : Window
    { string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public MarkersById()
        {
            InitializeComponent();
        }
        private void GetMarkersListOfTaskById_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "sp_GetMarkersById";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idTaskParam = new SqlParameter
                {
                    ParameterName = "@taskId",
                    Value = taskId.Text
                };
                command.Parameters.Add(idTaskParam);
                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    markersListTB.Text = reader.GetName(0);
                    while (reader.Read())
                    {
                        markersListTB.Text += $"\n\t{reader.GetString(0)}\n";
                    }
                }
            }
        }

        private void GetUsersHistory_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "sp_ShowHistory";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idTaskParam = new SqlParameter
                {
                    ParameterName = "@taskId",
                    Value = taskId.Text
                };
                command.Parameters.Add(idTaskParam);
                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        markersListTB.Text += $"\nпользователь {reader.GetInt32(1)}|был {reader.GetString(3)}|в {reader.GetDateTime(4)}";
                    }
                }
            }
        }
    }
}