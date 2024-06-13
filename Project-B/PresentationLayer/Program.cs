using System;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Globalization;
public class Program 
{
    static void Main()
    {
        Menu.StartMenu();

        Console.Title = "Flight Application";

        Thread.Sleep(2000);
        string NL = Environment.NewLine; // shortcut
        string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
        string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
        string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
        string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
        string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
        string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";
        string BOLD = Console.IsOutputRedirected ? "" : "\x1b[1m";
        string NOBOLD = Console.IsOutputRedirected ? "" : "\x1b[22m";
        string UNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[4m";
        string NOUNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[24m";
        string REVERSE = Console.IsOutputRedirected ? "" : "\x1b[7m";
        string NOREVERSE = Console.IsOutputRedirected ? "" : "\x1b[27m";


        Console.CursorVisible = false;
        List<Flight> flights = Flight.LoadJson();
        List<Reservation> reservations = ReservationManager.LoadReservations();
        flights = flights.OrderBy(flight => flight.DepartureTime).ToList();
        flights.RemoveAll(flight => flight.DepartureTime < DateTime.Now); 
        User myUser = new User(0);

        while (true){ myUser.IsMenu(ref myUser, flights, reservations); }
    }

}