public class Plane
{
    public string Model { get; set; }
    public List<Seat> Seats = new List<Seat>{};

    public Plane(string model)
    {
        Model = model;

        if (Model == "Boeing 737")
        {
            CreateSeatsBoeing737();
        }
        if (Model == "Airbus 330")
        {
            CreateSeatsAirbus330();
        }
        if (Model == "Boeing 787")
        {
            CreateSeatsBoeing787();
        }
    }

    public void CreateSeatsBoeing737()
    {
        char[] rows = { 'A', 'B', 'C', 'D', 'E', 'F' };
        
        foreach (char row in rows)
        {
            for (int i = 1; i <= 33; i++)
            {
                
                if (i == 1 && (row == 'D' || row == 'E'|| row == 'F'))
                {
                    continue;
                }
                if (i == 16 || i == 17)
                {
                    string seatClass = "Economy Extra Legroom";
                    string seatId = row.ToString() + i;
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }
                else
                {
                    string seatClass = "Economy";
                    string seatId = row.ToString() + i;
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

            }
        }
    }

    public void CreateSeatsAirbus330()
    {
        char[] rows = { 'A', 'B', 'C', 'D', 'F' , 'G', 'H', 'J', 'K'};

        foreach(char row in rows)
        {
            for (int i = 1; i <= 50; i++)
            {
                if ((row == 'A' || row == 'C' || row == 'D' || row == 'G' || row == 'H' || row == 'K') && (i == 1 || i == 2))
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Club Class";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

                if (i == 4)
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Economy Extra Legroom";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

                if ((row == 'A' || row == 'B' || row == 'C' || row == 'H' || row == 'J' || row == 'K') && (i >= 5 && i <= 7))
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Economy class in front of cabin";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

                if (i == 14)
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Economy Extra Legroom";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

                if ((row == 'A' || row == 'B' || row == 'C' || row == 'H' || row == 'J' || row == 'K') && (i >= 15 && i <= 32))
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Economy";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

                if (i == 36)
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Economy Extra Legroom";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

                if(i >= 37 && i <= 43)
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Economy";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

                if ((row == 'A' || row == 'C' || row == 'H' || row == 'K') && ( i >= 44 && i <= 49))
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Double seats";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

                if ((row == 'D' || row == 'F' || row == 'G') && ( i >= 45 && i <= 50))
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Economy";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

                if ((row == 'D' || row == 'F' || row == 'G') && ( i >= 15 && i <= 33))
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Economy";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

                if ((row == 'D' || row == 'F' || row == 'G') && i == 10)
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Economy";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }

                if ((row == 'D' || row == 'F' || row == 'G') && (i >= 6 && i <= 9))
                {
                    string seatId = row.ToString() + i;
                    string seatClass = "Economy class in front of cabin";
                    Seat seat = new Seat(seatId, seatClass);
                    Seats.Add(seat);
                }
            }
        }
    }

    public void CreateSeatsBoeing787()
    {
        char[] rows = { 'A', 'B', 'C', 'D', 'E', 'F', 'J', 'K', 'L'};

        foreach(char row in rows)
        {
            if(row == 'L'|| row == 'A' || row == 'K'|| row == 'B' || row == 'C'|| row == 'J')
            {
                for(int i = 1; i <= 36; i++)
                {
                    if(i <= 6)
                    {
                        if(row == 'J'|| row == 'C')
                        {

                        }
                        else
                        {
                            string seatId = row.ToString() + i;
                            string seatClass = "Business";
                            Seat seat = new Seat(seatId, seatClass);
                            Seats.Add(seat);
                        }
                    }

                    if(i >= 16 && i <= 22)
                    {
                        string seatId = row.ToString() + i;
                        string seatClass = "Economy Extra Legroom";
                        Seat seat = new Seat(seatId, seatClass);
                        Seats.Add(seat);
                    }

                    else if(i >= 23 && i <= 38)
                    {
                        if(i == 26)
                        {

                        }

                        else if ((row == 'B' || row == 'K' || row == 'C' || row == 'J') && i == 27)
                        {
                            string seatId = row.ToString() + i;
                            string seatClass = "Economy Extra Legroom";
                            Seat seat = new Seat(seatId, seatClass);
                            Seats.Add(seat);
                        }
        
                        else
                        {
                            string seatId = row.ToString() + i;
                            string seatClass = "Economy";
                            Seat seat = new Seat(seatId, seatClass);
                            Seats.Add(seat);
                        }
                    }
                }
            }
            if (row == 'F' || row == 'E'|| row == 'D')
            {
                for (int i = 1; i <= 38; i++)
                {
                    if(i <= 6 && (row == 'E'|| row == 'D'))
                    {
                        string seatId = row.ToString() + i;
                        string seatClass = "Business";
                        Seat seat = new Seat(seatId, seatClass);
                        Seats.Add(seat);
                    }

                    if(i >= 17 && i <= 38)
                    {
                        if(i >= 17 && i <= 23)
                        {
                            string seatId = row.ToString() + i;
                            string seatClass = "Economy Extra Legroom";
                            Seat seat = new Seat(seatId, seatClass);
                            Seats.Add(seat);
                        }

                        else if (i == 26)
                        {

                        }

                        else if(i == 27)
                        {
                            string seatId = row.ToString() + i;
                            string seatClass = "Economy Extra Legroom";
                            Seat seat = new Seat(seatId, seatClass);
                            Seats.Add(seat);                           
                        }
                        else
                        {
                            string seatId = row.ToString() + i;
                            string seatClass = "Economy";
                            Seat seat = new Seat(seatId, seatClass);
                            Seats.Add(seat);
                        }
                    }


                }
            }
        }

    }

    public void PrintBoeing737()
    {
        string rowA = "", rowB = "", rowC = "", rowD = "", rowE = "", rowF = "", beginRow = "", endRow = "";
        
        foreach(Seat seat in Seats)
        {

            if(seat.ID[0] == 'A')
            {
                if (seat.Quality == "Economy Extra Legroom")
                {
                    rowA += $"  ${seat.ID}$ ";
                    beginRow += "-----";
                    endRow += "-----";
                }
                else
                {
                    rowA += $" {seat.ID} ";
                    beginRow += "-----";
                    endRow += "-----";
                }
            }

            else if(seat.ID[0] == 'B')
            {
                if (seat.Quality == "Economy Extra Legroom")
                {
                    rowB += $"  ${seat.ID}$ ";
                }
                else
                {
                    rowB += $" {seat.ID} ";
                }
            }

            else if(seat.ID[0] == 'C')
            {
                if (seat.Quality == "Economy Extra Legroom")
                {
                    rowC += $"  ${seat.ID}$ ";
                }
                else
                {
                    rowC += $" {seat.ID} ";
                }
            }

            else if(seat.ID[0] == 'D')
            {
                if (seat.Quality == "Economy Extra Legroom")
                {
                    rowD += $"  ${seat.ID}$ ";
                }
                else
                {
                    rowD += $" {seat.ID} ";
                }
            }

            else if(seat.ID[0] == 'E')
            {
                if (seat.Quality == "Economy Extra Legroom")
                {
                    rowE += $"  ${seat.ID}$ ";
                }
                else
                {
                    rowE += $" {seat.ID} ";
                }
            }

            else if(seat.ID[0] == 'F')
            {
                if (seat.Quality == "Economy Extra Legroom")
                {
                    rowF += $"  ${seat.ID}$ ";
                }
                else
                {
                    rowF += $" {seat.ID} ";
                }
            }
        }
        Console.WriteLine(beginRow);
        Console.WriteLine("A: " + rowA);
        Console.WriteLine("B: " + rowB);
        Console.WriteLine("C: " + rowC);
        Console.WriteLine("D: " + rowD);
        Console.WriteLine("E: " + rowE);
        Console.WriteLine("F: " + rowF);
        Console.WriteLine(endRow);
    }
}