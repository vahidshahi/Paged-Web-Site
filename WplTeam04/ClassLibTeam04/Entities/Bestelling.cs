using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Entities
{
    public class Bestelling
    {
        public int BestellingNr { get; set; }       //PK
        public int KlantId { get; set; }             // FK
        public string BestellingDatum{ get; set; }             

    }
}
