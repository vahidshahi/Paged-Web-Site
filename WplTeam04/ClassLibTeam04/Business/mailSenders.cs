using ClassLibTeam04.Data;
using ClassLibTeam04.Entities;
using ClassLibTeam04.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Business
{
    public static class mailSenders
    {
        public static void OntwerpSentMail(MailSender mailsender)
        {
           var MailSendersData = new MailSendersData();
           MailSendersData.OntwerpMail(mailsender);

        }
        public static void OntwerpDoneerMail(MailSender mailsender)
        {
            var MailSendersData = new MailSendersData();
            MailSendersData.OntwerpDoneerMail(mailsender);

        }
    }
}
