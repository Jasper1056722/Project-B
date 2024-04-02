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

        foreach (var flight in flights)
        {
            if (flight.Destination.ToLower() == destinat)
            {
                DestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
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
            if (flight.DepartureDate == departureDateInput)
            {
                DateFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\n Departure date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
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

        List<string> PlaneFlights = new List<string>();

        foreach (var flight in flights)
        {
            Console.WriteLine(flight.Airplane.Model);
            if (flight.Airplane.Model.ToLower() == PlaneAnswer)
            {
                PlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
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