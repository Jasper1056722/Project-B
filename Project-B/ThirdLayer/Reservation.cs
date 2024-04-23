public class Reservation
{
    private int _reservationNumber;
    public Flight FlightForReservation;
    private List<int> _takenNumbers = new List<int>();
    public int ReservationNumber { get; set; }
    public List<Person> People = new List<Person>();
    public int AccountKey { get; set; }
    private static Random random = new Random();

    public Reservation()
    {
        _reservationNumber = random.Next(100000, 999999);

        while (_takenNumbers.Contains(_reservationNumber))
        {
            _reservationNumber = random.Next(100000, 999999);
        }

        ReservationNumber = _reservationNumber;
    }

    public void ReserveRandomSeat(Flight flight)
    {
        string SeatQual = "";
        bool isValidInput = false;

        while (!isValidInput)
        {
            if (flight.Airplane.Model == "Boeing 737")
            {
                Console.WriteLine("What seat quality:\n[1] - Economy\n[2] - Economy Extra Legroom");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    SeatQual = "Economy";
                    isValidInput = true;
                }
                else if (input == "2")
                {
                    SeatQual = "Economy Extra Legroom";
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 or 2.");
                }
            }
            else if (flight.Airplane.Model == "Boeing 787")
            {
                Console.WriteLine("What seat quality:\n[1] - Economy\n[2] - Business\n[3] - Economy Extra Legroom");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    SeatQual = "Economy";
                    isValidInput = true;
                }
                else if (input == "2")
                {
                    SeatQual = "Business";
                    isValidInput = true;
                }
                else if (input == "3")
                {
                    SeatQual = "Economy Extra Legroom";
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
                }
            }
            else if (flight.Airplane.Model == "Airbus 330")
            {
                Console.WriteLine("What seat quality:\n[1] - Economy\n[2] - Economy Extra Legroom\n[3] - Double seats\n[4] - Economy class in front of cabin\n[5] - Club Class");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    SeatQual = "Economy";
                    isValidInput = true;
                }
                else if (input == "2")
                {
                    SeatQual = "Economy Extra Legroom";
                    isValidInput = true;
                }
                else if (input == "3")
                {
                    SeatQual = "Double seats";
                    isValidInput = true;
                }
                else if (input == "4")
                {
                    SeatQual = "Economy class in front of cabin";
                    isValidInput = true;
                }
                else if (input == "5")
                {
                    SeatQual = "Club Class";
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            }
            else
            {
                Console.WriteLine("Invalid airplane model.");
                return;
            }
        }

        // Use SeatQual here for further processing
        Console.WriteLine($"You have selected {SeatQual} seat.");
    }

    public void AddContactInfo()
    {
        int count = People.Count + 1;
        Console.WriteLine($"Please enter contact information for person {count}:");

        string firstName;
        do
        {
            Console.WriteLine("First Name: ");
            firstName = Console.ReadLine();
            if (string.IsNullOrEmpty(firstName) || !firstName.All(char.IsLetter))
            {
                Console.WriteLine("Invalid first name.");
            }
        } while (string.IsNullOrEmpty(firstName) || !firstName.All(char.IsLetter));
    
        string lastName;
        do
        {
            Console.WriteLine("Last Name: ");
            lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName) || !lastName.All(char.IsLetter))
            {
                Console.WriteLine("Invalid last name.");
            }
        } while (string.IsNullOrEmpty(lastName) || !lastName.All(char.IsLetter));

        string birthDate;
        do
        {
            Console.WriteLine("Birth Date (DD-MM-YYYY): ");
            birthDate = Console.ReadLine();
            if (birthDate.Length < 8 || !birthDate.Replace("-", "").All(char.IsDigit))
            {
                Console.WriteLine("Invalid birth date format.");
            }
        } while (birthDate.Length < 8 || !birthDate.Replace("-", "").All(char.IsDigit));

        string phoneNumber;
        do
        {
            Console.WriteLine("Phone Number (7 to 15 digits, optionally starting with '+'): ");
            phoneNumber = Console.ReadLine();
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
            

        string emailAddress;
        do
        {
            Console.WriteLine("Email Address: ");
            emailAddress = Console.ReadLine();
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
    }

    static string GetValidFlightNumber()
    {
        string flightNum = "";

        while (true)
        {
            Console.WriteLine("Select a flight number");
            string input = Console.ReadLine();

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
        Dictionary<string, string> Seats = new Dictionary<string, string>();

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
                    Seats.Add(seat.ID,"X");
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
                    Seats.Add(seat.ID,"X");
                }
            }
            Flightinfo.PrintPlane("Airbus 330", Seats);
        }
        else if(FlightForReservation.Airplane.Model == "Boeing 787")
        {
            
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
    }
}