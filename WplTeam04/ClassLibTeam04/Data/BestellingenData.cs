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
    internal class BestellingenData : SqlCommands, ISqlCommands<Bestelling>
    {
        private const string tableName = "Bestellingen";
        public BestellingenData() : base(tableName)
        {
        }

        public InsertResult Insert(Bestelling bestelling)
        {
            var result = new InsertResult();

            try
            {
                //SQL command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {tableName} ");
                insertQuery.Append($"(klantId, BestellingDatum) VALUES ");
                insertQuery.Append($"(@klantId, @BestellingDatum);");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@klantId", SqlDbType.Int).Value = bestelling.KlantId;
                    insertCommand.Parameters.Add("@BestellingDatum", SqlDbType.DateTime).Value = bestelling.BestellingDatum;
                    result = InsertBestelling(insertCommand);
                    result.Succeeded = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
            return result;
        }

        public SelectResult UpdateBesteldatum(Item item)
        {
            var result = new SelectResult();

            //SQL command
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"UPDATE {tableName} ");
            selectQuery.Append($"set BestellingDatum = @bestellingDatum ");
            selectQuery.Append($"WHERE EAN = @EAN  ;");



            using (SqlCommand query = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                query.Parameters.AddWithValue("@bestellingDatum", item.bestellingsDatum);
                query.Parameters.AddWithValue("@EAN", item.EAN);

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
