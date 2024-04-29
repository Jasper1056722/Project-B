using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;


public static class ReservationManager
{

    public static List<Reservation> LoadReservations()
    {
        string json = File.ReadAllText("Reservations.json");
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
            foreach(Reservation reservation in reservations)
            {
                Console.WriteLine("+--------------------------------------------------------------------------------+");
                Console.WriteLine($"| {CYAN}Reservation number: {reservation.ReservationNumber.ToString().PadRight(19)}{NORMAL} | {CYAN}Destination: {reservation.FlightForReservation.Destination.PadRight(23)}{NORMAL} |");
                Console.WriteLine($"| {CYAN}Flightnumber:      {reservation.FlightForReservation.FlightNumber.ToString().PadRight(20)}{NORMAL} | {CYAN}Departure time: {reservation.FlightForReservation.DepartureTime.ToString("yyyy-MM-dd HH:mm:ss").PadRight(20)}{NORMAL} |");
                Console.WriteLine($"| {CYAN}Airplane model:    {reservation.FlightForReservation.Airplane.Model.PadRight(20)}{NORMAL} | {CYAN}ETA:            {reservation.FlightForReservation.EstimatedTimeofArrival.ToString("yyyy-MM-dd HH:mm:ss").PadRight(20)}{NORMAL} |");
                Console.WriteLine(reservation.AccountKey);
                Console.WriteLine(reservation.People[0].FirstName + " " + reservation.People[0].LastName);
                Console.WriteLine("+--------------------------------------------------------------------------------+\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("You have no Reservations");
        }
    }


}