using System;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Globalization;

public class Admin : User
{


    public Admin(int primkey) : base(primkey) { }

    // Add any additional Admin-specific properties or methods here
    public override User IsMenu(ref User currentUser, List<Flight> flights, List<Reservation> reservations)
    {
        while (true)
        {
            int AdminPanelIndex = Menu.MenuPanel(("Admin panel", "Here u can control all the reservations and flights"), ["Add a flight manually", "Add flights with file", "Remove a flight", "Change a flight", "Search a flight", "Filter for flights", "Show all flights", "Log out", "See all reservations", "Remove a reservation", "Quit Program"]);

            switch(AdminPanelIndex)
            {
                case 0:
                    Console.Clear();
                    bool InMenu = true;
                    int AirplaneSelectorIndex = Menu.MenuPanel(("Airplane Model Selector", "What plane model should be used for the flight"), ["Boeing 737", "Boeing 787", "Airbus 330", "Head back to menu"]);
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

                        case 3:
                            InMenu = false;
                            plane = new Plane("Boeing 737");
                            break;
                        
                        default:
                            plane = new Plane("Boeing 737");
                            break;
                    }

                    if (!InMenu)
                    {
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
                    }
                    
                    Console.Clear();
                    string AddDestination = Menu.GetString("Enter a destination for the flight (or q to exit): ").Trim();
                    while(!Validator.IsAllLetters(AddDestination.Trim()) || string.IsNullOrEmpty(AddDestination.Trim()))
                    {
                        Console.WriteLine("Destination can oly include letters, and cannot be null");
                        AddDestination = Menu.GetString("Enter a destination for the flight (or q to exit): ").Trim();
                        Console.Clear();
                    }
                    Console.Clear();
                    if(AddDestination == "q")
                    {
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
                    }

                    string AddCountry = Menu.GetString("Enter a country for the flight (or q to exit): ").Trim();
                    while(!Validator.IsAllLetters(AddCountry.Trim()) || string.IsNullOrEmpty(AddCountry.Trim()))
                    {
                        Console.WriteLine("Country can oly include letters, and cannot be null");
                        AddCountry = Menu.GetString("Enter a country for the flight (or q to exit): ").Trim();
                        Console.Clear();
                    }
                    Console.Clear();
                    if(AddCountry == "q")
                    {
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;    
                    }

                    string AddLocationOfDeparture = Menu.GetString("Enter a location of departure for the flight (or q to exit): ").Trim();
                    while(!Validator.IsAllLetters(AddLocationOfDeparture.Trim()) || string.IsNullOrEmpty(AddLocationOfDeparture.Trim()))
                    {
                        Console.WriteLine("Location of departure can oly include letters, and cannot be null");
                        AddLocationOfDeparture = Menu.GetString("Enter a location of departure for the flight (or q to exit): ").Trim();
                        Console.Clear();
                    }
                    Console.Clear();
                    if(AddLocationOfDeparture == "q")
                    {
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
                    }

                    string AddDepartureDateString = Menu.GetString("Enter a departure date for the flight (or q to exit): ").Trim();
                    if(AddDepartureDateString == "q")
                    {
                        Console.Clear();
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
                    }
                    while(!Validator.IsDate(AddDepartureDateString))
                    {
                        if(AddDepartureDateString == "q")
                        {
                            break;
                        }
                        Console.WriteLine("Invalid input, enter a date (dd-MM-yyyy)");
                        AddDepartureDateString = Menu.GetString("Enter a departure date for the flight (or q to exit): ").Trim();
                        Console.Clear();
                    }
                    Console.Clear();
                    if(AddDepartureDateString == "q")
                    {
                        Console.Clear();
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
                    }

                    string AddnewDepartureTimeString = Menu.GetString("Enter a new departure time (dd-MM-yyyy HH:mm:ss) (or q to exit): ");
                    if(AddnewDepartureTimeString == "q")
                    {
                        Console.Clear();
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
                    }

                    while(!Validator.IsTime(AddnewDepartureTimeString))
                    {
                        if(AddnewDepartureTimeString == "q")
                        {
                            break;
                        }
                        Console.WriteLine("Invalid input, enter a time (dd-MM-yyyy HH:mm:ss)");
                        AddnewDepartureTimeString = Menu.GetString("Enter a new departure time (or q to exit): ");
                        Console.Clear();
                    }
                    if(AddnewDepartureTimeString == "q")
                    {
                        Console.Clear();
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
                    }
                    DateTime AdddateDepartureTime = DateTime.ParseExact(AddnewDepartureTimeString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    Console.Clear();

                    string AddEstimatedTimeString = Menu.GetString("Enter a new estimated time of arrival (dd-MM-yyyy HH:mm:ss) (or q to exit): ");
                    if(AddEstimatedTimeString == "q")
                    {
                        Console.Clear();
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
                    }
                    while(!Validator.IsTime(AddEstimatedTimeString) || AddEstimatedTimeString == "q")
                    {
                        if(AddEstimatedTimeString == "q")
                        {
                            break;
                        }
                        Console.WriteLine("Invalid input, enter a time (dd-MM-yyyy HH:mm:ss)");
                        AddEstimatedTimeString = Menu.GetString("Enter a new estimated time of arrival (or q to exit): ");
                        Console.Clear();
                    }
                    if(AddEstimatedTimeString == "q")
                    {
                        Console.Clear();
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
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
                    int FileIndex = Menu.MenuPanel(("File Selector", "What file would you want to be read?"), [".csv", ".txt"]);
                    Console.Clear();
                    bool Error = false;
                    string Errorcode = "";
                    List<string> Errors = new List<string>();
                    int piece = 0;

                    switch (FileIndex)
                    {
                        case 0:
                            DateTime Departuretime = DateTime.Now;
                            DateTime ETA = DateTime.Now;
                            string filename = Menu.GetString("Name of the file: ");
                            string File_Path = $"Flight_Files/CSV/{filename}.csv";

                            foreach (string line in File.ReadLines(File_Path))
                            {
                                piece++;
                                string[] Flight = line.Split(",");
                                string destination = Flight[2];
                                string country = Flight[3];
                                string departingfrom = Flight[1];
                                string departuredate = Flight[5].Split(" ")[0];
                                string departuretime = Flight[5];
                                string eta = Flight[6];
                                plane = new Plane(Flight[4]);

                                if (!(Flight[4] == "Airbus 330" || Flight[4] == "Boeing 787" || Flight[4] == "Boeing 737"))
                                {
                                    Error = true;
                                        Errorcode = "PlaneType";
                                        Errors.Add(Errorcode + " " + piece);
                                }

                                if (departuredate.Split("-").Length == 3)
                                {
                                    string[] date = departuredate.Split("-");
                                    int D = Int32.Parse(date[0]);
                                    int M = Int32.Parse(date[1]);
                                    int Y = Int32.Parse(date[2]);
                                    if(!(D >= 1 && D <= 31 && M >= 1 && M <= 12 && Y >= 2024))
                                    {
                                        Error = true;
                                        Errorcode = "DateType";
                                        Errors.Add(Errorcode + " " + piece);
                                    }
                                }
                                else
                                {
                                    Error = true;
                                    Errorcode = "DateType";
                                    Errors.Add(Errorcode + " " + piece);
                                }

                                try
                                {
                                    Departuretime = DateTime.ParseExact(departuretime, "dd-MM-yyyy HH:mm:ss", null);
                                    ETA = DateTime.ParseExact(eta, "dd-MM-yyyy HH:mm:ss", null);
                                }
                                catch (FormatException)
                                {
                                    Error = true;
                                    Errorcode = "DateTimeType";
                                    Errors.Add(Errorcode + " " + piece);
                                }
                                
                                if(!Error)
                                {
                                    Flight newFlight = new(destination, country, plane, departingfrom, departuredate, "00-00-0000T00:00:00", "00-00-0000T00:00:00");
                                    newFlight.DepartureTime = Departuretime;
                                    newFlight.EstimatedTimeofArrival = ETA;
                                    flights.Add(newFlight);
                                }
                            }

                            if (Error)
                            {
                                Console.Clear();
                                foreach (var fault in Errors)
                                {
                                    string[] fault1 = fault.Split(" ");
                                    Console.WriteLine(fault.Split(" ")[0], fault.Split(" ")[1]);
                                    Console.WriteLine("+-----------------------------------------------+");
                                    Console.WriteLine($"An error occurred using file: {filename}\nOn line: {fault1[1]}\nCould not use type: {fault1[0]}");
                                }
                                Console.Write("+-----------------------------------------------+");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Flights have been succesfully added.");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
                            break;
                    }
                    break;

                case 2:
                    Console.Clear();
                    string FlightNumAnswerDel = Menu.GetString("Enter a flight number to delete: ").Trim();
                    while(!Validator.IsNotNull(FlightNumAnswerDel) || !Validator.IsAllDigits(FlightNumAnswerDel))
                    {
                        if(FlightNumAnswerDel == "q")
                        {
                            break;
                        }
                        Console.WriteLine("cant be null!, and needs to be a number!");
                        FlightNumAnswerDel = Menu.GetString("Enter a flight number to delete: ").Trim();
                        Console.Clear();
                    }
                    if(FlightNumAnswerDel == "q")
                    {
                        Console.Clear();
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
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
                
                case 3:
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
                            int ChangeFlightIndex = Menu.MenuPanel(("Changing Flight", $"Changing flight {flight.FlightNumber}, What do u want to change"), ["Destination", "Country", "Location of departure" ,"Departure date (DD-MM-YYYY)", "Departure Time (dd-MM-yyyyTHH:mm:ss)", "Estimated Time of Arrival (dd-MM-yyyyTHH:mm:ss)", "Go back and save changes"]);

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

                case 4:
                    Console.Clear();
                    bool AdminSearchingState = true;
                    while(AdminSearchingState)
                    {
                        int SearchingOptionIndex = Menu.MenuPanel(("Searching options", "Choose between these 3 options"), ["Destination", "Departure Date", "Airplane Model", "Flight number", "Back to menu"]);
                            
                            switch(SearchingOptionIndex)
                            {
                                case 0:
                                    Console.Clear();
                                    string DestAnswer = Menu.GetString("Enter a destination to look for: ").Trim();
                                    Console.Clear();
                                    Menu.LoadingBar("Looking for result with correct destination", TimeSpan.FromSeconds(1));
                                    Console.Clear();
                                    List<string> destResult = Searching.Destination(DestAnswer, flights);
                                    if (destResult.Count > 0)
                                    {
                                        Console.WriteLine($"Found {destResult.Count} flights to {DestAnswer}:\n");
                                        foreach (var flight in destResult)
                                        {
                                            Console.WriteLine(flight);
                                            Console.WriteLine("");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"No flights found with destination {DestAnswer}");
                                    }
                                    Console.WriteLine("Enter a key to go back to the searching menu");
                                    Console.ReadKey();
                                    break;

                                case 1:
                                    Console.Clear();
                                    string DateAnswer = Menu.GetString("Enter a departure date to look for: ").Trim();
                                    Console.Clear();
                                    Menu.LoadingBar("Looking for result with correct date", TimeSpan.FromSeconds(1));
                                    Console.Clear();
                                    List<string> timeResult = Searching.Time(DateAnswer, flights);
                                    if (timeResult.Count > 0)
                                    {
                                        Console.WriteLine($"Found {timeResult.Count} flights departing on: {DateAnswer}:\n");
                                        foreach (var flight in timeResult)
                                        {
                                            Console.WriteLine(flight);
                                            Console.WriteLine("");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"No flights found departing on {DateAnswer}");
                                    }
                                    Console.WriteLine("Enter a key to go back to the searching menu");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.Clear();
                                    string AirplanModelAnswer = Menu.GetString("Enter a airplane model to look for ( Boeing 737 | Airbus 330 | Boeing 787 ): ");
                                    Console.Clear();
                                    Menu.LoadingBar("Looking for result with correct airplane model", TimeSpan.FromSeconds(1));
                                    Console.Clear();
                                    List<string> airResult = Searching.Airline(AirplanModelAnswer, flights);
                                    if (airResult.Count > 0)
                                    {
                                        Console.WriteLine($"Found {airResult.Count} flights with Airplane: {AirplanModelAnswer}:\n");
                                        foreach (var flight in airResult)
                                        {
                                            Console.WriteLine(flight);
                                            Console.WriteLine("");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"No flights found with airplane model {AirplanModelAnswer}");
                                    }
                                    Console.WriteLine("Enter a key to go back to the searching menu");
                                    Console.ReadKey();
                                    break;

                                case 3:
                                    Console.Clear();
                                    string AirplanNumAnswer = Menu.GetString("Enter a flight number to look for: ");
                                    Console.Clear();
                                    Menu.LoadingBar("Looking for result with correct flight number", TimeSpan.FromSeconds(1));
                                    Console.Clear();
                                    List<string> numResult = Searching.FlightNumber(AirplanNumAnswer, flights);
                                    if (numResult.Count > 0)
                                    {
                                        Console.WriteLine($"Found {numResult.Count} flights to {AirplanNumAnswer}:\n");
                                        foreach (var flight in numResult)
                                        {
                                            Console.WriteLine(flight);
                                            Console.WriteLine("");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"No flights found with flightnumber {AirplanNumAnswer}");
                                    }
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
                
                case 5:
                    Console.Clear();
                    bool AdminFilteringState = true;
                    while(AdminFilteringState)
                    {
                        int SearchingOptionIndex = Menu.MenuPanel(("Filtering options", "Choose between these 2 options"), ["Proceed to filtering", "Back to menu"]);
                            
                            switch(SearchingOptionIndex)
                            {
                                case 0:
                                    Console.Clear();
                                    Console.WriteLine("Fill in all the filters you want to filter for (leave blank if not):");
                                    string destination01 = Menu.GetString("Departing from: ");
                                    string destination02 = Menu.GetString("Arriving at: ").ToLower();
                                    Console.WriteLine("Filtering between 2 dates for the departure date");
                                    Thread.Sleep(1);
                                    string input01 = Menu.GetString("First departure date (DD-MM-YYYY): ");
                                    string input02 = Menu.GetString("Second date: ");
                                    string planeAnswer01 = Menu.GetString("Airplane 1 (Airbus 330, Boeing 787, Boeing 737): ");
                                    string planeAnswer02 = Menu.GetString("Airplane 2 (Airbus 330, Boeing 787, Boeing 737): ");
                                    string planeAnswer03 = Menu.GetString("Airplane 3 (Airbus 330, Boeing 787, Boeing 737): ");
                                    string maxPrice = Menu.GetString("Maximum price of ticket: ");
                                    Console.Clear();
                                    Menu.LoadingBar("Looking for result with filter", TimeSpan.FromSeconds(1));
                                    Console.Clear();
                                    List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, input01, input02, planeAnswer01, planeAnswer02, planeAnswer03, maxPrice, flights);
                                    if (filteredFlights.Count > 0)
                                    {
                                        Console.WriteLine($"Found {filteredFlights.Count} flights:\n");
                                        foreach (var flight in filteredFlights)
                                        {
                                            Console.WriteLine(flight);
                                            Console.WriteLine("");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"No flights found.");
                                    }
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
                
                case 6:
                    Console.Clear();
                    Menu.LoadingBar("Loading flights", TimeSpan.FromSeconds(1));
                    Console.Clear();
                    Flightinfo.DisplayFlights(flights);
                    Console.WriteLine("Enter a key to go back to the menu");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 7:
                    Menu.LoadingBar("Logging out", TimeSpan.FromSeconds(2));
                    currentUser = User.Logout();
                    Console.Clear();
                    return currentUser;

                case 8:
                    Console.Clear();
                    ReservationManager.DisplayReservations(reservations);
                    Console.ReadKey();
                    break;

                case 9:
                    Console.Clear();
                    ReservationManager.DisplayReservations(reservations);
                    string reservationNumberAdmin = Menu.GetString("Enter reservationnumber (or q to exit): ");
                    if(reservationNumberAdmin == "q")
                    {
                        Console.Clear();
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
                    }
                    while (!reservations.Any(reservation => reservation.ReservationNumber.ToString() == reservationNumberAdmin))
                    {
                        if(reservationNumberAdmin == "q")
                        {
                            break;
                        }
                        Console.WriteLine("Incorrect input!");
                        reservationNumberAdmin = Menu.GetString("Enter reservationnumber (or \'q\' to exit ): : ");
                        if (reservationNumberAdmin == "q")
                        {
                            Console.Clear();
                            Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                            break;
                        }
                    }
                    if (reservationNumberAdmin == "q")
                    {
                        Console.Clear();
                        break;
                    }
                    if(reservationNumberAdmin == "q")
                    {
                        Console.Clear();
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
                    }
                    int reservationNumberAdminInt = int.Parse(reservationNumberAdmin);
                    Reservation.RemoveReservation(flights, reservations, reservationNumberAdminInt);
                    Console.Clear();
                    Menu.LoadingBar("Removing reservation", TimeSpan.FromSeconds(2));
                    Console.Clear();
                    break;
                    
                case 10:
                    Menu.LoadingBar("Quitting application", TimeSpan.FromSeconds(2));
                    Flight.WriteToJson(flights);
                    ReservationManager.WriteReservations(reservations);
                    Environment.Exit(1);
                    break;
            }
        }
    }
}