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
                Console.WriteLine("Sending email");
                EmailSend emailSend = new EmailSend();
                Attached athd = new Attached(@"C:\files\temp.txt");

                Console.WriteLine(emailSend.SendEmail(new EmailDetails("Musandlovu1988@gmail.com", "k5CaS4LqpUdB6LvP", 587, "smtp.gmail.com", "Musandlala@yahoo.com", "subjective subject", "hello body"), true, athd));
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