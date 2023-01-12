using ClassLibTeam04.Data;
using ClassLibTeam04.Data.Framework;
using ClassLibTeam04.Entities;
using ClassLibTeam04.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Business
{
    public static class Klanten 
    {

        //Get email en wachtwoord van de klant
        public static DataTable CheckEmail(Klant klant)
        {
            var dt = new DataTable();
            try
            {
                var table = new KlantenData();
                var result = table.SelectEmail(klant.Emailadres);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return dt;
        }
        public static DataTable CheckWachtwoordEnEmail(Klant klant)
        {
            var dt = new DataTable();
            try
            {
                var klantenData = new KlantenData();
                var result = klantenData.SelectEmailWachtwoord(klant.Emailadres,  klant.Wachtwoord);
                dt = result.DataTable;
               
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return dt;
        }
        public static bool LoginGelukt(Klant klant)
        {
            bool isLoggedin;
            var dt = new DataTable();
            try
            {
                var dataKlant = new KlantenData();
                var result = dataKlant.SelectEmailWachtwoord(klant.Emailadres, klant.Wachtwoord);
                dt = result.DataTable;
                if(dt.Rows.Count > 0)
                {
                    isLoggedin = true;
                }
                else
                {
                    isLoggedin = false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return isLoggedin;    // inplaats van de isLoggedin terug te stuuren stuur de klant terug dus de  ->  dt 
        }
  
        public static DataView GetKlanten()
        {
            var dv = new DataView();
            try
            {
                var klantenData = new KlantenData();
                var result = klantenData.SelectQueryAll();
                dv = result.DataTable.DefaultView;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dv;
        }
        public static DataTable GetKlantEmail(Klant klant)
        {
            var dt = new DataTable();
            try
            {
                var klantenData = new KlantenData();
                var result = klantenData.SelectEmail(klant.Emailadres);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public static DataTable GetKlantGegevens(Klant klant)
        {
            var dt = new DataTable();
            try
            {
                var klantenData = new KlantenData();
                var result = klantenData.SelectEmailWachtwoord(klant.Emailadres, klant.Wachtwoord);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public static string BevestigingsEmail(Klant klant)
        {
            string bericht;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Hi " + klant.Emailadres + ",");
                sb.AppendLine("Je hebt zojuist je wachtwoord gewijzigd.");
                sb.AppendLine("Paged account team");
                var mail = new PagedMail(klant.Emailadres);
                mail.Subject = "Paged Account Team ";
                mail.Body = sb.ToString();
                mail.SendMail();
                bericht = "true";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
            return bericht;
        }

        public static int CodeEmail(Klant klant)
        {
            int code = 0;
            StringBuilder stCode = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                code = rnd.Next(0,9);
                stCode.Append(code);
            }
            int parse = int.Parse(stCode.ToString());
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Hi, " + klant.Emailadres);
                stringBuilder.AppendLine("We hebben een code voor eenmalig gebruik aangevraagd om te gebruiken met uw Paged-account.");
                stringBuilder.AppendLine("Uw code voor eenmalig gebruik is " + parse);
                stringBuilder.AppendLine("Als u deze code niet heeft aangevraagd, kunt u deze e-mail gerust negeren. Iemand anders heeft mogelijk per ongeluk uw e-mailadres getypt.");
                stringBuilder.AppendLine("Bedankt,");
                stringBuilder.AppendLine("Th  Paged account team");
                var mail = new PxlMail(klant.Emailadres);
                mail.Body = stringBuilder.ToString();
                mail.Subject = "Paged Account Team ";
                mail.SendMail();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return parse;
        }
    
        public static DataTable GetKlantenDataTable()
        {
            var dt = new DataTable();
            try
            {
                var klantenData = new KlantenData();
                var result = klantenData.SelectQueryAll();
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public static bool UpdateWachtwoord(Klant klant)
        {
            bool isUpdated = false;
            try
            {
                var data = new KlantenData();
                var result = data.ChangePassword(klant);
                if(result.Succeeded == true)
                {
                    isUpdated = true;
                }
                else
                {
                    isUpdated = false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return isUpdated;
        }
  
        public static InsertResult AddKlant(Klant klant)
        {
            var result = new InsertResult();
            try
            {
                var klantenData = new KlantenData();
                result = klantenData.Insert(klant);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public static DataTable GetIngelogdeKlant(int id)
        {
            var dt = new DataTable();
            try
            {
                var Klantdata = new KlantenData();
                var result = Klantdata.SelectQueryIngelogdeGebruiker(id);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public static InsertResult UpdateKlantenData(Klant klant)
        {          
            var result = new InsertResult();
            try
            {
                var klantenData = new KlantenData();
                if (klant.indicator == "name"){ klantenData.ChangeName(klant); }
                else if (klant.indicator == "extraKlantenInfo"){ klantenData.ChangExtraKlantenInfo(klant); }
                else if (klant.indicator == "aderes") { klantenData.updateAderes(klant); }
                else if (klant.indicator == "gsmnr") {klantenData.ChangeGsmNummer(klant);}
                else if (klant.indicator == "gbd")  { klantenData.ChangeGeboorteDatum(klant); }
                else if (klant.indicator == "mail") { klantenData.ChangeEmailAderes(klant); }
                else if (klant.indicator == "wachtwoord") { klantenData.ChangeWachtWoord(klant); }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
            
        }


        public static DataTable GetBoekenVanKlant(Klant klant)
        {
            var dt = new DataTable();
            try
            {
                var Boekendata = new BoekenData();
                var result = Boekendata.SelectQueryBoekenVanKlant(klant);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
            
        }
        /* voor wpf -  Boek Terug */
        public static DataTable WPFGetBestellingenVanKlant(int klantId)
        {
            var dt = new DataTable();
            try
            {
                var Boekendata = new BoekenData();
                var result = Boekendata.WPFGetBestellingenVanKlantQuery(klantId);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;

        }
        /* voor wpf -  Boek Terug */
        public static DataTable WPFGetBestellingVanKlant(int bestelNr)
        {
            var dt = new DataTable();
            try
            {
                var Boekendata = new BoekenData();
                var result = Boekendata.WPFGetBestellingVanKlantQuery(bestelNr);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;

        }
        /* voor wpf -  Boek Terug */
        public static DataTable WPFUpdateReturnDatum(string EAN, int bestelNr, string rDate)
        {
            var dt = new DataTable();
            try
            {
                var ItemData = new ItemData();
                var result = ItemData.WPFUpdateReturndatum(EAN, bestelNr, rDate);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;

        }




        /// <summary>
        /// Als klant ontvang ik een mail met de bevestiging van mijn reservatie voor huur van een product.
        /// </summary>
        /// <param name="klant"></param>
        /// <exception cref="Exception"></exception>
        public static void ProductBevestigingsEmail(BestellingsNrMail mailGegevens)
        {
            try
            {
               
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Hi " + mailGegevens.Email + ",");
                sb.AppendLine("U hebt een bestelling geplaatst op " + DateTime.Now);
                sb.AppendLine("Bedankt voor uw bestelling");
                sb.AppendLine("Uw bestellings nummer: " + mailGegevens.BestellingsNr);
                sb.AppendLine("Voor meer informatie kunt u ons mail sturen naar ons email pagerentboeken@gmail.com");
                var mail = new PagedMail(mailGegevens.Email);
                mail.Body = sb.ToString();
                mail.Subject = "Paged Huur Boeken";
                mail.SendMail();
            
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
