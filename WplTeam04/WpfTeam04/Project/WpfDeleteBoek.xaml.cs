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
    /// Interaction logic for WpfDeleteBoek.xaml
    /// </summary>
    public partial class WpfDeleteBoek : Window
    {
        public WpfDeleteBoek()
        {
            InitializeComponent();
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            string ean = TextBoxEAN.Text;
            string titel = TextBoxBoekNaam.Text;
            if (titel != " " || ean != " ")
            {
                try
                {
                    SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind
                    string query = $"DELETE FROM Boeken where EAN = '{ean}' OR Titel = '{titel}';";
                    SqlCommand sql = new SqlCommand(query, conn);
                    conn.Open();
                    sql.ExecuteNonQuery();
                    MessageBox.Show("Het Boek is verwijderd");
                    conn.Close();
                    
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(e.Handled.ToString());
            }
            
          

        }
        private void ToonBoekenInDatagrid()
        {

            SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind
            conn.Open();
            string query = "Select * from boeken";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            var dv = dt.DefaultView;
            DataGridBoeken.ItemsSource = dv;
            conn.Close();

        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ToonBoekenInDatagrid();
        }

        private void DataGridBoeken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRowView = DataGridBoeken.SelectedItem as DataRowView;
            TextBoxEAN.Text = dataRowView.Row[0].ToString();
            TextBoxBoekNaam.Text = dataRowView.Row[2].ToString();
        }
    }
}
