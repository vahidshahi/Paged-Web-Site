using ClassLibTeam04.Settings;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for KlantenToevoegen.xaml
    /// </summary>
    public partial class KlantenToevoegen : Window
    {
        public KlantenToevoegen()
        {
            InitializeComponent();
        }

        private void btnKlantenToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind
                string query = $"Insert into KlantGegevens (Voornaam, Achternaam, Emailadres, Wachtwoord) VALUES('{txtVoornaam.Text}','{txtAchternaam.Text}','{txtEmailadres.Text}','{passwordBxWachtwoord.Password}')";
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

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
