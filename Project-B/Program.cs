
public class Program 
{
    static void Main()
    {
        // Console.WriteLine("Hello, World!");
        //Mail.Mailsender("Joey", "joeyzwinkels@gmail.com", "24885645");
        Account account = new Account();

        //account.signup();
        account.Login();
        if (account.IsLoggedIn)
        {
            Console.WriteLine("petpet");
            Console.WriteLine(account.Primkey);
        } 
        Console.ReadKey();
    }
}
