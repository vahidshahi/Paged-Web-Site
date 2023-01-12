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
    internal class BankKaartData : SqlCommands, ISqlCommands<BankKaartData>
    {
        private const string tableName = "BankKaarten";
        public BankKaartData() : base(tableName)
        {

        }


        public int Insert(Bankkaart bankKaart)
        {
            int result;
            try
            {
                //SQL command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {tableName}");
                insertQuery.Append($"(KlantId, KaartHouderNaam, VervalMaand, CreditKaartNr, VervalJaar) VALUES ");
                insertQuery.Append($"(@KlantId, @KaartHouderNaam, @VervalMaand, @CreditKaartNr, @VervalJaar);");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.CommandType = CommandType.Text;
                    //insertCommand.Parameters.Add("@KlantId", SqlDbType.VarChar).Value = klant.KlantId;
                    insertCommand.Parameters.Add("@KlantId", SqlDbType.Int).Value = bankKaart.KlantId;
                    insertCommand.Parameters.Add("@KaartHouderNaam", SqlDbType.VarChar).Value = bankKaart.KaartHouderNaam;
                    insertCommand.Parameters.Add("@VervalMaand", SqlDbType.VarChar).Value = bankKaart.VervalMaand;
                    insertCommand.Parameters.Add("@CreditKaartNr", SqlDbType.Int).Value = bankKaart.CreditKaartNr;
                    insertCommand.Parameters.Add("@VervalJaar", SqlDbType.Int).Value = bankKaart.VervalJaar;
                    result = InsertKaartGegevens(insertCommand);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public InsertResult Insert(BankKaartData t)
        {
            throw new NotImplementedException();
        }

        public SelectResult select()
        {
            throw new NotImplementedException();
        }
    }
}
