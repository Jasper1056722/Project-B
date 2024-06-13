public class Customer : User
{
    public Customer(int primkey) : base(primkey) { }

    public List<Reservation> LoadAccountsReservations(List<Reservation> reservations)
    {
    List<Reservation> PrivateRes = new List<Reservation>();
    try
    {
        foreach (Reservation reservation in reservations)
        {
            if(reservation.AccountKey == Primkey)
            {
                PrivateRes.Add(reservation);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while loading reservations: " + ex.Message);
    }
    return PrivateRes;
    }

    public override User IsMenu(ref User currentUser, List<Flight> flights, List<Reservation> reservations)
    {
        List<Reservation> reservationaccountlistflights = LoadAccountsReservations(reservations);
        while(true)
        {
            int UserPanelIndex = Menu.MenuPanel(("User Menu","Here u can make a reservation"), ["Search for a flight", "Filter for flights", "Make a reservation","Display all flights", "See reservations", "Remove reservation", "logout", "Quit Program"]);

            switch(UserPanelIndex)
            {
                case 0:
                    Console.Clear();
                    bool UserSearchingState = true;
                    while(UserSearchingState)
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
                        int SearchingOptionIndex = Menu.MenuPanel(("Filtering options", "Choose between these 2 options"), ["Proceed to filtering", "Back to menu"]);
                            
                            switch(SearchingOptionIndex)
                            {
                                case 0:
                                    Console.Clear();
                                    Console.WriteLine("Fill in all the filters you want to filter for (leave blank if not):");
                                    Console.WriteLine("\n====================================================================");
                                    string destination01 = Menu.GetString("| Departing from: ", "|", 49);
                                    string destination02 = Menu.GetString("| Arriving at: ", "|", 52);
                                    Console.WriteLine("|==================================================================|");
                                    Console.WriteLine("| Filtering between 2 dates for the departure date                 |");
                                    Thread.Sleep(1);
                                    string input01 = Menu.GetString("| First departure date (DD-MM-YYYY): ", "|", 30);
                                    string input02 = Menu.GetString("| Second date: ", "|", 52);
                                    Console.WriteLine("|==================================================================|");
                                    string planeAnswer01 = Menu.GetString("| Airplane 1 (Airbus 330, Boeing 787, Boeing 737): ", "|", 16);
                                    string planeAnswer02 = Menu.GetString("| Airplane 2 (Airbus 330, Boeing 787, Boeing 737): ", "|", 16);
                                    string planeAnswer03 = Menu.GetString("| Airplane 3 (Airbus 330, Boeing 787, Boeing 737): ", "|", 16);
                                    string maxPrice = Menu.GetString("| Maximum price of ticket: ", "|", 40);
                                    Console.WriteLine("====================================================================");
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
                

                case 2:
                    Menu.LoadingBar("Preparing reservation", TimeSpan.FromSeconds(1));
                    Reservation reservation = new Reservation(Primkey);
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

                    List<Flight> flights1 = new List<Flight>();
                    flights1.Add(reservation.FlightForReservation);
                    
                    if (AmountPersons == 1)
                    {
                        if (reservation.AddContactInfo())
                        {
                            bool isValidChoice = false;
                            while (!isValidChoice)
                            {
                                int SearchingOptionIndex = Menu.MenuPanel(("Seat options", "Do you want to select your seat or get it random?"), new[] { "Random seat", "Select seat" }, Flightinfo.ReturnFlights(flights1));
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
                            Mail.GetInfo(reservation);
                            reservationaccountlistflights.Add(reservation);
                            reservations.Add(reservation);
                        }
                        else
                        {
                            Console.WriteLine("Operation canceled.");
                        }
                    }
                    else if (AmountPersons > 1)
                    {
                        bool allContactsAdded = true;
                        for (int i = 0; i < AmountPersons; i++)
                        {
                            if (!reservation.AddContactInfo())
                            {
                                allContactsAdded = false;
                                break;
                            }
                        }

                        if (allContactsAdded)
                        {
                            bool isValidChoice = false;
                            while (!isValidChoice)
                            {
                                int SearchingOptionIndex = Menu.MenuPanel(("Seat options", "Do you want to select your seat or get it random?"), new[] { "Random seat", "Select seat" }, Flightinfo.ReturnFlights(flights1));
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
                            Mail.GetInfo(reservation);
                            reservationaccountlistflights.Add(reservation);
                            reservations.Add(reservation);
                        }
                        else
                        {
                            Console.WriteLine("Operation canceled.");
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
                    Console.Clear();
                    Menu.LoadingBar("Loading Reservations", TimeSpan.FromSeconds(1));

                    ReservationManager.DisplayReservations(reservationaccountlistflights);
                    Console.WriteLine("Enter a key to go back to the menu");
                    Console.ReadKey();
                    break;
                
                case 5:
                    Console.Clear();
                    ReservationManager.DisplayReservations(reservationaccountlistflights);
                    string reservationNumberUser = Menu.GetString("Enter reservation number (or 'q' to go back): ");
                    while (reservationNumberUser != "q" && !reservationaccountlistflights.Any(reservation => reservation.ReservationNumber.ToString() == reservationNumberUser))
                    {
                        Console.WriteLine("Incorrect input!");
                        if(reservationNumberUser == "q")
                        {
                            break;
                        }
                        reservationNumberUser = Menu.GetString("Enter reservation number (or 'q' to go back): ");
                    }
                    if (reservationNumberUser == "q")
                    {
                        Console.Clear();
                        Menu.LoadingBar(" Heading back to menu",TimeSpan.FromSeconds(1));
                        break;
                    }
                    int reservationNumberUserInt = int.Parse(reservationNumberUser);

                    string IsRemoved = Reservation.RemoveReservation(flights, reservations, reservationaccountlistflights, reservationNumberUserInt);
                    Console.Clear();
                    if(IsRemoved == "Not Removed")
                    {
                        Console.WriteLine("Its not possible to cancel a reservation 24 hours or less before the flight, press a key to return to the menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    Menu.LoadingBar("Removing reservation", TimeSpan.FromSeconds(2));
                    Console.Clear();
                    break;

                case 6:
                    Menu.LoadingBar("Logging out", TimeSpan.FromSeconds(2));
                    currentUser = User.Logout();
                    Console.Clear();
                    return currentUser;

                case 7:
                    Menu.LoadingBar("Quitting application", TimeSpan.FromSeconds(2));
                    Flight.WriteToJson(flights);
                    ReservationManager.WriteReservations(reservations);
                    Environment.Exit(1);
                    break;
            }
        }
    }
}