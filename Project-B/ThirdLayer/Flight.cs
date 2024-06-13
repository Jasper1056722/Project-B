using Newtonsoft.Json;

public class Flight : IEquatable<Flight>, IComparable<Flight>, IFlight
{
    public int FlightNumber { get; set; }
    public string Destination { get; set; }
    public string Country { get; set; }

    public string DepartingFrom { get; set; }
    public string DepartureDate { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime EstimatedTimeofArrival { get; set; }
    public Plane Airplane { get; set; }
    
    [JsonConstructor]
    public Flight(string destination, string country, Plane airplane, string departingFrom, string departureDate, string departureTime, string estimatedTimeOfArrival)
    {
        Random random = new Random();
        FlightNumber = random.Next(1000000,9999999);
        Destination = destination;
        Country = country;
        Airplane = airplane;
        DepartingFrom = departingFrom;
        DepartureDate = departureDate;

        try
        {
            EstimatedTimeofArrival = DateTime.ParseExact(estimatedTimeOfArrival, "dd-MM-yyyyTHH:mm:ss", null);
        }
        catch (FormatException)
        {
            EstimatedTimeofArrival = DateTime.MinValue;
        }

        try
        {
            DepartureTime = DateTime.ParseExact(departureTime, "dd-MM-yyyyTHH:mm:ss", null);
        }
        catch (FormatException)
        {
            DepartureTime = DateTime.MinValue;
        }
    }

    public Flight(string destination, string country, Plane airplane, string departingFrom, string departureDate, string departureTime, string estimatedTimeOfArrival, int flightNumber)
    {
        Random random = new Random();
        FlightNumber = flightNumber;
        Destination = destination;
        Country = country;
        Airplane = airplane;
        DepartingFrom = departingFrom;
        DepartureDate = departureDate;

        try
        {
            EstimatedTimeofArrival = DateTime.ParseExact(estimatedTimeOfArrival, "dd-MM-yyyyTHH:mm:ss", null);
        }
        catch (FormatException)
        {
            EstimatedTimeofArrival = DateTime.MinValue;
        }

        try
        {
            DepartureTime = DateTime.ParseExact(departureTime, "dd-MM-yyyyTHH:mm:ss", null);
        }
        catch (FormatException)
        {
            DepartureTime = DateTime.MinValue;
        }
    }

    public static List<Flight> LoadJson()
    {
        try
        {
            string json = File.ReadAllText("flightObject.json");
            List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(json);
            return flights;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while loading JSON: " + ex.Message);
            return new List<Flight>(); // if an error occurs we will just use an empty list
        }
    }

    public static void WriteToJson(List<Flight> flights)
    {
        try
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                DateFormatString = "dd-MM-yyyyTHH:mm:ss",
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(flights, settings);
            File.WriteAllText("flightObject.json", json);
        }
        catch (Exception ex)
        {
            //when it fails it just wont write to the json
            Console.WriteLine("An error occurred while writing to JSON: " + ex.Message);
        }
    }

    public bool IsFlightFull()
    {
        foreach (Seat seat in Airplane.Seats)
        {
            if (seat.PersonInSeat == null)
            {
                return false;
            }
        }
        return true;
    }

    public bool Equals(Flight flight)
    {
        if(flight is null)
        {
            return false;
        }
        else if(FlightNumber == flight.FlightNumber && DepartureDate == flight.DepartureDate && Destination == flight.Destination)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool Equals(object? obj)
    {
        if(obj is Flight flight) return Equals(flight);
        return false;
    }

    public int CompareTo(Flight other)
    {
        if(other is null) return 1;
        return Destination.CompareTo(other.Destination);
    }

    public static bool operator ==(Flight flight1, Flight flight2)
    {
        if(flight1 is null && flight2 is null)
        {
            return true;
        }
        else if(flight1 is null || flight2 is null)
        {
            return false;
        }
        return flight1.Equals(flight2);
    }

    public static bool operator !=(Flight flight, Flight flight2)
    {
        return !(flight == flight2);
    }


}