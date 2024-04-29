using System.Net;
using MimeKit.Cryptography;
using Org.BouncyCastle.Asn1.Cms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

public static class Filtering
{
    public static void filtorAll01(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        FilterDestinationFlights.Clear();
        return;
    }

    public static void filtorAll02(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
                if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        FilterDestinationFlights.Clear();
        return;
    }

    public static void filtorAll03(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
                if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
                if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer02)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        FilterDestinationFlights.Clear();
        return;
    }

    public static void filtorAll10(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        FilterDestinationFlights.Clear();
        return;
    }

    public static void filtorAll21(string destination01, string destination02, string PlaneAnswer01, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
            {
                FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        FilterDestinationFlights.Clear();
        return;
    }

    public static void filtorAll22(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
            {
                FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
            if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
            {
                FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        FilterDestinationFlights.Clear();
        return;
    }
    
    public static void filtorAll23(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
                if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
                if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
                if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02 && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer02)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        FilterDestinationFlights.Clear();
        return;
    }

    public static void filtorAll31(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        FilterDestinationFlights.Clear();
        return;
    }

    public static void filtorAll32(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        FilterDestinationFlights.Clear();
        return;
    }

    public static void filtorAll33(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer02)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        FilterDestinationFlights.Clear();
        return;
    }

    public static void Destination(string destination01, string destination02, List<Flight> flights)
    {
        List<string> FilterDestinationFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.DepartingFrom.ToLower() == destination01 && flight.Destination.ToLower() == destination02)
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
        List<string> FilterDateFlights = new List<string>();

        foreach (var flight in flights)
        {   
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02)
                {
                    FilterDateFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\n Departure date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
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



                                    Console.WriteLine("Fill in all the filters you want to filter for (leave blank if not):");
                                    string destination01 = Menu.GetString("Departing from: ").ToLower;
                                    string destination02 = Menu.GetString("Arriving at: ").ToLower();
                                    DateTime input01;
                                    string departureDateInput01 = Menu.GetString("First date (DD-MM-YYYY): ");
                                    DateTime input02;
                                    string departureDateInput02 = Menu.GetString("Second date: ");
                                    string planeAnswer01 = Menu.GetString("Airline 1 (Airbus 330, Boeing 787, Boeing 737): ").ToLower;
                                    string planeAnswer02 = Menu.GetString("Airline 1 (Airbus 330, Boeing 787, Boeing 737): ").ToLower;
                                    string planeAnswer03 = Menu.GetString("Airline 1 (Airbus 330, Boeing 787, Boeing 737): ").ToLower;

                                    if (destination02 != null && input02 != null && planeAnswer01 != null && planeAnswer02 == null && planeAnswer03 == null)
                                    {
                                        if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
                                        {
                                            if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                                            {
                                                Filtering.filtorAll01(destination01, destination02, departureDateInput01, departureDateInput02, PlaneAnswer01, flights)
                                            }
                                        }
                                    }
                                    if (destination02 != null && input02 != null && planeAnswer01 != null && planeAnswer02 != null && planeAnswer03 == null)
                                    {
                                        if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
                                        {
                                            if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                                            {
                                                Filtering.filtorAll02(destination01, destination02, departureDateInput01, departureDateInput02, PlaneAnswer01, PlaneAnswer02, flights)
                                            }
                                        }
                                    }
                                    if (destination02 != null && input02 != null && planeAnswer01 != null && planeAnswer02 != null && planeAnswer03 != null)
                                    {
                                        if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
                                        {
                                            if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                                            {
                                                Filtering.filtorAll03(destination01, destination02, departureDateInput01, departureDateInput02, PlaneAnswer01, PlaneAnswer02, planeAnswer03, flights)
                                            }
                                        }
                                    }
                                    if (destination02 != null && input02 != null && planeAnswer01 == null && planeAnswer02 == null && planeAnswer03 == null)
                                    {
                                        if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
                                        {
                                            if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                                            {
                                                Filtering.filtorAll10(destination01, destination02, departureDateInput01, departureDateInput02, flights)
                                            }
                                        }
                                    }
                                    if (destination02 != null && input02 == null && planeAnswer01 != null && planeAnswer02 == null && planeAnswer03 == null)
                                    {
                                        Filtering.filtorAll21(destination01, destination02, planeAnswer01, flights)
                                    }
                                    if (destination02 != null && input02 == null && planeAnswer01 != null && planeAnswer02 != null && planeAnswer03 == null)
                                    {
                                        Filtering.filtorAll22(destination01, destination02, planeAnswer01, planeAnswer02, flights)
                                    }
                                    if (destination02 != null && input02 == null && planeAnswer01 != null && planeAnswer02 != null && planeAnswer03 != null)
                                    {
                                        Filtering.filtorAll23(destination01, destination02, planeAnswer01, planeAnswer02, planeAnswer03, flights)
                                    }
                                    if (destination02 == null && input02 != null && planeAnswer01 != null && planeAnswer02 == null && planeAnswer03 == null)
                                    {
                                        if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
                                        {
                                            if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                                            {
                                                Filtering.filtorAll31(departureDateInput01, departureDateInput02, planeAnswer01, flights)
                                            }
                                        }
                                    }
                                    if (destination02 == null && input02 != null && planeAnswer01 != null && planeAnswer02 != null && planeAnswer03 == null)
                                    {
                                        if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
                                        {
                                            if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                                            {
                                                Filtering.filtorAll32(departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, flights)
                                            }
                                        }
                                    }
                                    if (destination02 == null && input02 != null && planeAnswer01 != null && planeAnswer02 != null && planeAnswer03 != null)
                                    {
                                        if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
                                        {
                                            if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                                            {
                                                Filtering.filtorAll33(departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, planeAnswer03, flights)
                                            }
                                        }
                                    }
                                    if (destination02 != null && input02 == null && planeAnswer01 == null && planeAnswer02 == null && planeAnswer03 == null)
                                    {
                                        Filtering.Destination(destination01, destination02, flights)
                                    }
                                    if (destination02 == null && input02 != null && planeAnswer01 == null && planeAnswer02 == null && planeAnswer03 == null)
                                    {
                                        if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
                                        {
                                            if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                                            {
                                                Filtering.Time(departureDateInput01, departureDateInput02, flights)
                                            }
                                        }
                                    }
                                    if (destination02 == null && input02 == null && planeAnswer01 != null && planeAnswer02 == null && planeAnswer03 == null)
                                    {
                                        Filtering.Time(planeAnswer01, flights)
                                    }
                                    if (destination02 == null && input02 == null && planeAnswer01 != null && planeAnswer02 != null && planeAnswer03 == null)
                                    {
                                        Filtering.Time(planeAnswer01, planeAnswer02, flights)
                                    }
                                    if (destination02 == null && input02 == null && planeAnswer01 != null && planeAnswer02 != null && planeAnswer03 != null)
                                    {
                                        Filtering.Time(planeAnswer01, planeAnswer02, planeAnswer03, flights)
                                    }
                                    if (destination02 == null && input02 == null && planeAnswer01 == null && planeAnswer02 == null && planeAnswer03 == null)
                                    {
                                        Console.WriteLine("You can't filter for nothing")
                                    }