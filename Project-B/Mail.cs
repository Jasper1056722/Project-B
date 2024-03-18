using MailKit.Net.Smtp;
using MimeKit;

public class Mail
{
    public static void Mailsender(string name, string mail, string flightnumber)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("AirPort", "airprojbgroupd@gmail.com"));
        message.To.Add(new MailboxAddress(name, mail));//name , email
        message.Subject = "Airplane reservation";

        message.Body = new TextPart("plain")
        {
            Text = @$"Dear {name},

I'm reaching out to confirm your recent flight reservation with us. Here are the details:

Passenger: [Passenger's Name]
Flight: {flightnumber}
Date: {Flightinfo.Getinfo(flightnumber)["Date"]}
Time: {Flightinfo.Getinfo(flightnumber)["Departure time"]}
From: {Flightinfo.Getinfo(flightnumber)["Departing from"]}
To: {Flightinfo.Getinfo(flightnumber)["Destination"]}
Seat(s): [Seat Number(s)]
Booking Reference: [Booking Reference Number]

Please review this information. If everything looks good, no further action is needed. If you have any questions or need assistance, feel free to contact us at [Customer Service Contact Information].

Thank you for choosing us for your travel needs. We're looking forward to serving you on board.

Best regards,

Rotterdam Airport
airprojbgroupd@gmail.com ---- 020-315 73 92"// is message 

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