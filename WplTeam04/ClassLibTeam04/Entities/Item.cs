using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Entities
{
    public class Item
    {
        public int BestellingNr { get; set; } // FK
        public string EAN { get; set; } // Fk  
      //  public DateTime ReturnDatum { get; set; }
        public string VerwachteReturnDatum { get; set; }
        public string bestellingsDatum { get; set; }
        

    }
}
