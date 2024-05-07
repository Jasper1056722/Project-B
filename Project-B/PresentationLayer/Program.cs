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
        List<Reservation> reservations = ReservationManager.LoadReservations();

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
                                    int AdminPanelIndex = Menu.MenuPanel("Admin panel", "Here u can control all the reservations and flights", ["Add a flight", "Remove a flight", "Change a flight", "Search a flight", "Filter for flights", "Show all flights", "Log out", "See all reservations", "Remove a reservation", "Quit Program"]);

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
                                            while(!Validator.IsAllLetters(AddDestination.Trim()) || string.IsNullOrEmpty(AddDestination.Trim()))
                                            {
                                                Console.WriteLine("Destination can oly include letters, and cannot be null");
                                                AddDestination = Menu.GetString("Enter a destination for the flight: ").Trim();
                                                Console.Clear();
                                            }
                                            Console.Clear();

                                            string AddCountry = Menu.GetString("Enter a country for the flight: ").Trim();
                                            while(!Validator.IsAllLetters(AddCountry.Trim()) || string.IsNullOrEmpty(AddCountry.Trim()))
                                            {
                                                Console.WriteLine("Country can oly include letters, and cannot be null");
                                                AddCountry = Menu.GetString("Enter a country for the flight ").Trim();
                                                Console.Clear();
                                            }
                                            Console.Clear();

                                            string AddLocationOfDeparture = Menu.GetString("Enter a location of departure for the flight: ").Trim();
                                            while(!Validator.IsAllLetters(AddLocationOfDeparture.Trim()) || string.IsNullOrEmpty(AddLocationOfDeparture.Trim()))
                                            {
                                                Console.WriteLine("Location of departure can oly include letters, and cannot be null");
                                                AddLocationOfDeparture = Menu.GetString("Enter a location of departure for the flight: ").Trim();
                                                Console.Clear();
                                            }
                                            Console.Clear();

                                            string AddDepartureDateString = Menu.GetString("Enter a departure date for the flight: ").Trim();
                                            while(!Validator.IsDate(AddDepartureDateString))
                                            {
                                                Console.WriteLine("Invalid input, enter a date (dd-MM-yyyy)");
                                                AddDepartureDateString = Menu.GetString("Enter a departure date for the flight: ").Trim();
                                                Console.Clear();
                                            }
                                            Console.Clear();

                                            string AddnewDepartureTimeString = Menu.GetString("Enter a new departure time (dd-MM-yyyy HH:mm:ss): ");
                                            while(!Validator.IsTime(AddnewDepartureTimeString))
                                            {
                                                Console.WriteLine("Invalid input, enter a time (dd-MM-yyyy HH:mm:ss)");
                                                AddnewDepartureTimeString = Menu.GetString("Enter a new departure time: ");
                                                Console.Clear();
                                            }
                                            DateTime AdddateDepartureTime = DateTime.ParseExact(AddnewDepartureTimeString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                            Console.Clear();

                                            string AddEstimatedTimeString = Menu.GetString("Enter a new estimated time of arrival (dd-MM-yyyy HH:mm:ss): ");
                                            while(!Validator.IsTime(AddEstimatedTimeString))
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
                                            while(!Validator.IsNotNull(FlightNumAnswerDel) || !Validator.IsAllDigits(FlightNumAnswerDel))
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
                                            while(!Validator.IsNotNull(FlightNumAnswer) || !Validator.IsAllDigits(FlightNumAnswer))
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
    
                                                            while(!Validator.IsAllLetters(newDestination.Trim()) || string.IsNullOrEmpty(newDestination.Trim()))
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
    
                                                            while(!Validator.IsAllLetters(newCountry.Trim()) || string.IsNullOrEmpty(newCountry.Trim()))
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
    
                                                            while(!Validator.IsAllLetters(newLocationOfDeparture.Trim()) || string.IsNullOrEmpty(newLocationOfDeparture.Trim()))
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
    
                                                            while(!Validator.IsDate(newDepartureDateString))
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
    
                                                            while(!Validator.IsTime(newDepartureTimeString))
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
    
                                                            while(!Validator.IsTime(newEstimatedTimeString))
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
                                            bool AdminFilteringState = true;
                                            while(AdminFilteringState)
                                            {
                                                int SearchingOptionIndex = Menu.MenuPanel("Filtering options", "Choose between these 2 options", ["Proceed to filtering", "Back to menu"]);
                                                    
                                                    switch(SearchingOptionIndex)
                                                    {
                                                        case 0:
                                                            Console.Clear();
                                                            Console.WriteLine("Fill in all the filters you want to filter for (leave blank if not):");
                                                            string destination01 = Menu.GetString("Departing from: ");
                                                            string destination02 = Menu.GetString("Arriving at: ").ToLower();
                                                            string input01 = Menu.GetString("First departure date (DD-MM-YYYY): ");
                                                            string input02 = Menu.GetString("Second date: ");
                                                            string planeAnswer01 = Menu.GetString("Airplane 1 (Airbus 330, Boeing 787, Boeing 737): ");
                                                            string planeAnswer02 = Menu.GetString("Airplane 2 (Airbus 330, Boeing 787, Boeing 737): ");
                                                            string planeAnswer03 = Menu.GetString("Airplane 3 (Airbus 330, Boeing 787, Boeing 737): ");
                                                            string maxPrice = Menu.GetString("Maximum price of ticket: ");
                                                            Console.Clear();
                                                            Menu.LoadingBar("Looking for result with filter", TimeSpan.FromSeconds(1));
                                                            Console.Clear();
                                                            Filtering.filtorSort(destination01, destination02, input01, input02, planeAnswer01, planeAnswer02, planeAnswer03, maxPrice, flights);
                                                            Console.WriteLine("Enter a key to go back to the filtering menu");
                                                            Console.ReadKey();
                                                            break;

                                                        case 1:
                                                            Console.Clear();
                                                            AdminFilteringState = false;
                                                            break;
                                                    }                     
                                            }
                                            break;
                                        
                                        case 5:
                                            Console.Clear();
                                            Menu.LoadingBar("Loading flights", TimeSpan.FromSeconds(1));
                                            Console.Clear();
                                            Flightinfo.DisplayFlights(flights);
                                            Console.WriteLine("Enter a key to go back to the menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;

                                        case 6:
                                            Menu.LoadingBar("Logging out", TimeSpan.FromSeconds(2));
                                            account.logout();
                                            AdminPanelState = false;
                                            break;

                                        case 7:
                                            Console.Clear();
                                            ReservationManager.DisplayReservations(reservations);
                                            Console.ReadKey();
                                            break;

                                        case 8:
                                            Console.Clear();
                                            ReservationManager.DisplayReservations(reservations);
                                            string reservationNumberAdmin = Menu.GetString("Enter reservationnumber: ");
                                            while (!reservations.Any(reservation => reservation.ReservationNumber.ToString() == reservationNumberAdmin))
                                            {
                                                Console.WriteLine("Incorrect input!");
                                                reservationNumberAdmin = Menu.GetString("Enter reservationnumber: ");
                                            }
                                            int reservationNumberAdminInt = int.Parse(reservationNumberAdmin);
                                            Reservation.RemoveReservation(flights, reservations, reservationNumberAdminInt);
                                            Console.Clear();
                                            Menu.LoadingBar("Removing reservation", TimeSpan.FromSeconds(2));
                                            Console.Clear();
                                            break;
                                            
                                        case 9:
                                            Console.WriteLine($"{NORMAL}CLOSING THE APPLICATION{NORMAL}");
                                            Thread.Sleep(1000);
                                            Flight.WriteToJson(flights);
                                            ReservationManager.WriteReservations(reservations);
                                            Environment.Exit(1);
                                            break;
                                    }
                                }
                            }
                            else if(account.IsLoggedIn)
                            {
                                List<Reservation> reservationaccountlistflights = account.LoadAccountsReservations(reservations);
                                bool UserPanelState = true;
                                while(UserPanelState)
                                {
                                    int UserPanelIndex = Menu.MenuPanel("User Menu","Here u can", ["Search for a flight", "Filter for flights", "Make a reservation","Change reservation", "Display all flights", "See reservations", "Remove reservation", "logout", "Quit Program"]);

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
                                            Console.Clear();
                                            bool AdminFilteringState = true;
                                            while(AdminFilteringState)
                                            {
                                                int SearchingOptionIndex = Menu.MenuPanel("Filtering options", "Choose between these 2 options", ["Proceed to filtering", "Back to menu"]);
                                                    
                                                    switch(SearchingOptionIndex)
                                                    {
                                                        case 0:
                                                            Console.Clear();
                                                            Console.WriteLine("Fill in all the filters you want to filter for (leave blank if not):");
                                                            string destination01 = Menu.GetString("Departing from: ");
                                                            string destination02 = Menu.GetString("Arriving at: ");
                                                            string input01 = Menu.GetString("First departure date (DD-MM-YYYY): ");
                                                            string input02 = Menu.GetString("Second date: ");
                                                            string planeAnswer01 = Menu.GetString("Airplane 1 (Airbus 330, Boeing 787, Boeing 737): ");
                                                            string planeAnswer02 = Menu.GetString("Airplane 2 (Airbus 330, Boeing 787, Boeing 737): ");
                                                            string planeAnswer03 = Menu.GetString("Airplane 3 (Airbus 330, Boeing 787, Boeing 737): ");
                                                            string maxPrice = Menu.GetString("Maximum price of ticket: ");
                                                            Console.Clear();
                                                            Menu.LoadingBar("Looking for result with filter", TimeSpan.FromSeconds(1));
                                                            Console.Clear();
                                                            Filtering.filtorSort(destination01, destination02, input01, input02, planeAnswer01, planeAnswer02, planeAnswer03, maxPrice, flights);
                                                            Console.WriteLine("Enter a key to go back to the filtering menu");
                                                            Console.ReadKey();
                                                            break;

                                                        case 1:
                                                            Console.Clear();
                                                            AdminFilteringState = false;
                                                            break;
                                                    }                     
                                            }
                                            break;
                                        

                                        case 2:
                                            Menu.LoadingBar("Preparing reservation", TimeSpan.FromSeconds(1));
                                            Reservation reservation = new Reservation(account.Primkey);
                                            reservation.SelectFlight(flights);
                                            Console.Clear();
                                            string AmountPersonsString = Menu.GetString("How many seats do you want to reserve: ").Trim();

                                            while(!Validator.IsAllDigits(AmountPersonsString) || string.IsNullOrWhiteSpace(AmountPersonsString))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Enter a number!");
                                                AmountPersonsString = Menu.GetString("How many seats do you want to reserve: ").Trim();
                                            }
                                            int AmountPersons = Convert.ToInt32(AmountPersonsString);
                                            
                                            if (AmountPersons == 1)
                                            {
                                                reservation.AddContactInfo();

                                                bool isValidChoice = false;
                                                while (!isValidChoice)
                                                {
                                                    int SearchingOptionIndex = Menu.MenuPanel("Seat options", "Do you want to select your seat or get it random?",["Random seat","Select seat"]);
                                                    switch (SearchingOptionIndex)
                                                    {
                                                        case 0:
                                                            reservation.ReserveRandomSeat(reservation.FlightForReservation);
                                                            isValidChoice = true;
                                                            break;
                                                        case 1:
                                                            reservation.SelectSeat();
                                                            isValidChoice = true;
                                                            break;
                                                    }   
                                                }
                                                reservationaccountlistflights.Add(reservation);
                                                reservations.Add(reservation);
                                            }

                                            else if (AmountPersons > 1)
                                            {
                                                for (int i = 0; i < AmountPersons; i++)
                                                {
                                                    reservation.AddContactInfo();
                                                }
                                                reservation.SelectSeat();
                                                reservationaccountlistflights.Add(reservation);
                                                reservations.Add(reservation);
                                            }
                                            Menu.LoadingBar("Saving reservation", TimeSpan.FromSeconds(1));
                                            break;

                                        case 3:
                                            Console.WriteLine("Change reservation");
                                            ReservationManager.DisplayReservations(reservationaccountlistflights);
                                            Console.WriteLine("What is the flightnumber of the flight you want to change?");
                                            string flightNumber = Console.ReadLine();
                                            Flightinfo.UpdateInfo(flightNumber, flights);
                                            Console.ReadKey();
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
                                            Console.Clear();
                                            Menu.LoadingBar("Loading Reservations", TimeSpan.FromSeconds(1));

                                            ReservationManager.DisplayReservations(reservationaccountlistflights);
                                            Console.WriteLine("Enter a key to go back to the menu");
                                            Console.ReadKey();
                                            break;
                                        
                                        case 6:
                                            Console.Clear();
                                            ReservationManager.DisplayReservations(reservationaccountlistflights);
                                            string reservationNumberUser = Menu.GetString("Enter reservationnumber: ");
                                            while (!reservationaccountlistflights.Any(reservation => reservation.ReservationNumber.ToString() == reservationNumberUser))
                                            {
                                                Console.WriteLine("Incorrect input!");
                                                reservationNumberUser = Menu.GetString("Enter reservationnumber: ");
                                            }
                                            int reservationNumberUserInt = int.Parse(reservationNumberUser);
                                            Reservation.RemoveReservation(flights, reservations, reservationaccountlistflights, reservationNumberUserInt);
                                            Console.Clear();
                                            Menu.LoadingBar("Removing reservation", TimeSpan.FromSeconds(2));
                                            Console.Clear();
                                            break;

                                        case 7:
                                            Menu.LoadingBar("Logging out", TimeSpan.FromSeconds(2));
                                            account.logout();
                                            UserPanelState = false;
                                            break;

                                        case 8:
                                            Console.WriteLine($"{NORMAL}CLOSING THE APPLICATION{NORMAL}");
                                            Thread.Sleep(1000);
                                            Flight.WriteToJson(flights);
                                            ReservationManager.WriteReservations(reservations);
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

                            while(!Validator.IsValidEmail(newUserEmail))
                            {
                                Console.WriteLine("Invalid email, Try again");
                                newUserEmail = Menu.GetString("ENTER A NEW EMAIL: ");
                                Console.Clear();
                            }
                            string newUserPassword = Menu.GetString("ENTER A PASSWORD: ");
                            
                            while(!Validator.IsNotNull(newUserPassword))
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
                            ReservationManager.WriteReservations(reservations);
                            Environment.Exit(1);
                            break;
                    }
                    
        }
            
    }

}