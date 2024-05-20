namespace Project_Btest
{
    [TestClass]
    public class Project_Btest
    {
        [TestMethod]
        public void TestSearching()
        {
            var flights = new List<Flight>
            {
                new Flight(
                    "Test", 
                    "Test Nation", 
                    new Plane("Testbus 3000"), 
                    "Testington", 
                    "11-11-1111", 
                    "11-11-1111T11:11:11", 
                    "11-11-1111T12:12:12"
                )
            };

            int flightNumber = 1111111;
            string destination = "Test";
            string departureDate = "11-11-1111";
            string airplane = "Testbus 3000";

            string Trost01 = Searching.TestSearching(Searching.Destination, destination, flights, new List<string>
            {
                $"Found 1 flights to {destination}:\n",
                $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111T11:11:11\nEstimated time of Arrival: 11-11-1111T12:12:12\n"
            });

            string Trost02 = Searching.TestSearching(Searching.FlightNumber, flightNumber.ToString(), flights, new List<string>
            {
                $"Found 1 flights to {flightNumber}:\n",
                $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111T11:11:11\nEstimated time of Arrival: 11-11-1111T12:12:12\n"
            });

            string Trost03 = Searching.TestSearching(Searching.Time, departureDate, flights, new List<string>
            {
                $"Found 1 flights departing on: {departureDate}:\n",
                $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111T11:11:11\nEstimated time of Arrival: 11-11-1111T12:12:12\n"
            });

            string Trost04 = Searching.TestSearching(Searching.Airline, airplane, flights, new List<string>
            {
                $"Found 1 flights with Airplane: {airplane}:\n",
                $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111T11:11:11\nEstimated time of Arrival: 11-11-1111T12:12:12\n"
            });

            string passed = "Passed";

            Assert.AreEqual(passed, Trost01);
            Assert.AreEqual(passed, Trost02);
            Assert.AreEqual(passed, Trost03);
            Assert.AreEqual(passed, Trost04);
        }
    }
}