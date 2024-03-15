using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


public class Flightinfo
{
    public static void Getinfo(string number)
    {

        try
        {
            // Read the JSON file synchronously
            string jsonString = File.ReadAllText("flights.json");

            // Deserialize the JSON directly into a nested dictionary
            Dictionary<string, Dictionary<string, string>> nestedDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonString);

            try
            {
                var flightinfo = nestedDictionary[number];
                //Use the data stored in the nested dictionary
                foreach (var innerKvp in flightinfo)
                {
                    Console.WriteLine($"{innerKvp.Key}: {innerKvp.Value}");
                }
            }
            catch
            {
                Console.WriteLine($"Flight {number} does not exist");
            }
        }
        catch (JsonReaderException e)
        {
            // Handle any JSON parsing errors
            Console.WriteLine($"Error parsing JSON: {e.Message}");
        }
        catch (FileNotFoundException e)
        {
            // Handle file not found error
            Console.WriteLine($"File not found: {e.Message}");
        }
    }
}