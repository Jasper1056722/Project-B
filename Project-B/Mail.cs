using MailKit.Net.Smtp;
using MimeKit;

public class Mail
{
    public static void Mailsender(string name, string mail)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("AirPort", "airprojbgroupd@gmail.com"));
        message.To.Add(new MailboxAddress(name, mail));//name , email
        message.Subject = "Airplane reservation";

        message.Body = new TextPart("plain")
        {
            Text = "We have recieved your reservation"// is message 
        };

        //unchangable is gwn die bog email setting
        string smtpServer = "smtp.gmail.com";// smpt server van gmail
        int port = 465;// port voor ssl
        string username = "airprojbgroupd@gmail.com";
        string password = "igss aonz gbxx dhro";//app password // normale password mail = petpetpet123#


        using (var client = new SmtpClient())
        {   
            Console.WriteLine("Connecting....");
            client.Connect(smtpServer,port,true);// connect aan server
            client.Authenticate(username,password);// logged in
            try
            {
                Console.WriteLine("Sending....");
                client.Send(message);//stuurt die message
                client.Disconnect(true);// disconnect van die server
                Console.WriteLine("Email has been send");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.ToString()}");// als error gebeurt
            }
        }
    }
}