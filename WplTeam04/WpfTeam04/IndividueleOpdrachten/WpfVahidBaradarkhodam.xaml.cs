using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using ClassLibTeam04.Mail;
using ClassLibTeam04.Settings;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
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
using WpfTeam04.Properties;
using Settings = ClassLibTeam04.Settings.Settings;

namespace WpfTeam04.IndividueleOpdrachten
{
    /// <summary>
    /// Interaction logic for WpfVahidBaradarkhodam.xaml
    /// </summary>
    public partial class WpfVahidBaradarkhodam : Window
    {
        public WpfVahidBaradarkhodam()
        {
            InitializeComponent();
        }

        private void BtnSelectTestSql_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);
                string quary = "select * from students";
                SqlCommand sql = new SqlCommand(quary, conn);
                conn.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(quary, conn);
                adaptor.SelectCommand = sql;
                var ds = new DataSet();
                adaptor.Fill(ds);
                conn.Close();
                //Data table
                //var dt = ds.Tables[0];
                //Data view
                //var dv = dt.DefaultView;
                DgStudents.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);
            try
            {
                
                string quary = $"insert into Students (firstname,lastname) VALUES ('{TxtVoornaam.Text}','{TxtNaam.Text}')";
                SqlCommand sql = new SqlCommand(quary, conn);
                conn.Open();
                sql.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }

        private void BtnSelectFramework_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DgStudents.ItemsSource = Students.GetStudents();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btnTestmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mail = new PxlMail("vvvahid@gmail.com");
                mail.Body = "TEST";
                mail.Subject = "HALOOOOOOOOOOOOOOOOOOO";
                mail.SendMail();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

