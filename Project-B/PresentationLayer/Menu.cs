public static class Menu
{
    public static string menus()
    {
        Console.WriteLine(@"All options
SE. Search for a flight
MR. Make a reservation
LO. logout
Q. Quit Program
");

        string menuChoice = Console.ReadLine();
        return menuChoice.ToUpper();
    }

    public static string Nmenus()
    {
        Console.WriteLine(@"All options
L. Login
S. Signup
SE. Searchup  
Q. Quit Program
");

        string NmenuChoice = Console.ReadLine();
        return NmenuChoice.ToUpper();
    }

    public static string menusadmin()
    {
        Console.WriteLine(@"All options
A. Add a Flight
R. Remove a Flight
C. Change a Flight
S. Search for a flight
L. logout
Q. Quit Program
");

        string AmenuChoice = Console.ReadLine();
        return AmenuChoice.ToUpper();
    }
}