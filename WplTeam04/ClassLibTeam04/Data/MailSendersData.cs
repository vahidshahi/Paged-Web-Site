using ClassLibTeam04.Entities;
using ClassLibTeam04.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ClassLibTeam04.Data
{
    internal class MailSendersData 
    {
        public  void OntwerpMail(MailSender mailSender)
        {
          
            string senderVoornaam = mailSender.Sender_voornaam;
            string senderAchternaam = mailSender.Sender_achternaam;
         
            string senderMail = mailSender.Sender_email;
            string senderGsm = mailSender.Sender_gsm;
            string senderklantNr = mailSender.Sender_klantNR;
            string senderBericht = mailSender.Sender_bericht;
           // string DankuBericht = $"Dank je {senderVoornaam} {senderAchternaam} voor je bericht";

            var mail = new MailToPage(senderMail);
            mail.Body = $"{senderAchternaam} {senderVoornaam} Heeft u een bericht gestuurd \n\r {senderBericht} \n\r informatie van de sender \n\r{senderMail} \n\r {senderGsm} \n\r {senderklantNr}";
            mail.Subject = $"{senderAchternaam} {senderVoornaam} {senderklantNr}";


            
           mail.SendMail();       


        }


        public void OntwerpDoneerMail(MailSender mailSender)

        {
         
            string senderMail = mailSender.Sender_email;
            var mail = new PagedMail(senderMail);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("" + DateTime.Now);
            sb.AppendLine("Hi " + mailSender.Sender_voornaam + mailSender.Sender_achternaam + ",");
            sb.AppendLine("Bedankt dat je wilt doneren ");
            sb.AppendLine("Zo simple is het ");
            sb.AppendLine("Print de bon uit en plak hem op de doos ");
            sb.AppendLine("Geef hem af bij een postcenter Wij regelen de verzendkosten!");
            sb.AppendLine("________________________________________________________________________________________________________");
            sb.AppendLine(" RETUURLABEL                                                                              ");
            sb.AppendLine("                                      Hasseltweg 4 3600 Genk  Paged                                             ");
            sb.AppendLine("                                                                                                          ");
            sb.AppendLine("                 |||||||||||| |||||| || ||||| ||||||| ||||| ||||||| ||||||||||| ||||||||                  ");
            sb.AppendLine("                 |||||||||||| |||||| || ||||| ||||||| ||||| ||||||| ||||||||||| ||||||||                  ");
            sb.AppendLine("                 |||||||||||| |||||| || ||||| ||||||| ||||| ||||||| ||||||||||| ||||||||                  ");
            sb.AppendLine("                 |||||||||||| |||||| || ||||| ||||||| ||||| ||||||| ||||||||||| ||||||||                  ");
            sb.AppendLine("                 |||||||||||| |||||| || ||||| ||||||| ||||| ||||||| ||||||||||| ||||||||                  ");
            sb.AppendLine("                                          08654 6412 9432 8946513 984651 9874 B                           ");
            sb.AppendLine("________________________________________________________________________________________________________");


            mail.Body = sb.ToString();
            mail.Subject = "Doneer Bon";

            mail.SendMail();
        }
       
    }
}
