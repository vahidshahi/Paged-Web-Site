using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Mail
{
   static class MailServer
    {
        const string mailServer = "smtp.gmail.com";
        const int portNumber = 587;
        const string userName = "pagerentboeken@gmail.com";
        const string password = "pxlTeam04";
        public static string MailFrom => userName;
        public static SmtpClient GetSmtpClient()
        {
            var smtpClient = new SmtpClient(mailServer, portNumber);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = userName,
                Password = password
            };
            smtpClient.EnableSsl = true;
            return smtpClient;

        }
        
    }
}
