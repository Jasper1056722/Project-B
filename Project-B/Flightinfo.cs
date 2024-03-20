using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


public class Flightinfo
{

    public static string jsonString = File.ReadAllText("flights.json");
    public static Dictionary<string, Dictionary<string, string>> nestedDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonString);
    public static Dictionary<string, string> Getinfo(string number)
    {

        var flightinfo = nestedDictionary[number];
        return flightinfo;

    }

    public static string Printinfo(Dictionary<string,string> flight)
    {
        string text = "";
        foreach (var innerKvp in flight)
        {
            string tekst = $"{innerKvp.Key}: {innerKvp.Value}\n";
            text = text + tekst;
        }

        return text;
    }

    public static void UpdateInfo(string flightNumber)
    {
        if (nestedDictionary.ContainsKey(flightNumber))
        {
            Console.WriteLine("Current flight data: "); //print current flight info,  maybe redundant? remove?
            Console.WriteLine($"Destination: {nestedDictionary[flightNumber]["Destination"]}");
            Console.WriteLine($"Country: {nestedDictionary[flightNumber]["Country"]}");
            Console.WriteLine($"Airplane: {nestedDictionary[flightNumber]["Airplane"]}");
            Console.WriteLine($"Departing from: {nestedDictionary[flightNumber]["Departing from"]}");
            Console.WriteLine($"Date: {nestedDictionary[flightNumber]["Date"]}");
            Console.WriteLine($"Departure time: {nestedDictionary[flightNumber]["Departure time"]}");
            Console.WriteLine($"Estimated time of arrival: {nestedDictionary[flightNumber]["Estimated time of Arrival"]}");
            Console.WriteLine($"\nSelect the detail you want to edit: "); //edit detail menu
            Console.WriteLine("1. Destination");
            Console.WriteLine("2. Country");
            Console.WriteLine("3. Airplane");
            Console.WriteLine("4. Departing from");
            Console.WriteLine("5. Date");
            Console.WriteLine("6. Departure time");
            Console.WriteLine("7. Estimated time of Arrival");
            Console.Write("Enter your choice (1-7): ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                Console.WriteLine("Enter new destination: ");
                string Destination = Console.ReadLine();
                nestedDictionary[flightNumber]["Destination"] = Destination;
                Console.WriteLine($"Destination updated to {nestedDictionary[flightNumber]["Destination"]}");
                break;
            case 2:
                Console.WriteLine("Enter new country: ");
                string Country = Console.ReadLine();
                nestedDictionary[flightNumber]["Country"] = Country;
                Console.WriteLine($"Country updated to {nestedDictionary[flightNumber]["Country"]}");
                break;
            case 3:
                Console.WriteLine("Enter new airplane: ");
                string Airplane = Console.ReadLine();
                nestedDictionary[flightNumber]["Airplane"] = Airplane;
                Console.WriteLine($"Airplane updated to {nestedDictionary[flightNumber]["Airplane"]}");
                break;
            case 4:
                Console.WriteLine("Enter new departing from: ");
                string DepartingFrom = Console.ReadLine();
                nestedDictionary[flightNumber]["Departing from"] = DepartingFrom;
                Console.WriteLine($"Departing from updated to {nestedDictionary[flightNumber]["Departing from"]}");
                break;
            case 5:
                Console.WriteLine("Enter new date: ");
                string Date = Console.ReadLine();
                nestedDictionary[flightNumber]["Date"] = Date;
                Console.WriteLine($"Date updated to {nestedDictionary[flightNumber]["Date"]}");
                break;
            case 6:
                Console.WriteLine("Enter new departure time: ");
                string DepartureTime = Console.ReadLine();
                nestedDictionary[flightNumber]["Departure time"] = DepartureTime;
                Console.WriteLine($"Departure time updated to {nestedDictionary[flightNumber]["Departure time"]}");
                break;
            case 7:
                Console.WriteLine("Enter new estimated time of arrival: ");
                string EstimatedTimeOfArrival = Console.ReadLine();
                nestedDictionary[flightNumber]["Estimated time of Arrival"] = EstimatedTimeOfArrival;
                Console.WriteLine($"Estimated time of Arrival updated to {nestedDictionary[flightNumber]["Estimated time of Arrival"]}");
                break;
            default:
                Console.WriteLine("Invalid choice");
                return;
            }

            string updatedJson = JsonConvert.SerializeObject(nestedDictionary, Formatting.Indented);
            File.WriteAllText("flights.json", updatedJson);
            Console.WriteLine("Flight information updated successfully.");
        }
        else
        {
            Console.WriteLine($"Flight with number {flightNumber} not found.");
        }
    }

    public static void FlightAdd()
    {
        Console.WriteLine("Please enter the date(DD-MM-YYYY)");
        string date = Console.ReadLine();
        while (string.IsNullOrEmpty(date))
        {
            Console.WriteLine("Please enter the date(DD-MM-YYYY)");
            date = Console.ReadLine();
        }

        Console.WriteLine("Please enter the Destination");
        string Destination = Console.ReadLine();
        while (string.IsNullOrEmpty(Destination))
        {
            Console.WriteLine("Please enter the Destination");
            Destination = Console.ReadLine();
        }

        Console.WriteLine("Please enter the Country");
        string Country = Console.ReadLine();
        while (string.IsNullOrEmpty(Country))
        {
            Console.WriteLine("Please enter the Country");
            Country = Console.ReadLine();
        }

        Console.WriteLine("Please enter the Airplane");
        string Airplane = Console.ReadLine();
        while (string.IsNullOrEmpty(Airplane))
        {
            Console.WriteLine("Please enter the Airplane");
            Airplane = Console.ReadLine();
        }

        Console.WriteLine("Please enter the Departure Time (HH:MM:SS)");
        string DepartureTime = Console.ReadLine();
        while (string.IsNullOrEmpty(DepartureTime))
        {
            Console.WriteLine("Please enter the Departure Time (HH:MM:SS)");
            DepartureTime = Console.ReadLine();
        }

        Console.WriteLine("Please enter the Estimated Time of Arrival (HH:MM:SS)");
        string ArrivalTime = Console.ReadLine();
        while (string.IsNullOrEmpty(ArrivalTime))
        {
            Console.WriteLine("Please enter the Estimated Time of Arrival (HH:MM:SS)");
            ArrivalTime = Console.ReadLine();
        }

        Dictionary<string, string> flight = new Dictionary<string, string>();
        flight.Add("Destination", Destination);
        flight.Add("Country", Country);
        flight.Add("Airplane", Airplane);
        flight.Add("Departing from", "Rotterdam");
        flight.Add("Date", date);
        flight.Add("Departure time", DepartureTime);
        flight.Add("Estimated time of Arrival", ArrivalTime);

        nestedDictionary.Add("12345678", flight);
    }


}