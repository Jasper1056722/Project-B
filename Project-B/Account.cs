using System.Data.SQLite;
public static class Account
{
    public static void Addtodb(string email, string password)
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


    public static void signup()
    {
        string checkpassword = "";
        Console.WriteLine("Fill in Email:\n");
        string email = Console.ReadLine();
        Console.WriteLine("Fill in Password");
        string password = Console.ReadLine();
        do
        {
            Console.WriteLine("Fill in Password again");
            checkpassword = Console.ReadLine();
        }while (password != checkpassword);
        Addtodb(email, password);
    }

    
}