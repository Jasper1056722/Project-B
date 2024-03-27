class Program
{
    static void Main()
    {
        Plane plane = new("Boeing 737");
        List<Flight> flights = new List<Flight>
        {

        };
        flights = Flight.LoadJson();

        foreach(Flight flight in flights)
        {
            Console.WriteLine(flight.DepartingFrom);
        }

        
    }
}