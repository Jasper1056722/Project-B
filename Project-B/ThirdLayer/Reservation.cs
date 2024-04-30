using System.Linq.Expressions;
using System.Xml.Serialization;

public class Reservation
{
    private int _reservationNumber;
    public Flight FlightForReservation;
    private List<int> _takenNumbers = new List<int>();
    public int ReservationNumber { get; set; }
    public List<Person> People = new List<Person>();
    private static Random random = new Random();
    public int AccountKey { get; set; }

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

        while (!isValidInput)
        {
            foreach(Person person in People)
            {
                if (flight.Airplane.Model == "Boeing 737")
                {
                    int selectedOptionIndex = Menu.MenuPanel("Seat Options","Please select your desired seat.",["Economy","Economy Extra Legroom"]);
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
                    int selectedOptionIndex = Menu.MenuPanel("Seat Options","Please select your desired seat.",["Economy","Economy Extra Legroom", "Business"]);
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
                    int selectedOptionIndex = Menu.MenuPanel("Seat Options","Please select your desired seat.",["Economy","Economy Extra Legroom", "Business"]);
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
            }

            Console.Clear();
            Menu.LoadingBar("Selecting seats for each person", TimeSpan.FromSeconds(4));

            Console.Clear();
            Console.WriteLine("We have recieved your reservation");
            Console.WriteLine("Press any key to return to the menu panel");
    } 
    }

    public void AddContactInfo()
    {
        Console.Clear();
        int count = People.Count + 1;
        Console.WriteLine($"Please enter contact information for person {count}: ");
        Thread.Sleep(2500);

        string firstName;
        do
        {
            firstName = Menu.GetString("First name: ");

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
            if (!emailAddress.Contains("@"))
            {
                Console.WriteLine("Invalid email address. Please enter a valid email address.");
            }
        } while (!emailAddress.Contains("@"));
        
        Person person = new Person
        {
            FirstName = firstName,
            LastName = lastName,
            BirthDate = birthDate,
            PhoneNumber = phoneNumber,
            EmailAddress = emailAddress
        };
        People.Add(person);
        Console.Clear();
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
        Flightinfo.DisplayFlights(flights);

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
        List<string> ChosenSeat = new List<string>();

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
                Console.WriteLine("Select a seat ID");
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
                                ChosenSeat.Add(seat.ID);
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

        int SearchingOptionIndex = Menu.MenuPanel("Confirmation", "Enter yes if you are happy with your chosen seats", ["Yes","No"], Flightinfo.GetPlane(FlightForReservation.Airplane.Model, TSeats));
        switch (SearchingOptionIndex)
        {
            case 0:
                Console.Clear();
                Console.WriteLine("We have recieved your reservation");
                Console.WriteLine("Press any key to return to the menu panel");
                break;
            
            case 1:
                foreach (string seat in ChosenSeat)
                {
                    foreach (Seat tseat in FlightForReservation.Airplane.Seats)
                        {
                            if (tseat.ID == seat)
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
}