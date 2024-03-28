using System.Data.SQLite;
public class Account
{
    public bool IsLoggedIn { get; private set; }
    public bool IsAdminbool {get; private set;}
    public int Primkey {get; set; } //autoincrement key of account that was logged into

    public void Addtodb(string email, string password)
    {   
        string connectionString = @"Data Source=Accounts.db;Version=3;";
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
            }
        }
    }

   public bool Logintodb(string email, string password)
    {
        string connectionString = @"Data Source=Accounts.db;Version=3;";
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
                        Primkey = reader.GetInt32(0);
                        IsAdminbool = reader.GetBoolean(1);
                        IsLoggedIn = true;

                        if(IsAdminbool)
                        {
                            Console.WriteLine("You are an admin.");
                        }
                        
                        return true;
                    }
                }
            }

            // If no matching account found
            IsLoggedIn = false;
            return false;
        }
    }

    public void Login()
    {
        Console.WriteLine("Fill in Email:");
        string email = Console.ReadLine();
        Console.WriteLine("Fill in Password");
        string password = Console.ReadLine();

        if(Logintodb(email, password))
        {
            Console.WriteLine("Login successful!");
            // Perform actions after successful login
        }
        else
        {
            Console.WriteLine("Login failed. Incorrect email or password.");
            // Handle failed login attempt
        }

    }

    public void signup()
    {
        Console.WriteLine("Fill in Email:");
        string email = Console.ReadLine();
        Console.WriteLine("Fill in Password");
        string password = Console.ReadLine();
        Addtodb(email, password);
    }
}