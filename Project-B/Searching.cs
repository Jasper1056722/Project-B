using System.Net;
using MimeKit.Cryptography;
using Org.BouncyCastle.Asn1.Cms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class Searching
{
    public static string jsonString = File.ReadAllText("flights.json");
    public static Dictionary<string, Dictionary<string, string>> nestedDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonString);
    public static void Destination(string destinat)
    {
        Console.WriteLine("Where do you want to travel to?");

        List<string> DestinationFlights = new List<string>();

        foreach (var flight in nestedDictionary)
        {
            var flightInfo = flight.Value;

            if (flightInfo["Destination"].ToLower() == destinat)
            {
                DestinationFlights.Add($"Flight {flight.Key}:\nDestination: {flightInfo["Destination"]}\nCountry: {flightInfo["Country"]}\nAirplane: {flightInfo["Airplane"]}\nDeparting from: {flightInfo["Departing from"]}\nDeparture time: {flightInfo["Departure time"]}\nEstimated time of Arrival: {flightInfo["Estimated time of Arrival"]}");
            }
        }
        if (DestinationFlights.Count > 0){

            Console.WriteLine($"Found {DestinationFlights.Count} flights to {destinat}:");

        foreach (var flight in DestinationFlights)
        {
            Console.WriteLine(flight);
            Console.WriteLine("");
        }
        }
        return;
    }

    public static void Time(string departureDateInput)
    {
        Console.WriteLine("Enter the departure date (dd-mm-yyyy):");

        List<string> DateFlights = new List<string>();

        foreach (var flight in nestedDictionary)
        {
            var flightInfo = flight.Value;

            string TimeDate = flightInfo["Departure time"].Split(' ')[0];
            if (TimeDate == departureDateInput)
            {
                DateFlights.Add($"Flight {flight.Key}:\nDestination: {flightInfo["Destination"]}\nCountry: {flightInfo["Country"]}\nAirplane: {flightInfo["Airplane"]}\nDeparting from: {flightInfo["Departing from"]}\nDeparture time: {flightInfo["Departure time"]}\nEstimated time of Arrival: {flightInfo["Estimated time of Arrival"]}");
            }

            if (DateFlights.Count > 0){

                Console.WriteLine($"Found {DateFlights.Count} flights departing on: {departureDateInput}:");

            foreach (var pettington in DateFlights)
            {
                Console.WriteLine(pettington);
                Console.WriteLine("");
            }
            }
        }
        return;
    }

    public static void Airline(string PlaneAnswer)
    {
        Console.WriteLine(@"
Which airplane do you want to travel with?
- Airbus 330
- Boeing 787
- Boeing 737");

        List<string> PlaneFlights = new List<string>();

        foreach (var flight in nestedDictionary)
        {
            var flightInfo = flight.Value;

            if (flightInfo["Airplane"].ToLower() == PlaneAnswer)
            {
                PlaneFlights.Add($"Flight {flight.Key}:\nDestination: {flightInfo["Destination"]}\nCountry: {flightInfo["Country"]}\nAirplane: {flightInfo["Airplane"]}\nDeparting from: {flightInfo["Departing from"]}\nDeparture time: {flightInfo["Departure time"]}\nEstimated time of Arrival: {flightInfo["Estimated time of Arrival"]}");
            }
        }
        if (PlaneFlights.Count > 0){

            Console.WriteLine($"Found {PlaneFlights.Count} flights with Airplane: {PlaneAnswer}:");

        foreach (var pompington in PlaneFlights)
        {
            Console.WriteLine(pompington);
            Console.WriteLine("");
        }
        }
        return;
    }
}