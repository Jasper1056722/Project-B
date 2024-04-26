using System;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Globalization;
public class Program 
{
    static void Main()
    {
        Menu.StartMenu();
        List<Flight> flights = Flight.LoadJson();
        Account account = new();
       
        Console.Title = "Flight Application";
        Thread.Sleep(2000);
        string NL = Environment.NewLine; // shortcut
        string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
        string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
        string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
        string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
        string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
        string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";
        string BOLD = Console.IsOutputRedirected ? "" : "\x1b[1m";
        string NOBOLD = Console.IsOutputRedirected ? "" : "\x1b[22m";
        string UNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[4m";
        string NOUNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[24m";
        string REVERSE = Console.IsOutputRedirected ? "" : "\x1b[7m";
        string NOREVERSE = Console.IsOutputRedirected ? "" : "\x1b[27m";
        bool state = true;


        Console.CursorVisible = false;
        while(state)
        {
            int selectedOptionIndex = Menu.MenuPanel("Login Menu", "Here u can login", ["Login", "Sign up", "Search Flight", "Show all flights", "Quit Program"]);
        
                    
                    switch (selectedOptionIndex)
                    {
                        case 0:  
                            string email = Menu.GetString("ENTER email: ");
                            string password = Menu.GetString("ENTER PASSWORD: ");

                            bool UserState = account.Logintodb(email, password);
                            Console.Clear();
                            Menu.LoadingBar("Loading account", TimeSpan.FromSeconds(2));
                            if (account.IsAdminbool)
                            {
                                bool AdminPanelState = true;
                                while (AdminPanelState)
                                {
                                    int AdminPanelIndex = Menu.MenuPanel("Admin panel", "Here u can control all the reservations and flights", ["Add a flight", "Remove a flight", "Change a flight", "Search a flight", "Show all flights", "Log out", "Quit Program"]);

                                    switch(AdminPanelIndex)
                                    {
                                        case 0:
                                            Console.Clear();
                                            int AirplaneSelectorIndex = Menu.MenuPanel("Airplane Model Selector", "What plane model should be used for the flight", ["Boeing 737", "Boeing 787", "Airbus 330"]);
                                            Console.Clear();
                                            Plane plane;

                                            switch (AirplaneSelectorIndex)
                                            {
                                                case 0:
                                                    plane = new Plane("Boeing 737");
                                                    Console.WriteLine("Selected Boeing 737!");
                                                    Thread.Sleep(1000);
                                                    break;

                                                case 1:
                                                    plane = new Plane("Boeing 787");
                                                    Console.WriteLine("Selected Boeing 787!");
                                                    Thread.Sleep(1000);
                                                    break;

                                                case 2:
                                                    plane = new Plane("Airbus 330");
                                                    Console.WriteLine("Selected Airbus 330");
                                                    Thread.Sleep(1000);
                                                    break;
                                                
                                                default:
                                                    plane = new Plane("Boeing 737");
                                                    break;
                                            }
                                            
                                            Console.Clear();
                                            string AddDestination = Menu.GetString("Enter a destination for the flight: ").Trim();
                                            while(!Account.IsAllLetters(AddDestination.Trim()) || string.IsNullOrEmpty(AddDestination.Trim()))
                                            {
                                                Console.WriteLine("Destination can oly include letters, and cannot be null");
                                                AddDestination = Menu.GetString("Enter a destination for the flight: ").Trim();
                                                Console.Clear();
                                            }
                                            Console.Clear();

                                            string AddCountry = Menu.GetString("Enter a country for the flight: ").Trim();
                                            while(!Account.IsAllLetters(AddCountry.Trim()) || string.IsNullOrEmpty(AddCountry.Trim()))
                                            {
                                                Console.WriteLine("Country can oly include letters, and cannot be null");
                                                AddCountry = Menu.GetString("Enter a country for the flight ").Trim();
                                                Console.Clear();
                                            }
                                            Console.Clear();

                                            string AddLocationOfDeparture = Menu.GetString("Enter a location of departure for the flight: ").Trim();
                                            while(!Account.IsAllLetters(AddLocationOfDeparture.Trim()) || string.IsNullOrEmpty(AddLocationOfDeparture.Trim()))
                                            {
                                                Console.WriteLine("Location of departure can oly include letters, and cannot be null");
                                                AddLocationOfDeparture = Menu.GetString("Enter a location of departure for the flight: ").Trim();
                                                Console.Clear();
                                            }
                                            Console.Clear();

                                            string AddDepartureDateString = Menu.GetString("Enter a departure date for the flight: ").Trim();
                                            while(!Account.IsDate(AddDepartureDateString))
                                            {
                                                Console.WriteLine("Invalid input, enter a date (dd-MM-yyyy)");
                                                AddDepartureDateString = Menu.GetString("Enter a departure date for the flight: ").Trim();
                                                Console.Clear();
                                            }
                                            Console.Clear();

                                            string AddnewDepartureTimeString = Menu.GetString("Enter a new departure time (dd-MM-yyyy HH:mm:ss): ");
                                            while(!Account.IsTime(AddnewDepartureTimeString))
                                            {
                                                Console.WriteLine("Invalid input, enter a time (dd-MM-yyyy HH:mm:ss)");
                                                AddnewDepartureTimeString = Menu.GetString("Enter a new departure time: ");
                                                Console.Clear();
                                            }
                                            DateTime AdddateDepartureTime = DateTime.ParseExact(AddnewDepartureTimeString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                            Console.Clear();

                                            string AddEstimatedTimeString = Menu.GetString("Enter a new estimated time of arrival (dd-MM-yyyy HH:mm:ss): ");
                                            while(!Account.IsTime(AddEstimatedTimeString))
                                            {
                                                Console.WriteLine("Invalid input, enter a time (dd-MM-yyyy HH:mm:ss)");
                                                AddEstimatedTimeString = Menu.GetString("Enter a new estimated time of arrival: ");
                                                Console.Clear();
                                            }
                                            DateTime AdddateETATime = DateTime.ParseExact(AddEstimatedTimeString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                            
                                            Console.Clear();
                                            Flight FlightToAdd = new(AddDestination, AddCountry, plane, AddLocationOfDeparture, AddDepartureDateString, "00-00-0000T00:00:00", "00-00-0000T00:00:00");
                                            FlightToAdd.DepartureTime = AdddateDepartureTime;
                                            FlightToAdd.EstimatedTimeofArrival = AdddateETATime;
                                            flights.Add(FlightToAdd);
                                            Menu.LoadingBar("Adding flight to data structure", TimeSpan.FromSeconds(1));
                                            Console.Clear();
                                            Console.WriteLine("New Flight Data:");
                                            Console.WriteLine($"Flightnumber: {FlightToAdd.FlightNumber}");
                                            Console.WriteLine($"Destination: {FlightToAdd.Destination}");
                                            Console.WriteLine($"Country: {FlightToAdd.Country}");
                                            Console.WriteLine($"Airplane Model: {FlightToAdd.Airplane.Model}");
                                            Console.WriteLine($"Location of Departure: {FlightToAdd.DepartingFrom}");
                                            Console.WriteLine($"Departure Date: {FlightToAdd.DepartureDate}");
                                            Console.WriteLine($"Departure Time: {FlightToAdd.DepartureTime}");
                                            Console.WriteLine($"Estimated Time of Arrival: {FlightToAdd.EstimatedTimeofArrival}\n");
                                            Console.WriteLine("Press a key to continue");
                                            Console.ReadKey();
                                            break;

                                        case 1:
                                            Console.Clear();
                                            string FlightNumAnswerDel = Menu.GetString("Enter a flight number to delete: ").Trim();
                                            while(!Account.IsNotNull(FlightNumAnswerDel) || !Account.IsAllDigits(FlightNumAnswerDel))
                                            { 
                                                Console.WriteLine("cant be null!, and needs to be a number!");
                                                FlightNumAnswerDel = Menu.GetString("Enter a flight number to delete: ").Trim();
                                                Console.Clear();
                                            }
                                            Flight flightToRem = flights.FirstOrDefault(flight => flight.FlightNumber.ToString() == FlightNumAnswerDel);
                                            if (flightToRem != null)
                                            {
                                                flights.Remove(flightToRem);
                                                Console.Clear();
                                                Menu.LoadingBar($"Removing flight {FlightNumAnswerDel}", TimeSpan.FromSeconds(1));
                                                Console.Clear();
                                                Console.WriteLine($"Succelfully removed flight {FlightNumAnswerDel}");
                                                Thread.Sleep(1400);
                                                break;
                                            }
                                            else
                                            {
                                            Console.WriteLine($"Flight {FlightNumAnswerDel} does not exist");
                                            Console.WriteLine("Returning back to the menu");
                                            Thread.Sleep(1400);
                                            break;
                                            }
                                        
                                        case 2:
                                            Console.Clear();
                                            string FlightNumAnswer = Menu.GetString("Enter a flight number to look for: ").Trim();
                                            while(!Account.IsNotNull(FlightNumAnswer) || !Account.IsAllDigits(FlightNumAnswer))
                                            { 
                                                Console.WriteLine("cant be null!, and needs to be a number!");
                                                FlightNumAnswer = Menu.GetString("Enter a flight number to look for: ").Trim();
                                                Console.Clear();
                                            }
                                            Console.Clear();
                                            bool FlightChangeState = true;
                                            while (FlightChangeState)
                                            {
                                                Flight flight = flights.FirstOrDefault(flight => flight.FlightNumber.ToString().Contains(FlightNumAnswer));
                    
                                                if (flight != null)
                                                {
                                                    int ChangeFlightIndex = Menu.MenuPanel("Changing Flight", $"Changing flight {flight.FlightNumber}, What do u want to change", ["Destination", "Country", "Location of departure" ,"Departure date (DD-MM-YYYY)", "Departure Time (dd-MM-yyyyTHH:mm:ss)", "Estimated Time of Arrival (dd-MM-yyyyTHH:mm:ss)", "Go back and save changes"]);

                                                    switch(ChangeFlightIndex)
                                                    {
                                                        case 0:
                                                            Console.Clear();
                                                            string newDestination = Menu.GetString("Enter a new destination: ").Trim();
    
                                                            while(!Account.IsAllLetters(newDestination.Trim()) || string.IsNullOrEmpty(newDestination.Trim()))
                                                            {
                                                                Console.WriteLine("Destination can oly include letters, and cannot be null");
                                                                newDestination = Menu.GetString("Enter a new destination: ").Trim();
                                                                Console.Clear();
                                                            }

                                                            flight.Destination = newDestination;
                                                            Console.WriteLine($"set flights destination to {flight.Destination}");
                                                            Thread.Sleep(1400);
                                                            break;

                                                        case 1:
                                                            Console.Clear();
                                                            string newCountry = Menu.GetString("Enter a new country: ").Trim();
    
                                                            while(!Account.IsAllLetters(newCountry.Trim()) || string.IsNullOrEmpty(newCountry.Trim()))
                                                            {
                                                                Console.WriteLine("Country can oly include letters, and cannot be null");
                                                                newCountry = Menu.GetString("Enter a new country: ").Trim();
                                                                Console.Clear();
                                                            }

                                                            flight.Country = newCountry;
                                                            Console.WriteLine($"set flights country to {flight.Country}");
                                                            Thread.Sleep(1400);
                                                            break;

                                                        case 2:
                                                            Console.Clear();
                                                            string newLocationOfDeparture = Menu.GetString("Enter a new location of departure: ").Trim();
    
                                                            while(!Account.IsAllLetters(newLocationOfDeparture.Trim()) || string.IsNullOrEmpty(newLocationOfDeparture.Trim()))
                                                            {
                                                                Console.WriteLine("Location of departure can oly include letters, and cannot be null");
                                                                newLocationOfDeparture = Menu.GetString("Enter a new location of departure: ").Trim();
                                                                Console.Clear();
                                                            }

                                                            flight.DepartingFrom = newLocationOfDeparture;
                                                            Console.WriteLine($"set flights location of departure to {flight.DepartingFrom}");
                                                            Thread.Sleep(1400);
                                                            break;

                                                        case 3:
                                                            Console.Clear();
                                                            string newDepartureDateString = Menu.GetString("Enter a new departure date: ").Trim();
    
                                                            while(!Account.IsDate(newDepartureDateString))
                                                            {
                                                                Console.WriteLine("Invalid input, enter a date (dd-MM-yyyy)");
                                                                newDepartureDateString = Menu.GetString("Enter a new departure date: ").Trim();
                                                                Console.Clear();
                                                            }

                                                            flight.DepartureDate = newDepartureDateString;
                                                            Console.WriteLine($"set flights location of departure to {flight.DepartureDate}");
                                                            Thread.Sleep(1400);
                                                            break;

                                                        case 4:
                                                            Console.Clear();
                                                            string newDepartureTimeString = Menu.GetString("Enter a new departure time: ");
    
                                                            while(!Account.IsTime(newDepartureTimeString))
                                                            {
                                                                Console.WriteLine("Invalid input, enter a time (dd-MM-yyyy HH:mm:ss)");
                                                                newDepartureTimeString = Menu.GetString("Enter a new departure time: ");
                                                                Console.Clear();
                                                            }
                                                            DateTime dateDepartureTime = DateTime.ParseExact(newDepartureTimeString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                                                            flight.DepartureTime = dateDepartureTime;
                                                            Console.WriteLine($"set flights departure time to {flight.DepartureTime}");
                                                            Thread.Sleep(1400);
                                                            break;

                                                        case 5:
                                                            Console.Clear();
                                                            string newEstimatedTimeString = Menu.GetString("Enter a new estimated time of arrival: ");
    
                                                            while(!Account.IsTime(newEstimatedTimeString))
                                                            {
                                                                Console.WriteLine("Invalid input, enter a time (dd-MM-yyyy HH:mm:ss)");
                                                                newEstimatedTimeString = Menu.GetString("Enter a new estimated time of arrival: ");
                                                                Console.Clear();
                                                            }
                                                            DateTime dateETATime = DateTime.ParseExact(newEstimatedTimeString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                                                            flight.EstimatedTimeofArrival = dateETATime;
                                                            Console.WriteLine($"set flights estimated time of arrival to {flight.EstimatedTimeofArrival}");
                                                            Thread.Sleep(1400);
                                                            break;

                                                        case 6:
                                                            Console.Clear();
                                                            Menu.LoadingBar("Saving Changes", TimeSpan.FromSeconds(2));
                                                            FlightChangeState = false;
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Flight {FlightNumAnswer} not found");
                                                    Thread.Sleep(1400);
                                                    break;
                                                }
                                        }
                                        break;

                                        case 3:
                                            Console.Clear();
                                            bool AdminSearchingState = true;
                                            while(AdminSearchingState)
                                            {
                                                int SearchingOptionIndex = Menu.MenuPanel("Searching options", "Choose between these 3 options", ["Destination", "Departure Date", "Airplane Model", "Flight number", "Back to menu"]);
                                                    
                                                    switch(SearchingOptionIndex)
                                                    {
                                                        case 0:
                                                            Console.Clear();
                                                            string DestAnswer = Menu.GetString("Enter a destination to look for: ").Trim();
                                                            Console.Clear();
                                                            Menu.LoadingBar("Looking for result with correct desitnation", TimeSpan.FromSeconds(1));
                                                            Console.Clear();
                                                            Searching.Destination(DestAnswer, flights);
                                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                                            Console.ReadKey();
                                                            break;

                                                        case 1:
                                                            Console.Clear();
                                                            string DateAnswer = Menu.GetString("Enter a departure date to look for: ").Trim();
                                                            Console.Clear();
                                                            Menu.LoadingBar("Looking for result with correct date", TimeSpan.FromSeconds(1));
                                                            Console.Clear();
                                                            Searching.Time(DateAnswer, flights);
                                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                                            Console.ReadKey();
                                                            break;

                                                        case 2:
                                                            Console.Clear();
                                                            string AirplanModelAnswer = Menu.GetString("Enter a airplane model to look for ( Boeing 737 | Airbus 330 | Boeing 787 ): ");
                                                            Console.Clear();
                                                            Menu.LoadingBar("Looking for result with correct airplane model", TimeSpan.FromSeconds(1));
                                                            Console.Clear();
                                                            Searching.Airline(AirplanModelAnswer, flights);
                                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                                            Console.ReadKey();
                                                            break;

                                                        case 3:
                                                            Console.Clear();
                                                            string AirplanNumAnswer = Menu.GetString("Enter a flight number to look for: ");
                                                            Console.Clear();
                                                            Menu.LoadingBar("Looking for result with correct flight number", TimeSpan.FromSeconds(1));
                                                            Console.Clear();
                                                            Searching.FlightNumber(AirplanNumAnswer, flights);
                                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                                            Console.ReadKey();
                                                            break;
                                                        case 4:
                                                            Console.Clear();
                                                            AdminSearchingState = false;
                                                            break;
                                                    }                     
                                            }
                                            break;
                                        
                                        case 4:
                                            Console.Clear();
                                            Menu.LoadingBar("Loading flights", TimeSpan.FromSeconds(1));
                                            Console.Clear();
                                            Flightinfo.DisplayFlights(flights);
                                            Console.WriteLine("Enter a key to go back to the menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;

                                        case 5:
                                            Menu.LoadingBar("Logging out", TimeSpan.FromSeconds(2));
                                            account.logout();
                                            AdminPanelState = false;
                                            break;
                                        
                                        case 6:
                                            Console.WriteLine($"{NORMAL}CLOSING THE APPLICATION{NORMAL}");
                                            Thread.Sleep(1000);
                                            Flight.WriteToJson(flights);
                                            Environment.Exit(1);
                                            break;
                                    }
                                }
                            }
                            else if(account.IsLoggedIn)
                            {
                                bool UserPanelState = true;
                                while(UserPanelState)
                                {
                                    int UserPanelIndex = Menu.MenuPanel("User Menu","Here u can", ["Search for a flight", "Make a reservation","Change reservation", "Display all flights", "See reservations", "logout", "Quit Program"]);

                                    switch(UserPanelIndex)
                                    {
                                        case 0:
                                            Console.Clear();
                                            bool UserSearchingState = true;
                                            while(UserSearchingState)
                                            {
                                                int SearchingOptionIndex = Menu.MenuPanel("Searching options", "Choose between these 3 options", ["Destination", "Departure Date", "Airplane Model", "Flight number", "Back to menu"]);
                                                    
                                                    switch(SearchingOptionIndex)
                                                    {
                                                        case 0:
                                                            Console.Clear();
                                                            string DestAnswer = Menu.GetString("Enter a destination to look for: ").Trim();
                                                            Console.Clear();
                                                            Menu.LoadingBar("Looking for result with correct desitnation", TimeSpan.FromSeconds(1));
                                                            Console.Clear();
                                                            Searching.Destination(DestAnswer, flights);
                                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                                            Console.ReadKey();
                                                            break;

                                                        case 1:
                                                            Console.Clear();
                                                            string DateAnswer = Menu.GetString("Enter a departure date to look for: ").Trim();
                                                            Console.Clear();
                                                            Menu.LoadingBar("Looking for result with correct date", TimeSpan.FromSeconds(1));
                                                            Console.Clear();
                                                            Searching.Time(DateAnswer, flights);
                                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                                            Console.ReadKey();
                                                            break;

                                                        case 2:
                                                            Console.Clear();
                                                            string AirplanModelAnswer = Menu.GetString("Enter a airplane model to look for ( Boeing 737 | Airbus 330 | Boeing 787 ): ");
                                                            Console.Clear();
                                                            Menu.LoadingBar("Looking for result with correct airplane model", TimeSpan.FromSeconds(1));
                                                            Console.Clear();
                                                            Searching.Airline(AirplanModelAnswer, flights);
                                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                                            Console.ReadKey();
                                                            break;

                                                        case 3:
                                                            Console.Clear();
                                                            string AirplanNumAnswer = Menu.GetString("Enter a flight number to look for: ");
                                                            Console.Clear();
                                                            Menu.LoadingBar("Looking for result with correct flight number", TimeSpan.FromSeconds(1));
                                                            Console.Clear();
                                                            Searching.FlightNumber(AirplanNumAnswer, flights);
                                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                                            Console.ReadKey();
                                                            break;
                                                        case 4:
                                                            Console.Clear();
                                                            UserSearchingState = false;
                                                            break;
                                                    }                     
                                            }
                                            break;

                                        case 1:
                                            Console.WriteLine("Make a reservation");
                                            Console.ReadKey();
                                            break;

                                        case 2:
                                            Console.WriteLine("Change reservation");
                                            Console.ReadKey();
                                            break;

                                        case 3:
                                            Console.Clear();
                                            Menu.LoadingBar("Loading flights", TimeSpan.FromSeconds(1));
                                            Console.Clear();
                                            Flightinfo.DisplayFlights(flights);
                                            Console.WriteLine("Enter a key to go back to the menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        
                                        case 4:
                                            Console.Clear();
                                            Menu.LoadingBar("Loading Reservations", TimeSpan.FromSeconds(1));
                                            Flightinfo.DisplayReservations(account.AccountReservations);
                                            Console.WriteLine("Enter a key to go back to the menu");
                                            Console.ReadKey();
                                            break;

                                        
                                        case 5:
                                            Menu.LoadingBar("Logging out", TimeSpan.FromSeconds(2));
                                            account.logout();
                                            UserPanelState = false;
                                            break;

                                        case 6:
                                            Console.WriteLine($"{NORMAL}CLOSING THE APPLICATION{NORMAL}");
                                            Thread.Sleep(1000);
                                            Flight.WriteToJson(flights);
                                            Environment.Exit(1);
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Account doesnt exist\nReturning to login screen");
                                Thread.Sleep(1400);
                            }
                            

                            
                            break;
                        case 1:
                            string newUserEmail = Menu.GetString("ENTER A NEW EMAIL: ");

                            while(!Account.IsValidEmail(newUserEmail))
                            {
                                Console.WriteLine("Invalid email, Try again");
                                newUserEmail = Menu.GetString("ENTER A NEW EMAIL: ");
                                Console.Clear();
                            }
                            string newUserPassword = Menu.GetString("ENTER A PASSWORD: ");
                            
                            while(!Account.IsNotNull(newUserPassword))
                            {
                                Console.WriteLine("Password cant be empty!");
                                newUserPassword = Menu.GetString("ENTER A PASSWORD: ");
                                Console.Clear();
                            }

                            Console.Clear();
                            account.Addtodb(newUserEmail, newUserPassword);
                            Menu.LoadingBar("Adding account to database", TimeSpan.FromSeconds(2));
                            break;
                        
                        case 2:
                            Console.Clear();
                            bool GuestSearchingState = true;
                            while(GuestSearchingState)
                            {
                                int SearchingOptionIndex = Menu.MenuPanel("Searching options", "Choose between these 3 options", ["Destination", "Departure Date", "Airplane Model", "Flight number", "Back to admin panel"]);
                                    
                                    switch(SearchingOptionIndex)
                                    {
                                        case 0:
                                            Console.Clear();
                                            string DestAnswer = Menu.GetString("Enter a destination to look for: ").Trim();
                                            Console.Clear();
                                            Menu.LoadingBar("Looking for result with correct desitnation", TimeSpan.FromSeconds(1));
                                            Console.Clear();
                                            Searching.Destination(DestAnswer, flights);
                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                            Console.ReadKey();
                                            break;

                                        case 1:
                                            Console.Clear();
                                            string DateAnswer = Menu.GetString("Enter a departure date to look for: ").Trim();
                                            Console.Clear();
                                            Menu.LoadingBar("Looking for result with correct date", TimeSpan.FromSeconds(1));
                                            Console.Clear();
                                            Searching.Time(DateAnswer, flights);
                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                            Console.ReadKey();
                                            break;

                                        case 2:
                                            Console.Clear();
                                            string AirplanModelAnswer = Menu.GetString("Enter a airplane model to look for ( Boeing 737 | Airbus 330 | Boeing 787 ): ");
                                            Console.Clear();
                                            Menu.LoadingBar("Looking for result with correct airplane model", TimeSpan.FromSeconds(1));
                                            Console.Clear();
                                            Searching.Airline(AirplanModelAnswer, flights);
                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                            Console.ReadKey();
                                            break;

                                        case 3:
                                            Console.Clear();
                                            string AirplanNumAnswer = Menu.GetString("Enter a flight number to look for: ");
                                            Console.Clear();
                                            Menu.LoadingBar("Looking for result with correct flight number", TimeSpan.FromSeconds(1));
                                            Console.Clear();
                                            Searching.FlightNumber(AirplanNumAnswer, flights);
                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                            Console.ReadKey();
                                            break;
                                        case 4:
                                            Console.Clear();
                                            GuestSearchingState = false;
                                            break;
                                    }                     
                            }
                            break;
                            
                        case 3:
                            Console.Clear();
                            Menu.LoadingBar("Loading flights", TimeSpan.FromSeconds(1));
                            Console.Clear();
                            Flightinfo.DisplayFlights(flights);
                            Console.WriteLine("Enter a key to go back to the menu");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 4:
                            Console.WriteLine($"{NORMAL}CLOSING THE APPLICATION{NORMAL}");
                            Thread.Sleep(1000);
                            Flight.WriteToJson(flights);
                            Environment.Exit(1);
                            break;
                    }
                    
        }
            
    }
}