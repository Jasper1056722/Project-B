public class Program 
{
    static void Main()
    {
        // Console.WriteLine("Hello, World!");
        Plane plane = new Plane("Boeing 737");
        foreach(Seat seat in plane.Seats)
        {
            Console.WriteLine(seat.ID);
        }
    }
}
