using ClassLibTeam04.Business;
using ClassLibTeam04.Data.Framework;
using ClassLibTeam04.Entities;
using ClassLibTeam04.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Data                           // DEZE FILE  -->   KlantenController    noemen
                                                        // Deze FILE IS GEEN CONTROLLER 
{
    internal class KlantenData : SqlCommands, ISqlCommands<Klant>
    {
        // gemaakt door Hassan
        private const string tableName = "KlantenInfo";
        public KlantenData() : base(tableName)
        {

        }
        /// <summary>
        /// Insert klant gegevens in de database
        /// </summary>
        /// <param name="klant"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

    
        public InsertResult Insert(Klant klant)
        {
            var result = new InsertResult();

            try
            {
                //SQL command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {tableName} ");
                insertQuery.Append($"(Voornaam, Achternaam, Emailadres, Wachtwoord) VALUES ");
                insertQuery.Append($"(@Voornaam, @Achternaam, @Emailadres, @Wachtwoord);");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    //insertCommand.Parameters.Add("@KlantId", SqlDbType.VarChar).Value = klant.KlantId;
                    insertCommand.Parameters.Add("@Voornaam", SqlDbType.VarChar).Value = klant.Voornaam;
                    insertCommand.Parameters.Add("@Achternaam", SqlDbType.VarChar).Value = klant.Achternaam;
                    insertCommand.Parameters.Add("@Emailadres", SqlDbType.VarChar).Value = klant.Emailadres;
                    insertCommand.Parameters.Add("@Wachtwoord", SqlDbType.VarChar).Value = klant.Wachtwoord;
                    result = InsertRecord(insertCommand);
                    result.Succeeded = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public SelectResult SelectEmail(string email)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"select * from {tableName} where Emailadres = '{email}';");
            var result = new SelectResult();
            using (SqlCommand insertCommand = new SqlCommand(query.ToString()))
            {
                base.SelectRecords(insertCommand);
                result = (SelectResult)base.BaseResult;
            }
            return result;
        }
        public SelectResult SelectEmailWachtwoord(string email, string password)
        {
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"select * from {tableName} where Emailadres = '{email}' and Wachtwoord = '{password}'");
            var result = new SelectResult();
            using (SqlCommand selectCommand = new SqlCommand(selectQuery.ToString()))
            {
                base.SelectRecords(selectCommand);
                result = (SelectResult)base.BaseResult;

            }

            return result;
        }
        // change wachtwoord hassan
        public SelectResult ChangePassword(Klant klant)
        {
            var result = new SelectResult();
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"UPDATE {tableName} set Wachtwoord = '{klant.Wachtwoord}' where Emailadres = '{klant.Emailadres}'");

            using (SqlCommand insertCommand = new SqlCommand(selectQuery.ToString()))
            {

                int rows = InsertResultWachtwoord(insertCommand);
                if (rows > 0)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Succeeded = false;
                }
                return result;
            }
        }
        public SelectResult SelectQueryAll()
        {
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"select * from {tableName}");
            var result = new SelectResult();
            using (SqlCommand sqlComm = new SqlCommand(selectQuery.ToString()))
            {
                base.SelectRecords(sqlComm);
                result = (SelectResult)base.BaseResult;
            }
            return result;
        }

        public SelectResult SelectQuery(string email)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"select * from {tableName} where Emailadres '{email}';");
            var result = new SelectResult();
            using (SqlCommand sqlComm = new SqlCommand(query.ToString()))
            {
                base.SelectRecords(sqlComm);
                result = (SelectResult)base.BaseResult;
            }
            return result;
        }

        // toegevoegd door elke 
        public SelectResult SelectQueryIngelogdeGebruiker(int id) // get INGELOGDE gebruiker 
        {

            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"select * from {tableName} where KlantId = @klantID ");

            var result = new SelectResult();
            using (SqlCommand sqlComm = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                sqlComm.Parameters.AddWithValue("@klantID", id);
                base.SelectRecords(sqlComm);
                result = (SelectResult)base.BaseResult;
            }
            return result;
        }
        public SelectResult ChangeName(Klant klant) // geeft voornaam en achternaam mee OK 
        {
            var result = new SelectResult();

            //SQL command
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"UPDATE {tableName} ");
            selectQuery.Append($"set Voornaam = @voornaam , Achternaam = @achternaam ");
            selectQuery.Append($"WHERE KlantId = @klantID;");




            using (SqlCommand query = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                query.Parameters.AddWithValue("@voornaam", klant.Voornaam);
                query.Parameters.AddWithValue("@achternaam", klant.Achternaam);
                query.Parameters.AddWithValue("@klantID", klant.KlantId);

                base.SelectRecords(query);
                result = (SelectResult)base.BaseResult;
                return result;
            }



        }
        public SelectResult ChangExtraKlantenInfo(Klant klant) // geeft extraKlantenInfo mee  OK
        {
            var result = new SelectResult();

            //SQL command
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"UPDATE {tableName} ");
            selectQuery.Append($"set ExtraKlantenInfo = @extraInfo ");
            selectQuery.Append($"WHERE KlantId = @klantID;");



            using (SqlCommand query = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                query.Parameters.AddWithValue("@extraInfo", klant.ExtraKlantenInfo);
                query.Parameters.AddWithValue("@klantID", klant.KlantId);

                base.SelectRecords(query);
                result = (SelectResult)base.BaseResult;
                return result;
            }



        }


        // in progres 
        public SelectResult controlleerPostcodeAndInserData(Klant klant)   // geeft  postcode Straatnaam Huisnr Busnr  en   Gemeente mee  
        {


            StringBuilder controlePostcode = new StringBuilder();
            controlePostcode.Append($" Select * from woonplaats where postcode = @postcode and woonplaats = @woonplaats  ");
            using (SqlCommand query = new SqlCommand(controlePostcode.ToString()))
            {
                query.Parameters.AddWithValue("@postcode", klant.givenPostcode);
                query.Parameters.AddWithValue("@woonplaats", klant.givenGemeente);
                base.SelectRecords(query);
                var result = (SelectResult)base.BaseResult;

                if (result.Rows != 0)
                {
                    result = updateAderes(klant);

                }
                else
                {
                    // insurt postcode 
                    var insertResult = new InsertResult();

                    try
                    {
                        //SQL command
                        StringBuilder insertQuery = new StringBuilder();
                        insertQuery.Append($"Insert INTO woonplaats ");
                        insertQuery.Append($"(@postcode, @woonplaats");
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                        {
                            //insertCommand.Parameters.Add("@KlantId", SqlDbType.VarChar).Value = klant.KlantId;
                            insertCommand.Parameters.Add("@postcode", SqlDbType.VarChar).Value = klant.givenPostcode;
                            insertCommand.Parameters.Add("@woonplaats", SqlDbType.VarChar).Value = klant.givenGemeente;
                            insertResult = InsertRecord(insertCommand);
                            insertResult.Succeeded = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);

                        // combinatsie is niet just 
                        // trug naar frontend met mess -> combinatie niet just 

                    }
                    finally
                    {
                        result = updateAderes(klant);
                    }

                }
                return result;
            }

        }
        public SelectResult updateAderes(Klant klant)
        {
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"UPDATE {tableName} ");
            selectQuery.Append($"set postcode = @postcode , Straatnaam = @straatnaam , gemeente = @gemeente , ");
            selectQuery.Append($" Huisnr = @huisnr , Busnr = @busnr");
            selectQuery.Append($" WHERE KlantId = @klantID;");

            using (SqlCommand queryUpdateAderes = new SqlCommand(selectQuery.ToString()))
            {
                queryUpdateAderes.Parameters.AddWithValue("@postcode", klant.givenPostcode);
                queryUpdateAderes.Parameters.AddWithValue("@gemeente", klant.givenGemeente);
                queryUpdateAderes.Parameters.AddWithValue("@straatnaam", klant.Straatnaam);
                queryUpdateAderes.Parameters.AddWithValue("@huisnr", klant.Huisnr);
                queryUpdateAderes.Parameters.AddWithValue("@busnr", klant.Busnr);

                queryUpdateAderes.Parameters.AddWithValue("@klantID", klant.KlantId);
                base.SelectRecords(queryUpdateAderes);
                var resultUpdatedAderes = (SelectResult)base.BaseResult;

                return resultUpdatedAderes;
            }
        }

        public SelectResult ChangeGsmNummer(Klant klant) // geeft gsmnmr mee    OK
        {
            var result = new SelectResult();

            //SQL command
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"UPDATE {tableName} ");
            selectQuery.Append($"set Gsmnr = @gsmnr ");
            selectQuery.Append($"WHERE KlantId = @klantID ;");



            using (SqlCommand query = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                query.Parameters.AddWithValue("@gsmnr", klant.Gsmnr);
                query.Parameters.AddWithValue("@klantID", klant.KlantId);

                base.SelectRecords(query);
                result = (SelectResult)base.BaseResult;
                return result;
            }



        }
        public SelectResult ChangeGeboorteDatum(Klant klant)  // geeft geboortedatum mee  OK
        {
            var result = new SelectResult();

            //SQL command
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"UPDATE {tableName} ");
            selectQuery.Append($"set Geboortedatum = @geboortedatum ");
            selectQuery.Append($"WHERE KlantId = @klantID;");

            // DateTime.Parse({klant.Geboortedatum})

            using (SqlCommand query = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                query.Parameters.AddWithValue("@geboortedatum", klant.Geboortedatum);
                query.Parameters.AddWithValue("@klantID", klant.KlantId);

                base.SelectRecords(query);
                result = (SelectResult)base.BaseResult;
                return result;
            }



        }
        public SelectResult ChangeEmailAderes(Klant klant)  // geeft email mee    OK
        {
            var result = new SelectResult();

            //SQL command
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"UPDATE {tableName} ");
            selectQuery.Append($"set Emailadres = @mail ");
            selectQuery.Append($" WHERE KlantId = @klantID;");



            using (SqlCommand query = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string    
            {
                query.Parameters.AddWithValue("@mail", klant.Emailadres);
                query.Parameters.AddWithValue("@klantID", klant.KlantId);

                base.SelectRecords(query);
                result = (SelectResult)base.BaseResult;
                return result;
            }



        }
        public SelectResult ChangeWachtWoord(Klant klant)  // geeft wachtwoord mee  OK
        {
            var result = new SelectResult();

            //SQL command
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"UPDATE {tableName} ");
            selectQuery.Append($"set Wachtwoord = @ww ");
            selectQuery.Append($"WHERE KlantId = @klantID;");



            using (SqlCommand query = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                query.Parameters.AddWithValue("@ww", klant.Wachtwoord);
                query.Parameters.AddWithValue("@klantID", klant.KlantId);

                base.SelectRecords(query);
                result = (SelectResult)base.BaseResult;
                return result;
            }

        }
        public SelectResult select()
        {
            throw new NotImplementedException();
        }



        // in progres ( niet gebruikt )
        //public SelectResult controlleerPostcodeAndInserData(Klant klant)   // geeft  postcode Straatnaam Huisnr Busnr  en   Gemeente mee  
        //{


        //    StringBuilder controlePostcode = new StringBuilder();
        //    controlePostcode.Append($"Select * from woonplaats where postcode = @postcode and woonplaats = @woonplaats");
        //    using (SqlCommand query = new SqlCommand(controlePostcode.ToString()))
        //    {
        //        query.Parameters.AddWithValue("@postcode", klant.givenPostcode);
        //        query.Parameters.AddWithValue("@woonplaats", klant.givenGemeente);
        //        base.SelectRecords(query);
        //        var result = (SelectResult)base.BaseResult;

        //        if (result.Rows != 0)
        //        {
        //            result = updateAderes(klant);

        //        }
        //        else
        //        {
        //            // insurt postcode 
        //            var insertResult = new InsertResult();

        //            try
        //            {
        //                //SQL command
        //                StringBuilder insertQuery = new StringBuilder();
        //                insertQuery.Append($"Insert INTO woonplaats ");
        //                insertQuery.Append($"(@postcode, @woonplaats");
        //                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
        //                {
        //                    //insertCommand.Parameters.Add("@KlantId", SqlDbType.VarChar).Value = klant.KlantId;
        //                    insertCommand.Parameters.Add("@postcode", SqlDbType.VarChar).Value = klant.givenPostcode;
        //                    insertCommand.Parameters.Add("@woonplaats", SqlDbType.VarChar).Value = klant.givenGemeente;
        //                    insertResult = InsertRecord(insertCommand);
        //                    insertResult.Succeeded = true;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception(ex.Message);

        //                // combinatsie is niet just 
        //                // trug naar frontend met mess -> combinatie niet just 

        //            }
        //            finally
        //            {
        //                result = updateAderes(klant);
        //            }

        //        }
        //        return result;
        //    }

        //}
    }
}
