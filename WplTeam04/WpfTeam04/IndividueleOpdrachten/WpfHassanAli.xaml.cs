using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using ClassLibTeam04.IndividueleTaken.HassanAli.HassanAli;
using ClassLibTeam04.Mail;
using ClassLibTeam04.Settings;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfTeam04.IndividueleOpdrachten
{
    /// <summary>
    /// Interaction logic for WpfHassanAli.xaml
    /// Origineel 
    /// Werkt
    /// Niet pushen
    /// </summary>
    public partial class WpfHassanAli : Window
    {
       

        public WpfHassanAli()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var hassan = new HassanAli();
            TxtNaam.Text = hassan.Voornaam;
            TxtNaam.Text = hassan.Naam;
            foreach (var hobby in hassan.Hobbies)
            {
                LstHobbies.Items.Add(hobby);
            }
         }

        private void BtnSelectTestSql_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind
                string query = "select * from Students;";
                SqlCommand sql = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = sql;
                var ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();
                //DataTable
                var dt = ds.Tables[0];
                var dv = dt.DefaultView;
                DgStudents.ItemsSource = dv;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind
                string query = $"Insert into students (firstname, lastname) VALUES('{TxtVoornaam.Text}','{TxtNaam.Text}')";
                SqlCommand sql = new SqlCommand(query, conn);
                conn.Open();
                sql.ExecuteNonQuery();
                conn.Close();
              
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSelectFramework_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DgStudents.ItemsSource = Students.GetStudents();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnInsertFfrmwrk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = new Student();
                student.FirstName = TxtVoornaam.Text;
                student.LastName = TxtNaam.Text;
                Students.AddStudent(student);
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void BtnTestMail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mail = new PxlMail("hassan.ali@student.pxl.be");
                mail.Body = "test";
                mail.Subject = "test";
                mail.SendMail();
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void BtnSelectFirst_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DgStudents.ItemsSource = Students.GetStudentsDataTable(TxtVoornaam.Text).DefaultView;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
