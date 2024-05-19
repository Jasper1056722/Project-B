namespace Project_Btest;

[TestClass]
public class Project_Btest
{
    [TestMethod]
    public void TestSearching()
    {
        List<Flight> flights = Flight.LoadJson();
        int flightnumber = 1111111;
        string destination = "Test";
        string departureDate = "11-11-1111";
        string airplane = "Testbus 3000";

        string Trost01 = TestDestination(destination, flights);
        string Trost02 = TestFlightNumber(flightnumber.ToString(), flights);
        string Trost03 = TestTime(departureDate, flights);
        string Trost04 = TestAirline(airplane, flights);

        Assert.AreEqual("Passed", Trost01);
        Assert.AreEqual("Passed", Trost02);
        Assert.AreEqual("Passed", Trost03);
        Assert.AreEqual("Passed", Trost04);
    }

    [TestMethod]
    public void ==Test Method==() // vul iets in tussen de ==
    {
        
    }









    public static string TestDestination(string destination, List<Flight> flights)
    {
        Console.WriteLine("Testing Destination Search...");
        List<string> expected = new List<string>
        {
            $"Found 1 flights to {destination}:\n",
            $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n"
        };

        return TestOutput(Searching.Destination, destination, flights, expected);
    }

    public static string TestFlightNumber(string flightNumber, List<Flight> flights)
    {
        Console.WriteLine("Testing Flight Number Search...");
        List<string> expected = new List<string>
        {
            $"Found 1 flights to {flightNumber}:\n",
            $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n"
        };

        return TestOutput(Searching.FlightNumber, flightNumber, flights, expected);
    }

    public static string TestTime(string departureDate, List<Flight> flights)
    {
        Console.WriteLine("Testing Time Search...");
        List<string> expected = new List<string>
        {
            $"Found 1 flights departing on: {departureDate}:\n",
            $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n"
        };

        return TestOutput(Searching.Time, departureDate, flights, expected);
    }

    public static string TestAirline(string airplane, List<Flight> flights)
    {
        Console.WriteLine("Testing Airline Search...");
        List<string> expected = new List<string>
        {
            $"Found 1 flights with Airplane: {airplane}:\n",
            $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n"
        };

        return TestOutput(Searching.Airline, airplane, flights, expected);
    }

    public static string TestOutput(Action<string, List<Flight>> searchMethod, string parameter, List<Flight> flights, List<string> expectedOutput)
    {
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);

        searchMethod(parameter, flights);

        string[] lines = consoleOutput.ToString().Trim().Split("\r\n");

        bool success = true;
        if (lines.Length != expectedOutput.Count)
            success = false;
        else
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != expectedOutput[i])
                {
                    success = false;
                    break;
                }
            }
        }

        return success ? "Passed" : "Failed";
        
    }
}