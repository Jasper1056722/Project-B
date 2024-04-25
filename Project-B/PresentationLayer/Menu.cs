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
            Console.WriteLine($"│     {CYAN}{Title.PadRight(56)}{NORMAL} |");
            Console.WriteLine($"│                                                              | ");
            Console.WriteLine($"│     {CYAN}{SubTitle.PadRight(56)}{NORMAL} |");
            Console.WriteLine($"│                                                              | ");
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedOptionIndex)
                {
                    Console.Write("│ ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write($" > {CYAN}{options[i]}{NORMAL}");
                    Console.ResetColor();
                    Console.WriteLine(new string(' ', 58 - options[i].Length) + "│");
                }
                else
                {
                    Console.WriteLine($"│ > {CYAN}{options[i]}{NORMAL}{new string(' ', 59 - options[i].Length)}│");
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
                    Console.Clear();
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
                                                                                                 ╚═╝░░╚═╝╚═╝╚═╝░░╚═╝╚═╝░░░░░░╚════╝░╚═╝░░╚═╝░░░╚═╝░░░             `*-// \\.._\             /_..// \\-*`
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

    public static string GetString(string prompt)
    {
        Console.Write(prompt);

        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
            {
                password += key.KeyChar;
                Console.Write(key.KeyChar); // Echo the character
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                // Remove the last character from the password
                password = password.Substring(0, password.Length - 1);

                // Move the cursor back one position and write a space to "erase" the character
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine(); // Move to the next line after the input

        return password;
    }

    public static void LoadingBar(string loadingString, TimeSpan duration)
    {
        int maxDots = 5; // Maximum number of dots
        int interval = (int)(duration.TotalMilliseconds / (maxDots + 1)); // Calculate interval between dots
        DateTime startTime = DateTime.Now;

        while (DateTime.Now - startTime < duration)
        {
            for (int i = 0; i <= maxDots && DateTime.Now - startTime < duration; i++)
            {
                Console.Write($"{loadingString}{new string('.', i)}\r");
                Thread.Sleep(interval);
            }

            // Clear the line
            Console.Write(new string(' ', Console.WindowWidth - 1) + "\r");
        }
    }
}