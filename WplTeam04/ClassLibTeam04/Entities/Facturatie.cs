using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Entities
{
    public class Facturatie
    {
        public int FactuurNr { get; set; }
        public int KlantId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Straat { get; set; }
        public string Woonplaats { get; set; }

    }
}
