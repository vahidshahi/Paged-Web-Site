using ClassLibTeam04.Data;
using ClassLibTeam04.Data.Framework;
using ClassLibTeam04.Entities;
using ClassLibTeam04.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Business
{
    public static class Bestellingen
    {
        public static string SendMail(BevestigingsEmail bevestigingsEmail)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                var mail = new PagedMail(bevestigingsEmail.Email);
                mail.Subject = "Uw bestelling is geplaatst";
                stringBuilder.AppendLine("Beste, " + bevestigingsEmail.Naam + " uw bestelling hebben wij goed ontvangen.");
                stringBuilder.AppendLine("Bedankt voor je bestelling ");
                stringBuilder.AppendLine("Uw bestellings Nummer is " + bevestigingsEmail.BestellingsNr);
                mail.Body = stringBuilder.ToString();
                mail.SendMail();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return stringBuilder.ToString();
        }
        public static InsertResult BestellingPlaatsen(Bestelling bestelling)
        {
            var result = new InsertResult();

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            bestelling.BestellingDatum = dateTime;
            try
            {
                var bestellingData = new BestellingenData();
                result = bestellingData.Insert(bestelling);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;

        }
    }
}
