using System;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
public class Program 
{
    static void Main()
    {
        Menu.StartMenu();
        Reservation reservation = new Reservation();
        List<Flight> flights = Flight.LoadJson();
       
        Console.Title = "Flight Application";
        Thread.Sleep(2000);
        string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        bool state = true;


        Console.CursorVisible = false;
        while(state)
        {
        int selectedOptionIndex = Menu.MenuPanel("Login Menu", "Here u can login", ["Login", "Sign up", "Search Flight", "Quit Program"]);
                    
                    switch (selectedOptionIndex)
                    {
                        case 0:
                            
                            
                            string UserName = Menu.GetString("ENTER USERNAME: ");
                            string password = Menu.GetString("ENTER PASSWORD: ");
                            Console.Clear();
                            Menu.LoadingBar("Loading account", TimeSpan.FromSeconds(2));
                            Console.Clear();
                            Console.WriteLine("U are logged in");
                            break;
                        case 1:
                            Console.WriteLine("2");
                            break;
                        case 2:
                        Console.Clear();
                            Flightinfo.DisplayFlights(flights);
                            Console.WriteLine("Enter a key to continue to the menu");
                            break;
                        case 3:
                            Console.WriteLine($"{NORMAL}CLOSING THE APPLICATION{NORMAL}");
                            Thread.Sleep(1000);
                            Environment.Exit(1);
                            break;
                    }
                    Console.ReadKey();
                    // Exit the program after executing the selected option
        }
            
    }
}