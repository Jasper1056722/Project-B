using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Bcpg;
using static System.Runtime.InteropServices.JavaScript.JSType;
 
 
public static class Flightinfo
{
 
    public static void UpdateInfo(string flightnumber, List<Flight> flights)
    {
        if(string.IsNullOrEmpty(flightnumber))
        {
            Console.WriteLine("Flight Number cant be empty");
            return;
        }
 
        if(!flightnumber.All(char.IsDigit))
        {
            Console.WriteLine("Cant use letters in flight number, only digits");
            return;
        }
 
        foreach (Flight flight in flights)
        {
            int Toflightnumber = int.Parse(flightnumber);
            if (flight.FlightNumber == Toflightnumber)
            {
                Console.WriteLine("Current flight data: ");
                Console.WriteLine($"Destination: {flight.Destination}");
                Console.WriteLine($"Country: {flight.Country}");
                Console.WriteLine($"Airplane: {flight.Airplane.Model}");
                Console.WriteLine($"Departing from: {flight.DepartingFrom}");
                Console.WriteLine($"Date: {flight.DepartureDate}");
                Console.WriteLine($"Departure time: {flight.DepartureTime}");
                Console.WriteLine($"Estimated time of arrival: {flight.EstimatedTimeofArrival}");
                Console.WriteLine($"\nSelect the detail you want to edit: ");
                Console.WriteLine("1. Destination");
                Console.WriteLine("2. Country");
                Console.WriteLine("3. Departing from");
                Console.WriteLine("4. Date");
                Console.WriteLine("5. Departure time");
                Console.WriteLine("6. Estimated time of Arrival");
                Console.WriteLine("7 Dont change anything");
                Console.Write("Enter your choice (1-7): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter new destination: ");
                        string Destination = Console.ReadLine();
                        flight.Destination = Destination;
                        Console.WriteLine($"Destination updated to {flight.Destination}");
                        break;
                    case 2:
                        Console.WriteLine("Enter new country: ");
                        string Country = Console.ReadLine();
                        flight.Country = Country;
                        Console.WriteLine($"Country updated to {flight.Country}");
                        break;
                    case 3:
                        Console.WriteLine("Enter new departing from: ");
                        string DepartingFrom = Console.ReadLine();
                        flight.DepartingFrom = DepartingFrom;
                        Console.WriteLine($"Departing from updated to {flight.DepartingFrom}");
                        break;
                    case 4:
                        Console.WriteLine("Enter new date: ");
                        string Date = Console.ReadLine();
                        flight.DepartureDate = Date;
                        Console.WriteLine($"Date updated to {flight.DepartureDate}");
                        break;
                    case 5:
                        Console.WriteLine("Enter new departure time (dd-MM-yyyy HH:mm:ss): ");
                        string newDepartureTimeString = Console.ReadLine();
                       
                        DateTime newDepartureTime;
                        if (!DateTime.TryParseExact(newDepartureTimeString, "dd-MM-yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out newDepartureTime))
                        {
                            Console.WriteLine("Invalid datetime format. Please enter the departure time in the format dd-MM-yyyy HH:mm:ss.");
                            break;
                        }
 
                        flight.DepartureTime = newDepartureTime;
                        Console.WriteLine($"Departure time updated to {flight.DepartureTime}");
                        break;
                    case 6:
                        Console.WriteLine("Enter new departure time (dd-MM-yyyy HH:mm:ss): ");
                        string EstimatedTimeofArrivalstring = Console.ReadLine();
                       
                        DateTime EstimatedTimeofArrival;
                        if (!DateTime.TryParseExact(EstimatedTimeofArrivalstring, "dd-MM-yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out EstimatedTimeofArrival))
                        {
                            Console.WriteLine("Invalid datetime format. Please enter the estimated arrival time in the format dd-MM-yyyy HH:mm:ss.");
                            break;
                        }
 
                        flight.EstimatedTimeofArrival = EstimatedTimeofArrival;
                        Console.WriteLine($"Estimated time of arrival updated to {flight.EstimatedTimeofArrival}");
                        break;
 
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        return;
                }
                return;
            }
        Console.WriteLine($"{flightnumber} doesn't exist");
    }
    }

    public static void FlightAdd(List<Flight> flights)
    {
        Console.WriteLine("Please enter the Destination");
        string Destination = Console.ReadLine();
        while (string.IsNullOrEmpty(Destination))
        {
            Console.WriteLine("Please enter the Destination");
            Destination = Console.ReadLine();
        }
 
        Console.WriteLine("Please enter the Country");
        string Country = Console.ReadLine();
        while (string.IsNullOrEmpty(Country))
        {
            Console.WriteLine("Please enter the Country");
            Country = Console.ReadLine();
        }
 
        Console.WriteLine("Please enter the Airplane");
        string Airplane = Console.ReadLine();
        while (string.IsNullOrEmpty(Airplane))
        {
            Console.WriteLine("Please enter the Airplane");
            Airplane = Console.ReadLine();
        }
 
        Console.WriteLine("Please enter the location of Departure");
        string DepartingFrom = Console.ReadLine();
        while (string.IsNullOrEmpty(DepartingFrom))
        {
            Console.WriteLine("Please enter the location of Departure");
            DepartingFrom = Console.ReadLine();
        }
 
        Console.WriteLine("Please enter the Departure Date");
        string DepartureDate = Console.ReadLine();
        while (string.IsNullOrEmpty(DepartureDate))
        {
            Console.WriteLine("Please enter the Departure Date");
            DepartureDate = Console.ReadLine();
        }
 
        Console.WriteLine("Please enter the Departure Time (DD-MM-YYYY HH:MM:SS)");
        string DepartureTime = Console.ReadLine();
        while (string.IsNullOrEmpty(DepartureTime))
        {
            Console.WriteLine("Please enter the Departure Time (DD-MM-YYYY HH:MM:SS)");
            DepartureTime = Console.ReadLine();
        }
 
        Console.WriteLine("Please enter the Estimated Time of Arrival (DD-MM-YYYY HH:MM:SS)");
        string ArrivalTime = Console.ReadLine();
        while (string.IsNullOrEmpty(ArrivalTime))
        {
            Console.WriteLine("Please enter the Estimated Time of Arrival (DD-MM-YYYY HH:MM:SS)");
            ArrivalTime = Console.ReadLine();
        }
 
        Plane plane = new Plane("Boeing 787");
        flights.Add(new Flight(Destination, Country, plane, DepartingFrom, DepartureDate, DepartureTime, ArrivalTime));                                                  
    }
 
    public static void FlightDelete(string flightNumber, List<Flight> flights)
    {
        if (string.IsNullOrEmpty(flightNumber))
        {
            Console.WriteLine("Flight number cannot be empty");
            return;
        }
 
        if (!int.TryParse(flightNumber, out int parsedFlightNumber))
        {
            Console.WriteLine("Invalid flight number format. Please enter a valid integer flight number.");
            return;
        }
 
        foreach (Flight flight in flights)  
        {
            if (flight.FlightNumber == parsedFlightNumber)
            {
                flights.Remove(flight);
                Console.WriteLine($"Flight with number {parsedFlightNumber} deleted successfully");
                return;
            }
        }
       
        Console.WriteLine($"Flight with number {parsedFlightNumber} not found");
    }

    public static void DisplayFlights(List<Flight> flights)
    {
        Console.ForegroundColor = ConsoleColor.White;
        StringBuilder flightsString = new StringBuilder();

        // Find the maximum length for each component
        int maxFlightNumberLength = flights.Max(f => f.FlightNumber.ToString().Length);
        int maxDestinationLength = flights.Max(f => f.Destination.Length);
        int maxCountryLength = flights.Max(f => f.Country.Length);
        int maxDepartingFromLength = flights.Max(f => f.DepartingFrom.Length);

        // Calculate the maximum length for DateTime components
        int maxDepartureTimeLength = flights.Max(f => f.DepartureTime.ToString().Length);
        int maxEstimatedTimeLength = flights.Max(f => f.EstimatedTimeofArrival.ToString().Length);

        foreach (Flight flight in flights)
        {
            string flightinfo = $"\u001b[1;37m| Flightnumber: {flight.FlightNumber.ToString().PadRight(maxFlightNumberLength)} | Destination: {flight.Destination.PadRight(maxDestinationLength)} | Country: {flight.Country.PadRight(maxCountryLength)} | DepartingFrom: {flight.DepartingFrom.PadRight(maxDepartingFromLength)} | DepartureTime: {flight.DepartureTime.ToString().PadRight(maxDepartureTimeLength)} | Estimated time of arrival: {flight.EstimatedTimeofArrival.ToString().PadRight(maxEstimatedTimeLength)} |\u001b[0m\n";

            flightsString.Append(flightinfo);
        }


        if (flightsString.Length > 0)
        {
            flightsString.Length--; // Remove the last character (newline)
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\u001b[37m+------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+\u001b[0m");
        Console.WriteLine(flightsString);
        Console.WriteLine("\u001b[37m+------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+\u001b[0m");    
        }

    public static void PrintPlane(string airplane, Dictionary<string, string> Seats)
    {
        string picture = "";

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

        if (airplane is "Boeing 737")
        {
            picture = @$"
                                                                    ______________
                            [ ] = Economy Class                    /              |
                            {BLUE}[ ]{NORMAL} = Economy extra leg room          /               |
                                                                 /                |
                                                                /                 |
                                                               /                  |
                 ___^_________________________________________/__________^___^____\_________________________________________________
         _______/         F    [{Seats["F2"]}][{Seats["F3"]}][{Seats["F4"]}][{Seats["F5"]}][{Seats["F6"]}][{Seats["F7"]}][{Seats["F8"]}][{Seats["F9"]}][{Seats["F10"]}][{Seats["F11"]}][{Seats["F12"]}][{Seats["F13"]}][{Seats["F14"]}][{Seats["F15"]}] {BLUE}[{Seats["F16"]}{BLUE}] [{Seats["F17"]}]{NORMAL}[{Seats["F18"]}][{Seats["F19"]}][{Seats["F20"]}][{Seats["F21"]}][{Seats["F22"]}][{Seats["F23"]}][{Seats["F24"]}][{Seats["F25"]}][{Seats["F26"]}][{Seats["F27"]}][{Seats["F28"]}][{Seats["F29"]}][{Seats["F30"]}][{Seats["F31"]}][{Seats["F32"]}][{Seats["F33"]}] _ \_^_____
      __/                 E    [{Seats["E2"]}][{Seats["E3"]}][{Seats["E4"]}][{Seats["E5"]}][{Seats["E6"]}][{Seats["E7"]}][{Seats["E8"]}][{Seats["E9"]}][{Seats["E10"]}][{Seats["E11"]}][{Seats["E12"]}][{Seats["E13"]}][{Seats["E14"]}][{Seats["E15"]}] {BLUE}[{Seats["E16"]}{BLUE}] [{Seats["E17"]}]{NORMAL}[{Seats["E18"]}][{Seats["E19"]}][{Seats["E20"]}][{Seats["E21"]}][{Seats["E22"]}][{Seats["E23"]}][{Seats["E24"]}][{Seats["E25"]}][{Seats["E26"]}][{Seats["E27"]}][{Seats["E28"]}][{Seats["E29"]}][{Seats["E30"]}][{Seats["E31"]}][{Seats["E32"]}][{Seats["E33"]}]|w|        \
     /   /--              D    [{Seats["D2"]}][{Seats["D3"]}][{Seats["D4"]}][{Seats["D5"]}][{Seats["D6"]}][{Seats["D7"]}][{Seats["D8"]}][{Seats["D9"]}][{Seats["D10"]}][{Seats["D11"]}][{Seats["D12"]}][{Seats["D13"]}][{Seats["D14"]}][{Seats["D15"]}] {BLUE}[{Seats["D16"]}{BLUE}] [{Seats["D17"]}]{NORMAL}[{Seats["D18"]}][{Seats["D19"]}][{Seats["D20"]}][{Seats["D21"]}][{Seats["D22"]}][{Seats["D23"]}][{Seats["D24"]}][{Seats["D25"]}][{Seats["D26"]}][{Seats["D27"]}][{Seats["D28"]}][{Seats["D29"]}][{Seats["D30"]}][{Seats["D31"]}][{Seats["D32"]}][{Seats["D33"]}]|c|         |
    |    |        _          1  2  3  4  5  6  7  8  9 10 11 12 13 14 15  16  17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33  _          |
     \__ \--     |w|      C [{Seats["C1"]}][{Seats["C2"]}][{Seats["C3"]}][{Seats["C4"]}][{Seats["C5"]}][{Seats["C6"]}][{Seats["C7"]}][{Seats["C8"]}][{Seats["C9"]}][{Seats["C10"]}][{Seats["C11"]}][{Seats["C12"]}][{Seats["C13"]}][{Seats["C14"]}][{Seats["C15"]}] {BLUE}[{Seats["C16"]}{BLUE}] [{Seats["C17"]}]{NORMAL}[{Seats["C18"]}][{Seats["C19"]}][{Seats["C20"]}][{Seats["C21"]}][{Seats["C22"]}][{Seats["C23"]}][{Seats["C24"]}][{Seats["C25"]}][{Seats["C26"]}][{Seats["C27"]}][{Seats["C28"]}][{Seats["C29"]}][{Seats["C30"]}][{Seats["C31"]}][{Seats["C32"]}][{Seats["C33"]}]|w|         |
        \_______ |c|      B [{Seats["B1"]}][{Seats["B2"]}][{Seats["B3"]}][{Seats["B4"]}][{Seats["B5"]}][{Seats["B6"]}][{Seats["B7"]}][{Seats["B8"]}][{Seats["B9"]}][{Seats["B10"]}][{Seats["B11"]}][{Seats["B12"]}][{Seats["B13"]}][{Seats["B14"]}][{Seats["B15"]}] {BLUE}[{Seats["B16"]}{BLUE}] [{Seats["B17"]}]{NORMAL}[{Seats["B18"]}][{Seats["B19"]}][{Seats["B20"]}][{Seats["B21"]}][{Seats["B22"]}][{Seats["B23"]}][{Seats["B24"]}][{Seats["B25"]}][{Seats["B26"]}][{Seats["B27"]}][{Seats["B28"]}][{Seats["B29"]}][{Seats["B30"]}][{Seats["B31"]}][{Seats["B32"]}][{Seats["B33"]}]|c| _______/
                \________ A [{Seats["A1"]}][{Seats["A2"]}][{Seats["A3"]}][{Seats["A4"]}][{Seats["A5"]}][{Seats["A6"]}][{Seats["A7"]}][{Seats["A8"]}][{Seats["A9"]}][{Seats["A10"]}][{Seats["A11"]}][{Seats["A12"]}][{Seats["A13"]}][{Seats["A14"]}][{Seats["A15"]}] {BLUE}[{Seats["A16"]}{BLUE}] [{Seats["A17"]}]{NORMAL}[{Seats["A18"]}][{Seats["A19"]}][{Seats["A20"]}][{Seats["A21"]}][{Seats["A22"]}][{Seats["A23"]}][{Seats["A24"]}][{Seats["A25"]}][{Seats["A26"]}][{Seats["A27"]}][{Seats["A28"]}][{Seats["A29"]}][{Seats["A30"]}][{Seats["A31"]}][{Seats["A32"]}][{Seats["A33"]}]___/ !
                    !    \_______________________________________________!___!__________________________________________________/
                                                              \                   /
                            [ ] = empty seats                  \                  |
                            [{RED}X{NORMAL}] = taken seats                   \                 |
                            [{CYAN}O{NORMAL}] = chosen seats                   \                |
                                                                  \               |
                                                                   \              |
";
        }
        else if (airplane is "Airbus 330")
        {
            picture = @$"           
                                                                                     ______________________________
                          [ ] = Economy Class                                       /                              |
                          {BLUE}[ ]{NORMAL}= Economy extra leg room                              /                               |
                          {YELLOW}[ ]{NORMAL} = Club Class                                        /                                |
                          {GREEN}[ ]{NORMAL} = Double seat                                      /                                 |
                    __^_______________________________^_________________________/__________________________________\________^____________________________
              _____/    |K {YELLOW}[{Seats["K1"]}{YELLOW}] [{Seats["K2"]}{YELLOW}]{NORMAL}  [{Seats["K4"]}][{Seats["K5"]}][{Seats["K6"]}][{Seats["K7"]}] |w|	 | K {BLUE}[{Seats["K14"]}]{NORMAL}[{Seats["K15"]}][{Seats["K16"]}][{Seats["K17"]}][{Seats["K18"]}][{Seats["K19"]}][{Seats["K20"]}][{Seats["K21"]}][{Seats["K22"]}][{Seats["K23"]}][{Seats["K24"]}][{Seats["K25"]}][{Seats["K26"]}][{Seats["K27"]}][{Seats["K28"]}][{Seats["K29"]}][{Seats["K30"]}][{Seats["K31"]}][{Seats["K32"]}] |w| |   K {BLUE}[{Seats["K36"]}]{NORMAL}[{Seats["K37"]}][{Seats["K38"]}][{Seats["K39"]}][{Seats["K40"]}][{Seats["K41"]}][{Seats["K42"]}][{Seats["K43"]}]\____________________^_
         ____/|         |J          [{Seats["J4"]}][{Seats["J5"]}][{Seats["J6"]}][{Seats["J7"]}] |c|     | J {BLUE}[{Seats["J14"]}]{NORMAL}[{Seats["J15"]}][{Seats["J16"]}][{Seats["J17"]}][{Seats["J18"]}][{Seats["J19"]}][{Seats["J20"]}][{Seats["J21"]}][{Seats["J22"]}][{Seats["J23"]}][{Seats["J24"]}][{Seats["J25"]}][{Seats["J26"]}][{Seats["J27"]}][{Seats["J28"]}][{Seats["J29"]}][{Seats["J30"]}][{Seats["J31"]}][{Seats["J32"]}] |c| |   J {BLUE}[{Seats["J36"]}]{NORMAL}[{Seats["J37"]}][{Seats["J38"]}][{Seats["J39"]}][{Seats["J40"]}][{Seats["J41"]}][{Seats["J42"]}][{Seats["J43"]}]{GREEN}[{Seats["K44"]}{GREEN}][{Seats["K45"]}{GREEN}][{Seats["K46"]}{GREEN}][{Seats["K47"]}{GREEN}][{Seats["K48"]}{GREEN}][{Seats["K49"]}{GREEN}]{NORMAL}     |
        /     |         |H {YELLOW}[{Seats["H1"]}{YELLOW}] [{Seats["H2"]}{YELLOW}]{NORMAL}  [{Seats["H4"]}][{Seats["H5"]}][{Seats["H6"]}][{Seats["H7"]}]         | H {BLUE}[{Seats["H14"]}]{NORMAL}[{Seats["H15"]}][{Seats["H16"]}][{Seats["H17"]}][{Seats["H18"]}][{Seats["H19"]}][{Seats["H20"]}][{Seats["H21"]}][{Seats["H22"]}][{Seats["H23"]}][{Seats["H24"]}][{Seats["H25"]}][{Seats["H26"]}][{Seats["H27"]}][{Seats["H28"]}][{Seats["H29"]}][{Seats["H30"]}][{Seats["H31"]}][{Seats["H32"]}]     |   H {BLUE}[{Seats["H36"]}]{NORMAL}[{Seats["H37"]}][{Seats["H38"]}][{Seats["H39"]}][{Seats["H40"]}][{Seats["H41"]}][{Seats["H42"]}][{Seats["H43"]}]{GREEN}[{Seats["H44"]}{GREEN}][{Seats["H45"]}{GREEN}][{Seats["H46"]}{GREEN}][{Seats["H47"]}{GREEN}][{Seats["H48"]}{GREEN}][{Seats["H49"]}{GREEN}]{NORMAL}     |
     __/  /   |             1   2    4  5  6  7  8  9 10     14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33   _     36 37 38 39 40 41 42 43 44 45 46 47 48 49 50   |
    /    /    |         |G {YELLOW}[{Seats["G1"]}{YELLOW}] [{Seats["G2"]}{YELLOW}]{NORMAL}     [{Seats["G4"]}][{Seats["G6"]}][{Seats["G7"]}][{Seats["G8"]}][{Seats["G9"]}][{Seats["G10"]}]  G {BLUE}[{Seats["G14"]}{BLUE}]{NORMAL}[{Seats["G15"]}][{Seats["G16"]}][{Seats["G17"]}][{Seats["G18"]}][{Seats["G19"]}][{Seats["G20"]}][{Seats["G21"]}][{Seats["G22"]}][{Seats["G23"]}][{Seats["G24"]}][{Seats["G25"]}][{Seats["G26"]}][{Seats["G27"]}][{Seats["G28"]}][{Seats["G29"]}][{Seats["G30"]}][{Seats["G31"]}][{Seats["G32"]}][{Seats["G33"]}] |c| G {BLUE}[{Seats["G36"]}{BLUE}]{NORMAL}[{Seats["G37"]}][{Seats["G38"]}][{Seats["G39"]}][{Seats["G40"]}][{Seats["G41"]}][{Seats["G42"]}][{Seats["G43"]}][{Seats["G44"]}][{Seats["G45"]}][{Seats["G46"]}][{Seats["G47"]}][{Seats["G48"]}][{Seats["G49"]}][{Seats["G50"]}]|  |
   |	|     |         |F             [{Seats["F4"]}][{Seats["F6"]}][{Seats["F7"]}][{Seats["F8"]}][{Seats["F9"]}][{Seats["F10"]}]  F {BLUE}[{Seats["F14"]}{BLUE}]{NORMAL}[{Seats["F15"]}][{Seats["F16"]}][{Seats["F17"]}][{Seats["F18"]}][{Seats["F19"]}][{Seats["F20"]}][{Seats["F21"]}][{Seats["F22"]}][{Seats["F23"]}][{Seats["F24"]}][{Seats["F25"]}][{Seats["F26"]}][{Seats["F27"]}][{Seats["F28"]}][{Seats["F29"]}][{Seats["F30"]}][{Seats["F31"]}][{Seats["F32"]}][{Seats["F33"]}] |w| F {BLUE}[{Seats["F36"]}{BLUE}]{NORMAL}[{Seats["F37"]}][{Seats["F38"]}][{Seats["F39"]}][{Seats["F40"]}][{Seats["F41"]}][{Seats["F42"]}][{Seats["F43"]}][{Seats["F44"]}][{Seats["F45"]}][{Seats["F46"]}][{Seats["F47"]}][{Seats["F48"]}][{Seats["F49"]}][{Seats["F50"]}]|  |
    \__	 \    |         |D {YELLOW}[{Seats["D1"]}{YELLOW}] [{Seats["D2"]}{YELLOW}]{NORMAL}     [{Seats["D4"]}][{Seats["D6"]}][{Seats["D7"]}][{Seats["D8"]}][{Seats["D9"]}][{Seats["D10"]}]  D {BLUE}[{Seats["D14"]}{BLUE}]{NORMAL}[{Seats["D15"]}][{Seats["D16"]}][{Seats["D17"]}][{Seats["D18"]}][{Seats["D19"]}][{Seats["D20"]}][{Seats["D21"]}][{Seats["D22"]}][{Seats["D23"]}][{Seats["D24"]}][{Seats["D25"]}][{Seats["D26"]}][{Seats["D27"]}][{Seats["D28"]}][{Seats["D29"]}][{Seats["D30"]}][{Seats["D31"]}][{Seats["D32"]}][{Seats["D33"]}] |c| D {BLUE}[{Seats["D36"]}{BLUE}]{NORMAL}[{Seats["D37"]}][{Seats["D38"]}][{Seats["D39"]}][{Seats["D40"]}][{Seats["D41"]}][{Seats["D42"]}][{Seats["D43"]}][{Seats["D44"]}][{Seats["D45"]}][{Seats["D46"]}][{Seats["D47"]}][{Seats["D48"]}][{Seats["D49"]}][{Seats["D50"]}]|  |
       \  \   |	 _                                                                                                                                                              |
        \____ | |w|     |C {YELLOW}[{Seats["C1"]}{YELLOW}] [{Seats["C2"]}{YELLOW}]{NORMAL}  [{Seats["C4"]}][{Seats["C5"]}][{Seats["C6"]}][{Seats["C7"]}]  _      | C {BLUE}[{Seats["C14"]}{BLUE}]{NORMAL}[{Seats["C15"]}][{Seats["C16"]}][{Seats["C17"]}][{Seats["C18"]}][{Seats["C19"]}][{Seats["C20"]}][{Seats["C21"]}][{Seats["C22"]}][{Seats["C23"]}][{Seats["C24"]}][{Seats["C25"]}][{Seats["C26"]}][{Seats["C27"]}][{Seats["C28"]}][{Seats["C29"]}][{Seats["C30"]}][{Seats["C31"]}][{Seats["C32"]}]  _  |   C {BLUE}[{Seats["C36"]}{BLUE}]{NORMAL}[{Seats["C37"]}][{Seats["C38"]}][{Seats["C39"]}][{Seats["C40"]}][{Seats["C41"]}][{Seats["C42"]}][{Seats["C43"]}]{GREEN}[{Seats["C44"]}{GREEN}][{Seats["C45"]}{GREEN}][{Seats["C46"]}{GREEN}][{Seats["C47"]}{GREEN}][{Seats["C48"]}{GREEN}][{Seats["C49"]}{GREEN}]{NORMAL}     |
             \|_|c|     |B          [{Seats["B4"]}][{Seats["B5"]}][{Seats["B6"]}][{Seats["B7"]}] |w|     | B {BLUE}[{Seats["B14"]}]{NORMAL}[{Seats["B15"]}][{Seats["B16"]}][{Seats["B17"]}][{Seats["B18"]}][{Seats["B19"]}][{Seats["B20"]}][{Seats["B21"]}][{Seats["B22"]}][{Seats["B23"]}][{Seats["B24"]}][{Seats["B25"]}][{Seats["B26"]}][{Seats["B27"]}][{Seats["B28"]}][{Seats["B29"]}][{Seats["B30"]}][{Seats["B31"]}][{Seats["B32"]}] |w| |   B {BLUE}[{Seats["B36"]}{BLUE}]{NORMAL}[{Seats["B37"]}][{Seats["B38"]}][{Seats["B39"]}][{Seats["B40"]}][{Seats["B41"]}][{Seats["B42"]}][{Seats["B43"]}]{GREEN}[{Seats["A44"]}{GREEN}][{Seats["A45"]}{GREEN}][{Seats["A46"]}{GREEN}][{Seats["A47"]}{GREEN}][{Seats["A48"]}{GREEN}][{Seats["A49"]}{GREEN}]{NORMAL}     |
                  \___!_|A {YELLOW}[{Seats["A1"]}{YELLOW}] [{Seats["A2"]}{YELLOW}]{NORMAL}  [{Seats["A4"]}][{Seats["A5"]}][{Seats["A6"]}][{Seats["A7"]}] |c|     | A {BLUE}[{Seats["A14"]}{BLUE}]{NORMAL}[{Seats["A15"]}][{Seats["A16"]}][{Seats["A17"]}][{Seats["A18"]}][{Seats["A19"]}][{Seats["A20"]}][{Seats["A21"]}][{Seats["A22"]}][{Seats["A23"]}][{Seats["A24"]}][{Seats["A25"]}][{Seats["A26"]}][{Seats["A27"]}][{Seats["A28"]}][{Seats["A29"]}][{Seats["A30"]}][{Seats["A31"]}][{Seats["A32"]}] |c| |   A {BLUE}[{Seats["A36"]}{BLUE}]{NORMAL}[{Seats["A37"]}][{Seats["A38"]}][{Seats["A39"]}][{Seats["A40"]}][{Seats["A41"]}][{Seats["A42"]}][{Seats["A43"]}]_____________________!_|
                        \______________________________!____________________________________________________________________!___________________________/
                                                                                \                                  /  
                            [ ] = empty seat                                     \                                 |
                            [{RED}X{NORMAL}] = taken seat                                      \                                |
                            [{CYAN}O{NORMAL}] = chosen seat                                      \                               |
                                                                                    \______________________________|
";
        }
        else if (airplane is "Boeing 787") 
        {
            picture = @$"
                                 
                [ ] = Economy Class                       _____________________________________________
                {BLUE}[ ]{NORMAL} = Economy extra leg room             /                                            /
                {YELLOW}[ ]{NORMAL} = Business Class                    /                                            /
                 _^________1____2____3________^_____4__/_5____6______16_17 18_19_20_21_22_23_24_25__/___^__27_28_29_30_31_32_33_34_35_36_37_38____^________
            ____/   |w| L {YELLOW}[{Seats["L1"]}{YELLOW}]  [{Seats["L2"]}{YELLOW}]  [{Seats["L3"]}{YELLOW}]{NORMAL} | |w|    | {YELLOW}[{Seats["L4"]}{YELLOW}]  [{Seats["L5"]}{YELLOW}]  [{Seats["L6"]}{YELLOW}]{NORMAL}| L {BLUE}[{Seats["L16"]}{BLUE}][{Seats["L17"]}{BLUE}][{Seats["L18"]}{BLUE}][{Seats["L19"]}{BLUE}][{Seats["L20"]}{BLUE}][{Seats["L21"]}{BLUE}][{Seats["L22"]}{BLUE}]{NORMAL}[{Seats["L23"]}][{Seats["L24"]}][{Seats["L25"]}]|w|      [{Seats["L27"]}][{Seats["L28"]}][{Seats["L29"]}][{Seats["L30"]}][{Seats["L31"]}][{Seats["L32"]}][{Seats["L33"]}][{Seats["L34"]}][{Seats["L35"]}][{Seats["L36"]}]| |w|      |      \
       ____/__      |c| K {YELLOW}[{Seats["K1"]}{YELLOW}]  [{Seats["K2"]}{YELLOW}]  [{Seats["K3"]}{YELLOW}]{NORMAL} | |c|    | {YELLOW}[{Seats["K4"]}{YELLOW}]  [{Seats["K5"]}{YELLOW}]  [{Seats["K6"]}{YELLOW}]{NORMAL}| K {BLUE}[{Seats["K16"]}{BLUE}][{Seats["K17"]}{BLUE}][{Seats["K18"]}{BLUE}][{Seats["K19"]}{BLUE}][{Seats["K20"]}{BLUE}][{Seats["K21"]}{BLUE}][{Seats["K22"]}{BLUE}]{NORMAL}[{Seats["K23"]}][{Seats["K24"]}][{Seats["K25"]}]|c|      {BLUE}[{Seats["K27"]}{BLUE}]{NORMAL}[{Seats["K28"]}][{Seats["K29"]}][{Seats["K30"]}][{Seats["K31"]}][{Seats["K32"]}][{Seats["K33"]}][{Seats["K34"]}][{Seats["K35"]}][{Seats["K36"]}]| |c|      |       \
      /    |  |                                                   J {BLUE}[{Seats["J16"]}][{Seats["J17"]}][{Seats["J18"]}][{Seats["J19"]}][{Seats["J20"]}][{Seats["J21"]}][{Seats["J22"]}]{NORMAL}[{Seats["J23"]}][{Seats["J24"]}][{Seats["J25"]}]         {BLUE}[{Seats["J27"]}{BLUE}]{NORMAL}[{Seats["J28"]}][{Seats["J29"]}][{Seats["J30"]}][{Seats["J31"]}][{Seats["J32"]}][{Seats["J33"]}][{Seats["J34"]}][{Seats["J35"]}][{Seats["J36"]}]|          |_____   \
     /  /  | R|    _                       _    _                                                     _                                        _          |_  \
    /  /|  |__|   |R| | E   {YELLOW}[{Seats["E1"]}{YELLOW}]  [{Seats["E2"]}{YELLOW}]  [{Seats["E3"]}{YELLOW}]{NORMAL} | |  | |  {YELLOW}[{Seats["E4"]}{YELLOW}]  [{Seats["E5"]}{YELLOW}]  [{Seats["E6"]}{YELLOW}]{NORMAL}| F  {BLUE}[{Seats["F17"]}{BLUE}][{Seats["F18"]}{BLUE}][{Seats["F19"]}{BLUE}][{Seats["F20"]}{BLUE}][{Seats["F21"]}{BLUE}][{Seats["F22"]}{BLUE}][{Seats["F23"]}{BLUE}]{NORMAL}[{Seats["F24"]}][{Seats["F25"]}] |  | |  [{Seats["F27"]}][{Seats["F28"]}][{Seats["F29"]}][{Seats["F30"]}][{Seats["F31"]}][{Seats["F32"]}][{Seats["F33"]}][{Seats["F34"]}][{Seats["F35"]}][{Seats["F36"]}][{Seats["F37"]}][{Seats["F38"]}]| |         | |  \
   |  | |  |          |                   |R|  |R|               | E  {BLUE}[{Seats["E17"]}{BLUE}][{Seats["E18"]}{BLUE}][{Seats["E19"]}{BLUE}][{Seats["E20"]}{BLUE}][{Seats["E21"]}{BLUE}][{Seats["E22"]}{BLUE}][{Seats["E23"]}{BLUE}]{NORMAL}[{Seats["E24"]}][{Seats["E25"]}] |  |R|  [{Seats["E27"]}][{Seats["E28"]}][{Seats["E29"]}][{Seats["E30"]}][{Seats["E31"]}][{Seats["E32"]}][{Seats["E33"]}][{Seats["E34"]}][{Seats["E35"]}][{Seats["E36"]}][{Seats["E37"]}][{Seats["E38"]}]|R|         |R|  |
    \  \|  |          | D   {YELLOW}[{Seats["D1"]}{YELLOW}]  [{Seats["D2"]}{YELLOW}]  [{Seats["D3"]}{YELLOW}]{NORMAL} |_|  |_|  {YELLOW}[{Seats["D4"]}{YELLOW}]  [{Seats["D5"]}{YELLOW}]  [{Seats["D6"]}{YELLOW}]{NORMAL}| D  {BLUE}[{Seats["D17"]}{BLUE}][{Seats["D18"]}{BLUE}][{Seats["D19"]}{BLUE}][{Seats["D20"]}{BLUE}][{Seats["D21"]}{BLUE}][{Seats["D22"]}{BLUE}][{Seats["D23"]}{BLUE}]{NORMAL}[{Seats["D24"]}][{Seats["D25"]}] |  |_|  [{Seats["D27"]}][{Seats["D28"]}][{Seats["D29"]}][{Seats["D30"]}][{Seats["D31"]}][{Seats["D32"]}][{Seats["D33"]}][{Seats["D34"]}][{Seats["D35"]}][{Seats["D36"]}][{Seats["D37"]}][{Seats["D38"]}]|_|         |_|  /
     \  \  |__                                                                                                                                      ______|   /
      \    |  |                                                   C {BLUE}[{Seats["C16"]}][{Seats["C17"]}][{Seats["C18"]}][{Seats["C19"]}][{Seats["C20"]}][{Seats["C21"]}][{Seats["C22"]}]{NORMAL}[{Seats["C23"]}][{Seats["C24"]}][{Seats["C25"]}] _       {BLUE}[{Seats["C27"]}{BLUE}]{NORMAL}[{Seats["C28"]}][{Seats["C29"]}][{Seats["C30"]}][{Seats["C31"]}][{Seats["C32"]}][{Seats["C33"]}][{Seats["C34"]}][{Seats["C35"]}][{Seats["C36"]}]|  _       |        /
       \___| G|       | B {YELLOW}[{Seats["B1"]}{YELLOW}]  [{Seats["B2"]}{YELLOW}]  [{Seats["B3"]}{YELLOW}]{NORMAL}  | W |   | {YELLOW}[{Seats["B4"]}{YELLOW}]  [{Seats["B5"]}{YELLOW}]  [{Seats["B6"]}{YELLOW}]{NORMAL}| B {BLUE}[{Seats["B16"]}{BLUE}][{Seats["B17"]}{BLUE}][{Seats["B18"]}{BLUE}][{Seats["B19"]}{BLUE}][{Seats["B20"]}{BLUE}][{Seats["B21"]}{BLUE}][{Seats["B22"]}{BLUE}]{NORMAL}[{Seats["B23"]}][{Seats["B24"]}][{Seats["B25"]}]|w|      {BLUE}[{Seats["B27"]}{BLUE}]{NORMAL}[{Seats["B28"]}][{Seats["B29"]}][{Seats["B30"]}][{Seats["B31"]}][{Seats["B32"]}][{Seats["B33"]}][{Seats["B34"]}][{Seats["B35"]}][{Seats["B36"]}]| |w|      |       /
           \__|_      | A {YELLOW}[{Seats["A1"]}{YELLOW}]  [{Seats["A2"]}{YELLOW}]  [{Seats["A3"]}{YELLOW}]{NORMAL}  | C |   | {YELLOW}[{Seats["A4"]}{YELLOW}]  [{Seats["A5"]}{YELLOW}]  [{Seats["A6"]}{YELLOW}{NORMAL}| A {BLUE}[{Seats["A16"]}{BLUE}][{Seats["A17"]}{BLUE}][{Seats["A18"]}{BLUE}][{Seats["A19"]}{BLUE}][{Seats["A20"]}{BLUE}][{Seats["A21"]}{BLUE}][{Seats["A22"]}{BLUE}]{NORMAL}[{Seats["A23"]}][{Seats["A24"]}][{Seats["A25"]}]|c|      [{Seats["A27"]}][{Seats["A28"]}][{Seats["A29"]}][{Seats["A30"]}][{Seats["A31"]}][{Seats["A32"]}][{Seats["A33"]}][{Seats["A34"]}][{Seats["A35"]}][{Seats["A36"]}]| |c|      |      /
                \_!________1____2____3________!_____4____5____6______16_17_18_19_20_21_22_23_24_25______!__27_28_29_30_31_32_33_34_35_36_37_38____!_|_____/
                                                       \                                            \  
                [ ] = empty seats                       \                                            \
                [{RED}X{NORMAL}] = taken seats                        \____________________________________________\            
                [{CYAN}O{NORMAL}] = chosen seats
";
        }

        Console.WriteLine(picture);
    }
    public static string GetPlane(string airplane, Dictionary<string, string> Seats)
    {
        string picture = "";

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

        if (airplane is "Boeing 737")
        {
            picture = @$"
                                                                    ______________
                            [ ] = Economy Class                    /              |
                            {BLUE}[ ]{NORMAL} = Economy extra leg room          /               |
                                                                 /                |
                                                                /                 |
                                                               /                  |
                 ___^_________________________________________/__________^___^____\_________________________________________________
         _______/         F    [{Seats["F2"]}][{Seats["F3"]}][{Seats["F4"]}][{Seats["F5"]}][{Seats["F6"]}][{Seats["F7"]}][{Seats["F8"]}][{Seats["F9"]}][{Seats["F10"]}][{Seats["F11"]}][{Seats["F12"]}][{Seats["F13"]}][{Seats["F14"]}][{Seats["F15"]}] {BLUE}[{Seats["F16"]}{BLUE}] [{Seats["F17"]}{BLUE}]{NORMAL}[{Seats["F18"]}][{Seats["F19"]}][{Seats["F20"]}][{Seats["F21"]}][{Seats["F22"]}][{Seats["F23"]}][{Seats["F24"]}][{Seats["F25"]}][{Seats["F26"]}][{Seats["F27"]}][{Seats["F28"]}][{Seats["F29"]}][{Seats["F30"]}][{Seats["F31"]}][{Seats["F32"]}][{Seats["F33"]}] _ \_^_____
      __/                 E    [{Seats["E2"]}][{Seats["E3"]}][{Seats["E4"]}][{Seats["E5"]}][{Seats["E6"]}][{Seats["E7"]}][{Seats["E8"]}][{Seats["E9"]}][{Seats["E10"]}][{Seats["E11"]}][{Seats["E12"]}][{Seats["E13"]}][{Seats["E14"]}][{Seats["E15"]}] {BLUE}[{Seats["E16"]}{BLUE}] [{Seats["E17"]}{BLUE}]{NORMAL}[{Seats["E18"]}][{Seats["E19"]}][{Seats["E20"]}][{Seats["E21"]}][{Seats["E22"]}][{Seats["E23"]}][{Seats["E24"]}][{Seats["E25"]}][{Seats["E26"]}][{Seats["E27"]}][{Seats["E28"]}][{Seats["E29"]}][{Seats["E30"]}][{Seats["E31"]}][{Seats["E32"]}][{Seats["E33"]}]|w|        \
     /   /--              D    [{Seats["D2"]}][{Seats["D3"]}][{Seats["D4"]}][{Seats["D5"]}][{Seats["D6"]}][{Seats["D7"]}][{Seats["D8"]}][{Seats["D9"]}][{Seats["D10"]}][{Seats["D11"]}][{Seats["D12"]}][{Seats["D13"]}][{Seats["D14"]}][{Seats["D15"]}] {BLUE}[{Seats["D16"]}{BLUE}] [{Seats["D17"]}{BLUE}]{NORMAL}[{Seats["D18"]}][{Seats["D19"]}][{Seats["D20"]}][{Seats["D21"]}][{Seats["D22"]}][{Seats["D23"]}][{Seats["D24"]}][{Seats["D25"]}][{Seats["D26"]}][{Seats["D27"]}][{Seats["D28"]}][{Seats["D29"]}][{Seats["D30"]}][{Seats["D31"]}][{Seats["D32"]}][{Seats["D33"]}]|c|         |
    |    |        _          1  2  3  4  5  6  7  8  9 10 11 12 13 14 15  16  17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33  _          |
     \__ \--     |w|      C [{Seats["C1"]}][{Seats["C2"]}][{Seats["C3"]}][{Seats["C4"]}][{Seats["C5"]}][{Seats["C6"]}][{Seats["C7"]}][{Seats["C8"]}][{Seats["C9"]}][{Seats["C10"]}][{Seats["C11"]}][{Seats["C12"]}][{Seats["C13"]}][{Seats["C14"]}][{Seats["C15"]}] {BLUE}[{Seats["C16"]}{BLUE}] [{Seats["C17"]}{BLUE}]{NORMAL}[{Seats["C18"]}][{Seats["C19"]}][{Seats["C20"]}][{Seats["C21"]}][{Seats["C22"]}][{Seats["C23"]}][{Seats["C24"]}][{Seats["C25"]}][{Seats["C26"]}][{Seats["C27"]}][{Seats["C28"]}][{Seats["C29"]}][{Seats["C30"]}][{Seats["C31"]}][{Seats["C32"]}][{Seats["C33"]}]|w|         |
        \_______ |c|      B [{Seats["B1"]}][{Seats["B2"]}][{Seats["B3"]}][{Seats["B4"]}][{Seats["B5"]}][{Seats["B6"]}][{Seats["B7"]}][{Seats["B8"]}][{Seats["B9"]}][{Seats["B10"]}][{Seats["B11"]}][{Seats["B12"]}][{Seats["B13"]}][{Seats["B14"]}][{Seats["B15"]}] {BLUE}[{Seats["B16"]}{BLUE}] [{Seats["B17"]}{BLUE}]{NORMAL}[{Seats["B18"]}][{Seats["B19"]}][{Seats["B20"]}][{Seats["B21"]}][{Seats["B22"]}][{Seats["B23"]}][{Seats["B24"]}][{Seats["B25"]}][{Seats["B26"]}][{Seats["B27"]}][{Seats["B28"]}][{Seats["B29"]}][{Seats["B30"]}][{Seats["B31"]}][{Seats["B32"]}][{Seats["B33"]}]|c| _______/
                \________ A [{Seats["A1"]}][{Seats["A2"]}][{Seats["A3"]}][{Seats["A4"]}][{Seats["A5"]}][{Seats["A6"]}][{Seats["A7"]}][{Seats["A8"]}][{Seats["A9"]}][{Seats["A10"]}][{Seats["A11"]}][{Seats["A12"]}][{Seats["A13"]}][{Seats["A14"]}][{Seats["A15"]}] {BLUE}[{Seats["A16"]}{BLUE}] [{Seats["A17"]}{BLUE}]{NORMAL}[{Seats["A18"]}][{Seats["A19"]}][{Seats["A20"]}][{Seats["A21"]}][{Seats["A22"]}][{Seats["A23"]}][{Seats["A24"]}][{Seats["A25"]}][{Seats["A26"]}][{Seats["A27"]}][{Seats["A28"]}][{Seats["A29"]}][{Seats["A30"]}][{Seats["A31"]}][{Seats["A32"]}][{Seats["A33"]}]___/ !
                    !    \_______________________________________________!___!__________________________________________________/
                                                              \                   /
                            [ ] = empty seats                  \                  |
                            [{RED}X{NORMAL}] = taken seats                   \                 |
                            [{CYAN}O{NORMAL}] = chosen seats                   \                |
                                                                  \               |
                                                                   \              |
";
        }
        else if (airplane is "Airbus 330")
        {
            picture = @$"           
                                                                                     ______________________________
                          [ ] = Economy Class                                       /                              |
                          {BLUE}[ ]{NORMAL}= Economy extra leg room                              /                               |
                          {YELLOW}[ ]{NORMAL} = Club Class                                        /                                |
                          {GREEN}[ ]{NORMAL} = Double seat                                      /                                 |
                    __^_______________________________^_________________________/__________________________________\________^____________________________
              _____/    |K {YELLOW}[{Seats["K1"]}{YELLOW}] [{Seats["K2"]}{YELLOW}]{NORMAL}  [{Seats["K4"]}][{Seats["K5"]}][{Seats["K6"]}][{Seats["K7"]}] |w|	 | K {BLUE}[{Seats["K14"]}]{NORMAL}[{Seats["K15"]}][{Seats["K16"]}][{Seats["K17"]}][{Seats["K18"]}][{Seats["K19"]}][{Seats["K20"]}][{Seats["K21"]}][{Seats["K22"]}][{Seats["K23"]}][{Seats["K24"]}][{Seats["K25"]}][{Seats["K26"]}][{Seats["K27"]}][{Seats["K28"]}][{Seats["K29"]}][{Seats["K30"]}][{Seats["K31"]}][{Seats["K32"]}] |w| |   K {BLUE}[{Seats["K36"]}]{NORMAL}[{Seats["K37"]}][{Seats["K38"]}][{Seats["K39"]}][{Seats["K40"]}][{Seats["K41"]}][{Seats["K42"]}][{Seats["K43"]}]\____________________^_
         ____/|         |J          [{Seats["J4"]}][{Seats["J5"]}][{Seats["J6"]}][{Seats["J7"]}] |c|     | J {BLUE}[{Seats["J14"]}]{NORMAL}[{Seats["J15"]}][{Seats["J16"]}][{Seats["J17"]}][{Seats["J18"]}][{Seats["J19"]}][{Seats["J20"]}][{Seats["J21"]}][{Seats["J22"]}][{Seats["J23"]}][{Seats["J24"]}][{Seats["J25"]}][{Seats["J26"]}][{Seats["J27"]}][{Seats["J28"]}][{Seats["J29"]}][{Seats["J30"]}][{Seats["J31"]}][{Seats["J32"]}] |c| |   J {BLUE}[{Seats["J36"]}]{NORMAL}[{Seats["J37"]}][{Seats["J38"]}][{Seats["J39"]}][{Seats["J40"]}][{Seats["J41"]}][{Seats["J42"]}][{Seats["J43"]}]{GREEN}[{Seats["K44"]}{GREEN}][{Seats["K45"]}{GREEN}][{Seats["K46"]}{GREEN}][{Seats["K47"]}{GREEN}][{Seats["K48"]}{GREEN}][{Seats["K49"]}{GREEN}]{NORMAL}     |
        /     |         |H {YELLOW}[{Seats["H1"]}{YELLOW}] [{Seats["H2"]}{YELLOW}]{NORMAL}  [{Seats["H4"]}][{Seats["H5"]}][{Seats["H6"]}][{Seats["H7"]}]         | H {BLUE}[{Seats["H14"]}]{NORMAL}[{Seats["H15"]}][{Seats["H16"]}][{Seats["H17"]}][{Seats["H18"]}][{Seats["H19"]}][{Seats["H20"]}][{Seats["H21"]}][{Seats["H22"]}][{Seats["H23"]}][{Seats["H24"]}][{Seats["H25"]}][{Seats["H26"]}][{Seats["H27"]}][{Seats["H28"]}][{Seats["H29"]}][{Seats["H30"]}][{Seats["H31"]}][{Seats["H32"]}]     |   H {BLUE}[{Seats["H36"]}]{NORMAL}[{Seats["H37"]}][{Seats["H38"]}][{Seats["H39"]}][{Seats["H40"]}][{Seats["H41"]}][{Seats["H42"]}][{Seats["H43"]}]{GREEN}[{Seats["H44"]}{GREEN}][{Seats["H45"]}{GREEN}][{Seats["H46"]}{GREEN}][{Seats["H47"]}{GREEN}][{Seats["H48"]}{GREEN}][{Seats["H49"]}{GREEN}]{NORMAL}     |
     __/  /   |             1   2    4  5  6  7  8  9 10     14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33   _     36 37 38 39 40 41 42 43 44 45 46 47 48 49 50   |
    /    /    |         |G {YELLOW}[{Seats["G1"]}{YELLOW}] [{Seats["G2"]}{YELLOW}]{NORMAL}     [{Seats["G4"]}][{Seats["G6"]}][{Seats["G7"]}][{Seats["G8"]}][{Seats["G9"]}][{Seats["G10"]}]  G {BLUE}[{Seats["G14"]}{BLUE}]{NORMAL}[{Seats["G15"]}][{Seats["G16"]}][{Seats["G17"]}][{Seats["G18"]}][{Seats["G19"]}][{Seats["G20"]}][{Seats["G21"]}][{Seats["G22"]}][{Seats["G23"]}][{Seats["G24"]}][{Seats["G25"]}][{Seats["G26"]}][{Seats["G27"]}][{Seats["G28"]}][{Seats["G29"]}][{Seats["G30"]}][{Seats["G31"]}][{Seats["G32"]}][{Seats["G33"]}] |c| G {BLUE}[{Seats["G36"]}{BLUE}]{NORMAL}[{Seats["G37"]}][{Seats["G38"]}][{Seats["G39"]}][{Seats["G40"]}][{Seats["G41"]}][{Seats["G42"]}][{Seats["G43"]}][{Seats["G44"]}][{Seats["G45"]}][{Seats["G46"]}][{Seats["G47"]}][{Seats["G48"]}][{Seats["G49"]}][{Seats["G50"]}]|  |
   |	|     |         |F             [{Seats["F4"]}][{Seats["F6"]}][{Seats["F7"]}][{Seats["F8"]}][{Seats["F9"]}][{Seats["F10"]}]  F {BLUE}[{Seats["F14"]}{BLUE}]{NORMAL}[{Seats["F15"]}][{Seats["F16"]}][{Seats["F17"]}][{Seats["F18"]}][{Seats["F19"]}][{Seats["F20"]}][{Seats["F21"]}][{Seats["F22"]}][{Seats["F23"]}][{Seats["F24"]}][{Seats["F25"]}][{Seats["F26"]}][{Seats["F27"]}][{Seats["F28"]}][{Seats["F29"]}][{Seats["F30"]}][{Seats["F31"]}][{Seats["F32"]}][{Seats["F33"]}] |w| F {BLUE}[{Seats["F36"]}{BLUE}]{NORMAL}[{Seats["F37"]}][{Seats["F38"]}][{Seats["F39"]}][{Seats["F40"]}][{Seats["F41"]}][{Seats["F42"]}][{Seats["F43"]}][{Seats["F44"]}][{Seats["F45"]}][{Seats["F46"]}][{Seats["F47"]}][{Seats["F48"]}][{Seats["F49"]}][{Seats["F50"]}]|  |
    \__	 \    |         |D {YELLOW}[{Seats["D1"]}{YELLOW}] [{Seats["D2"]}{YELLOW}]{NORMAL}     [{Seats["D4"]}][{Seats["D6"]}][{Seats["D7"]}][{Seats["D8"]}][{Seats["D9"]}][{Seats["D10"]}]  D {BLUE}[{Seats["D14"]}{BLUE}]{NORMAL}[{Seats["D15"]}][{Seats["D16"]}][{Seats["D17"]}][{Seats["D18"]}][{Seats["D19"]}][{Seats["D20"]}][{Seats["D21"]}][{Seats["D22"]}][{Seats["D23"]}][{Seats["D24"]}][{Seats["D25"]}][{Seats["D26"]}][{Seats["D27"]}][{Seats["D28"]}][{Seats["D29"]}][{Seats["D30"]}][{Seats["D31"]}][{Seats["D32"]}][{Seats["D33"]}] |c| D {BLUE}[{Seats["D36"]}{BLUE}]{NORMAL}[{Seats["D37"]}][{Seats["D38"]}][{Seats["D39"]}][{Seats["D40"]}][{Seats["D41"]}][{Seats["D42"]}][{Seats["D43"]}][{Seats["D44"]}][{Seats["D45"]}][{Seats["D46"]}][{Seats["D47"]}][{Seats["D48"]}][{Seats["D49"]}][{Seats["D50"]}]|  |
       \  \   |	 _                                                                                                                                                              |
        \____ | |w|     |C {YELLOW}[{Seats["C1"]}{YELLOW}] [{Seats["C2"]}{YELLOW}]{NORMAL}  [{Seats["C4"]}][{Seats["C5"]}][{Seats["C6"]}][{Seats["C7"]}]  _      | C {BLUE}[{Seats["C14"]}{BLUE}]{NORMAL}[{Seats["C15"]}][{Seats["C16"]}][{Seats["C17"]}][{Seats["C18"]}][{Seats["C19"]}][{Seats["C20"]}][{Seats["C21"]}][{Seats["C22"]}][{Seats["C23"]}][{Seats["C24"]}][{Seats["C25"]}][{Seats["C26"]}][{Seats["C27"]}][{Seats["C28"]}][{Seats["C29"]}][{Seats["C30"]}][{Seats["C31"]}][{Seats["C32"]}]  _  |   C {BLUE}[{Seats["C36"]}{BLUE}]{NORMAL}[{Seats["C37"]}][{Seats["C38"]}][{Seats["C39"]}][{Seats["C40"]}][{Seats["C41"]}][{Seats["C42"]}][{Seats["C43"]}]{GREEN}[{Seats["C44"]}{GREEN}][{Seats["C45"]}{GREEN}][{Seats["C46"]}{GREEN}][{Seats["C47"]}{GREEN}][{Seats["C48"]}{GREEN}][{Seats["C49"]}{GREEN}]{NORMAL}     |
             \|_|c|     |B          [{Seats["B4"]}][{Seats["B5"]}][{Seats["B6"]}][{Seats["B7"]}] |w|     | B {BLUE}[{Seats["B14"]}]{NORMAL}[{Seats["B15"]}][{Seats["B16"]}][{Seats["B17"]}][{Seats["B18"]}][{Seats["B19"]}][{Seats["B20"]}][{Seats["B21"]}][{Seats["B22"]}][{Seats["B23"]}][{Seats["B24"]}][{Seats["B25"]}][{Seats["B26"]}][{Seats["B27"]}][{Seats["B28"]}][{Seats["B29"]}][{Seats["B30"]}][{Seats["B31"]}][{Seats["B32"]}] |w| |   B {BLUE}[{Seats["B36"]}{BLUE}]{NORMAL}[{Seats["B37"]}][{Seats["B38"]}][{Seats["B39"]}][{Seats["B40"]}][{Seats["B41"]}][{Seats["B42"]}][{Seats["B43"]}]{GREEN}[{Seats["A44"]}{GREEN}][{Seats["A45"]}{GREEN}][{Seats["A46"]}{GREEN}][{Seats["A47"]}{GREEN}][{Seats["A48"]}{GREEN}][{Seats["A49"]}{GREEN}]{NORMAL}     |
                  \___!_|A {YELLOW}[{Seats["A1"]}{YELLOW}] [{Seats["A2"]}{YELLOW}]{NORMAL}  [{Seats["A4"]}][{Seats["A5"]}][{Seats["A6"]}][{Seats["A7"]}] |c|     | A {BLUE}[{Seats["A14"]}{BLUE}]{NORMAL}[{Seats["A15"]}][{Seats["A16"]}][{Seats["A17"]}][{Seats["A18"]}][{Seats["A19"]}][{Seats["A20"]}][{Seats["A21"]}][{Seats["A22"]}][{Seats["A23"]}][{Seats["A24"]}][{Seats["A25"]}][{Seats["A26"]}][{Seats["A27"]}][{Seats["A28"]}][{Seats["A29"]}][{Seats["A30"]}][{Seats["A31"]}][{Seats["A32"]}] |c| |   A {BLUE}[{Seats["A36"]}{BLUE}]{NORMAL}[{Seats["A37"]}][{Seats["A38"]}][{Seats["A39"]}][{Seats["A40"]}][{Seats["A41"]}][{Seats["A42"]}][{Seats["A43"]}]_____________________!_|
                        \______________________________!____________________________________________________________________!___________________________/
                                                                                \                                  /  
                            [ ] = empty seat                                     \                                 |
                            [{RED}X{NORMAL}] = taken seat                                      \                                |
                            [{CYAN}O{NORMAL}] = chosen seat                                      \                               |
                                                                                    \______________________________|
";
        }
        else if (airplane is "Boeing 787") 
        {
            picture = @$"
                                 
                [ ] = Economy Class                       _____________________________________________
                {BLUE}[ ]{NORMAL} = Economy extra leg room             /                                            /
                {YELLOW}[ ]{NORMAL} = Business Class                    /                                            /
                 _^________1____2____3________^_____4__/_5____6______16_17 18_19_20_21_22_23_24_25__/___^__27_28_29_30_31_32_33_34_35_36_37_38____^________
            ____/   |w| L {YELLOW}[{Seats["L1"]}{YELLOW}]  [{Seats["L2"]}{YELLOW}]  [{Seats["L3"]}{YELLOW}]{NORMAL} | |w|    | {YELLOW}[{Seats["L4"]}{YELLOW}]  [{Seats["L5"]}{YELLOW}]  [{Seats["L6"]}{YELLOW}]{NORMAL}| L {BLUE}[{Seats["L16"]}{BLUE}][{Seats["L17"]}{BLUE}][{Seats["L18"]}{BLUE}][{Seats["L19"]}{BLUE}][{Seats["L20"]}{BLUE}][{Seats["L21"]}{BLUE}][{Seats["L22"]}{BLUE}]{NORMAL}[{Seats["L23"]}][{Seats["L24"]}][{Seats["L25"]}]|w|      [{Seats["L27"]}][{Seats["L28"]}][{Seats["L29"]}][{Seats["L30"]}][{Seats["L31"]}][{Seats["L32"]}][{Seats["L33"]}][{Seats["L34"]}][{Seats["L35"]}][{Seats["L36"]}]| |w|      |      \
       ____/__      |c| K {YELLOW}[{Seats["K1"]}{YELLOW}]  [{Seats["K2"]}{YELLOW}]  [{Seats["K3"]}{YELLOW}]{NORMAL} | |c|    | {YELLOW}[{Seats["K4"]}{YELLOW}]  [{Seats["K5"]}{YELLOW}]  [{Seats["K6"]}{YELLOW}]{NORMAL}| K {BLUE}[{Seats["K16"]}{BLUE}][{Seats["K17"]}{BLUE}][{Seats["K18"]}{BLUE}][{Seats["K19"]}{BLUE}][{Seats["K20"]}{BLUE}][{Seats["K21"]}{BLUE}][{Seats["K22"]}{BLUE}]{NORMAL}[{Seats["K23"]}][{Seats["K24"]}][{Seats["K25"]}]|c|      {BLUE}[{Seats["K27"]}{BLUE}]{NORMAL}[{Seats["K28"]}][{Seats["K29"]}][{Seats["K30"]}][{Seats["K31"]}][{Seats["K32"]}][{Seats["K33"]}][{Seats["K34"]}][{Seats["K35"]}][{Seats["K36"]}]| |c|      |       \
      /    |  |                                                   J {BLUE}[{Seats["J16"]}][{Seats["J17"]}][{Seats["J18"]}][{Seats["J19"]}][{Seats["J20"]}][{Seats["J21"]}][{Seats["J22"]}]{NORMAL}[{Seats["J23"]}][{Seats["J24"]}][{Seats["J25"]}]         {BLUE}[{Seats["J27"]}{BLUE}]{NORMAL}[{Seats["J28"]}][{Seats["J29"]}][{Seats["J30"]}][{Seats["J31"]}][{Seats["J32"]}][{Seats["J33"]}][{Seats["J34"]}][{Seats["J35"]}][{Seats["J36"]}]|          |_____   \
     /  /  | R|    _                       _    _                                                     _                                        _          |_  \
    /  /|  |__|   |R| | E   {YELLOW}[{Seats["E1"]}{YELLOW}]  [{Seats["E2"]}{YELLOW}]  [{Seats["E3"]}{YELLOW}]{NORMAL} | |  | |  {YELLOW}[{Seats["E4"]}{YELLOW}]  [{Seats["E5"]}{YELLOW}]  [{Seats["E6"]}{YELLOW}]{NORMAL}| F  {BLUE}[{Seats["F17"]}{BLUE}][{Seats["F18"]}{BLUE}][{Seats["F19"]}{BLUE}][{Seats["F20"]}{BLUE}][{Seats["F21"]}{BLUE}][{Seats["F22"]}{BLUE}][{Seats["F23"]}{BLUE}]{NORMAL}[{Seats["F24"]}][{Seats["F25"]}] |  | |  [{Seats["F27"]}][{Seats["F28"]}][{Seats["F29"]}][{Seats["F30"]}][{Seats["F31"]}][{Seats["F32"]}][{Seats["F33"]}][{Seats["F34"]}][{Seats["F35"]}][{Seats["F36"]}][{Seats["F37"]}][{Seats["F38"]}]| |         | |  \
   |  | |  |          |                   |R|  |R|               | E  {BLUE}[{Seats["E17"]}{BLUE}][{Seats["E18"]}{BLUE}][{Seats["E19"]}{BLUE}][{Seats["E20"]}{BLUE}][{Seats["E21"]}{BLUE}][{Seats["E22"]}{BLUE}][{Seats["E23"]}{BLUE}]{NORMAL}[{Seats["E24"]}][{Seats["E25"]}] |  |R|  [{Seats["E27"]}][{Seats["E28"]}][{Seats["E29"]}][{Seats["E30"]}][{Seats["E31"]}][{Seats["E32"]}][{Seats["E33"]}][{Seats["E34"]}][{Seats["E35"]}][{Seats["E36"]}][{Seats["E37"]}][{Seats["E38"]}]|R|         |R|  |
    \  \|  |          | D   {YELLOW}[{Seats["D1"]}{YELLOW}]  [{Seats["D2"]}{YELLOW}]  [{Seats["D3"]}{YELLOW}]{NORMAL} |_|  |_|  {YELLOW}[{Seats["D4"]}{YELLOW}]  [{Seats["D5"]}{YELLOW}]  [{Seats["D6"]}{YELLOW}]{NORMAL}| D  {BLUE}[{Seats["D17"]}{BLUE}][{Seats["D18"]}{BLUE}][{Seats["D19"]}{BLUE}][{Seats["D20"]}{BLUE}][{Seats["D21"]}{BLUE}][{Seats["D22"]}{BLUE}][{Seats["D23"]}{BLUE}]{NORMAL}[{Seats["D24"]}][{Seats["D25"]}] |  |_|  [{Seats["D27"]}][{Seats["D28"]}][{Seats["D29"]}][{Seats["D30"]}][{Seats["D31"]}][{Seats["D32"]}][{Seats["D33"]}][{Seats["D34"]}][{Seats["D35"]}][{Seats["D36"]}][{Seats["D37"]}][{Seats["D38"]}]|_|         |_|  /
     \  \  |__                                                                                                                                      ______|   /
      \    |  |                                                   C {BLUE}[{Seats["C16"]}][{Seats["C17"]}][{Seats["C18"]}][{Seats["C19"]}][{Seats["C20"]}][{Seats["C21"]}][{Seats["C22"]}]{NORMAL}[{Seats["C23"]}][{Seats["C24"]}][{Seats["C25"]}] _       {BLUE}[{Seats["C27"]}{BLUE}]{NORMAL}[{Seats["C28"]}][{Seats["C29"]}][{Seats["C30"]}][{Seats["C31"]}][{Seats["C32"]}][{Seats["C33"]}][{Seats["C34"]}][{Seats["C35"]}][{Seats["C36"]}]|  _       |        /
       \___| G|       | B {YELLOW}[{Seats["B1"]}{YELLOW}]  [{Seats["B2"]}{YELLOW}]  [{Seats["B3"]}{YELLOW}]{NORMAL}  | W |   | {YELLOW}[{Seats["B4"]}{YELLOW}]  [{Seats["B5"]}{YELLOW}]  [{Seats["B6"]}{YELLOW}]{NORMAL}| B {BLUE}[{Seats["B16"]}{BLUE}][{Seats["B17"]}{BLUE}][{Seats["B18"]}{BLUE}][{Seats["B19"]}{BLUE}][{Seats["B20"]}{BLUE}][{Seats["B21"]}{BLUE}][{Seats["B22"]}{BLUE}]{NORMAL}[{Seats["B23"]}][{Seats["B24"]}][{Seats["B25"]}]|w|      {BLUE}[{Seats["B27"]}{BLUE}]{NORMAL}[{Seats["B28"]}][{Seats["B29"]}][{Seats["B30"]}][{Seats["B31"]}][{Seats["B32"]}][{Seats["B33"]}][{Seats["B34"]}][{Seats["B35"]}][{Seats["B36"]}]| |w|      |       /
           \__|_      | A {YELLOW}[{Seats["A1"]}{YELLOW}]  [{Seats["A2"]}{YELLOW}]  [{Seats["A3"]}{YELLOW}]{NORMAL}  | C |   | {YELLOW}[{Seats["A4"]}{YELLOW}]  [{Seats["A5"]}{YELLOW}]  [{Seats["A6"]}{YELLOW}{NORMAL}| A {BLUE}[{Seats["A16"]}{BLUE}][{Seats["A17"]}{BLUE}][{Seats["A18"]}{BLUE}][{Seats["A19"]}{BLUE}][{Seats["A20"]}{BLUE}][{Seats["A21"]}{BLUE}][{Seats["A22"]}{BLUE}]{NORMAL}[{Seats["A23"]}][{Seats["A24"]}][{Seats["A25"]}]|c|      [{Seats["A27"]}][{Seats["A28"]}][{Seats["A29"]}][{Seats["A30"]}][{Seats["A31"]}][{Seats["A32"]}][{Seats["A33"]}][{Seats["A34"]}][{Seats["A35"]}][{Seats["A36"]}]| |c|      |      /
                \_!________1____2____3________!_____4____5____6______16_17_18_19_20_21_22_23_24_25______!__27_28_29_30_31_32_33_34_35_36_37_38____!_|_____/
                                                       \                                            \  
                [ ] = empty seats                       \                                            \
                [{RED}X{NORMAL}] = taken seats                        \____________________________________________\            
                [{CYAN}O{NORMAL}] = chosen seats
";
        }

        return picture;
    }
}
