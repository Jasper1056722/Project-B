public class Admin : User
{


    public Admin(int primkey) : base(primkey) { }

    // Add any additional Admin-specific properties or methods here
    public override void IsMenu()
    {
        Console.WriteLine("im a admin");
    }
}