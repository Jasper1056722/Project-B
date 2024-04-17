using System;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
public class Program 
{
    static void Main()
    {
        
        // // Add contactinfo test
        // Reservation reservation = new Reservation(123456);
        // int AmountPersons = 2; // 2 people
        // for (int i = 0; i < AmountPersons; i++) // Adds multiple people contactinfo
        // {
        //     reservation.AddContactInfo();
        // }
        
        // List<Flight> flights = Flight.LoadJson();
        // foreach (Flight flight in flights)
        // {
        //     Console.WriteLine(flight.DepartureTime);
        // }
        // Flightinfo.DisplayFlights(flights);
        // Flight.WriteToJson(flights);
        // Console.ReadKey();
        // Add contactinfo test
        Reservation reservation = new Reservation();
        List<Flight> flights = Flight.LoadJson();
        reservation.SelectFlight(flights);

        

        Console.WriteLine("How many seats do you want to reserve?");
        int AmountPersons = Convert.ToInt32(Console.ReadLine());
        if (AmountPersons == 1)
        {
            reservation.ReserveRandomSeat(reservation.FlightForReservation);
        }

        else if (AmountPersons > 1)
        {
            for (int i = 0; i < AmountPersons; i++)
            {
                reservation.AddContactInfo(); // Adds a person object to list and adds contactinfo for each
                reservation.SelectSeat();
            }
        }
        
        foreach (var person in reservation.People)
        {
            Console.WriteLine($"First Name: {person.FirstName}");
            Console.WriteLine($"Last Name: {person.LastName}");
            Console.WriteLine($"Birth Date: {person.BirthDate}");
            Console.WriteLine($"Phone Number: {person.PhoneNumber}");
            Console.WriteLine($"Email Address: {person.EmailAddress}");
            Console.WriteLine("");
        }
        // Console.WriteLine("Hello, World!");
        //Mail.Mailsender("Joey", "joeyzwinkels@gmail.com", "24885645");
        /*
        Console.Title = "Flight Application";
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.Clear();

        bool exitRequested = false;
        
        Account account = new Account();
        List<Flight> flights = Flight.LoadJson();

        do
        {
            
            if (!account.IsLoggedIn)
            {
                string NmenuChoice = Menu.Nmenus();
                switch (NmenuChoice)
                {
                    case "L":
                        if (!account.IsLoggedIn)
                        {
                            Console.WriteLine("Fill in Email:");
                            string email = Console.ReadLine();
                            Console.WriteLine("Fill in Password:");
                            string password = Console.ReadLine();

                            account.Login(email, password);
                            if (account.IsLoggedIn)
                            {
                                Console.WriteLine("Logged in\n");
                            }
                            }
                            else
                            {
                                Console.WriteLine("You are already logged in");
                            }
                            break;

                    case "S":
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
                    case "SE":
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
                }
            }
            else if (!account.IsAdminbool)
            {
                string menuChoice = Menu.menus();
                switch (menuChoice)
                {
                    case "SE":
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

                    case "LO":
                        if (account.IsLoggedIn)
                        {
                            account.logout();
                            Console.WriteLine("\nLogged out\n");
                        }
                        break;
                    
                    case "Q":
                        exitRequested = true;
                        break;
                }
                    
            }
            else if (account.IsAdminbool)
            {
                string AmenuChoice = Menu.menusadmin();
                switch (AmenuChoice)
                {
                    case "A":
                        Flightinfo.FlightAdd(flights);
                        break;

                    case "R":
                        Console.WriteLine("Enter the flightnumber for the flight u want to change");
                        string flightnumber = Console.ReadLine();
                        Flightinfo.UpdateInfo(flightnumber, flights);
                        break;
                    
                    case "C":
                        Console.WriteLine("Enter the flightnumber for the flight u want to remove");
                        string flightnumber2 = Console.ReadLine();
                        Flightinfo.UpdateInfo(flightnumber2, flights);
                        break;

                    case "S":
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
                        }while (trueNess01 == false);

                        break;
                    
                    case "L":
                        if (account.IsLoggedIn)
                            {
                                Console.WriteLine("Logging out");
                                account.logout();
                                Console.WriteLine("Logged out");
                            }
                        break;

                    case "Q":
                        exitRequested = true;
                        break;
                }
            }
        } while (!exitRequested);
            
            
            Console.WriteLine("Exiting the program...");
            Flight.WriteToJson(flights);
            Console.ReadKey();*/
    }


}