using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;


public static class ReservationManager
{

    public static List<Reservation> LoadReservations()
    {
        string json = File.ReadAllText("Reservations.json");

        if (string.IsNullOrEmpty(json))
        {
            return new List<Reservation>();
        }

        List<Reservation> reservations = JsonConvert.DeserializeObject<List<Reservation>>(json);
        return reservations;
    }



    public static void WriteReservations(List<Reservation> reservations)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            DateFormatString = "dd-MM-yyyyTHH:mm:ss", // Customize the date format here
            Formatting = Formatting.Indented
        };

        string json = JsonConvert.SerializeObject(reservations, settings);
        File.WriteAllText("Reservations.json", json);
    }

    public static void DisplayReservations(List<Reservation> reservations)
    {
        
        string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        try
        {
            int ReservationCount = 1;
            foreach(Reservation reservation in reservations)
            {
                int PersonCount = 0;
                Console.WriteLine($"RESERVATION {ReservationCount}");
                Console.WriteLine("+--------------------------------------------------------------------------------+");
                Console.WriteLine($"| {CYAN}Reservation number: {reservation.ReservationNumber.ToString().PadRight(20)}{NORMAL} | {CYAN}Destination:    {reservation.FlightForReservation.Destination.PadRight(19)}{NORMAL} |");
                Console.WriteLine($"| {CYAN}Flightnumber:       {reservation.FlightForReservation.FlightNumber.ToString().PadRight(20)}{NORMAL} | {CYAN}Departure time: {reservation.FlightForReservation.DepartureTime.ToString("yyyy-MM-dd HH:mm:ss").PadRight(18)}{NORMAL} |");
                Console.WriteLine($"| {CYAN}Airplane model:     {reservation.FlightForReservation.Airplane.Model.PadRight(20)}{NORMAL} | {CYAN}ETA:            {reservation.FlightForReservation.EstimatedTimeofArrival.ToString("yyyy-MM-dd HH:mm:ss").PadRight(18)}{NORMAL} |");
                ReservationCount++;


                foreach(Person person in reservation.People)
                {
                    PersonCount++;
                    Console.WriteLine("+--------------------------------------------------------------------------------+");
                    Console.WriteLine("|                                                                                |");
                    Console.WriteLine($"| {CYAN}PERSON {PersonCount.ToString().PadRight(71)}{NORMAL} |");
                    Console.WriteLine("+--------------------------------------------------------------------------------+");
                    Console.WriteLine($"| {CYAN}Name:         {person.FirstName} {person.LastName.PadRight(21)}{NORMAL} | {CYAN}Date of birth: {person.BirthDate.PadRight(20)}{NORMAL} |");
                    Console.WriteLine($"| {CYAN}Phone number: {person.PhoneNumber.PadRight(26)}{NORMAL} | {CYAN}Email:         {person.EmailAddress.PadRight(20)}{NORMAL} |");

                }
                Console.WriteLine("+--------------------------------------------------------------------------------+\n\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("You have no Reservations");
        }
    }
}