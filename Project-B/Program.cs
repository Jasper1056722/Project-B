
public class Program 
{
    static void Main()
    {
        // Console.WriteLine("Hello, World!");
        //Mail.Mailsender("Joey", "joeyzwinkels@gmail.com", "24885645");

        
        Account account = new Account();


        do
        {
            Menu.menus();
            string Menuchoice = Console.ReadLine();

            if (Menuchoice == "1")
            {
                if(!account.IsLoggedIn) 
                    {
                        account.Login();
                        if (account.IsLoggedIn)
                        {
                            Console.WriteLine("Logged in");
                        }
                    }
                    
                else 
                {
                    Console.WriteLine("You are already logged in");
                } 

            }
            else if (Menuchoice == "2")
            {   
                if(!account.IsLoggedIn)
                {
                    account.signup();
                }
                else 
                {
                    Console.WriteLine("You are already logged in");
                } 

            }

        }while (true);
        Console.ReadKey();
    }
}
