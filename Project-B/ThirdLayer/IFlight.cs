using System;
using System.Collections.Generic;

public interface IFlight
{
    int FlightNumber { get; set; }
    string Destination { get; set; }
    string Country { get; set; }
    string DepartingFrom { get; set; }
    string DepartureDate { get; set; }
    DateTime DepartureTime { get; set; }
    DateTime EstimatedTimeofArrival { get; set; }
    Plane Airplane { get; set; }

    bool IsFlightFull();
}