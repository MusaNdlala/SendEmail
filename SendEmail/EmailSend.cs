using System;
using System.Net;
using System.Net.Mail;

namespace SendEmail
{
    sealed class EmailSend
    {
        public bool SendEmail(EmailDetails sendEmail)
        {
            try
            {
                var smtpClient = new SmtpClient(sendEmail.smtpParam)
                {
                    Port = sendEmail.portParam,
                    Credentials = new NetworkCredential(sendEmail.SendingEmail, sendEmail.password),
                    EnableSsl = true
                };
                smtpClient.Send(sendEmail.SendingEmail, sendEmail.RecievingEmail, sendEmail.subject, sendEmail.body);
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