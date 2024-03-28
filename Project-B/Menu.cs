public static class Menu
{
    public static string menus()
    {
        Console.WriteLine(@"All options
1. Login
2. Signup
3. Search
4.
5.
Q. Quit Program");

        string menuChoice = Console.ReadLine();
        return menuChoice;
    }
}