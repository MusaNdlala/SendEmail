using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace SendEmail
{
    sealed class EmailSend
    {
        public bool SendEmail(EmailDetails sendEmail, bool sslOn_Of=true,Attached attached=null)
        {
            try
            {
                var smtpClient = new SmtpClient(sendEmail.smtpParam)
                {
                    Port = sendEmail.portParam,
                    Credentials = new NetworkCredential(sendEmail.SendingEmail, sendEmail.password),
                    EnableSsl = sslOn_Of,
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(sendEmail.SendingEmail),
                    Subject = sendEmail.subject,
                    Body = "<h1>"+ sendEmail.body + "</h1>",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(sendEmail.RecievingEmail);
                
                if (attached !=null) {
                    if(attached.MediaType == null)
                        attached.MediaType = MediaTypeNames.Text.Plain;

                    var attachment = new Attachment(attached.url, attached.MediaType);
                    mailMessage.Attachments.Add(attachment);
                    smtpClient.Send(mailMessage);
                    return true;
                }
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}