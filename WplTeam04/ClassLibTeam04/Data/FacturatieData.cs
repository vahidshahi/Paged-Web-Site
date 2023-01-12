using ClassLibTeam04.Business;
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

    internal class FacturatieData : SqlCommands, ISqlCommands<Facturatie>
    {
        private const string tableName = "FacturatieAdres";
        public FacturatieData() : base(tableName)
        {
        }

        public InsertResult Insert(Facturatie t)
        {
            var result = new InsertResult();

            try
            {
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {tableName} ");
                insertQuery.Append($"(KlantId, Voornaam, Achternaam, Email, Straat, Woonplaats) VALUES ");
                insertQuery.Append($"(@KlantId, @Voornaam, @Achternaam, @Email, @Straat, @Woonplaats);");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@KlantId", SqlDbType.Int).Value = t.KlantId;
                    insertCommand.Parameters.Add("@Voornaam", SqlDbType.VarChar).Value = t.Voornaam;
                    insertCommand.Parameters.Add("@Achternaam", SqlDbType.VarChar).Value = t.Achternaam;
                    insertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = t.Email;
                    insertCommand.Parameters.Add("@Straat", SqlDbType.VarChar).Value = t.Straat;
                    insertCommand.Parameters.Add("@Woonplaats", SqlDbType.VarChar).Value = t.Woonplaats;
                    result = InsertFactuur(insertCommand);
                    int factuurNr = result.FactuurNr;
                    result.Succeeded = true;
                            
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public SelectResult select(int facuurNr, int klandId)
        {
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"select * from {tableName} where FactuurNr = {facuurNr} AND KlantId  = {klandId}");
            var result = new SelectResult();
            using (SqlCommand selectCommand = new SqlCommand(selectQuery.ToString()))
            {
                base.SelectRecords(selectCommand);
                result = (SelectResult)base.BaseResult;

            }
            return result;
        }

        public SelectResult select()
        {
            throw new NotImplementedException();
        }
    }
}
