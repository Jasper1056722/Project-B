public static class Menu
{
    public static string menus()
    {
        Console.WriteLine(@"All options
1. Login
2. Signup
3. Add a Flight
4. Remove a Flight
5. Change a Flight
Q. Quit Program");

        string menuChoice = Console.ReadLine();
        return menuChoice;
    }
}