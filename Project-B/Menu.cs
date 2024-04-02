public static class Menu
{
    public static string menus()
    {
        Console.WriteLine(@"All options
SE. Search for a flight
LO. logout
Q. Quit Program");

        string menuChoice = Console.ReadLine();
        return menuChoice.ToUpper();
    }
}