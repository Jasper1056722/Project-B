using System.Net;
using MimeKit.Cryptography;
using Org.BouncyCastle.Asn1.Cms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class Searching
{
    public static void Destination(string destinat, List<Flight> flights)
    {
        List<string> DestinationFlights = new List<string>();

        foreach (Flight flight in flights)
        {
            if (flight.Destination.ToLower() == destinat.ToLower())
            {
                DestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (DestinationFlights.Count > 0)
        {
            Console.WriteLine($"Found {DestinationFlights.Count} flights to {destinat}:\n");
        }
        else if(DestinationFlights.Count == 0)
        {
            Console.WriteLine($"No flights found with destination {destinat}");
        }
        foreach (var flight in DestinationFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        return;
    }

    public static void FlightNumber(string flightnumber, List<Flight> flights)
    {
        List<string> NumFlights = new List<string>();

        foreach (Flight flight in flights)
        {
            if (flight.FlightNumber.ToString() == flightnumber)
            {
                NumFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (NumFlights.Count > 0)
        {
            Console.WriteLine($"Found {NumFlights.Count} flights to {flightnumber}:\n");
        }
        else if(NumFlights.Count == 0)
        {
            Console.WriteLine($"No flights found with flightnumber {flightnumber}");
        }
        foreach (var flight in NumFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        return;
    }

    public static void Time(string departureDateInput, List<Flight> flights)
    {
        List<string> DateFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.DepartureDate == departureDateInput)
            {
                DateFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if(DateFlights.Count > 0)
        {
            Console.WriteLine($"Found {DateFlights.Count} flights departing on: {departureDateInput}:\n");
        }
        else if(DateFlights.Count == 0)
        {
            Console.WriteLine($"No flights found departing on {departureDateInput}");
        }
        foreach (var pettington in DateFlights)
        {
            Console.WriteLine(pettington);
            Console.WriteLine("");
        }
        return;
    }

    public static void Airline(string PlaneAnswer, List<Flight> flights)
    {

        List<string> PlaneFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.Airplane.Model.ToLower() == PlaneAnswer.ToLower())
            {
                PlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (PlaneFlights.Count > 0)
        {
            Console.WriteLine($"Found {PlaneFlights.Count} flights with Airplane: {PlaneAnswer}:");
        }

        else if(PlaneFlights.Count == 0)
        {
            Console.WriteLine($"No flights found with airplane model {PlaneAnswer}");
        }

        foreach (var pompington in PlaneFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        return;
    }
}