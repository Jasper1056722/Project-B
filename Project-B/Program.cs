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

                case "3":
                    bool trueNess01 = false;
                    do
                    {
                        Console.WriteLine(@"
            Based on what criteria do you want to search flights?
            - Destination [D]
            - Departure Time [T]
            - Airline [A]

            Or do you want to Exit?
            - Exit [E]");
                        string answer01 = Console.ReadLine().ToUpper();
                        
                        switch (answer01)
                        {
                            case "D":
                                string destinat = Console.ReadLine().ToLower();
                                Searching.Destination(destinat);
                                break;
                            case "T":
                                string departureDateInput = Console.ReadLine();
                                Searching.Time(departureDateInput);
                                break;
                            case "A":
                                string PlaneAnswer = Console.ReadLine().ToLower();
                                Searching.Airline(PlaneAnswer);
                                break;
                            case "E":
                                trueNess01 = true;
                                break;
                            default:
                                Console.WriteLine("Not a valid input.");
                                break;
                        }
                    }
                    while (trueNess01 == false);
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