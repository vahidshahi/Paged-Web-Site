
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
    /// Interaction logic for WpfBoekenToevoegen.xaml
    /// </summary>
    public partial class WpfBoekenToevoegen : Window
    {
        public WpfBoekenToevoegen()
        {
            InitializeComponent();
   

        }
        private void AddComboxItems()
        {
            comBoxCategories.Items.Add(" ");
            comBoxCategories.Items.Add("Fantasy");
            comBoxCategories.Items.Add("Kinderboeken");
            comBoxCategories.Items.Add("Tienerboeken");
            comBoxCategories.Items.Add("Young Adult Boeken");
            comBoxCategories.Items.Add("Romans");
            comBoxCategories.Items.Add("Romantische boeken");
            comBoxCategories.Items.Add("Thrillers");
            comBoxCategories.Items.Add("Comics & Graphic Novels");


            ComboxUitvoering.Items.Add("E - boek");
            ComboxUitvoering.Items.Add("PaperBack");

            ComBoxFilterCategories.Items.Add(" ");
            ComBoxFilterCategories.Items.Add("Fantasy");
            ComBoxFilterCategories.Items.Add("Kinderboeken");
            ComBoxFilterCategories.Items.Add("Tienerboeken");
            ComBoxFilterCategories.Items.Add("Young Adult Boeken");
            ComBoxFilterCategories.Items.Add("Romans");
            ComBoxFilterCategories.Items.Add("Romantische boeken");
            ComBoxFilterCategories.Items.Add("Thrillers");
            comBoxCategories.Items.Add("Comics & Graphic Novels");

        }
        private void ToonBoekenInDatagrid()
        {

            SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);
            conn.Open();
            string query = "Select * from boeken";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            var dv = dt.DefaultView;    
            DTGRidBoeken.ItemsSource = dv;
            conn.Close();

        }
        private void FilterByCategories()
            
        {
            if(ComBoxFilterCategories.SelectedIndex > -1)
            try
            {

                SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind
                conn.Open();
                string query = $"Select * from Boeken where EAN = '{txtboxZoekBoek.Text}' OR Categorie = '{ComBoxFilterCategories.SelectedValue}'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                var ds = new DataSet();
                adapter.Fill(ds);
                var dt = ds.Tables[0];
                var dv = dt.DefaultView;
                DTGRidBoeken.ItemsSource = dv;
                conn.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message) ;
            }

          

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WpfUsers wpfUsers  = new WpfUsers();
            wpfUsers.ShowDialog();
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            
            if(txtboxEAN.Text == " " || txtboxBoekTitel.Text == " " || txtboxAuthor.Text == " " || txtboxUitgeverij.Text == " " || comBoxCategories.SelectedIndex == -1 || txtboxBladzijden.Text == " ")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                
                try
                {
                    string ean = txtboxEAN.Text; 
                    string author = txtboxAuthor.Text;
                    string titel = txtboxBoekTitel.Text;
                    decimal prijs;
                    bool prijsOut = decimal.TryParse(txtboxPrijs.Text, out prijs);
                    if(prijsOut == false)
                    {
                        MessageBox.Show("De is een decimal nummer bijvoorbeeld ");
                    }
                    string imageSource = txtboxImgSource.Text;
                    string uitgeverij = txtboxUitgeverij.Text;
                    int bladzijden = int.Parse(txtboxBladzijden.Text);
                    string uitvoering = ComboxUitvoering.SelectedValue.ToString(); 
                    string gewicht = txtboxGewicht.Text;
                    if (!prijsOut)
                    {
                        MessageBox.Show("geef een juiste input");
                        return;
                    }
                    string omschrijving = txtboxOmschrijving.Text;
                    SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind
                    string query = $"Insert into Boeken (EAN, Auteur, Titel, HuurPrijs, SourceImg, Omschrijving, Categorie, Uitgeverij, AantalBladzijden, Uitvoering, Gewicht, Taal) VALUES('{ean}','{author}','{titel}', {prijs}, '{imageSource}', '{omschrijving}','{comBoxCategories.SelectedValue}','{uitgeverij}',{bladzijden},'{uitvoering}','{gewicht}', '{txtboxTaal.Text}')";
                    SqlCommand sql = new SqlCommand(query, conn);
                    conn.Open();
                    sql.ExecuteNonQuery();
                    MessageBox.Show("Het Boek is succesvol opgeslagen");
                    conn.Close();
                    ToonBoekenInDatagrid();
                    Reset();


                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                 
            }
        }

        private void Reset()
        {
            txtboxAuthor.Text = " ";
            txtboxGewicht.Text = " ";
            txtboxBoekTitel.Text = " ";
            txtboxBladzijden.Text = " ";
            txtboxZoekBoek.Text = " ";
            txtboxEAN.Text = " ";
            txtboxImgSource.Text = " ";
            txtboxUitgeverij.Text = " ";
            txtboxPrijs.Text = " ";
            
        }
        private void btnResetten_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            WpfDeleteBoek wpfDeleteBoek = new WpfDeleteBoek();
            wpfDeleteBoek.ShowDialog();
        }



        private void btnZoekBoek_Click(object sender, RoutedEventArgs e)
        {
            FilterByCategories();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Wpflogin wpflogin = new Wpflogin();
            wpflogin.ShowDialog();
        }
        private void btnEditen_Click(object sender, RoutedEventArgs e)
        {
            //update de tabellen
                if (txtboxEAN.Text == " " || txtboxBoekTitel.Text == " " || txtboxAuthor.Text == " " || txtboxUitgeverij.Text == " " || comBoxCategories.SelectedIndex == -1 || txtboxBladzijden.Text == " " || txtboxImgSource.Text == " " || txtboxPrijs.Text == " " || txtboxOmschrijving.Text == " " || ComboxUitvoering.SelectedIndex == -1 || txtboxGewicht.Text == " " || txtboxTaal.Text == " ")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {

                try
                {
                    string categorie = comBoxCategories.SelectedValue.ToString();
                    string ean = txtboxEAN.Text;
                    string author = txtboxAuthor.Text;
                    string titel = txtboxBoekTitel.Text;
                    decimal prijs;
                    bool prijsOut = decimal.TryParse(txtboxPrijs.Text, out prijs);
                    if (prijsOut == false)
                    {
                        MessageBox.Show("De is een decimal nummer bijvoorbeeld ");
                    }
                    string imageSource = txtboxImgSource.Text;
                    string uitgeverij = txtboxUitgeverij.Text;
                    int bladzijden = int.Parse(txtboxBladzijden.Text);
                    string uitvoering = ComboxUitvoering.SelectedValue.ToString();
                    string gewicht = txtboxGewicht.Text;
                    if (!prijsOut)
                    {
                        MessageBox.Show("geef een juiste input");
                        return;
                    }

                    SqlConnection conn = new SqlConnection(Settings.Database.ProjectConnectionstring);//Settings.Datbase.Ind
                    string query = $"Update Boeken set Auteur = '{author}', Titel = '{titel}', HuurPrijs ='{prijs}', SourceImg = '{imageSource}', Categorie ='{categorie}', Uitgeverij ='{uitgeverij}', AantalBladzijden = '{bladzijden}', Uitvoering = '{uitvoering}', Gewicht ='{gewicht}', Taal ='{txtboxTaal.Text}' where EAN = '{ean}'";
                    SqlCommand sql = new SqlCommand(query, conn);
                    conn.Open();
                    sql.ExecuteNonQuery();
                    MessageBox.Show("Het Boek is succesvol geupdated");
                    conn.Close();
                    ToonBoekenInDatagrid();
                    Reset();


                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddComboxItems();
        }

        private void DTGRidBoeken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DTGRidBoeken.SelectedIndex == -1)
            {
                MessageBox.Show(e.Handled.ToString());
            }
            else
            {
                DataRowView rowview = DTGRidBoeken.SelectedItem as DataRowView;
                txtboxEAN.Text = rowview.Row[0].ToString();
                txtboxAuthor.Text = rowview.Row[1].ToString();
                txtboxBoekTitel.Text = rowview.Row[2].ToString();
                txtboxPrijs.Text = rowview.Row[3].ToString();
                txtboxImgSource.Text = rowview.Row[4].ToString();
                txtboxOmschrijving.Text = rowview.Row[5].ToString();
                string categorie = rowview.Row[6].ToString();
                comBoxCategories.SelectedItem = categorie;
                txtboxUitgeverij.Text = rowview.Row[7].ToString();
                txtboxBladzijden.Text = rowview.Row[8].ToString();
                string uitvoering = rowview.Row[9].ToString();
                ComboxUitvoering.SelectedItem = uitvoering;
                txtboxGewicht.Text = rowview.Row[10].ToString();
                txtboxTaal.Text = rowview.Row[11].ToString();
               // DTGRidBoeken.SelectedCells[5].Column.Width = "200";
            }
           
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ToonBoekenInDatagrid();
            
        }

        private void btnBoekTerug_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            boekTerug wpfboekTerug = new boekTerug();
            wpfboekTerug.ShowDialog();
        }
    }
}
