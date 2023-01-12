using ClassLibTeam04.Data;
using ClassLibTeam04.Data.Framework;
using ClassLibTeam04.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Business
{
    public static class Facturaties
    {
        public static DataTable FactuurKrijgen(Facturatie factuur)
        {
            var dt = new DataTable();

            try
            {
                var factuurData = new FacturatieData();
                var result = factuurData.select(factuur.FactuurNr, factuur.KlantId);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
    
        public static bool FactuurOpslaan(Facturatie factuur)
        {
            bool isJuist = false;
            try
            {
                var factuurData = new FacturatieData();
                var result = factuurData.Insert(factuur);
                if(result.FactuurNr != 0)
                {
                    isJuist = true;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return isJuist;
        }
        public static InsertResult FactuurGegevens(Facturatie factuur)
        {
            var result = new InsertResult();
            try
            {
                var factuurData = new FacturatieData();
                result = factuurData.Insert(factuur);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        public static int Factuur(Facturatie factuur)
        {
            int rows = 0;
            try
            {
                var factuurData = new FacturatieData();
                var result = factuurData.Insert(factuur);
                rows = result.Rows;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return rows;
        }
    }
}
