using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Common
{
  public  class SendEmailAPI
    {
        public SendEmailAPI()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static bool SendEmail(string pGmailEmail, string pTo, string pSubject, string pBody, string cc)
        {
            try
            {



                pGmailEmail = "ssd@sun.edu.ng";

                SmtpClient SmtpServer = new SmtpClient();
                MailMessage mail = new MailMessage();
                System.Text.StringBuilder mailbody = new System.Text.StringBuilder();
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.office365.com";
                // SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\marketing@sun.edu.ng", "Xdirsun202034");
                SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\ssd@sun.edu.ng", "kaJjs$!8192");
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.EnableSsl = true;
                //SmtpServer.Port = 25;
                //SmtpServer.Host = "86.96.198.37";
                //SmtpServer.Credentials = new NetworkCredential("86.96.198.37\\admissions@skylineuniversity.ac.ae", "Mark205");
                //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                ;
                mail.From = new MailAddress(pGmailEmail);

                mail.To.Add(pTo);
                mail.Subject = pSubject;
                if (cc != "")
                    mail.CC.Add(cc);
                mail.IsBodyHtml = true;

                mailbody.Append(pBody);

                mail.Body = mailbody.ToString();
                SmtpServer.Send(mail);
                return true;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool SendEmail2(string pGmailEmail, string pTo, string pSubject, string pBody, string cc)
        {
            try
            {

                pGmailEmail = "developer@sun.edu.ng";

                SmtpClient SmtpServer = new SmtpClient();
                MailMessage mail = new MailMessage();
                System.Text.StringBuilder mailbody = new System.Text.StringBuilder();
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.office365.com";
                SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\developer@sun.edu.ng", "Xdirsun202034");
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.EnableSsl = true;

                //SmtpServer.Port = 25;
                //SmtpServer.Host = "86.96.198.37";
                //SmtpServer.Credentials = new NetworkCredential("86.96.198.37\\admissions@skylineuniversity.ac.ae", "Mark205");
                //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;


                mail.From = new MailAddress(pGmailEmail);
                mail.To.Add(pTo);
                mail.Subject = pSubject;
                if (cc != "")
                    mail.CC.Add(cc);
                mail.IsBodyHtml = true;

                mailbody.Append(pBody);

                mail.Body = mailbody.ToString();
                SmtpServer.Send(mail);
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
