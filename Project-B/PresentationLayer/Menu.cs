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
    string NL = Environment.NewLine; // shortcut
    string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
    string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
    int selectedOptionIndex = 0;

    // Calculate center position
    int consoleWidth = Console.WindowWidth;
    int consoleHeight = Console.WindowHeight;
    int titleLength = Title.Length;
    int subTitleLength = SubTitle.Length;
    int optionsCount = options.Length;

    int titleStartPos = (consoleWidth - titleLength) / 2;
    int subTitleStartPos = (consoleWidth - subTitleLength) / 2;

    // Clear the console
    Console.Clear();

    // Print the menu panel
    Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
    Console.WriteLine($"│{new string(' ', consoleWidth - 2)}│");
    Console.WriteLine($"│{new string(' ', titleStartPos)}{CYAN}{Title}{NORMAL}{new string(' ', consoleWidth - titleStartPos - titleLength - 2)}│");
    Console.WriteLine($"│{new string(' ', consoleWidth - 2)}│");
    Console.WriteLine($"│{new string(' ', subTitleStartPos)}{CYAN}{SubTitle}{NORMAL}{new string(' ', consoleWidth - subTitleStartPos - subTitleLength - 2)}│");
    Console.WriteLine($"│{new string(' ', consoleWidth - 2)}│");
    for (int i = 0; i < optionsCount; i++)
    {
        if (i == selectedOptionIndex)
        {
            Console.Write($"│ > {CYAN}{options[i]}{NORMAL}{new string(' ', consoleWidth - options[i].Length - 7)}│");
        }
        else
        {
            Console.WriteLine($"│ > {CYAN}{options[i]}{NORMAL}{new string(' ', consoleWidth - options[i].Length - 7)}│");
        }
    }
    Console.WriteLine($"│{new string(' ', consoleWidth - 2)}│");
    Console.WriteLine("└──────────────────────────────────────────────────────────────┘");

    while (true)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
                selectedOptionIndex = Math.Max(0, selectedOptionIndex - 1);
                break;
            case ConsoleKey.DownArrow:
                selectedOptionIndex = Math.Min(optionsCount - 1, selectedOptionIndex + 1);
                break;
            case ConsoleKey.Enter:
                Console.Clear();
                return selectedOptionIndex;
        }

        // Update the menu panel with the new selection
        Console.SetCursorPosition(0, 3); // Set cursor position to the beginning of the menu panel content
        for (int i = 0; i < optionsCount; i++)
        {
            if (i == selectedOptionIndex)
            {
                Console.Write($"│ > {CYAN}{options[i]}{NORMAL}{new string(' ', consoleWidth - options[i].Length - 7)}│");
            }
            else
            {
                Console.WriteLine($"│ > {CYAN}{options[i]}{NORMAL}{new string(' ', consoleWidth - options[i].Length - 7)}│");
            }
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