using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Data.Framework
{
   public class InsertResult:BaseResult
    {
        public int NewId { get; set; }
        public int FactuurNr { get; set; }
        public int BestellingNr { get; set; }
        
    }
}
