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

    public static int MenuPanel(string Title, string SubTitle, string[] options)
    {
        string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        int selectedOptionIndex = 0;
        while (true)
        {
            Console.Clear();

            // Draw box around options
            Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
            Console.WriteLine($"│     {Title.PadRight(56)} |");
            Console.WriteLine($"│                                                              | ");
            Console.WriteLine($"│     {SubTitle.PadRight(56)} |");
            Console.WriteLine($"│                                                              | ");
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedOptionIndex)
                {
                    Console.Write("│ ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write($" > {CYAN}{options[i]}{NORMAL}");
                    Console.ResetColor();
                    Console.WriteLine(new string(' ', 48 - options[i].Length) + "│");
                }
                else
                {
                    Console.WriteLine($"│ > {CYAN}{options[i]}{NORMAL}{new string(' ', 49 - options[i].Length)}│");
                }
            }
            Console.WriteLine($"│                                                              | ");
            Console.WriteLine("└──────────────────────────────────────────────────────────────┘");

            // Handle user input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedOptionIndex = Math.Max(0, selectedOptionIndex - 1);
                    break;
                case ConsoleKey.DownArrow:
                    selectedOptionIndex = Math.Min(options.Length - 1, selectedOptionIndex + 1);
                    break;
                case ConsoleKey.Enter:
                    // User has selected an option
                    return selectedOptionIndex;
            }
        }
    }

    public static void StartMenu()
    {   
        string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        Console.WriteLine(@$"{CYAN}
                                                                                       .-*****-. 
        ░█████╗░██╗██████╗░██████╗░░█████╗░██████╗░████████╗                         .'_________'.
        ██╔══██╗██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝                        /_/_|__|__|_\_\
        ███████║██║██████╔╝██████╔╝██║░░██║██████╔╝░░░██║░░░                       ;'-._       _.-';
        ██╔══██║██║██╔══██╗██╔═══╝░██║░░██║██╔══██╗░░░██║░░░  ,--------------------|    `-. .-'    |--------------------,
        ██║░░██║██║██║░░██║██║░░░░░╚█████╔╝██║░░██║░░░██║░░░   ``**--..__    ___   ;       '       ;   ___    __..--**``
                                                                        `*-// \\.._\             /_..// \\-*`
                                                                            \\_//    '._       _.'    \\_//
                                                                             `*`        ``---``        `*`
        ██████╗░░█████╗░████████╗████████╗███████╗██████╗░██████╗░░█████╗░███╗░░░███╗
        ██╔══██╗██╔══██╗╚══██╔══╝╚══██╔══╝██╔════╝██╔══██╗██╔══██╗██╔══██╗████╗░████║
        ██████╔╝██║░░██║░░░██║░░░░░░██║░░░█████╗░░██████╔╝██║░░██║███████║██╔████╔██║
        ██╔══██╗██║░░██║░░░██║░░░░░░██║░░░██╔══╝░░██╔══██╗██║░░██║██╔══██║██║╚██╔╝██║
        ██║░░██║╚█████╔╝░░░██║░░░░░░██║░░░███████╗██║░░██║██████╔╝██║░░██║██║░╚═╝░██║
        ╚═╝░░╚═╝░╚════╝░░░░╚═╝░░░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝
       {NORMAL} ");
    }
}