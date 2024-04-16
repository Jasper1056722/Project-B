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
        Console.WriteLine("+------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+");
        Console.WriteLine(flightsString);
        Console.WriteLine("+------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+");
    }
}