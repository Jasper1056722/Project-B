public class Customer : User
{


    public Customer(int primkey) : base(primkey)
    {
    }


    // Add any additional Admin-specific properties or methods here
    public override void IsMenu()
    {
        Console.Clear();
        Console.WriteLine("Customer Menu:");
        Console.WriteLine("1. View Account");
        Console.WriteLine("2. Book a Flight");
        Console.WriteLine("3. Logout");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine("Viewing Account...");
                break;
            case "2":
                Console.WriteLine("Booking a Flight...");
                break;
            case "3":
                Console.WriteLine("pet");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}