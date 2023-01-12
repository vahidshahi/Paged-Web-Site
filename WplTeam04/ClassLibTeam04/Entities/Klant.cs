using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Entities
{
    public class Klant
    {
       
        // toegevoeg door Elke :  is nodig voor de info die ik binnen krijg te verwerken
        public string indicator { get; set; }


        // dit is de standaard vorm van een KLANT                         
        public int KlantId { get; set; }      // KP
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Emailadres { get; set; }
        public string Wachtwoord { get; set; }
        public string Postcode { get; set; }
        public string Straatnaam { get; set; }
        public string Huisnr { get; set; }
        public string Busnr { get; set; }
        public string Geboortedatum { get; set; }
        public string Gsmnr { get; set; }
        public string ExtraKlantenInfo { get; set; }
        public string Bankkaartnr { get; set; }
        public string VervaldatumBankKaart { get; set; }
        public string BankkaartControleNr { get; set; }
        public string RekeningNr { get; set; }

        public string givenGemeente { get; set; }
        public string givenPostcode { get; set; }



        // public string idklant { get; set; }  

    }
}
