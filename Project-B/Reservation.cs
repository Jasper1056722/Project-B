public class Reservation
{
    private int _reservationNumber;
    private List<int> _takenNumbers = new List<int>();
    public int ReservationNumber { get; set; }
    public List<Person> People = new List<Person>();
    public int AccountKey { get; set; }
    private static Random random = new Random();

    public Reservation(int accountKey)
    {
        _reservationNumber = random.Next(100000, 999999);

        while (_takenNumbers.Contains(_reservationNumber))
        {
            _reservationNumber = random.Next(100000, 999999);
        }

        ReservationNumber = _reservationNumber;
    }
}