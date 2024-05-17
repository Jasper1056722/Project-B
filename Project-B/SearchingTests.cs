using System;
using System.Collections.Generic;

public static class SearchingTests
{
    public static void RunTests()
    {
        List<Flight> flights = Flight.LoadJson();
        int flightnumber = 1111111;
        string destination = "Test";
        string departureDate = "11-11-1111";
        string airplane = "Testbus 3000";

        TestDestination(destination, flights);
        TestFlightNumber(flightnumber.ToString(), flights);
        TestTime(departureDate, flights);
        TestAirline(airplane, flights);
    }

    private static void TestDestination(string destination, List<Flight> flights)
    {
        Console.WriteLine("Testing Destination Search...");
        List<string> expected = new List<string>
        {
            $"Found 1 flights to {destination}:\n",
            $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n"
        };

        TestOutput(Searching.Destination, destination, flights, expected);
    }

    private static void TestFlightNumber(string flightNumber, List<Flight> flights)
    {
        Console.WriteLine("Testing Flight Number Search...");
        List<string> expected = new List<string>
        {
            $"Found 1 flights to {flightNumber}:\n",
            $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n"
        };

        TestOutput(Searching.FlightNumber, flightNumber, flights, expected);
    }

    private static void TestTime(string departureDate, List<Flight> flights)
    {
        Console.WriteLine("Testing Time Search...");
        List<string> expected = new List<string>
        {
            $"Found 1 flights departing on: {departureDate}:\n",
            $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n"
        };

        TestOutput(Searching.Time, departureDate, flights, expected);
    }

    private static void TestAirline(string airplane, List<Flight> flights)
    {
        Console.WriteLine("Testing Airline Search...");
        List<string> expected = new List<string>
        {
            $"Found 1 flights with Airplane: {airplane}:\n",
            $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n"
        };

        TestOutput(Searching.Airline, airplane, flights, expected);
    }

    private static void TestOutput(Action<string, List<Flight>> searchMethod, string parameter, List<Flight> flights, List<string> expectedOutput)
    {
        // Redirect Console output
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);

        // Call search method
        searchMethod(parameter, flights);

        // Capture Console output
        string[] lines = consoleOutput.ToString().Trim().Split("\r\n");

        // Compare output
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

        // Print test result
        if (success)
            Console.WriteLine("Test Passed\n");
        else
        {
            Console.WriteLine("Test Failed\n");
            Console.WriteLine("Expected Output:");
            foreach (var line in expectedOutput)
                Console.WriteLine(line);
            Console.WriteLine("\nActual Output:");
            foreach (var line in lines)
                Console.WriteLine(line);
            Console.WriteLine();
        }
    }
}
