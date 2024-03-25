using System.Data.SQLite;
public class Account
{
    public bool IsLoggedIn { get; private set; }
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
                SELECT Id
                FROM Accounts
                WHERE Username = @Username AND Password = @Password";

            using (var command = new SQLiteCommand(selectAccountQuery, connection))
            {
                // Add parameters to the query
                command.Parameters.AddWithValue("@Username", email);
                command.Parameters.AddWithValue("@Password", password);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    Primkey = Convert.ToInt32(result);
                    IsLoggedIn = true;
                    return true;
                }
                else
                {
                    IsLoggedIn = false;
                    return false;
                }
            }
        }
    }

    public void Login()
    {
        Console.WriteLine("Fill in Email:\n");
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
        Console.WriteLine("Fill in Email:\n");
        string email = Console.ReadLine();
        Console.WriteLine("Fill in Password");
        string password = Console.ReadLine();
        Addtodb(email, password);
    }
}