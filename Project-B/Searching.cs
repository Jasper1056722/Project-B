using System.Net;
using MimeKit.Cryptography;
using Org.BouncyCastle.Asn1.Cms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class Searching
{
    public static void Destination(string destinat, List<Flight> flights)
    {
        Console.WriteLine("Where do you want to travel to?");

        List<string> DestinationFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.Destination.ToLower() == destinat)
            {
                DestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane}\nDeparting from: {flight.DepartingFrom}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (DestinationFlights.Count > 0){

            Console.WriteLine($"Found {DestinationFlights.Count} flights to {destinat}:");

        foreach (var flight in DestinationFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        return;
    }

    public static void Time(string departureDateInput, List<Flight> flights)
    {
        Console.WriteLine("Enter the departure date (dd-mm-yyyy):");

        List<string> DateFlights = new List<string>();

        foreach (var flight in flights)
        {

            string TimeDate = flight.DepartureDate;
            if (TimeDate == departureDateInput)
            {
                DateFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane}\nDeparting from: {flight.DepartingFrom}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }

            if (DateFlights.Count > 0){

                Console.WriteLine($"Found {DateFlights.Count} flights departing on: {departureDateInput}:");

            foreach (var pettington in DateFlights)
            {
                Console.WriteLine(pettington);
                Console.WriteLine("");
            }
            }
        }
        return;
    }

    public static void Airline(string PlaneAnswer, List<Flight> flights)
    {
        Console.WriteLine(@"
Which airplane do you want to travel with?
- Airbus 330
- Boeing 787
- Boeing 737");

        List<string> PlaneFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.Airplane.Model == PlaneAnswer)
            {
                PlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane}\nDeparting from: {flight.DepartingFrom}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (PlaneFlights.Count > 0){

            Console.WriteLine($"Found {PlaneFlights.Count} flights with Airplane: {PlaneAnswer}:");

        foreach (var pompington in PlaneFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        }
        return;
    }
}