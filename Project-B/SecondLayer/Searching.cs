using System.Net;
using MimeKit.Cryptography;
using Org.BouncyCastle.Asn1.Cms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class Searching
{
    public static List<string> Destination(string destinat, List<Flight> flights)
    {
        List<string> DestinationFlights = new List<string>();

        foreach (Flight flight in flights)
        {
            if (flight.Destination.ToLower() == destinat.ToLower())
            {
                DestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        return DestinationFlights;
    }

    public static List<string> FlightNumber(string flightnumber, List<Flight> flights)
    {
        List<string> NumFlights = new List<string>();

        foreach (Flight flight in flights)
        {
            if (flight.FlightNumber.ToString() == flightnumber)
            {
                NumFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        return NumFlights;
    }

    public static List<string> Time(string departureDateInput, List<Flight> flights)
    {
        List<string> DateFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.DepartureDate == departureDateInput)
            {
                DateFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        return DateFlights;
    }

    public static List<string> Airline(string PlaneAnswer, List<Flight> flights)
    {

        List<string> PlaneFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.Airplane.Model.ToLower() == PlaneAnswer.ToLower())
            {
                PlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        return PlaneFlights;
    }
}