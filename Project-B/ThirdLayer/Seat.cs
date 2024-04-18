public class Seat
{
    public string ID { get; set; }
    public string Quality { get; set; }
    public int Price { get; set; }
    public Person PersonInSeat { get; set; }
    public int SeatReservationNumber { get; set; }

    public Seat(string id, string quality)
    {
        ID = id;
        Quality = quality;
    }
}