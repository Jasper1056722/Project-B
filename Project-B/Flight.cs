using Newtonsoft.Json;

public class Flight
{
    public int FlightNumber { get; set; }
    public string Destination { get; set; }
    public string Country { get; set; }

    public string DepartingFrom { get; set; }
    public string DepartureDate { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime EstimatedTimeofArrival { get; set; }
    public Plane Airplane { get; set; }

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

    public static List<Flight> LoadJson()
    {
        string json = File.ReadAllText("flightObject.json");
        List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(json);
        return flights;
    }

    public static void WriteToJson(List<Flight> flights)
    {
        string json = JsonConvert.SerializeObject(flights, Formatting.Indented);
        File.WriteAllText("flightObject.json", json);
    }
}