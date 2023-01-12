using ClassLibTeam04.Data;
using ClassLibTeam04.Data.Framework;
using ClassLibTeam04.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Business
{
    public static class Boeken
    {
        public static DataView GetBoeken()
        {
            var dv = new DataView();
            try
            {
               var boekendata = new BoekenData();
                var result = boekendata.SelectQueryAll();
                dv = result.DataTable.DefaultView; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
                throw;
            }
            return dv;
        }
        public static DataTable GetBoekendt()
        {
            var dt = new DataTable();
            try
            {
                var boekenData = new BoekenData();

                var result = boekenData.SelectBoekenWithDates();
                dt = result.DataTable;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt; 
        }
        

        public static DataTable GetBoekenWithDates()
        {
            
                var dt = new DataTable();
                try
                {
                    var boekenData = new BoekenData();
                    var result = boekenData.SelectBoekenWithDates();
                    dt = result.DataTable;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return dt;
            
        }


        public static InsertResult AddBoek(Boek boek)
        {
            var result = new InsertResult();
            try
            {
                var boekenData = new BoekenData();
                boekenData.Insert(boek);
                
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
