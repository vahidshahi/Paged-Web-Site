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

namespace WpfTeam04
{
    /// <summary>
    /// Interaction logic for WpfKlanten.xaml
    /// </summary>
    public partial class WpfKlanten : Window
    {
        public WpfKlanten()
        {
            InitializeComponent();
        }
        private void ViewData()
        {
            try
            {
                try
                {
                    SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind
                    string query = "select * from KlantGegevens;";
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
                    datagridKlanten.ItemsSource = dv;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnSelectTestSql_Click(object sender, RoutedEventArgs e)
        {
            ViewData();
        }
    }
}
