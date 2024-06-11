using System.Data.SQLite;
using System.IO;


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
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), Trost01[0].Trim());
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
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), Trost02[0].Trim());
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
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), Trost03[0].Trim());
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
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), Trost04[0].Trim());
        }
        
        [TestMethod]
        public void Test_shouldaddtodb()
        {
            
            string connectionString = "Data Source=Accounts.db;Version=3;";

            var account = new Account(connectionString); 
            bool result = account.Addtodb("pet@example.com", "pet123");

            Assert.IsTrue(result);

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQeury = "SELECT COUNT(*) FROM Accounts WHERE Username = 'pet@example.com'";

                using (var command = new SQLiteCommand(selectQeury, connection))
                {
                    var count = Convert.ToInt32(command.ExecuteScalar());
                    Assert.AreEqual(1, count);
                }
            }
        }
        
        [TestMethod]
        public void Test_logintodbsuccesfull()
        {
            string connectionString = "Data Source=Accounts.db;Version=3;";
            
            var account = new Account(connectionString);
            account.Addtodb("test@example.com", "password123");

            bool result = account.Logintodb("test@example.com", "password123");

            Assert.IsTrue(result);
            Assert.IsTrue(account.IsLoggedIn);
        }
        
        [TestMethod]
        public void Test_logintodbincorrectly()
        {
            string connectionString = "Data Source=Accounts.db;Version=3;";
            
            var account = new Account(connectionString);
            account.Addtodb("test@example.com", "password123");

            bool result = account.Logintodb("test@example.com", "wrong password");

            Assert.IsFalse(result);
            Assert.IsFalse(account.IsLoggedIn);
        }

        [TestMethod]
        public void Test_filtorAll01_returnsListString()
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

            string destination01 = "Testington";
            string destination02 = "Test";
            string departureDate01 = "11-11-1111";
            string departureDate02 = "11-11-1111";
            string airplane01 = "Testbus 3000";
            string airplane02 = "";
            string airplane03 = "";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_filtorAll02_returnsListString()
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

            string destination01 = "Testington";
            string destination02 = "Test";
            string departureDate01 = "11-11-1111";
            string departureDate02 = "11-11-1111";
            string airplane01 = "Testbus 3000";
            string airplane02 = "boeing 737";
            string airplane03 = "";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_filtorAll03_returnsListString()
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

            string destination01 = "Testington";
            string destination02 = "Test";
            string departureDate01 = "11-11-1111";
            string departureDate02 = "11-11-1111";
            string airplane01 = "Testbus 3000";
            string airplane02 = "boeing 737";
            string airplane03 = "boeing 787";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_filtorAll10_returnsListString()
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

            string destination01 = "Testington";
            string destination02 = "Test";
            string departureDate01 = "11-11-1111";
            string departureDate02 = "11-11-1111";
            string airplane01 = "";
            string airplane02 = "";
            string airplane03 = "";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_filtorAll21_returnsListString()
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

            string destination01 = "Testington";
            string destination02 = "Test";
            string departureDate01 = "";
            string departureDate02 = "";
            string airplane01 = "";
            string airplane02 = "";
            string airplane03 = "";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_filtorAll22_returnsListString()
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

            string destination01 = "Testington";
            string destination02 = "Test";
            string departureDate01 = "";
            string departureDate02 = "";
            string airplane01 = "Testbus 3000";
            string airplane02 = "boeing 737";
            string airplane03 = "";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_filtorAll23_returnsListString()
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

            string destination01 = "Testington";
            string destination02 = "Test";
            string departureDate01 = "";
            string departureDate02 = "";
            string airplane01 = "Testbus 3000";
            string airplane02 = "boeing 737";
            string airplane03 = "boeing 787";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_filtorAll31_returnsListString()
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

            string destination01 = "";
            string destination02 = "";
            string departureDate01 = "11-11-1111";
            string departureDate02 = "11-11-1111";
            string airplane01 = "Testbus 3000";
            string airplane02 = "";
            string airplane03 = "";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_filtorAll32_returnsListString()
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

            string destination01 = "";
            string destination02 = "";
            string departureDate01 = "11-11-1111";
            string departureDate02 = "11-11-1111";
            string airplane01 = "Testbus 3000";
            string airplane02 = "boeing 737";
            string airplane03 = "";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_filtorAll33_returnsListString()
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

            string destination01 = "";
            string destination02 = "";
            string departureDate01 = "11-11-1111";
            string departureDate02 = "11-11-1111";
            string airplane01 = "Testbus 3000";
            string airplane02 = "boeing 737";
            string airplane03 = "boeing 787";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_Destination_returnsListString()
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

            string destination01 = "Testington";
            string destination02 = "Test";
            string departureDate01 = "";
            string departureDate02 = "";
            string airplane01 = "";
            string airplane02 = "";
            string airplane03 = "";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_Time_returnsListString()
        {
            (DateTime departureDateInput01, DateTime departureDateInput02, List<Flight> flights)
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

            string destination01 = "";
            string destination02 = "";
            string departureDate01 = "11-11-1111";
            string departureDate02 = "11-11-1111";
            string airplane01 = "";
            string airplane02 = "";
            string airplane03 = "";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_Airline01_returnsListString()
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

            string destination01 = "";
            string destination02 = "";
            string departureDate01 = "";
            string departureDate02 = "";
            string airplane01 = "Testbus 3000";
            string airplane02 = "";
            string airplane03 = "";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_Airline02_returnsListString()
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

            string destination01 = "";
            string destination02 = "";
            string departureDate01 = "";
            string departureDate02 = "";
            string airplane01 = "Testbus 3000";
            string airplane02 = "boeing 737";
            string airplane03 = "";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }

        [TestMethod]
        public void Test_Airline03_returnsListString()
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

            string destination01 = "";
            string destination02 = "";
            string departureDate01 = "";
            string departureDate02 = "";
            string airplane01 = "Testbus 3000";
            string airplane02 = "boeing 737";
            string airplane03 = "boeing 787";
            string maxPrice = "";

            List<string> filteredFlights = Filtering.filtorSort(destination01, destination02, departureDate01, departureDate02, airplane01, airplane02, airplane03, maxPrice, flights);
            
            string Expected = $"Flight 1111111:\nDestination: Test\nCountry: Test Nation\nAirplane: Testbus 3000\nDeparting from: Testington\nDeparture date: 11-11-1111\nDeparture time: 11-11-1111 11:11:11\nEstimated time of Arrival: 11-11-1111 12:12:12\n";

            Assert.AreEqual(Expected.Trim(), filteredFlights[0].Trim());
        }
    }
}