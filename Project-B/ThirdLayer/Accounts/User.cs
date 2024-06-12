using System.Data.SQLite;
using System.Globalization;

public class User
{

    public int Primkey { get; protected set; } = 0;

    public User(int Primkey)
    {
        this.Primkey = Primkey;
    }

    public static User Login(string email, string password)
    {
        string connectionString = @"Data Source=Accounts.db;Version=3;";
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectAccountQuery = @"
                    SELECT Id, IsAdmin
                    FROM Accounts
                    WHERE Username = @Username AND Password = @Password";

                using (var command = new SQLiteCommand(selectAccountQuery, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@Username", email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            bool isAdmin = reader.GetBoolean(1);

                            if (isAdmin)
                            {
                                return this = new Admin(id);
                            }
                            else
                            {
                                return this = new Customer(id);
                            }
                        }
                    }
                }
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return null;
        }
    }
    public User logout()
    {
        return this = new User(0);
    }
    public virtual void IsMenu()
    {
    int selectedOptionIndex = Menu.MenuPanel("Login Menu", "Here u can login", ["Login", "Sign up", "Search Flight", "Show all flights", "Quit Program"]);
        
                    
    switch (selectedOptionIndex)
    {
    case 0:  
                        
        string email = Menu.GetString("ENTER email: ");
        string password = Menu.GetString("ENTER PASSWORD: ");

        Login(email, password);
        Console.Clear();
        Menu.LoadingBar("Loading account", TimeSpan.FromSeconds(2));
        break;

    case 1:
        string newUserEmail = Menu.GetString("ENTER A NEW EMAIL: ");

        while(!Validator.IsValidEmail(newUserEmail))
        {
            Console.WriteLine("Invalid email, Try again");
            newUserEmail = Menu.GetString("ENTER A NEW EMAIL: ");
            Console.Clear();
        }
        string newUserPassword = Menu.GetString("ENTER A PASSWORD: ");
        
        while(!Validator.IsNotNull(newUserPassword))
        {
            Console.WriteLine("Password cant be empty!");
            newUserPassword = Menu.GetString("ENTER A PASSWORD: ");
            Console.Clear();
        }

        Console.Clear();
        //account.Addtodb(newUserEmail, newUserPassword);
        Menu.LoadingBar("Adding account to database", TimeSpan.FromSeconds(2));
        break;
    
    // case 2:
    //     Console.Clear();
    //     bool GuestSearchingState = true;
    //     while(GuestSearchingState)
    //     {
    //         int SearchingOptionIndex = Menu.MenuPanel("Searching options", "Choose between these 3 options", ["Destination", "Departure Date", "Airplane Model", "Flight number", "Back to admin panel"]);
                
    //             switch(SearchingOptionIndex)
    //             {
    //                 case 0:
    //                     Console.Clear();
    //                     string DestAnswer = Menu.GetString("Enter a destination to look for: ").Trim();
    //                     Console.Clear();
    //                     Menu.LoadingBar("Looking for result with correct destination", TimeSpan.FromSeconds(1));
    //                     Console.Clear();
    //                     List<string> destResult = Searching.Destination(DestAnswer, flights);
    //                     if (destResult.Count > 0)
    //                     {
    //                         Console.WriteLine($"Found {destResult.Count} flights to {DestAnswer}:\n");
    //                         foreach (var flight in destResult)
    //                         {
    //                             Console.WriteLine(flight);
    //                             Console.WriteLine("");
    //                         }
    //                     }
    //                     else
    //                     {
    //                         Console.WriteLine($"No flights found with destination {DestAnswer}");
    //                     }
    //                     Console.WriteLine("Enter a key to go back to the searching menu");
    //                     Console.ReadKey();
    //                     break;

    //                 case 1:
    //                     Console.Clear();
    //                     string DateAnswer = Menu.GetString("Enter a departure date to look for: ").Trim();
    //                     Console.Clear();
    //                     Menu.LoadingBar("Looking for result with correct date", TimeSpan.FromSeconds(1));
    //                     Console.Clear();
    //                     List<string> timeResult = Searching.Time(DateAnswer, flights);
    //                     if (timeResult.Count > 0)
    //                     {
    //                         Console.WriteLine($"Found {timeResult.Count} flights departing on: {DateAnswer}:\n");
    //                         foreach (var flight in timeResult)
    //                         {
    //                             Console.WriteLine(flight);
    //                             Console.WriteLine("");
    //                         }
    //                     }
    //                     else
    //                     {
    //                         Console.WriteLine($"No flights found departing on {DateAnswer}");
    //                     }
    //                     Console.WriteLine("Enter a key to go back to the searching menu");
    //                     Console.ReadKey();
    //                     break;

    //                 case 2:
    //                     Console.Clear();
    //                     string AirplanModelAnswer = Menu.GetString("Enter a airplane model to look for ( Boeing 737 | Airbus 330 | Boeing 787 ): ");
    //                     Console.Clear();
    //                     Menu.LoadingBar("Looking for result with correct airplane model", TimeSpan.FromSeconds(1));
    //                     Console.Clear();
    //                     List<string> airResult = Searching.Airline(AirplanModelAnswer, flights);
    //                     if (airResult.Count > 0)
    //                     {
    //                         Console.WriteLine($"Found {airResult.Count} flights with Airplane: {AirplanModelAnswer}:\n");
    //                         foreach (var flight in airResult)
    //                         {
    //                             Console.WriteLine(flight);
    //                             Console.WriteLine("");
    //                         }
    //                     }
    //                     else
    //                     {
    //                         Console.WriteLine($"No flights found with airplane model {AirplanModelAnswer}");
    //                     }
    //                     Console.WriteLine("Enter a key to go back to the searching menu");
    //                     Console.ReadKey();
    //                     break;

    //                 case 3:
    //                     Console.Clear();
    //                     string AirplanNumAnswer = Menu.GetString("Enter a flight number to look for: ");
    //                     Console.Clear();
    //                     Menu.LoadingBar("Looking for result with correct flight number", TimeSpan.FromSeconds(1));
    //                     Console.Clear();
    //                     List<string> numResult = Searching.FlightNumber(AirplanNumAnswer, flights);
    //                     if (numResult.Count > 0)
    //                     {
    //                         Console.WriteLine($"Found {numResult.Count} flights to {AirplanNumAnswer}:\n");
    //                         foreach (var flight in numResult)
    //                         {
    //                             Console.WriteLine(flight);
    //                             Console.WriteLine("");
    //                         }
    //                     }
    //                     else
    //                     {
    //                         Console.WriteLine($"No flights found with flightnumber {AirplanNumAnswer}");
    //                     }
    //                     Console.WriteLine("Enter a key to go back to the searching menu");
    //                     Console.ReadKey();
    //                     break;

    //                 case 4:
    //                     Console.Clear();
    //                     GuestSearchingState = false;
    //                     break;
    //             }                     
    //     }
    //     break;
        
    //         case 3:
    //             Console.Clear();
    //             Menu.LoadingBar("Loading flights", TimeSpan.FromSeconds(1));
    //             Console.Clear();
    //             Flightinfo.DisplayFlights(flights);
    //             Console.WriteLine("Enter a key to go back to the menu");
    //             Console.ReadKey();
    //             Console.Clear();
    //             break;

    //         case 4:
    //             Console.WriteLine($"{NORMAL}CLOSING THE APPLICATION{NORMAL}");
    //             Thread.Sleep(1000);
    //             Flight.WriteToJson(flights);
    //             ReservationManager.WriteReservations(reservations);
    //             Environment.Exit(1);
    //             break;
        }

    }
}