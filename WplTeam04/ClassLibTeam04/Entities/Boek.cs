using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Entities
{
    public class Boek
    {
        // standaard waarden van een boek
            public string EAN { get; set; }    // PK
            public string Auteur { get; set; }
            public string Titel { get; set; }
            public string HuurPrijs { get; set; }
            public string SourceImg { get; set; }
            public string Omschrijving { get; set; }
            public string Categorie { get; set; }
            public string Uitgeverij { get; set; }
            public string Aantalbladzijden { get; set; }
            public string Uitvoering { get; set; }
            public string Gewicht { get; set; }
            public string Taal { get; set; }
        
    }
}
