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
                return SendEmail(sendEmail, sslOn_Of, null);
            }
            catch (Exception) {
                return false;
            }
        }
        public bool SendEmail(EmailDetails sendEmail, Attached attached = null)
        {
            try {
                return SendEmail(sendEmail, true, attached);
            }
            catch (Exception) {
                return false;
            }
        }
        public bool SendEmail(EmailDetails sendEmail, bool sslOn_Of = true, Attached attached = null)
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

                var pathurl = @"C:\Users\Musa\source\repos\SendEmail\SendEmail\html\EmailTEmplate1\images\email.png";
                mailMessage = EmbedPictures(mailMessage, pathurl, sendEmail.body);
                if (mailMessage == null)
                    return false;

                if (attached != null) {
                    if (attached.MediaType == null)
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
        private MailMessage EmbedPictures(MailMessage temp,string imageUrl, string htmlBody)
        {
            try
            {
                var picturez = new Attached(imageUrl);
                var attachment2 = new Attachment(picturez.url, picturez.MediaType);
                AlternateView alternativeView = GetEmbeddedImage(picturez.url, htmlBody);
                temp.AlternateViews.Add(alternativeView);
                return temp;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private AlternateView GetEmbeddedImage(String filePath, string EmailBody)
        {
            LinkedResource res = new LinkedResource(filePath);
            res.ContentId = Guid.NewGuid().ToString();

            string htmlBody = EmailBody.Replace("[LogoImage]", "cid:" + res.ContentId);
            
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
    }
}