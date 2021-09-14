using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace SendEmail
{
    sealed class EmailSend
    {
        public bool SendEmail(EmailDetails sendEmail, bool sslOn_Of = true) 
        {
            try {
                return SendEmail(sendEmail,sslOn_Of,null);
            }
            catch (Exception){
                return false;
            }
        }
        public bool SendEmail(EmailDetails sendEmail, Attached attached = null)
        {
            try { 
                return SendEmail(sendEmail,true,attached);
            }
            catch (Exception){ 
                return false;
            }
        }
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
                    //Body =  sendEmail.body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(sendEmail.RecievingEmail);
                AlternateView alternativeView = AlternateView.CreateAlternateViewFromString(sendEmail.body, null, MediaTypeNames.Text.Html);
                //alternativeView.LinkedResources.Add(iconResource);
                mailMessage.AlternateViews.Add(alternativeView);

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