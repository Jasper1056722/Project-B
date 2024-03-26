public class Flight
{
    public int FlightNumber { get; set; }
    public string Destination { get; set; }
    public string Country { get; set; }
    public Plane Airplane { get; set; }
    public string DepartingFrom { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime EstimatedTimeofArrival { get; set; }

    public Flight(int flightNumber, string destination, string country, Plane airplane, string departingFrom, string departureDate, string estimatedTimeOfArrival)
    {
        FlightNumber = flightNumber;
        Destination = destination;
        Country = country;
        Airplane = airplane;
        DepartingFrom = departingFrom;
        DepartureDate = DateTime.ParseExact(departureDate, "dd-MM-yyyy HH:mm:ss", null);
        EstimatedTimeofArrival = DateTime.ParseExact(estimatedTimeOfArrival, "dd-MM-yyyy HH:mm:ss", null);
    }
}