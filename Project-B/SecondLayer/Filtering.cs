using System.Net;
using MimeKit.Cryptography;
using Org.BouncyCastle.Asn1.Cms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

public static class Filtering
{
    public static void filtorSort(string destination01, string destination02, string input01, string input02, string planeAnswer01, string planeAnswer02, string planeAnswer03, string maxPrice, List<Flight> flights)
    {
        DateTime departureDateInput01;
        DateTime departureDateInput02;
        if (destination02 != "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAll01(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, flights);
                }
            }
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAll02(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, flights);
                }
            }
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAll03(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, planeAnswer03, flights);
                }
            }
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAll10(destination01, destination02, departureDateInput01, departureDateInput02, flights);
                }
            }
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            Filtering.filtorAll21(destination01, destination02, planeAnswer01, flights);
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice == "")
        {
            Filtering.filtorAll22(destination01, destination02, planeAnswer01, planeAnswer02, flights);
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice == "")
        {
            Filtering.filtorAll23(destination01, destination02, planeAnswer01, planeAnswer02, planeAnswer03, flights);
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAll31(departureDateInput01, departureDateInput02, planeAnswer01, flights);
                }
            }
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAll32(departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, flights);
                }
            }
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAll33(departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, planeAnswer03, flights);
                }
            }
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            Filtering.Destination(destination01, destination02, flights);
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.Time(departureDateInput01, departureDateInput02, flights);
                }
            }
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            Filtering.Airline(planeAnswer01, flights);
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice == "")
        {
            Filtering.Airline(planeAnswer01, planeAnswer02, flights);
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice == "")
        {
            Filtering.Airline(planeAnswer01, planeAnswer02, planeAnswer03, flights);
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            Console.WriteLine("You can't filter for nothing");
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAllprice01(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, maxPrice, flights);
                }
            }
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAllprice02(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, maxPrice, flights);
                }
            }
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAllprice03(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, planeAnswer03, maxPrice, flights);
                }
            }
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            Filtering.filtorAllprice11(destination01, destination02, planeAnswer01, maxPrice, flights);
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice != "")
        {
            Filtering.filtorAllprice12(destination01, destination02, planeAnswer01, planeAnswer02, maxPrice, flights);
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice != "")
        {
            Filtering.filtorAllprice13(destination01, destination02, planeAnswer01, planeAnswer02, planeAnswer03, maxPrice, flights);
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAllprice21(destination01, destination02, departureDateInput01, departureDateInput02, maxPrice, flights);
                }
            }
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAllprice31(departureDateInput01, departureDateInput02, planeAnswer01, maxPrice, flights);
                }
            }
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAllprice32(departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, maxPrice, flights);
                }
            }
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.filtorAllprice33(departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, planeAnswer03, maxPrice, flights);
                }
            }
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            Filtering.DestinationPrice(destination01, destination02, maxPrice, flights);
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    Filtering.TimePrice(departureDateInput01, departureDateInput02, maxPrice, flights);
                }
            }
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            Filtering.AirlinePrice(planeAnswer01, maxPrice, flights);
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice != "")
        {
            Filtering.AirlinePrice(planeAnswer01, planeAnswer02, maxPrice, flights);
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice != "")
        {
            Filtering.AirlinePrice(planeAnswer01, planeAnswer02, planeAnswer03, maxPrice, flights);
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            Filtering.Price(maxPrice, flights);
        }
    }







    public static void filtorAll01(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAll02(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase)))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAll03(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer03, StringComparison.OrdinalIgnoreCase)))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAll10(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02)
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAll21(string destination01, string destination02, string PlaneAnswer01, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAll22(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase)))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }
    
    public static void filtorAll23(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer03, StringComparison.OrdinalIgnoreCase)))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAll31(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAll32(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase)))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAll33(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer03, StringComparison.OrdinalIgnoreCase)))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAllprice01(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                            && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAllprice02(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase))
                            && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAllprice03(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer03, StringComparison.OrdinalIgnoreCase))
                            && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAllprice11(string destination01, string destination02, string PlaneAnswer01, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                            && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAllprice12(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase))
                            && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAllprice13(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer03, StringComparison.OrdinalIgnoreCase))
                            && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();
        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAllprice21(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out var datetimeDate)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAllprice31(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime DatetimeDate)
                            && DatetimeDate >= departureDateInput01
                            && DatetimeDate <= departureDateInput02
                            && flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                            && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAllprice32(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime DatetimeDate)
                            && DatetimeDate >= departureDateInput01
                            && DatetimeDate <= departureDateInput02
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase))
                            && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void filtorAllprice33(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime DatetimeDate)
                            && DatetimeDate >= departureDateInput01
                            && DatetimeDate <= departureDateInput02
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer03, StringComparison.OrdinalIgnoreCase))
                            && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void DestinationPrice(string destination01, string destination02, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                        && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                        && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        filteredFlights.Clear();
        return;
    }

    public static void AirlinePrice(string PlaneAnswer01, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                        && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights with Airplane: {PlaneAnswer01}:");

        foreach (var pompington in filteredFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing with: {PlaneAnswer01}");}

        filteredFlights.Clear();
        return;
    }

    public static void AirlinePrice(string PlaneAnswer01, string PlaneAnswer02, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase))
                        && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights with Airplane: {PlaneAnswer01} and {PlaneAnswer02}:");

        foreach (var pompington in filteredFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing with: {PlaneAnswer01} and {PlaneAnswer02}");}

        filteredFlights.Clear();
        return;
    }

    public static void AirlinePrice(string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer03, StringComparison.OrdinalIgnoreCase))
                        && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights with Airplane: {PlaneAnswer01}, {PlaneAnswer02} and {PlaneAnswer03}:");

        foreach (var pompington in filteredFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing with: {PlaneAnswer01}, {PlaneAnswer02} and {PlaneAnswer03}");}

        filteredFlights.Clear();
        return;
    }

    public static void TimePrice(DateTime departureDateInput01, DateTime departureDateInput02, string maxPrice,List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                        && datetimeDate >= departureDateInput01 && datetimeDate <= departureDateInput02
                        && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights departing between: {departureDateInput01} and {departureDateInput02}");

        foreach (var pettington in filteredFlights)
        {
            Console.WriteLine(pettington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing between: {departureDateInput01} and {departureDateInput02}");}

        filteredFlights.Clear();
        return;
    }

    public static void Price(string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        filteredFlights.Clear();
        return;
    }

    public static void Destination(string destination01, string destination02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower())
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights from {destination01} to {destination02}:");

        foreach (var flight in filteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found flying between: {destination01} and {destination02}");}

        filteredFlights.Clear();
        return;
    }

    public static void Time(DateTime departureDateInput01, DateTime departureDateInput02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                        && datetimeDate >= departureDateInput01 && datetimeDate <= departureDateInput02)
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\n Departure date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights departing between: {departureDateInput01} and {departureDateInput02}");

        foreach (var pettington in filteredFlights)
        {
            Console.WriteLine(pettington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing between: {departureDateInput01} and {departureDateInput02}");}

        filteredFlights.Clear();
        return;
    }

    public static void Airline(string PlaneAnswer01, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights with Airplane: {PlaneAnswer01}:");

        foreach (var pompington in filteredFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing with: {PlaneAnswer01}");}

        filteredFlights.Clear();
        return;
    }

    public static void Airline(string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights with Airplane: {PlaneAnswer01} and {PlaneAnswer02}:");

        foreach (var pompington in filteredFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing with: {PlaneAnswer01} and {PlaneAnswer02}");}

        filteredFlights.Clear();
        return;
    }

    public static void Airline(string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer03, StringComparison.OrdinalIgnoreCase))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        if (filteredFlights.Count > 0){

            Console.WriteLine($"Found {filteredFlights.Count} flights with Airplane: {PlaneAnswer01}, {PlaneAnswer02} and {PlaneAnswer03}:");

        foreach (var pompington in filteredFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found departing with: {PlaneAnswer01}, {PlaneAnswer02} and {PlaneAnswer03}");}

        filteredFlights.Clear();
        return;
    }
}