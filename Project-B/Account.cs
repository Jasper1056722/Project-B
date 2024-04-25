using System.Data.SQLite;
public class Account
{
    public bool IsLoggedIn { get; private set; }
    public bool IsAdminbool {get; private set;}
    public int Primkey {get; set; } //autoincrement key of account that was logged into

    public bool Addtodb(string email, string password)
    {   
        string connectionString = @"Data Source=Accounts.db;Version=3;";
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

   public bool Logintodb(string email, string password)
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
                            Primkey = reader.GetInt32(0);
                            IsAdminbool = reader.GetBoolean(1);
                            IsLoggedIn = true;
                            
                            return true;
                        }
                    }
                }

                // If no matching account found
                IsLoggedIn = false;
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return false;
        }
    }

    public void logout()
    {
        IsAdminbool = false;
        IsLoggedIn = false;
        Primkey = 0;
    }

    public static bool IsValidEmail(string email)
    {
        // Split the email address into two parts
        string[] parts = email.Split('@');

        // Check if there are exactly two parts
        if (parts.Length != 2)
        {
            return false;
        }

        // Check if the part before the '@' contains at least one letter
        string localPart = parts[0];
        if (!localPart.Any(char.IsLetter))
        {
            return false;
        }

        // Check if the part after the '@' contains a period
        string domainPart = parts[1];
        if (!domainPart.Contains('.'))
        {
            return false;
        }

        // Email is valid
        return true;
    }

    public static bool IsNotNull(string WordToCheck)
    {
        if(WordToCheck == null || WordToCheck.Trim() == "")
        {
            return false;
        }
        return true;
    }
}

