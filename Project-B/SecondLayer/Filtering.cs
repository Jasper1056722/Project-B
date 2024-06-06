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
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower())
                {
                    FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
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
                if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower()))
                {
                    FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
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
                if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer03.ToLower()))
                {
                    FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
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
                if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02)
                {
                    FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }

    public static void filtorAll21(string destination01, string destination02, string PlaneAnswer01, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower())
            {
                FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }

    public static void filtorAll22(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower()))
            {
                FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }
    
    public static void filtorAll23(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();

        foreach (var flight in flights)
        {
                if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer03.ToLower()))
                {
                    FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
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
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower())
                {
                    FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
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
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower()))
                {
                    FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
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
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer03.ToLower()))
                {
                    FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
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
        List<string> FilteredFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower()))
                {
                    bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                    if (seatsUnderMaxPrice)
                    {
                        FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                    }
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }

    public static void filtorAllprice03(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer03.ToLower()))
                {
                    bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                    if (seatsUnderMaxPrice)
                    {
                        FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                    }
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }

    public static void filtorAllprice11(string destination01, string destination02, string PlaneAnswer01, string maxPrice, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower())
            {
                bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                if (seatsUnderMaxPrice)
                {
                    FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }

    public static void filtorAllprice12(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, string maxPrice, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower()))
            {
                bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                if (seatsUnderMaxPrice)
                {
                    FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }

    public static void filtorAllprice13(string destination01, string destination02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer03.ToLower()))
            {
                bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                if (seatsUnderMaxPrice)
                {
                    FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }

    public static void filtorAllprice21(string destination01, string destination02, DateTime departureDateInput01, DateTime departureDateInput02, string maxPrice, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower() && DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02)
                {
                    bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                    if (seatsUnderMaxPrice)
                    {
                        FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                    }
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }

    public static void filtorAllprice31(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string maxPrice, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower())
                {
                    bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                    if (seatsUnderMaxPrice)
                    {
                        FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                    }
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }

    public static void filtorAllprice32(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string maxPrice, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower()))
                {
                    bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                    if (seatsUnderMaxPrice)
                    {
                        FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                    }
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }

    public static void filtorAllprice33(DateTime departureDateInput01, DateTime departureDateInput02, string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
    {
        List<string> FilteredFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02 && (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer03.ToLower()))
                {
                    bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                    if (seatsUnderMaxPrice)
                    {
                        FilteredFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                    }
                }
            }
        }
        if (FilteredFlights.Count > 0){

            Console.WriteLine($"Found {FilteredFlights.Count} flights:");

        foreach (var flight in FilteredFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilteredFlights.Clear();
        return;
    }

    public static void DestinationPrice(string destination01, string destination02, string maxPrice, List<Flight> flights)
    {
        List<string> FilterDestinationFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower())
            {
                bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                if (seatsUnderMaxPrice)
                {
                    FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
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

    public static void AirlinePrice(string PlaneAnswer01, string maxPrice, List<Flight> flights)
    {
        List<string> FilterPlaneFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            if (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower())
            {
                bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                if (seatsUnderMaxPrice)
                {
                    FilterPlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
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

    public static void AirlinePrice(string PlaneAnswer01, string PlaneAnswer02, string maxPrice, List<Flight> flights)
    {

        List<string> FilterPlaneFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            if (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower())
            {
                bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                if (seatsUnderMaxPrice)
                {
                    FilterPlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
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

    public static void AirlinePrice(string PlaneAnswer01, string PlaneAnswer02, string PlaneAnswer03, string maxPrice, List<Flight> flights)
    {
        List<string> FilterPlaneFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            if (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer03.ToLower())
            {
                bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                if (seatsUnderMaxPrice)
                {
                    FilterPlaneFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                }
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

    public static void TimePrice(DateTime departureDateInput01, DateTime departureDateInput02, string maxPrice,List<Flight> flights)
    {
        List<string> FilterDateFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {   
            DateTime DatetimeDate;
            string input = flight.DepartureDate;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DatetimeDate))
            {
                if (DatetimeDate >= departureDateInput01 && DatetimeDate <= departureDateInput02)
                {
                    bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
                    if (seatsUnderMaxPrice)
                    {
                        FilterDateFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
                    }
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

    public static void Price(string maxPrice, List<Flight> flights)
    {
        List<string> FilterDestinationFlights = new List<string>();
        int maxPriceValue = int.Parse(maxPrice);

        foreach (var flight in flights)
        {
            bool seatsUnderMaxPrice = flight.Airplane.Seats.Any(seat => seat.Price > 0 && seat.Price <= maxPriceValue);
            if (seatsUnderMaxPrice)
            {
                FilterDestinationFlights.Add($"Flight {flight.FlightNumber}:\nDestination: {flight.Destination}\nCountry: {flight.Country}\nAirplane: {flight.Airplane.Model}\nDeparting from: {flight.DepartingFrom}\nDeparture date: {flight.DepartureDate}\nDeparture time: {flight.DepartureTime}\nEstimated time of Arrival: {flight.EstimatedTimeofArrival}");
            }
        }
        if (FilterDestinationFlights.Count > 0){

            Console.WriteLine($"Found {FilterDestinationFlights.Count} flights:");

        foreach (var flight in FilterDestinationFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        else {Console.WriteLine($"No FLights found.");}

        FilterDestinationFlights.Clear();
        return;
    }

    public static void Destination(string destination01, string destination02, List<Flight> flights)
    {
        List<string> FilterDestinationFlights = new List<string>();

        foreach (var flight in flights)
        {
            if (flight.DepartingFrom.ToLower() == destination01.ToLower() && flight.Destination.ToLower() == destination02.ToLower())
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
            if (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower())
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
            if (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower())
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
            if (flight.Airplane.Model.ToLower() == PlaneAnswer01.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer02.ToLower() || flight.Airplane.Model.ToLower() == PlaneAnswer03.ToLower())
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