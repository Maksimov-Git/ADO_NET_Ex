using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

using System.Configuration;
using System.Collections.Specialized;

namespace ADO_NET_Ex3__Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //  ну вот совсем не безопасно !!!!!!!
            string conStr = "Data Source=tsoop.c6oo9thiejqr.us-east-1.rds.amazonaws.com;" +
          "Persist Security Info=True;" +
          "User ID = " + Login.Text + "; Password=" + Pass.Text + ";";


            //  получение строки подключения по средствам  SqlConnectionStringBuilder
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder();
            sqlConnectionString.DataSource = "tsoop.c6oo9thiejqr.us-east-1.rds.amazonaws.com";
            sqlConnectionString.InitialCatalog = "TestDB";
            sqlConnectionString.UserID = Login.Text;
            sqlConnectionString.Password = Pass.Text;


         //   ConnectionStringSettingsCollection sett = ConfigurationManager.ConnectionStrings;
         //   conStr = sett[0].ConnectionString;
         //   получение строки подключения из файла конфигурации


            ///домашнее задание узнать про пулинг
            sqlConnectionString.Pooling = true;


            // оператор using Предоставляет удобный синтаксис, обеспечивающий
            //правильное использование объектов IDisposable
            using (SqlConnection connection = new SqlConnection(sqlConnectionString.ConnectionString))
            //using (SqlConnection connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection opened to " + connection.Database); // вывод на экран информации о подключении к базе данных
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }


        }
    }
}
