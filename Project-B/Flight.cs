public class Flight
{
    public int FlightNumber;
    public string Destination;
    public string Country;
    public Plane Airplane;
    public string DepartingFrom;
    public DateTime DepartureDate;
    public DateTime EstimatedTimeofArrival;

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