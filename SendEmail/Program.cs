using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.IO;

namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                                .AddJsonFile(@"C:\Users\Musa\AppData\Roaming\Microsoft\UserSecrets\57a1ea15-aab6-45ab-a639-67e0605697d0\secrets.json");
                var config = builder.Build();

                Console.WriteLine("Sending email");
                EmailSend emailSend = new EmailSend();
                Attached athd = new Attached(@"C:\files\temp.txt");
                var mail = config["email"];
                var paspharse = config["password"];

                string FilePath = @"C:\Users\Musa\source\repos\SendEmail\SendEmail\html\EmailTEmplate1\Template.html";
                StreamReader str = new StreamReader(FilePath);
                string MailText = str.ReadToEnd();
                str.Close();
                string MyHeader = "M-Ndlala";
                string MyMessage = "Hi this is the message";
                string MessageHeader = "Welcome to the message";
                MailText = MailText.Replace("[MyHeader]", MyHeader);
                MailText = MailText.Replace("[Message]", MyMessage);
                MailText = MailText.Replace("[MessageHeader]", MessageHeader);

                //Console.WriteLine(emailSend.SendEmail(new EmailDetails("Musandlovu1988@gmail.com", "k5CaS4LqpUdB6LvP", 587, "smtp.gmail.com", "Musandlala@yahoo.com", "subjective subject", "hello body"), true, athd));
                Console.WriteLine(emailSend.SendEmail(new EmailDetails(mail,paspharse, 587, "smtp.gmail.com", "Musandlala@yahoo.com", "subjective subject", MailText), true, athd));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    public class MYConfigure
    {
        private IConfiguration _configuration;
        public MYConfigure(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string getEmail()
        {
            return _configuration["email"];
        }
        public string getPassword()
        {
            return _configuration["password"];
        }
    }
}