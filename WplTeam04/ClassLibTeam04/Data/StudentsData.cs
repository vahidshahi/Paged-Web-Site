using ClassLibTeam04.Data.Framework;
using ClassLibTeam04.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Data         // voorbeeld van Kristof
{
    ///...
    internal class StudentsData : SqlCommands, ISqlCommands<Student>
    {
        private const string tableName = "Students"; 
        public StudentsData():base(tableName){}
       
        public SelectResult select()
        {
            var result = new SelectResult();
            base.SelectRecords();
            result = (SelectResult)base.BaseResult;
            return result;
        }

        public SelectResult SelectQueryFirstName(string FirstName)
        {
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"select * from {tableName} where ");
            selectQuery.Append($" firstname = @firstname");
            var result = new SelectResult();
            using(SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Parameters.Add("@firstname", SqlDbType.VarChar).Value = FirstName;
                base.SelectRecords(sqlComm);
                result = (SelectResult)base.BaseResult;
            }
            
            return result;
        }
        public InsertResult Insert(Student student)
        {
            var result = new InsertResult();
            try
            {
                //SQL command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {tableName}");
                insertQuery.Append($"(firstname, lastname) VALUES ");
                insertQuery.Append($"(@firstname, @lastname);");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@firstname", SqlDbType.VarChar).Value = student.FirstName;
                    insertCommand.Parameters.Add("@lastname", SqlDbType.VarChar).Value = student.LastName;
                    result = InsertRecord(insertCommand);
                }
                // var result = new InsertResult();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        
    }
}
