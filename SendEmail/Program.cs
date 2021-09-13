using System;

namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sending email");
            EmailSend emailSend = new EmailSend();
            try
            {
                Console.WriteLine(emailSend.SendEmail(new EmailDetails("sendingemail@email.com", "password", 587, "smtp.gmail.com", "Musandlala@yahoo.com", "subjective subject", "hello body")));
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}