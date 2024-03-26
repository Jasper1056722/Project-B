using Newtonsoft.Json;

public class FJson
{
    public static string jsonString = File.ReadAllText("flights.json");
    public static Dictionary<string, Dictionary<string, string>> nestedDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonString);

    public static void WriteJson()
    {
        List<object> flightList = new List<object>();
        foreach (var flight in nestedDictionary)
        {
            string number = flight.Key;
            Plane plane = new Plane(flight.Value["Airplane"]);
            Console.WriteLine(number + ": " + plane);
            var flightObject = new
            {
                FlightNumber = number,
                Plane = plane
            };

            flightList.Add(flightObject);
        }

        // Serialize the list of flight objects to a JSON string
        string json = JsonConvert.SerializeObject(flightList, Formatting.Indented);

        // Write the JSON string to a file
        string filePath = "flightObject.json";
        File.WriteAllText(filePath, json);

        Console.WriteLine($"Flight details written to {filePath}");
    }
}