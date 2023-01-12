using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibTeam04.Settings;


namespace ClassLibTeam04.Data.Framework
{
    internal abstract class SqlCommands
    {
        private SqlConnection sqlConn ;
        public SqlCommands(string tableName)
        {
            TableName = tableName;                                                              // tabelnaam
           // SuptableName = suptableName;                                                              // tabelnaam
           // SupTwotableName = supTwotableName;                                                              // tabelnaam
            sqlConn = new SqlConnection(Settings.Settings.Database.ProjectConnectionstring);     // conectionstring 

        }
        protected BaseResult BaseResult{get; set;}
        protected string TableName { get; set; }
        
        
        protected void SelectRecords()
        {
            try
            {
                string query = $"select * from {TableName}";
                SelectRecords(query);

            }
            catch (Exception ex)
            {

                BaseResult.Adderror(ex.Message);
            }

        }

        protected void SelectRecords(string query)
        {
            
            try
            {
                BaseResult = new SelectResult();
                using (SqlCommand sqlComm = new SqlCommand(query))
                {
                    SelectRecords(sqlComm);
                }
                
                   // del overbodige code 
  
            }
            catch (Exception ex)
            {

                BaseResult.Adderror(ex.Message);
            }
            finally
            {
                sqlConn.Close();

            }
        }
        
        protected void SelectRecords(SqlCommand selectCommand)   // select 
        {
            try
            {
                BaseResult = new SelectResult();
                using (sqlConn)
                {
                    if (string.IsNullOrEmpty(sqlConn.ConnectionString))
                        sqlConn = new SqlConnection(Settings.Settings.Database.ProjectConnectionstring);
                    sqlConn.Open();
                    selectCommand.Connection = sqlConn;
                    var adapter = new SqlDataAdapter(selectCommand);
                    var ds = new DataSet();
                    var dt = new DataTable();
                    BaseResult.DataTable = new System.Data.DataTable();

                    BaseResult.Rows = adapter.Fill(ds);
                    BaseResult.DataTable = ds.Tables[0];
                    BaseResult.Succeeded = true;
          
                }
                
            }
            catch (Exception ex)
            {
                // hier
                BaseResult.Adderror(ex.Message);
             
            }
            finally
            {
                sqlConn.Close();
               
            }
        }
        protected int InsertResultWachtwoord(SqlCommand insertCommand)
        {
            int rowsAffected;

            try
            {
                using (sqlConn)
                {
                    insertCommand.Connection = sqlConn;
                    sqlConn.Open();
                    rowsAffected = insertCommand.ExecuteNonQuery();
                    
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return rowsAffected;
        }
        
        protected int InsertKaartGegevens(SqlCommand insertCommand)
        {
            int rowsAffected;
            try
            {
                using(sqlConn)
                {
                    insertCommand.Connection=sqlConn;
                    sqlConn.Open();
                    rowsAffected = insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConn.Close();
            }
            return rowsAffected;
        }
        protected InsertResult InsertKaart(SqlCommand insertCommand)
        {
            var result = new InsertResult();
            try
            {
                using(sqlConn)
                {
                    if (string.IsNullOrEmpty(sqlConn.ConnectionString))
                        sqlConn = new SqlConnection(Settings.Settings.Database.ProjectConnectionstring);
                        
                        insertCommand.Connection = sqlConn;
                        sqlConn.Open();
                        insertCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return result;
        }
        protected InsertResult InsertBestelling(SqlCommand insertCommand)
        {
            var result = new InsertResult();

            try
            {
                using (sqlConn)
                {
                    if (string.IsNullOrEmpty(sqlConn.ConnectionString))
                        sqlConn = new SqlConnection(Settings.Settings.Database.ProjectConnectionstring);
                    insertCommand.CommandText += "SET @BestellingNr=SCOPE_IDENTITY();";
                    insertCommand.Parameters.Add("@BestellingNr", SqlDbType.Int).Direction = ParameterDirection.Output;
                    insertCommand.Connection = sqlConn;
                    sqlConn.Open();
                    insertCommand.ExecuteNonQuery();
                    int bestellingNr = Convert.ToInt32(insertCommand.Parameters["@BestellingNr"].Value);
                    result.BestellingNr = bestellingNr;
                    //rowsAffected = insertCommand.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return result;
        }
        protected InsertResult InsertFactuur(SqlCommand insertCommand)
        {
            var result = new InsertResult();

            try
            {
                using (sqlConn)
                {
                    if (string.IsNullOrEmpty(sqlConn.ConnectionString))
                        sqlConn = new SqlConnection(Settings.Settings.Database.ProjectConnectionstring);
                    insertCommand.CommandText += "SET @FactuurNr=SCOPE_IDENTITY();";
                    insertCommand.Parameters.Add("@FactuurNr", SqlDbType.Int).Direction = ParameterDirection.Output;
                    insertCommand.Connection = sqlConn;
                    sqlConn.Open();   
                    insertCommand.ExecuteNonQuery();
                    int factuurNr = Convert.ToInt32(insertCommand.Parameters["@FactuurNr"].Value);
                    result.FactuurNr = factuurNr;

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return result;
        }
        protected InsertResult InsertRecord(SqlCommand insertCommand)
        {
            var result = new InsertResult();

            try 
            {
                using (sqlConn)
                {
                    if (string.IsNullOrEmpty(sqlConn.ConnectionString))
                        sqlConn = new SqlConnection(Settings.Settings.Database.ProjectConnectionstring);
                    insertCommand.CommandText += "SET @new_id=SCOPE_IDENTITY();";
                    insertCommand.Parameters.Add("@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    insertCommand.Connection = sqlConn;
                    sqlConn.Open();
                    insertCommand.ExecuteNonQuery();
                    int newId = Convert.ToInt32(insertCommand.Parameters["@new_id"].Value);
                    result.NewId = newId;     
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConn.Close();
            }
            return result;
        }





/*        protected InsertResult UpdateRecord(SqlCommand insertCommand)
        {
            var result = new InsertResult();

            try
            {
                using (sqlConn)
                {
                    insertCommand.Connection = sqlConn;
                    sqlConn.Open();

                      // hier moet iets gebeuren 
                   // insertCommand.ExecuteNonQuery();
                 
                    result = new InsertResult();

                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConn.Close();
            }
            return result;
        }*/
    }

}
