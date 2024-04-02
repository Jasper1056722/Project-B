public static class NMenu
{
    public static string Nmenus()
    {
        Console.WriteLine(@"All options
L. Login
S. Signup
SE. Searchup  
Q. Quit Program");

        string NmenuChoice = Console.ReadLine();
        return NmenuChoice.ToUpper();
    }
}