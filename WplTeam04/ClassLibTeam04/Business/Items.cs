using ClassLibTeam04.Data;
using ClassLibTeam04.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Business
{
    public static class Items
    {

        public static DataTable ItemsOpslaan(Item item)
        {
            //items static met BestellingData gebruikt
           

            var dt = new DataTable();
            try
            {
                var itemData = new ItemData();
                var bestelData = new BestellingenData();
               
                var result = itemData.Insert(item);
                bestelData.UpdateBesteldatum(item);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
    }
}
