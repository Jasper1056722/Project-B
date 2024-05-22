namespace Project_Btest
{
    [TestClass]
    public class Project_Btest
    {
        [TestMethod]
        public void Test_SearchingDestination_returnsListString()
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
                    "11-11-1111T12:12:12",
                    1111111
                )
            };

            string flightNumber = "1111111";
            string destination = "Test";
            string departureDate = "11-11-1111";
            string airplane = "Testbus 3000";

            List<string> Trost01 = Searching.Destination(destination, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n";

            Assert.AreEqual(Trost01[0].Trim(), Expected.Trim());
        }

        [TestMethod]
        public void Test_SearchingFlightNumber_returnsListString()
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
                    "11-11-1111T12:12:12",
                    1111111
                )
            };

            string flightNumber = "1111111";
            string destination = "Test";
            string departureDate = "11-11-1111";
            string airplane = "Testbus 3000";

            List<string> Trost02 = Searching.FlightNumber(flightNumber, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n";

            Assert.AreEqual(Trost02[0].Trim(), Expected.Trim());
        }

        [TestMethod]
        public void Test_SearchingTime_returnsListString()
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
                    "11-11-1111T12:12:12",
                    1111111
                )
            };

            string flightNumber = "1111111";
            string destination = "Test";
            string departureDate = "11-11-1111";
            string airplane = "Testbus 3000";

            List<string> Trost03 = Searching.Time(departureDate, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n";

            Assert.AreEqual(Trost03[0].Trim(), Expected.Trim());
        }

        [TestMethod]
        public void Test_SearchingAirline_returnsListString()
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
                    "11-11-1111T12:12:12",
                    1111111
                )
            };

            string flightNumber = "1111111";
            string destination = "Test";
            string departureDate = "11-11-1111";
            string airplane = "Testbus 3000";

            List<string> Trost04 = Searching.Airline(airplane, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11/11/1111 11:11:11 AM\nEstimated time of Arrival: 11/11/1111 12:12:12 PM\n";

            Assert.AreEqual(Trost04[0].Trim(), Expected.Trim());
        }
    }
}