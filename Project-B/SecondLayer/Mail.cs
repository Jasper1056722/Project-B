using MailKit.Net.Smtp;
using MimeKit;

public static class Mail
{

    public static void GetInfo(Reservation info)
    {
        int reservationnumber = info._reservationNumber;
        Person firstPerson = info.People[0];
        string fullname = ($"{firstPerson.FirstName} {firstPerson.LastName})");
        string BirthDate = ($"{firstPerson.BirthDate}");
        string number = ($"{firstPerson.PhoneNumber}");
        string mail = ($"{firstPerson.EmailAddress}");
        Mailsender(reservationnumber , fullname, mail);
    }

    public static void Mailsender(int number, string name, string mail)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("AirPort", "airprojbgroupd@gmail.com"));
        message.To.Add(new MailboxAddress(name, mail));//name , email
        message.Subject = "Airplane reservation";

        message.Body = new TextPart("plain")
        {
            Text = $"We have recieved your reservation flight reservation number: {number}"// is message 
        };

        //unchangable is gwn die bog email setting
        string smtpServer = "smtp.gmail.com";
        int port = 465;// port voor ssl
        string username = "airprojbgroupd@gmail.com";
        string password = "igss aonz gbxx dhro";//app password // normale password mail = petpetpet123#


        using (var client = new SmtpClient())
        {   
            Console.WriteLine("Connecting....");
            client.Connect(smtpServer,port,true);
            client.Authenticate(username,password);
            try
            {
                Console.WriteLine("Sending....");
                client.Send(message);
                client.Disconnect(true);
                Console.WriteLine("Email has been send");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.ToString()}");
            }
        }
    }
}