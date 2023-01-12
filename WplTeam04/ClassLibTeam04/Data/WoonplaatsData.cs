using ClassLibTeam04.Data.Framework;
using ClassLibTeam04.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
        
namespace ClassLibTeam04.Data                           // diend om een woonplaats aan te vullen ( nog niet geimplementeerd) 
{ 
    internal class WoonplaatsData : SqlCommands, ISqlCommands<Woonplaats>
    {
        private const string tableName = "Woonplaats";
        public WoonplaatsData() : base(tableName) { }     // kom 


        public SelectResult select()
        {
            var result = new SelectResult();
            base.SelectRecords();
            result = (SelectResult)base.BaseResult;
            return result;
        }



        public SelectResult InsertWoonplaats(string postcode , string gemeente) // geeft voornaam en achternaam mee OK 
        {
            var result = new SelectResult();

            //SQL command
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"insert into {tableName} ");
            selectQuery.Append($"values ('{postcode}' , '{gemeente}');");

            using (SqlCommand query = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                base.SelectRecords(query);
                result = (SelectResult)base.BaseResult;
                return result;
            }



        }

        InsertResult ISqlCommands<Woonplaats>.Insert(Woonplaats t)
        {
            throw new NotImplementedException();
        }

        SelectResult ISqlCommands<Woonplaats>.select()
        {
            throw new NotImplementedException();
        }
    }
}
