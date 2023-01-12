using ClassLibTeam04.Data.Framework;
using ClassLibTeam04.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Data
{
    internal class ItemData : SqlCommands, ISqlCommands<Item>
    {
        private const string tableName = "Items";
        public ItemData() : base(tableName)
        {

        }
        SqlConnection conn;
        public InsertResult Insert(Item item)
        {
            
            var result = new InsertResult();
            try
            {
                // 
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"INSERT INTO {tableName} ");
                insertQuery.Append("(BestellingNr, EAN, VerwachteReturnDatum) VALUES ");
                insertQuery.Append($"(@BestellingNr, @EAN, @VerwachteReturnDatum);");
                using(SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@BestellingNr", SqlDbType.Int).Value = item.BestellingNr;
                    insertCommand.Parameters.Add("@EAN", SqlDbType.VarChar).Value = item.EAN;
                    insertCommand.Parameters.Add("@VerwachteReturnDatum", SqlDbType.DateTime).Value = item.VerwachteReturnDatum;
                    using ( conn = new SqlConnection(Settings.Settings.Database.ProjectConnectionstring))
                    {
                        insertCommand.Connection = conn;
                        conn.Open();
                        insertCommand.ExecuteNonQuery();
                        result.Succeeded = true;

                    }

                }
            }
            catch (Exception ex)
            {

               throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
        /*voor WPF   boek terug */
        public SelectResult WPFUpdateReturndatum(string EAN, int bestelNr, string Rdate)
        {
            var result = new SelectResult();

            //SQL command
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"UPDATE {tableName}");
            selectQuery.Append($" set ReturnDatum = @returnDatum ");
            selectQuery.Append($"WHERE EAN = @EAN  ");
            selectQuery.Append($"and  BestellingNr = @bestelNr") ;



            using (SqlCommand query = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                query.Parameters.AddWithValue("@returnDatum", Rdate);
                query.Parameters.AddWithValue("@EAN", EAN);
                query.Parameters.AddWithValue("@bestelNr", bestelNr);

                base.SelectRecords(query);
                result = (SelectResult)base.BaseResult;
                return result;
            }
        }



        public SelectResult select()
        {
            throw new NotImplementedException();
        }
    }
}
