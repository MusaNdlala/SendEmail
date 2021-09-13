using System;

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
                Attached athd = new Attached(@"C:\files\temp.txt","");
                //athd.MediaType = @"C:\files\temp";
                Console.WriteLine(emailSend.SendEmail(new EmailDetails("Musandlovu8819@gmail.com", "k5CaS4LpUdB6LvP", 587, "smtp.gmail.com", "Musandlala@yahoo.com", "subjective subject", "hello body"),true,athd));
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}