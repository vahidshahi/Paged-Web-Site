using ClassLibTeam04.Data.Framework;
using ClassLibTeam04.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Data
{
    internal class BoekenData : SqlCommands, ISqlCommands<Boek>
    {
        private const string tableName = "Boeken";
        private const string suptableName = "Items";
        private const string supTwotableName = "Bestellingen";

        public BoekenData() : base(tableName) { }     
       
        public SelectResult select()
        {
            var result = new SelectResult();
            base.SelectRecords();
            result = (SelectResult)base.BaseResult;
            return result;
        }
        public SelectResult SelectQueryAll()
        {
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"select * from {tableName}");
          
          
            var result = new SelectResult();
            using (SqlCommand sqlComm = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                base.SelectRecords(sqlComm);
                result = (SelectResult)base.BaseResult;
              
            }
            return result;
        }



        // select * from boeken a join Items b on a.EAN = b.EAN join Bestellingen c on b.BestellingNr = c.BestellingNr 

        public SelectResult SelectBoekenWithDates()
        {
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"select boeken.EAN, boeken.Auteur, boeken.Titel, boeken.HuurPrijs, boeken.SourceImg, boeken.Omschrijving, boeken.Categorie, boeken.Uitgeverij, boeken.AantalBladzijden, boeken.Uitvoering, boeken.Gewicht, boeken.Taal, Items.ReturnDatum, Items.VerwachteReturnDatum, Bestellingen.BestellingDatum from boeken  LEFT JOIN Items on boeken.EAN = Items.EAN LEFT JOIN Bestellingen on Items.BestellingNr = Bestellingen.BestellingNr");
            // boek + boek en datum 

            var result = new SelectResult();
            using (SqlCommand sqlComm = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                base.SelectRecords(sqlComm);
                result = (SelectResult)base.BaseResult;
            }
            return result;  
        }

        public SelectResult SelectQueryBoekenVanKlant(Klant klant)
        {

            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"select DISTINCT Boeken.Titel , Boeken.SourceImg , Boeken.Auteur ," +
                $" Items.ReturnDatum , Items.VerwachteReturnDatum , Bestellingen.BestellingDatum" +
                $" from Boeken join Items on Boeken.EAN = Items.EAN " +
                $"join Bestellingen on Items.BestellingNr = Items.BestellingNr" +
                $" Where Bestellingen.KlantId = @klantid");
            // boek + boek en datum 

            var result = new SelectResult();
            using (SqlCommand sqlComm = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                sqlComm.Parameters.Add("@klantid", SqlDbType.VarChar).Value = klant.KlantId;
                base.SelectRecords(sqlComm);
                result = (SelectResult)base.BaseResult;
            }

            return result;
        }
        /* voor WPF -- Boek terug */
        public SelectResult WPFGetBestellingenVanKlantQuery(int klantId)
        {

            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"select DISTINCT   Items.BestellingNr,  Boeken.Titel , Boeken.EAN ," +
                $" Items.ReturnDatum , Items.VerwachteReturnDatum , Bestellingen.BestellingDatum , bestellingen.klantId" +
                $" from Boeken join Items on Boeken.EAN = Items.EAN " +
                $"join Bestellingen on Items.BestellingNr = Items.BestellingNr" +
                $" Where Bestellingen.KlantId = @klantid");
            // boek + boek en datum 

            var result = new SelectResult();
            using (SqlCommand sqlComm = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                sqlComm.Parameters.Add("@klantid", SqlDbType.VarChar).Value = klantId;
                base.SelectRecords(sqlComm);
                result = (SelectResult)base.BaseResult;
            }

            return result;
        }
        /* voor WPF -- Boek terug */
        public SelectResult WPFGetBestellingVanKlantQuery(int bestelNr)
        {

            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"select * from Items where BestellingNr = 1186 " );
            // boek + boek en datum 

            var result = new SelectResult();
            using (SqlCommand sqlComm = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                sqlComm.Parameters.Add("@bestelNr", SqlDbType.VarChar).Value = bestelNr;
                base.SelectRecords(sqlComm);
                result = (SelectResult)base.BaseResult;
            }

            return result;
        }






        public InsertResult Insert(Boek boek)
        {
            var result = new InsertResult();
            try
            {
                //SQL command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {tableName}");
             /*   insertQuery.Append($"(Voornaam, Achternaam, Emailadres, Wachtwoord ");
                insertQuery.Append($"(@Voornaam, @Vchternaam, @Emailadres, @Wachtwoord);");*/
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
           /*       //  insertCommand.Parameters.Add(@"Voornaam", SqlDbType.VarChar).Value = klant.Voornaam;
                    insertCommand.Parameters.Add("@Achternaam", SqlDbType.VarChar).Value = klant.Achternaam;
                    insertCommand.Parameters.Add("@Emailadres", SqlDbType.VarChar).Value = klant.Emailadres;
                    insertCommand.Parameters.Add("@Wachtwoord", SqlDbType.VarChar).Value = klant.Wachtwoord;*/
                    result = InsertRecord(insertCommand);
                }
            }
            catch (Exception ex)
            {



                throw new Exception(ex.Message);
            }
            return result;
        }




    }
}
