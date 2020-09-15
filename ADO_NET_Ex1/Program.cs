using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ADO_NET_Ex1
{
    class Program
    {
       


        static void Main(string[] args)
        {
            string conStr = "Data Source=tsoop.c6oo9thiejqr.us-east-1.rds.amazonaws.com;" +
           "Persist Security Info=True;" +
           "User ID = admin; Password=Geirby1799";

            SqlConnection connection = new SqlConnection(conStr);

            connection.Open();

            connection.Close();

            try
            {
                connection.Open(); // открытие физического подключения к источнику данных 
                Console.WriteLine(connection.State);

                Console.WriteLine                 //вывод информации о соединении и его состоянии
               (
               "Connection to" + Environment.NewLine +
               "Data Source: " + connection.DataSource + Environment.NewLine +
               "Database: " + connection.Database + Environment.NewLine +
               "State: " + connection.State
               );

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close(); //закрытие физического соединения с источником данных
                Console.WriteLine(connection.State);
            }






            Console.ReadKey();
        }
    }
}
