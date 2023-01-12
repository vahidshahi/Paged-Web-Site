using System;
using System.Collections.Generic;
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
    /// Interaction logic for boekTerug.xaml
    /// </summary>
    public partial class boekTerug : Window
    {
        public boekTerug()
        {
            InitializeComponent();
            screenDateTime();
        }

        //-- mag nooit alleen ean zijn  
        //-- mag een alleen bestellingNr zijn maar alles van de bestelling word aangepast 
        //-- bestellingsNR en EAN is goed  : kan maar een keer voorkomen per bestelling
        // update Items set ReturnDatum = '2022-05-28' where ean = 9781786892720 and BestellingNr = 1184
        // 3 input velden : EAN, BestelNR , Datum(combobox)||datum vandaag 


        private void screenDateTime()
        {
            lblDateTime.Content = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void mnuAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Wpflogin wpflogin = new Wpflogin();
            wpflogin.ShowDialog();

        }

        private void btnKlantBestelGeschiedenis_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtKlantId.Text))
            {

                int klantId;
                if (Int32.TryParse(txtKlantId.Text, out klantId))
                {                                              // WPFGetBestellingenVanKlant
                    var dt = ClassLibTeam04.Business.Klanten.WPFGetBestellingenVanKlant(klantId);
                    if (dt != null)
                    {
                        System.Data.DataView dv = dt.DefaultView;
                        // DataVieuwBoekTerug dataVieuwWPF = new DataVieuwBoekTerug();
                        // dataVieuwWPF.Show();

                        dtgBoekTerug.ItemsSource = dv;
                    }
                }
                else
                {
                    MessageBox.Show("Geef een nummer in");
                }



            }

        }

        private void btnBestellingOph_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBestelNr.Text))
            {

                int bestelNr;
                if (Int32.TryParse(txtBestelNr.Text, out bestelNr))
                {
                    var dt = ClassLibTeam04.Business.Klanten.WPFGetBestellingVanKlant(bestelNr);
                    if (dt != null)
                    {
                        System.Data.DataView dv = dt.DefaultView;
                        dtgBoekTerug.ItemsSource = dv;
                    }
                }
                else
                {
                    MessageBox.Show("Geef een nummer in");
                }



            }
        }


        private void btnUpdateDate(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBestelNr.Text) && !string.IsNullOrWhiteSpace(txtEAN.Text))
            {
                string rDate = DateTime.Now.ToString("yyyy-MM-dd"); 
                string EAN = txtEAN.Text;
                int bestelNr;
                if (Int32.TryParse(txtBestelNr.Text, out bestelNr))
                {
                    var dt = ClassLibTeam04.Business.Klanten.WPFUpdateReturnDatum(EAN ,bestelNr,rDate);
                    if (dt != null)
                    {
                        System.Data.DataView dv = dt.DefaultView;
                        dtgBoekTerug.ItemsSource = dv;
                    }
                }
                else
                {
                    MessageBox.Show("Geef een bestelNr en EAN in");
                }



            }
        }
    }
}
