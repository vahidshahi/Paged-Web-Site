using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Entities
{
    public class Bankkaart
    {
        public int KlantId { get; set; }
        public string KaartHouderNaam { get; set; }
        public string VervalMaand { get; set; }
        public int CreditKaartNr { get; set; }
        public int VervalJaar { get; set; }
      

    }
}
