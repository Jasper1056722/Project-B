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

    public void ReserveRandomSeat(Flight flight)
    {
        string SeatQual = "";
        bool isValidInput = false;

        while (!isValidInput)
        {
            if (flight.Airplane.Model == "Boeing 737")
            {
                Console.WriteLine("What seat quality:\n[1] - Economy\n[2] - Economy Extra Legroom");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    SeatQual = "Economy";
                    isValidInput = true;
                }
                else if (input == "2")
                {
                    SeatQual = "Economy Extra Legroom";
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 or 2.");
                }
            }
            else if (flight.Airplane.Model == "Boeing 787")
            {
                Console.WriteLine("What seat quality:\n[1] - Economy\n[2] - Business\n[3] - Economy Extra Legroom");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    SeatQual = "Economy";
                    isValidInput = true;
                }
                else if (input == "2")
                {
                    SeatQual = "Business";
                    isValidInput = true;
                }
                else if (input == "3")
                {
                    SeatQual = "Economy Extra Legroom";
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
                }
            }
            else if (flight.Airplane.Model == "Airbus 330")
            {
                Console.WriteLine("What seat quality:\n[1] - Economy\n[2] - Economy Extra Legroom\n[3] - Double seats\n[4] - Economy class in front of cabin\n[5] - Club Class");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    SeatQual = "Economy";
                    isValidInput = true;
                }
                else if (input == "2")
                {
                    SeatQual = "Economy Extra Legroom";
                    isValidInput = true;
                }
                else if (input == "3")
                {
                    SeatQual = "Double seats";
                    isValidInput = true;
                }
                else if (input == "4")
                {
                    SeatQual = "Economy class in front of cabin";
                    isValidInput = true;
                }
                else if (input == "5")
                {
                    SeatQual = "Club Class";
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            }
            else
            {
                Console.WriteLine("Invalid airplane model.");
                return;
            }
        }

        // Use SeatQual here for further processing
        Console.WriteLine($"You have selected {SeatQual} seat.");
    }
}