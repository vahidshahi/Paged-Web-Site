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
    /// Interaction logic for WpfUsers.xaml
    /// </summary>
    public partial class WpfUsers : Window
    {
        public WpfUsers()
        {
            InitializeComponent();
        }

        //private void ToonAlleUsers()
        //{
        //    try
        //    {
               
        //        SqlConnection conn = new SqlConnection(Settings.Database.PagedDataConnString);//Settings.Datbase.Ind
        //        conn.Open();
        //        string query = $"Select * from Gebruikers;";
        //        SqlCommand sql = new SqlCommand(query, conn);
        //        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
        //        SqlCommandBuilder cBuilder = new SqlCommandBuilder(dataAdapter);
        //        var ds = new DataSet();
        //        dataAdapter.Fill(ds);
        //        var dt = ds.Tables[0];
        //        var dv = dt.DefaultView;
        //        DataGridUsers.ItemsSource = dv;
        //        conn.Close();

        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (txtNaam.Text==  "" || txtEmailadres.Text == "" || passwordBxWachtwoord.Password == "" || txtVoornaam.Text == " ")
            {
                MessageBox.Show("Informatie is niet volledig", "Infomatie ontbreekt");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind
                    string query = $"Insert into Users (Naam, Voornaam, Email, Wachtwoord) VALUES('{txtNaam.Text}', '{txtVoornaam.Text}', '{txtEmailadres.Text.Trim()}','{passwordBxWachtwoord.Password.Trim()}')";
                    SqlCommand sql = new SqlCommand(query, conn);
                    conn.Open();
                    sql.ExecuteNonQuery();
                    MessageBox.Show("Je hebt succesvol een account aangemaakt");
                    conn.Close();
                    this.Close();

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

          
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (txtNaam.Text == "" || txtEmailadres.Text == "" || passwordBxWachtwoord.Password == "")
            {
                MessageBox.Show("Informatie is niet volledig");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind
                    string query = $"Delete from Gebruikers where (Naam = '{txtNaam.Text}' AND Email = '{txtEmailadres.Text.Trim()}' AND Wachtwoord = '{passwordBxWachtwoord.Password}')";
                    SqlCommand sql = new SqlCommand(query, conn);
                    conn.Open();
                    sql.ExecuteNonQuery();
                    MessageBox.Show("Het Gebruiker is verwijderd.");
                    conn.Close();

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnResetten_Click(object sender, RoutedEventArgs e)
        {
            txtEmailadres.Text = "";
            txtNaam.Text = "";
            passwordBxWachtwoord.Password = "";
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (txtNaam.Text != " " || txtVoornaam.Text != " " || passwordBxWachtwoord.Password != " ")
            {
                try
                {
                    SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);
                    string query = $"UPDATE Users SET Naam = '{txtNaam.Text}', Voornaam = '{txtVoornaam.Text}', Wachtwoord = '{passwordBxWachtwoord.Password}' where Email = {txtEmailadres.Text}";
                    SqlCommand sqlCommand = new SqlCommand(query, conn);
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Uw account is bijgewerkt", "Account bijwerken");
                    conn.Close();



                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Er ontbreekt informatie");
            }
        }
    }
}
