using ClassLibTeam04.Settings;
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

namespace WpfTeam04.TestingDBboeken
{
    /// <summary>
    /// Interaction logic for TestBoekData.xaml
    /// </summary>
    public partial class TestBoekData : Window
    {
        public TestBoekData()
        {
            InitializeComponent();
        }


        private void VieuwData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind

                string query = "select * from Boeken;";
                SqlCommand sql = new SqlCommand(query, conn);

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = sql;
                var ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();

                //DataTable
                var dt = ds.Tables[0];
                //Datavieuw
                var dv = dt.DefaultView;
                datagridStudents.ItemsSource = dv;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnSelectTestSql_Click(object sender, RoutedEventArgs e)
        {
            VieuwData();

        }// ----->>> om data uit de databank weer te geven 
       
        
        /*private void AddData()  // ----->>> om data aan de databank toe te voegen 
        {
            try
            {
                SqlConnection conn = new SqlConnection(Settings.Database.BoekenDataConnectionstring);//Settings.Datbase.Ind

                string query = $"insert into Students (LastName, FirstName) values ('{txtNaam.Text}','{txtVoornaam.Text}');";
                SqlCommand sql = new SqlCommand(query, conn);

                conn.Open();
                sql.ExecuteNonQuery();
                conn.Close();
                VieuwData();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnIsert_Click(object sender, RoutedEventArgs e)
        {
            AddData();
        }*/
    }
}
