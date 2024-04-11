using System.Net;
using MimeKit.Cryptography;
using Org.BouncyCastle.Asn1.Cms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class Filtering
{
    public static void Destination(string destination01, string destination02, List<Flight> flights)
    {
        List<string> FilterDestinationFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02)
            {
                FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
            if (flight.DepartingFrom.ToLower() == destination02 && flight.Destination.ToLower() == destination01)
            {
                FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in FilterDestinationFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        FilterDestinationFlights.Clear();
        return;
    }

    public static void Time(DateTime departureDateInput01, DateTime departureDateInput02, List<Flight> flights)
    {
        Console.WriteLine("Enter the departure date (dd-mm-yyyy):");

        List<string> FilterDateFlights = new List<string>();

        foreach (var flight in flights)
        {
            DateTime DatetimeDate = Convert.ToDateTime(flight.DepartureDate);

            if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02)
            {
                FilterDateFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\n Departure date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (FilterDateFlights.Count > 0){

            Console.WriteLine($"Found {FilterDateFlights.Count} flights departing between: {departureDateInput01} and {departureDateInput02}");

        foreach (var pettington in FilterDateFlights)
        {
            Console.WriteLine(pettington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing between: {departureDateInput01} and {departureDateInput02}");}

        FilterDateFlights.Clear();
        return;
    }

    public static void Airline(string PlaneAnswer01, List<Flight> flights)
    {

        List<string> FilterPlaneFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.Airplane.Model.ToLower() == PlaneAnswer01)
            {
                FilterPlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (FilterPlaneFlights.Count > 0){

            Console.WriteLine($"Found {FilterPlaneFlights.Count} flights with Airplane: {PlaneAnswer01}:");

        foreach (var pompington in FilterPlaneFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing with: {PlaneAnswer01}");}

        FilterPlaneFlights.Clear();
        return;
    }

    public static void Airline(string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {

        List<string> FilterPlaneFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.Airplane.Model.ToLower() == PlaneAnswer01)
            {
                FilterPlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
            if (flight.Airplane.Model.ToLower() == PlaneAnswer02)
            {
                FilterPlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (FilterPlaneFlights.Count > 0){

            Console.WriteLine($"Found {FilterPlaneFlights.Count} flights with Airplane: {PlaneAnswer01} and {PlaneAnswer02}:");

        foreach (var pompington in FilterPlaneFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing with: {PlaneAnswer01} and {PlaneAnswer02}");}

        FilterPlaneFlights.Clear();
        return;
    }

    public static void Airline(string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
    {

        List<string> FilterPlaneFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.Airplane.Model.ToLower() == PlaneAnswer01)
            {
                FilterPlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
            if (flight.Airplane.Model.ToLower() == PlaneAnswer02)
            {
                FilterPlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
            if (flight.Airplane.Model.ToLower() == PlaneAnswer03)
            {
                FilterPlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (FilterPlaneFlights.Count > 0){

            Console.WriteLine($"Found {FilterPlaneFlights.Count} flights with Airplane: {PlaneAnswer01}, {PlaneAnswer02} and {PlaneAnswer03}:");

        foreach (var pompington in FilterPlaneFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing with: {PlaneAnswer01}, {PlaneAnswer02} and {PlaneAnswer03}");}

        FilterPlaneFlights.Clear();
        return;
    }
}