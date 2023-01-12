using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
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

namespace WpfTeam04.Project
{
    /// <summary>
    /// Interaction logic for Wpflogin.xaml
    /// </summary>
    public partial class Wpflogin : Window
    {
        public Wpflogin()
        {
            InitializeComponent();
        }

        private void btnAdminLogin_Click(object sender, RoutedEventArgs e)
        {
            Adminlogin adminlogin = new Adminlogin();
            adminlogin.ShowDialog();
        }
       
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);
                conn.Open();
                string query = $"Select Email, Wachtwoord from Users where Email = '{TxtEmail.Text}' AND Wachtwoord = '{PasswrBoxPassword.Password}'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(adapter);
                DataSet ds = new DataSet();
                var dt = new DataTable();
                adapter.Fill(dt);
                //adapter.Fill(ds);
                //var dt = ds.Tables[0];

                if(dt.Rows.Count > 0)
                {
                    WpfBoekenToevoegen wpfBoekenToevoegen = new WpfBoekenToevoegen();
                    wpfBoekenToevoegen.ShowDialog();
                    this.Hide();
                    conn.Close();
                   
                }
                else
                {
                    MessageBox.Show("Username of wachtwoord is niet juist");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nieuwAccount_Click(object sender, RoutedEventArgs e)
        {
            WpfUsers wpfUsers = new WpfUsers();
            wpfUsers.ShowDialog();
        }
    }
}
