using System.Linq.Expressions;
using System.Xml.Serialization;

public class Reservation
{
    public int _reservationNumber;
    public Flight FlightForReservation;
    private List<int> _takenNumbers = new List<int>();
    public int ReservationNumber { get; set; }
    public List<Person> People = new List<Person>();
    private static Random random = new Random();
    public int AccountKey { get; set; }

    string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
    string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
    string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m"; 


    public Reservation(int accountKey)
    {
        _reservationNumber = random.Next(100000, 999999);

        while (_takenNumbers.Contains(_reservationNumber))
        {
            _reservationNumber = random.Next(100000, 999999);
        }

        ReservationNumber = _reservationNumber;
        FlightForReservation = null;
        AccountKey = accountKey;

    }



    public void ReserveRandomSeat(Flight flight)
    {
        string SeatQual = "";
        bool isValidInput = false;
        List<string> ChosenSeat = new List<string>();

        while (!isValidInput)
        {
            foreach(Person person in People)
            {
                if (flight.Airplane.Model == "Boeing 737")
                {
                    Console.Clear();
                    int selectedOptionIndex = Menu.MenuPanel(("Seat Options",$"Please select your desired seat for {person.FirstName} {person.LastName}."),["Economy","Economy Extra Legroom"]);
                    Console.Clear();
                    switch(selectedOptionIndex)
                    {
                        case 0:
                            SeatQual = "Economy";
                            isValidInput = true;
                            break;
                        case 1:
                            SeatQual = "Economy Extra Legroom";
                            isValidInput = true;
                            break;
                    }
                }
                else if (flight.Airplane.Model == "Boeing 787")
                {
                    Console.Clear();
                    int selectedOptionIndex = Menu.MenuPanel(("Seat Options",$"Please select your desired seat for {person.FirstName} {person.LastName}."),["Economy","Economy Extra Legroom", "Business"]);
                    Console.Clear();
                    switch(selectedOptionIndex)
                    {
                        case 0:
                            SeatQual = "Economy";
                            isValidInput = true;
                            break;
                        case 1:
                            SeatQual = "Economy Extra Legroom";
                            isValidInput = true;
                            break;
                        case 2:
                            SeatQual = "Business";
                            isValidInput = true;
                            break;
                    }
                }
                else if (flight.Airplane.Model == "Airbus 330")
                {
                    Console.Clear();
                    int selectedOptionIndex = Menu.MenuPanel(("Seat Options",$"Please select your desired seat for {person.FirstName} {person.LastName}."),["Economy","Economy Extra Legroom", "Double seats","Economy class in front of cabin", "Club Class"]);
                    Console.Clear();
                    switch(selectedOptionIndex)
                    {
                        case 0:
                            SeatQual = "Economy";
                            isValidInput = true;
                            break;
                        case 1:
                            SeatQual = "Economy Extra Legroom";
                            isValidInput = true;
                            break;
                        case 2:
                            SeatQual = "Double seats";
                            isValidInput = true;
                            break;
                        case 3:
                            SeatQual = "Economy class in front of cabin";
                            isValidInput = true;
                            break;
                        case 4:
                            SeatQual = "Club Class";
                            isValidInput = true;
                            break;
                    }
                }

            // Use SeatQual here for further processing
                Console.WriteLine($"You have selected {SeatQual} seat.");
                List<Seat> seatOptions = new List<Seat>();
                foreach( Seat seat in FlightForReservation.Airplane.Seats)
                {
                    if (seat.Quality == SeatQual && seat.PersonInSeat is null)
                    {
                        seatOptions.Add(seat);
                    }
                }

                Random rnd = new Random();
                Seat seat1 = seatOptions[rnd.Next(seatOptions.Count)];
                seat1.PersonInSeat = person;
                seat1.SeatReservationNumber = ReservationNumber;
                ChosenSeat.Add(seat1.ID);
            }

            Console.Clear();
            Menu.LoadingBar("Selecting seats for each person", TimeSpan.FromSeconds(4));
            Console.Clear();

            List<Flight> flights1 = new List<Flight>();
            flights1.Add(FlightForReservation);
            Console.WriteLine(Flightinfo.ReturnFlights(flights1));

            Dictionary<string, string> TSeats = new Dictionary<string, string>();
            if(FlightForReservation.Airplane.Model == "Boeing 737")
            {
                foreach (string seat in ChosenSeat)
                {
                    TSeats.Add(seat, $"{CYAN}O{NORMAL}");
                }

                foreach (Seat seat in FlightForReservation.Airplane.Seats)
                {
                    if(TSeats.ContainsKey(seat.ID))
                    {

                    }
                    else if (seat.PersonInSeat is null)
                    {
                        TSeats.Add(seat.ID," ");
                    }
                    else
                    {
                        TSeats.Add(seat.ID,$"{RED}X{NORMAL}");
                    }
                }
                Flightinfo.PrintPlane("Boeing 737", TSeats);
            }
            else if(FlightForReservation.Airplane.Model == "Airbus 330")
            {
                foreach (string seat in ChosenSeat)
                {
                    TSeats.Add(seat, $"{CYAN}O{NORMAL}");
                }

                foreach (Seat seat in FlightForReservation.Airplane.Seats)
                {
                    if(TSeats.ContainsKey(seat.ID))
                    {

                    }
                    else if (seat.PersonInSeat is null)
                    {
                        TSeats.Add(seat.ID," ");
                    }
                    else
                    {
                        TSeats.Add(seat.ID,$"{RED}X{NORMAL}");
                    }
                }
                Flightinfo.PrintPlane("Airbus 330", TSeats);
            }
            else if(FlightForReservation.Airplane.Model == "Boeing 787")
            {
                foreach (string seat in ChosenSeat)
                {
                    TSeats.Add(seat, $"{CYAN}O{NORMAL}");
                }

                foreach (Seat seat in FlightForReservation.Airplane.Seats)
                {
                    if(TSeats.ContainsKey(seat.ID))
                    {

                    }
                    else if (seat.PersonInSeat is null)
                    {
                        TSeats.Add(seat.ID," ");
                    }
                    else
                    {
                        TSeats.Add(seat.ID,$"{RED}X{NORMAL}");
                    }
                }
                Flightinfo.PrintPlane("Boeing 787", TSeats);
            }
            Console.WriteLine("We have recieved your reservation");
            Console.WriteLine("Press any key to return to the menu panel");
            Console.ReadKey();
        } 
    }

    public bool AddContactInfo()
    {
        Console.Clear();
        int count = People.Count + 1;
        Console.WriteLine($"Please enter contact information for person {count} (or 'q' to quit): ");
        Thread.Sleep(2500);

        string firstName;
        do
        {
            firstName = Menu.GetString("First name: ");
            if (firstName.ToLower() == "q")
            {
                Console.Clear();
                Menu.LoadingBar("Heading back to menu", TimeSpan.FromSeconds(3));
                return false;
            } 

            if(!string.IsNullOrEmpty(firstName))
            {
                firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();
            }

            if (string.IsNullOrEmpty(firstName) || !firstName.All(char.IsLetter))
            {
                Console.WriteLine("Invalid first name.");
            }
        } while (string.IsNullOrEmpty(firstName) || !firstName.All(char.IsLetter));

        Console.Clear();
        string lastName;
        do
        {
            lastName = Menu.GetString("Last name: ");
            if (lastName.ToLower() == "q") return false;

            if (!string.IsNullOrEmpty(lastName))
            {
                lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();
            }
            
            if (string.IsNullOrEmpty(lastName) || !lastName.All(char.IsLetter))
            {
                Console.WriteLine("Invalid last name.");
            }
        } while (string.IsNullOrEmpty(lastName) || !lastName.All(char.IsLetter));

        Console.Clear();
        string birthDate;
        do
        {
            birthDate = Menu.GetString("Birth Date (DD-MM-YYYY): ");
            if (birthDate.ToLower() == "q") return false;

            if (!Validator.IsDate(birthDate))
            {
                Console.WriteLine("Invalid birth date format.");
            }
        } while (!Validator.IsDate(birthDate));

        Console.Clear();
        string phoneNumber;
        do
        {
            phoneNumber = Menu.GetString("Phone Number (7 to 15 digits, optionally starting with '+'): ");
            phoneNumber = phoneNumber.TrimStart('+');
            if (phoneNumber.ToLower() == "q") return false;
            
            if (string.IsNullOrEmpty(phoneNumber))
            {
                Console.WriteLine("Phone number cannot be empty.");
            }
            else if (phoneNumber.Length < 7 || phoneNumber.Length > 15 || !phoneNumber.All(char.IsDigit))
            {
                Console.WriteLine("Invalid phone number.");
            }
        } while (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length < 7 || phoneNumber.Length > 15 || !phoneNumber.All(char.IsDigit));
            
        Console.Clear();
        string emailAddress;
        do
        {
            emailAddress = Menu.GetString("Email Address: ");
            if (emailAddress.ToLower() == "q") return false;

            if (!emailAddress.Contains("@"))
            {
                Console.WriteLine("Invalid email address. Please enter a valid email address.");
            }
        } while (!emailAddress.Contains("@"));

        Console.Clear();
        
        FoodPackage SelectedPackage = GetSelectedPackage();
        
        Person person = new Person
        {
            FirstName = firstName,
            LastName = lastName,
            BirthDate = birthDate,
            PhoneNumber = phoneNumber,
            EmailAddress = emailAddress,
            FoodOption = SelectedPackage,

        };
        People.Add(person);
        Console.Clear();
        return true;
    }

    static string GetValidFlightNumber()
    {
        string flightNum = "";

        while (true)
        {
            string input = Menu.GetString("Select a flight number: ");

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Flight number cannot be blank. Please try again.");
                continue;
            }

            if (!int.TryParse(input, out _))
            {
                Console.WriteLine("Invalid input. Please enter a valid flight number (a number).");
                continue;
            }

            flightNum = input;
            break;
        }

        return flightNum;
    }


    public void SelectFlight(List<Flight> flights)
    {
        List<Flight> newflights = new List<Flight>();
        //ask for destination and date before showing all the flights
        Console.Clear();

        bool Bool = true;
        while(Bool)
        { 
            Console.WriteLine("Please assign your desired country of destination");
            string destination = Console.ReadLine();

            foreach (Flight flight in flights)
            {
                if (flight.Country.ToUpper() == destination.ToUpper())
                {
                    newflights.Add(flight);
                }
            }

            if (newflights.Count > 0)
            {
                Bool = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your input was either spelled wrong or the country is not a valid destination");
                Thread.Sleep(1000);
            }
        }

        Flightinfo.DisplayFlights(newflights);

        while(true)
        {
            string FlightNum = GetValidFlightNumber();

            foreach (Flight flight in flights)
            {
                if(FlightNum == flight.FlightNumber.ToString())
                {
                    if(!flight.IsFlightFull())
                    {
                        Console.WriteLine($"Selected flight {flight.FlightNumber} to {flight.Destination}");
                        FlightForReservation = flight;
                        return;
                    }
                }
                
            }
            Console.WriteLine("Not a correct flight number");
            
        }
    }

    public void SelectSeat()
    {
        string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
        string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m"; 

        Dictionary<string, string> Seats = new Dictionary<string, string>();
        List<Seat> ChosenSeat = new List<Seat>();
        int price = 0;

        List<Flight> flights1 = new List<Flight>();
        flights1.Add(FlightForReservation);
        Console.WriteLine(Flightinfo.ReturnFlights(flights1));

        if(FlightForReservation.Airplane.Model == "Boeing 737")
        {
            foreach (Seat seat in FlightForReservation.Airplane.Seats)
            {
                if (seat.PersonInSeat is null)
                {
                    Seats.Add(seat.ID," ");
                }
                else
                {
                    Seats.Add(seat.ID,$"{RED}X{NORMAL}");
                }
            }
            Flightinfo.PrintPlane("Boeing 737", Seats);
        }
        else if(FlightForReservation.Airplane.Model == "Airbus 330")
        {
            foreach (Seat seat in FlightForReservation.Airplane.Seats)
            {
                if (seat.PersonInSeat is null)
                {
                    Seats.Add(seat.ID," ");
                }
                else
                {
                    Seats.Add(seat.ID,$"{RED}X{NORMAL}");
                }
            }
            Flightinfo.PrintPlane("Airbus 330", Seats);
        }
        else if(FlightForReservation.Airplane.Model == "Boeing 787")
        {
            foreach (Seat seat in FlightForReservation.Airplane.Seats)
            {
                if (seat.PersonInSeat is null)
                {
                    Seats.Add(seat.ID," ");
                }
                else
                {
                    Seats.Add(seat.ID,$"{RED}X{NORMAL}");
                }
            }
            Flightinfo.PrintPlane("Boeing 787", Seats);
        }

        foreach(Person person in People)
        {
            Console.WriteLine($"Selecting a seat for {person.FirstName} { person.LastName}");
            string seatID = "";
            bool InLoop = true;

            while (InLoop)
            {
                Console.WriteLine("Select a seat ID (X00)");
                seatID = Console.ReadLine();
                bool seatExists = FlightForReservation.Airplane.Seats.Any(seat => seat.ID == seatID);

                if (seatExists)
                {
                    foreach (Seat seat in FlightForReservation.Airplane.Seats)
                    {
                        if (seat.ID == seatID)
                        {
                            if (seat.PersonInSeat == null)
                            {
                                seat.PersonInSeat = person;
                                seat.SeatReservationNumber = ReservationNumber;
                                Console.WriteLine($"Selected seat {seat.ID} for {person.FirstName} {person.LastName}");
                                ChosenSeat.Add(seat);
                                InLoop = false;
                            }
                            else
                            {
                                Console.WriteLine($"Seat {seat.ID} is already taken. Please select another seat:");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Seat does not exist. Please try again:");
                }
            }
        }
        Menu.LoadingBar("Reserving seats",TimeSpan.FromSeconds(3));
        Console.WriteLine($"These are your chosen seats {CYAN}O{NORMAL}.");
        Dictionary<string, string> TSeats = new Dictionary<string, string>();
        if(FlightForReservation.Airplane.Model == "Boeing 737")
        {
            foreach (Seat seat in ChosenSeat)
            {
                TSeats.Add(seat.ID, $"{CYAN}O{NORMAL}");
            }

            foreach (Seat seat in FlightForReservation.Airplane.Seats)
            {
                if(TSeats.ContainsKey(seat.ID))
                {

                }
                else if (seat.PersonInSeat is null)
                {
                    TSeats.Add(seat.ID," ");
                }
                else
                {
                    TSeats.Add(seat.ID,$"{RED}X{NORMAL}");
                }
            }

            foreach (Seat seat in ChosenSeat)
            {
                if (seat.Quality == "Economy Class")
                {
                    price = price + seat.Price;
                }
                else if(seat.Quality == "Economy extra leg room")
                {
                    price = price + seat.Price;
                }
            }
            Flightinfo.PrintPlane("Boeing 737", TSeats);
        }
        else if(FlightForReservation.Airplane.Model == "Airbus 330")
        {
            foreach (Seat seat in ChosenSeat)
            {
                TSeats.Add(seat.ID, $"{CYAN}O{NORMAL}");
            }

            foreach (Seat seat in FlightForReservation.Airplane.Seats)
            {
                if(TSeats.ContainsKey(seat.ID))
                {

                }
                else if (seat.PersonInSeat is null)
                {
                    TSeats.Add(seat.ID," ");
                }
                else
                {
                    TSeats.Add(seat.ID,$"{RED}X{NORMAL}");
                }
            }

            foreach (Seat seat in ChosenSeat)
            {
                if (seat.Quality == "Economy Class")
                {
                    price = price + seat.Price;
                }
                else if(seat.Quality == "Economy extra leg room")
                {
                    price = price + seat.Price;
                }
                else if(seat.Quality == "Club Class")
                {
                    price = price + seat.Price;
                }
                else if(seat.Quality == "Double seat")
                {
                    price = price + seat.Price;
                }
            }
            Flightinfo.PrintPlane("Airbus 330", TSeats);
        }
        else if(FlightForReservation.Airplane.Model == "Boeing 787")
        {
            foreach (Seat seat in ChosenSeat)
            {
                TSeats.Add(seat.ID, $"{CYAN}O{NORMAL}");
            }

            foreach (Seat seat in FlightForReservation.Airplane.Seats)
            {
                if(TSeats.ContainsKey(seat.ID))
                {

                }
                else if (seat.PersonInSeat is null)
                {
                    TSeats.Add(seat.ID," ");
                }
                else
                {
                    TSeats.Add(seat.ID,$"{RED}X{NORMAL}");
                }
            }

            foreach (Seat seat in ChosenSeat)
            {
                if (seat.Quality == "Economy Class")
                {
                    price = price + seat.Price;
                }
                else if(seat.Quality == "Economy extra leg room")
                {
                    price = price + seat.Price;
                }
                else if(seat.Quality == "Business Class")
                {
                    price = price + seat.Price;
                }
            }
            Flightinfo.PrintPlane("Boeing 787", TSeats);
        }

        Console.Clear();
        int SearchingOptionIndex = Menu.MenuPanel(("Confirmation", "Enter yes if you are happy with your chosen seats"), ["Yes","No"], Flightinfo.ReturnFlights(flights1), Flightinfo.GetPlane(FlightForReservation.Airplane.Model, TSeats));
        Console.Clear();
        switch (SearchingOptionIndex)
        {
            case 0:
                Console.Clear();
                Console.WriteLine("We have recieved your reservation");
                Console.WriteLine($"The Total cost for the seats is: ${price}");
                Console.WriteLine("Press any key to return to the menu panel");
                Console.ReadKey();
                break;
            
            case 1:
                foreach (Seat seat in ChosenSeat)
                {
                    foreach (Seat tseat in FlightForReservation.Airplane.Seats)
                        {
                            if (tseat.ID == seat.ID)
                            {
                                tseat.PersonInSeat = null;
                                tseat.SeatReservationNumber = 0;
                            }
                        }

                }
                SelectSeat();
                break;
        }
    }

    public static string RemoveReservation(List<Flight> flights, List<Reservation> reservations, int reservationnumber)
    {
        foreach (Reservation reservation in reservations)
        {
            if(reservation.ReservationNumber == reservationnumber && DateTime.Now.AddHours(24) <= reservation.FlightForReservation.DepartureTime)
            {
                return "Not Removed";
            }
        }
        foreach (var seat in flights.SelectMany(flight => flight.Airplane.Seats))
        {
            if (seat.SeatReservationNumber == reservationnumber)
            {
                seat.PersonInSeat = null;
                seat.SeatReservationNumber = 0;
            }
        }
        reservations.RemoveAll(reservation => reservation.ReservationNumber == reservationnumber);
        return "Is Removed";
    }

    public static string RemoveReservation(List<Flight> flights, List<Reservation> reservations, List<Reservation> reservationsUser, int reservationnumber)
    {
        foreach (Reservation reservation in reservations)
        {
            if(reservation.ReservationNumber == reservationnumber && DateTime.Now.AddHours(24) >= reservation.FlightForReservation.DepartureTime)
            {
                return "Not Removed";
            }
        }
        foreach (var seat in flights.SelectMany(flight => flight.Airplane.Seats))
        {
            if (seat.SeatReservationNumber == reservationnumber)
            {
                seat.PersonInSeat = null;
                seat.SeatReservationNumber = 0;
            }
        }
        reservations.RemoveAll(reservation => reservation.ReservationNumber == reservationnumber);
        reservationsUser.RemoveAll(reservation => reservation.ReservationNumber == reservationnumber);
        return "Is Removed";
    }

    public FoodPackage GetSelectedPackage()
    {
        FoodPackage package1 = new FoodPackage("Basic Package", 0.00);
        FoodPackage package2 = new FoodPackage("Premium Package", 15.00);
        FoodPackage package3 = new FoodPackage("Deluxe Package", 25.00);
        FoodPackage selectedPackage = package1;
        Console.Clear();
        Console.WriteLine("A free meal package is included in the reservation");
        Console.Write("Would you like to upgrade from Basic Package? \n1. Yes\n2. No ");
        string upgradeChoice = Console.ReadLine();

        if (upgradeChoice == "1")
        {
            Console.Clear();
            Console.WriteLine("Upgrade Options:");
            Console.WriteLine("1. " + package2);
            Console.WriteLine("2. " + package3);
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    selectedPackage = package2;
                    break;
                case 2:
                    selectedPackage = package3;
                    break;
                default:
                    Console.WriteLine("Invalid choice! Keeping Basic Package.");
                    break;
            }
        }
        Console.WriteLine($"You have reserved the following package: {selectedPackage.ToString()}");
        Thread.Sleep(1500);
        return selectedPackage;
    }

}