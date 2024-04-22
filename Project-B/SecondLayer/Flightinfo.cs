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
            Console.WriteLine(Seats);
            picture = @$"
                                                                ______________
                          [ ] = Economy Class                  /              |
                          {BLUE}[ ]{NORMAL} = Economy extra leg room        /               |
                                                             /                |
                                                            /                 |
                                                           /                  |
             ___^_________________________________________/__________^___^____\_________________________________________________
     _______/	      F    [{Seats["F2"]}][{Seats["F3"]}][{Seats["F4"]}][{Seats["F5"]}][{Seats["F6"]}][{Seats["F7"]}][{Seats["F8"]}][{Seats["F9"]}][{Seats["F10"]}][{Seats["F11"]}][{Seats["F12"]}][{Seats["F13"]}][{Seats["F14"]}][{Seats["F15"]}] {BLUE}[{Seats["F16"]}] [{Seats["F17"]}]{NORMAL}[{Seats["F18"]}][{Seats["F19"]}][{Seats["F20"]}][{Seats["F21"]}][{Seats["F22"]}][{Seats["F23"]}][{Seats["F24"]}][{Seats["F25"]}][{Seats["F26"]}][{Seats["F27"]}][{Seats["F28"]}][{Seats["F29"]}][{Seats["F30"]}][{Seats["F31"]}][{Seats["F32"]}][{Seats["F33"]}] _ \_^_____
  __/                 E    [{Seats["E2"]}][{Seats["E3"]}][{Seats["E4"]}][{Seats["E5"]}][{Seats["E6"]}][{Seats["E7"]}][{Seats["E8"]}][{Seats["E9"]}][{Seats["E10"]}][{Seats["E11"]}][{Seats["E12"]}][{Seats["E13"]}][{Seats["E14"]}][{Seats["E15"]}] {BLUE}[{Seats["E16"]}] [{Seats["E17"]}]{NORMAL}[{Seats["E18"]}][{Seats["E19"]}][{Seats["E20"]}][{Seats["E21"]}][{Seats["E22"]}][{Seats["E23"]}][{Seats["E24"]}][{Seats["E25"]}][{Seats["E26"]}][{Seats["E27"]}][{Seats["E28"]}][{Seats["E29"]}][{Seats["E30"]}][{Seats["E31"]}][{Seats["E32"]}][{Seats["E33"]}]|w|        \
 /   /--              D    [{Seats["D2"]}][{Seats["D3"]}][{Seats["D4"]}][{Seats["D5"]}][{Seats["D6"]}][{Seats["D7"]}][{Seats["D8"]}][{Seats["D9"]}][{Seats["D10"]}][{Seats["D11"]}][{Seats["D12"]}][{Seats["D13"]}][{Seats["D14"]}][{Seats["D15"]}] {BLUE}[{Seats["D16"]}] [{Seats["D17"]}]{NORMAL}[{Seats["D18"]}][{Seats["D19"]}][{Seats["D20"]}][{Seats["D21"]}][{Seats["D22"]}][{Seats["D23"]}][{Seats["D24"]}][{Seats["D25"]}][{Seats["D26"]}][{Seats["D27"]}][{Seats["D28"]}][{Seats["D29"]}][{Seats["D30"]}][{Seats["D31"]}][{Seats["D32"]}][{Seats["D33"]}]|c|         |
|    |        _          1  2  3  4  5  6  7  8  9 10 11 12 13 14 15  16  17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33  _          |
 \__ \--     |w|      C [{Seats["C1"]}][{Seats["C2"]}][{Seats["C3"]}][{Seats["C4"]}][{Seats["C5"]}][{Seats["C6"]}][{Seats["C7"]}][{Seats["C8"]}][{Seats["C9"]}][{Seats["C10"]}][{Seats["C11"]}][{Seats["C12"]}][{Seats["C13"]}][{Seats["C14"]}][{Seats["C15"]}] {BLUE}[{Seats["C16"]}] [{Seats["C17"]}]{NORMAL}[{Seats["C18"]}][{Seats["C19"]}][{Seats["C20"]}][{Seats["C21"]}][{Seats["C22"]}][{Seats["C23"]}][{Seats["C24"]}][{Seats["C25"]}][{Seats["C26"]}][{Seats["C27"]}][{Seats["C28"]}][{Seats["C29"]}][{Seats["C30"]}][{Seats["C31"]}][{Seats["C32"]}][{Seats["C33"]}]|w|         |
    \_______ |c|      B [{Seats["B1"]}][{Seats["B2"]}][{Seats["B3"]}][{Seats["B4"]}][{Seats["B5"]}][{Seats["B6"]}][{Seats["B7"]}][{Seats["B8"]}][{Seats["B9"]}][{Seats["B10"]}][{Seats["B11"]}][{Seats["B12"]}][{Seats["B13"]}][{Seats["B14"]}][{Seats["B15"]}] {BLUE}[{Seats["B16"]}] [{Seats["B17"]}]{NORMAL}[{Seats["B18"]}][{Seats["B19"]}][{Seats["B20"]}][{Seats["B21"]}][{Seats["B22"]}][{Seats["B23"]}][{Seats["B24"]}][{Seats["B25"]}][{Seats["B26"]}][{Seats["B27"]}][{Seats["B28"]}][{Seats["B29"]}][{Seats["B30"]}][{Seats["B31"]}][{Seats["B32"]}][{Seats["B33"]}]|c| _______/
            \________ A [{Seats["A1"]}][{Seats["A2"]}][{Seats["A3"]}][{Seats["A4"]}][{Seats["A5"]}][{Seats["A6"]}][{Seats["A7"]}][{Seats["A8"]}][{Seats["A9"]}][{Seats["A10"]}][{Seats["A11"]}][{Seats["A12"]}][{Seats["A13"]}][{Seats["A14"]}][{Seats["A15"]}] {BLUE}[{Seats["A16"]}] [{Seats["A17"]}]{NORMAL}[{Seats["A18"]}][{Seats["A19"]}][{Seats["A20"]}][{Seats["A21"]}][{Seats["A22"]}][{Seats["A23"]}][{Seats["A24"]}][{Seats["A25"]}][{Seats["A26"]}][{Seats["A27"]}][{Seats["A28"]}][{Seats["A29"]}][{Seats["A30"]}][{Seats["A31"]}][{Seats["A32"]}][{Seats["A33"]}]___/ !
                !    \_______________________________________________!___!__________________________________________________/
                                                          \                   /
                                                           \                  |
                                                            \                 |
                                                             \                |
                                                              \               |
                                                               \              |
";

        }
        else if (airplane is "Airbus 330")
        {
            picture = @$"           


                                                                                     _____________________________
                          [ ] = Economy Class                                       /                             |
                          {BLUE}[ ]{NORMAL}= Economy extra leg room                              /                              |
                          {YELLOW}[ ]{NORMAL} = Club Class                                        /                               |
                          {RED}[ ]{NORMAL} = Double seat                                      /                                |
                    __^_______________________________^_________________________/__________________________________\________^____________________________
              _____/    |K {YELLOW}[ ] [ ]{NORMAL}  [ ][ ][ ][ ] |w|	 | K {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] |w| |   K {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ]\____________________^_
         ____/|         |J          [ ][ ][ ][ ] |c|     | J {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] |c| |   J {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ]{RED}[ ][ ][ ][ ][ ]{NORMAL}     |
        /     |         |H {YELLOW}[ ] [ ]{NORMAL}  [ ][ ][ ][ ]         | H {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]     |   H {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ]{RED}[ ][ ][ ][ ][ ]{NORMAL}     |
     __/  /   |             1   2    4  5  6  7  8  9 10     14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33   _     36 37 38 39 40 41 42 43 44 45 46 47 48 49 50   |
    /    /    |         |G {YELLOW}[ ] [ ]{NORMAL}     [ ][ ][ ][ ][ ][ ]  G {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] |c| G {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]|  |
   |	|     |         |F             [ ][ ][ ][ ][ ][ ]  F {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] |w| F {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]|  |
    \__	 \    |         |D {YELLOW}[ ] [ ]{NORMAL}     [ ][ ][ ][ ][ ][ ]  D {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] |c| D {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]|  |
       \  \   |	 _                                                                                                                                                              |
        \____ | |w|     |C {YELLOW}[ ] [ ]{NORMAL}  [ ][ ][ ][ ]  _      | C {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]  _  |   C {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ]{RED}[ ][ ][ ][ ][ ]{NORMAL}     |
             \| |c|     |B          [ ][ ][ ][ ] |w|     | B {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] |w| |   B {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ]{RED}[ ][ ][ ][ ][ ]{NORMAL}     |
                  \___!_|A {YELLOW}[ ] [ ]{NORMAL}  [ ][ ][ ][ ] |c|     | A {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] |c| |   A {BLUE}[ ]{NORMAL}[ ][ ][ ][ ][ ][ ][ ]_____________________!_|
                        \______________________________!____________________________________________________________________!___________________________/
";
        }

        Console.WriteLine(picture);
    }
}
