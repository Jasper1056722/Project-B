using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


public class Flightinfo
{
    public static Dictionary<string, string> Getinfo(string number)
    {

        // Read the JSON file synchronously
        string jsonString = File.ReadAllText("flights.json");

        // Deserialize the JSON directly into a nested dictionary
        Dictionary<string, Dictionary<string, string>> nestedDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonString);

        var flightinfo = nestedDictionary[number];
        return flightinfo;

    }

    public static string Printinfo(Dictionary<string,string> flight)
    {
        string text = "";
        foreach (var innerKvp in flight)
        {
            string tekst = $"{innerKvp.Key}: {innerKvp.Value}/n";
            text = text + tekst;
        }

        return text;
    }
}