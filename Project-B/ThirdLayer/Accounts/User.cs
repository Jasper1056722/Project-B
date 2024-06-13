using System;
using System.Data.SQLite;

public class User
{
    public int Primkey { get; protected set; } = 0;

    public User(int primkey)
    {
        this.Primkey = primkey;
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
                                return new Admin(id);
                            }
                            else
                            {
                                return new Customer(id);
                            }
                        }
                    }
                }
                Console.WriteLine("Invalid email or password.");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return null;
        }
    }

    public static User Logout()
    {
        return new User(0);
    }

    public static bool Addtodb(string email, string password)
    {   
        string connectionString = "Data Source=Accounts.db;Version=3;";
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertAccountQuery = @"
                    INSERT INTO Accounts (Username, Password, IsAdmin)
                    VALUES (@Username, @Password, 0)";

                using (var command = new SQLiteCommand(insertAccountQuery, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@Username", email);
                    command.Parameters.AddWithValue("@Password", password);
                    
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return false;
        }
    }
    
    public virtual List<Reservation> LoadAccountsReservations(List<Reservation> reservations)
    {
        return reservations;
    }

    public virtual User IsMenu(ref User currentUser, List<Flight> flights, List<Reservation> reservations)
    {
        while (true)
        {
        
        int selectedOptionIndex = Menu.MenuPanel(("Login Menu", "Here u can login"), ["Login", "Sign up", "Search Flight", "Show all flights", "Quit Program"]);
                       
        switch (selectedOptionIndex)
        {
        case 0:  
            Console.Clear();
            string email = Menu.GetString("Enter email: ");
            string password = Menu.GetString("Enter password: ");
            Menu.LoadingBar("Attempting login", TimeSpan.FromSeconds(2));

            currentUser = User.Login(email, password);
            if (currentUser != null)
            {
                return currentUser; // Return the logged-in user instance
            }
            else
            {
                Console.WriteLine("Login failed. Please try again.");
                Console.ReadKey();
            }
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
            User.Addtodb(newUserEmail, newUserPassword);
            Menu.LoadingBar("Adding account to database", TimeSpan.FromSeconds(2));
            break;
    
    case 2:
        Console.Clear();
        bool GuestSearchingState = true;
        while(GuestSearchingState)
        {
            int SearchingOptionIndex = Menu.MenuPanel(("Searching options", "Choose between these 3 options"), ["Destination", "Departure Date", "Airplane Model", "Flight number", "Back to admin panel"]);
                
                switch(SearchingOptionIndex)
                {
                    case 0:
                        Console.Clear();
                        string DestAnswer = Menu.GetString("Enter a destination to look for: ").Trim();
                        Console.Clear();
                        Menu.LoadingBar("Looking for result with correct destination", TimeSpan.FromSeconds(1));
                        Console.Clear();
                        List<string> destResult = Searching.Destination(DestAnswer, flights);
                        if (destResult.Count > 0)
                        {
                            Console.WriteLine($"Found {destResult.Count} flights to {DestAnswer}:\n");
                            foreach (var flight in destResult)
                            {
                                Console.WriteLine(flight);
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No flights found with destination {DestAnswer}");
                        }
                        Console.WriteLine("Enter a key to go back to the searching menu");
                        Console.ReadKey();
                        break;

                    case 1:
                        Console.Clear();
                        string DateAnswer = Menu.GetString("Enter a departure date to look for: ").Trim();
                        Console.Clear();
                        Menu.LoadingBar("Looking for result with correct date", TimeSpan.FromSeconds(1));
                        Console.Clear();
                        List<string> timeResult = Searching.Time(DateAnswer, flights);
                        if (timeResult.Count > 0)
                        {
                            Console.WriteLine($"Found {timeResult.Count} flights departing on: {DateAnswer}:\n");
                            foreach (var flight in timeResult)
                            {
                                Console.WriteLine(flight);
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No flights found departing on {DateAnswer}");
                        }
                        Console.WriteLine("Enter a key to go back to the searching menu");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        string AirplanModelAnswer = Menu.GetString("Enter a airplane model to look for ( Boeing 737 | Airbus 330 | Boeing 787 ): ");
                        Console.Clear();
                        Menu.LoadingBar("Looking for result with correct airplane model", TimeSpan.FromSeconds(1));
                        Console.Clear();
                        List<string> airResult = Searching.Airline(AirplanModelAnswer, flights);
                        if (airResult.Count > 0)
                        {
                            Console.WriteLine($"Found {airResult.Count} flights with Airplane: {AirplanModelAnswer}:\n");
                            foreach (var flight in airResult)
                            {
                                Console.WriteLine(flight);
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No flights found with airplane model {AirplanModelAnswer}");
                        }
                        Console.WriteLine("Enter a key to go back to the searching menu");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        string AirplanNumAnswer = Menu.GetString("Enter a flight number to look for: ");
                        Console.Clear();
                        Menu.LoadingBar("Looking for result with correct flight number", TimeSpan.FromSeconds(1));
                        Console.Clear();
                        List<string> numResult = Searching.FlightNumber(AirplanNumAnswer, flights);
                        if (numResult.Count > 0)
                        {
                            Console.WriteLine($"Found {numResult.Count} flights to {AirplanNumAnswer}:\n");
                            foreach (var flight in numResult)
                            {
                                Console.WriteLine(flight);
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No flights found with flightnumber {AirplanNumAnswer}");
                        }
                        Console.WriteLine("Enter a key to go back to the searching menu");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        GuestSearchingState = false;
                        break;
                }                     
        }
        break;
        
            case 3:
                Console.Clear();
                Menu.LoadingBar("Loading flights", TimeSpan.FromSeconds(1));
                Console.Clear();
                Flightinfo.DisplayFlights(flights);
                Console.WriteLine("Enter a key to go back to the menu");
                Console.ReadKey();
                Console.Clear();
                break;

            case 4:
                Menu.LoadingBar("Quitting application", TimeSpan.FromSeconds(2));
                Flight.WriteToJson(flights);
                ReservationManager.WriteReservations(reservations);
                Environment.Exit(1);
                break;
            }
        }
    }
}