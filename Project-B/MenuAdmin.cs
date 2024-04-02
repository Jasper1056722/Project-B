public static class MenuAdmin
{
    public static string menusadmin()
    {
        Console.WriteLine(@"All options
A. Add a Flight
R. Remove a Flight
C. Change a Flight
S. Search for a flight
L. logout
Q. Quit Program
");

        string AmenuChoice = Console.ReadLine();
        return AmenuChoice.ToUpper();
    }
}

                    // case "3":
                    //     Flightinfo.FlightAdd(flights);
                    //     break;

                    // case "4":
                    //     Console.WriteLine("Enter the flightnumber for the flight u want to change");
                    //     string flightnumber = Console.ReadLine();
                    //     Flightinfo.UpdateInfo(flightnumber, flights);
                    //     break;

                    // case "5":
                    //     Console.WriteLine("Enter the flightnumber for the flight u want to remove");
                    //     string flightnumber2 = Console.ReadLine();
                    //     Flightinfo.UpdateInfo(flightnumber2, flights);
                    //     break;