using System.Data.SQLite;
using System.Globalization;

public class User
{
    public string email { get; protected set; }
    public string password { get; protected set; }

    public User(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    public void Login();
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
    
    
}