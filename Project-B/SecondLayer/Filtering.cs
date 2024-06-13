using System.Net;
using MimeKit.Cryptography;
using Org.BouncyCastle.Asn1.Cms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

public static class Filtering
{
    public static List<string> filtorSort(string destination01, string destination02, string input01, string input02, string planeAnswer01, string planeAnswer02, string planeAnswer03, string maxPrice, List<Flight> flights)
    {
        List<string> Empty = new List<string>();
        DateTime departureDateInput01;
        DateTime departureDateInput02;
        if (destination02 != "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAll01(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, flights);
                }
            }
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAll02(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, flights);
                }
            }
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAll03(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, planeAnswer03, flights);
                }
            }
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAll10(destination01, destination02, departureDateInput01, departureDateInput02, flights);
                }
            }
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            return Filtering.filtorAll21(destination01, destination02, planeAnswer01, flights);
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice == "")
        {
            return Filtering.filtorAll22(destination01, destination02, planeAnswer01, planeAnswer02, flights);
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice == "")
        {
            return Filtering.filtorAll23(destination01, destination02, planeAnswer01, planeAnswer02, planeAnswer03, flights);
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAll31(departureDateInput01, departureDateInput02, planeAnswer01, flights);
                }
            }
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAll32(departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, flights);
                }
            }
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAll33(departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, planeAnswer03, flights);
                }
            }
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            return Filtering.Destination(destination01, destination02, flights);
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.Time(departureDateInput01, departureDateInput02, flights);
                }
            }
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice == "")
        {
            return Filtering.Airline(planeAnswer01, flights);
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice == "")
        {
            return Filtering.Airline(planeAnswer01, planeAnswer02, flights);
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice == "")
        {
            return Filtering.Airline(planeAnswer01, planeAnswer02, planeAnswer03, flights);
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
                    return Filtering.filtorAllprice01(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, maxPrice, flights);
                }
            }
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAllprice02(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, maxPrice, flights);
                }
            }
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAllprice03(destination01, destination02, departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, planeAnswer03, maxPrice, flights);
                }
            }
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            return Filtering.filtorAllprice11(destination01, destination02, planeAnswer01, maxPrice, flights);
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice != "")
        {
            return Filtering.filtorAllprice12(destination01, destination02, planeAnswer01, planeAnswer02, maxPrice, flights);
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice != "")
        {
            return Filtering.filtorAllprice13(destination01, destination02, planeAnswer01, planeAnswer02, planeAnswer03, maxPrice, flights);
        }

        else if (destination02 != "" && input02 != "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAllprice21(destination01, destination02, departureDateInput01, departureDateInput02, maxPrice, flights);
                }
            }
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAllprice31(departureDateInput01, departureDateInput02, planeAnswer01, maxPrice, flights);
                }
            }
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAllprice32(departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, maxPrice, flights);
                }
            }
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.filtorAllprice33(departureDateInput01, departureDateInput02, planeAnswer01, planeAnswer02, planeAnswer03, maxPrice, flights);
                }
            }
        }

        else if (destination02 != "" && input02 == "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            return Filtering.DestinationPrice(destination01, destination02, maxPrice, flights);
        }

        else if (destination02 == "" && input02 != "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            if (DateTime.TryParseExact(input01, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput01))
            {
                if (DateTime.TryParseExact(input02, "dd-MM-yyyy", null, DateTimeStyles.None, out departureDateInput02))
                {
                    return Filtering.TimePrice(departureDateInput01, departureDateInput02, maxPrice, flights);
                }
            }
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            return Filtering.AirlinePrice(planeAnswer01, maxPrice, flights);
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 == "" && maxPrice != "")
        {
            return Filtering.AirlinePrice(planeAnswer01, planeAnswer02, maxPrice, flights);
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 != "" && planeAnswer02 != "" && planeAnswer03 != "" && maxPrice != "")
        {
            return Filtering.AirlinePrice(planeAnswer01, planeAnswer02, planeAnswer03, maxPrice, flights);
        }

        else if (destination02 == "" && input02 == "" && planeAnswer01 == "" && planeAnswer02 == "" && planeAnswer03 == "" && maxPrice != "")
        {
            return Filtering.Price(maxPrice, flights);
        }

        return Empty;
    }

    public static List<string> filtorAll01(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAll02(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAll03(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAll10(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02)
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> filtorAll21(string destination01, string destination02, string PlaneAnswer01, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> filtorAll22(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase)))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }
    
    public static List<string> filtorAll23(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer03, StringComparison.OrdinalIgnoreCase)))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> filtorAll31(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> filtorAll32(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                            && datetimeDate >= departureDateInput01
                            && datetimeDate <= departureDateInput02
                            && (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                                || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase)))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> filtorAll33(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAllprice01(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string maxPrice, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAllprice02(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string maxPrice, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAllprice03(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAllprice11(string destination01, string destination02, string PlaneAnswer01, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                            && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                            && flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                            && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> filtorAllprice12(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, string maxPrice, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAllprice13(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAllprice21(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string maxPrice, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAllprice31(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string maxPrice, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAllprice32(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string maxPrice, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> filtorAllprice33(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
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

        return filteredFlights;
    }

    public static List<string> DestinationPrice(string destination01, string destination02, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.Equals(destination01, StringComparison.OrdinalIgnoreCase)
                        && flight.Destination.Equals(destination02, StringComparison.OrdinalIgnoreCase)
                        && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> AirlinePrice(string PlaneAnswer01, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase)
                        && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> AirlinePrice(string PlaneAnswer01, string PlaneAnswer02, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase))
                        && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> AirlinePrice(string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => (flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer03, StringComparison.OrdinalIgnoreCase))
                        && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> TimePrice(DateTime departureDateInput01, DateTime departureDateInput02, string maxPrice,List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                        && datetimeDate >= departureDateInput01 && datetimeDate <= departureDateInput02
                        && flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> Price(string maxPrice, List<Flight> flights)
    {
        int maxPriceValue = int.Parse(maxPrice);

        var filteredFlights = flights
            .Where(flight => flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> Destination(string destination01, string destination02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower())
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> Time(DateTime departureDateInput01, DateTime departureDateInput02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => DateTime.TryParseExact(flight.DepartureDate, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime datetimeDate)
                        && datetimeDate >= departureDateInput01 && datetimeDate <= departureDateInput02)
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\n Departure date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> Airline(string PlaneAnswer01, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> Airline(string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }

    public static List<string> Airline(string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
    {
        var filteredFlights = flights
            .Where(flight => flight.Airplane.Model.Equals(PlaneAnswer01, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer02, StringComparison.OrdinalIgnoreCase) || flight.Airplane.Model.Equals(PlaneAnswer03, StringComparison.OrdinalIgnoreCase))
            .Select(flight => $"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}")
            .ToList();

        return filteredFlights;
    }
}