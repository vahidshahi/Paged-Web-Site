using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Mail
{
    public class MailToPage
    {
        public MailToPage(string senderMail)
        {
            To = MailServer.MailFrom;
            From = senderMail;
        }
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        

              
        public void SendMail()
        {
            try
            {
                MailMessage mail = new MailMessage(From, To);
                mail.Body = Body;
                mail.Subject = Subject;
                var smtp = MailServer.GetSmtpClient();
                smtp.Send(mail);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
