using ClassLibTeam04.Data;
using ClassLibTeam04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Business
{
    public static class BankKaartStatic
    {
        public static bool KaartGegevensOpslaan(Bankkaart bankkaart)
        {
            bool isSucceded = false;
            try
            {
                var bankKaartData = new BankKaartData();
                var result = bankKaartData.Insert(bankkaart);
                if (result != 0)
                {
                   isSucceded = true;
                }
           

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return isSucceded;
        }
    }
}
