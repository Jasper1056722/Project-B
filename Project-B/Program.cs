using System;
public class Program 
{
    static void Main()
    {
        // Console.WriteLine("Hello, World!");
        //Mail.Mailsender("Joey", "joeyzwinkels@gmail.com", "24885645");

        bool exitRequested = false;
        
        Account account = new Account();
        List<Flight> flights = Flight.LoadJson();



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

<<<<<<< Updated upstream
                case "6":
=======
                case "3":
>>>>>>> Stashed changes
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
                                Console.WriteLine("Where do u want to travel to");
                                string destinat = Console.ReadLine().ToLower();
                                Searching.Destination(destinat, flights);
                                break;
                            case "T":
                                Console.WriteLine("What date do u want to look for?");
                                string departureDateInput = Console.ReadLine();
                                Searching.Time(departureDateInput, flights);
                                break;
                            case "A":
                                Console.WriteLine(@"
Which airplane do you want to travel with?
- Airbus 330
- Boeing 787
- Boeing 737");
                                string PlaneAnswer = Console.ReadLine().ToLower();
                                Searching.Airline(PlaneAnswer, flights);
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

                case "3":
                    Flightinfo.FlightAdd(flights);
                    break;

                case "4":
                    Console.WriteLine("Enter the flightnumber for the flight u want to change");
                    string flightnumber = Console.ReadLine();
                    Flightinfo.UpdateInfo(flightnumber, flights);
                    break;

                case "5":
                    Console.WriteLine("Enter the flightnumber for the flight u want to remove");
                    string flightnumber2 = Console.ReadLine();
                    Flightinfo.UpdateInfo(flightnumber2, flights);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        } while (!exitRequested);

        Console.WriteLine("Exiting the program...");
        Flight.WriteToJson(flights);
    }


}