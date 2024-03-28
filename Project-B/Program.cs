using System;
public class Program 
{
    static void Main()
    {
        // Console.WriteLine("Hello, World!");
        //Mail.Mailsender("Joey", "joeyzwinkels@gmail.com", "24885645");

        bool exitRequested = false;
        
        Account account = new Account();



        do
        {
            string menuChoice = Menu.menus();
            switch (menuChoice)
            {
                case "1":
                    if (!account.IsLoggedIn)
                    {
                        Console.WriteLine("Fill in Email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Fill in Password:");
                        string password = Console.ReadLine();

                        account.Login(email, password);
                        if (account.IsLoggedIn)
                        {
                            Console.WriteLine("Logged in");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You are already logged in");
                    }
                    break;

                case "2":
                    if (!account.IsLoggedIn)
                    {   
                        Console.WriteLine("Fill in Email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Fill in Password:");
                        string password = Console.ReadLine();
                        account.Signup(email, password);
                    }
                    else
                    {
                        Console.WriteLine("You are already logged in");
                    }
                    break;

                case "Q":
                    exitRequested = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        } while (!exitRequested);

        Console.WriteLine("Exiting the program...");
        Console.ReadKey();
    }
}