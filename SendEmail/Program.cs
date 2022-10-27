using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

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

                Console.WriteLine(emailSend.SendEmail(new EmailDetails(mail,paspharse, 587, "smtp.gmail.com", "Musandlala@yahoo.com", "subjective subject", "hello body"), true, athd));
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
