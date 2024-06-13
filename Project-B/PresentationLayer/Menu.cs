public static class Menu
{
    public static int MenuPanel(ValueTuple<string, string> titles, string[] options, string Towrite1 = "", string Towrite2 = "")
    {
        string NL = Environment.NewLine;
        string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
        string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
        string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
        string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
        string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
        string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";
        string BOLD = Console.IsOutputRedirected ? "" : "\x1b[1m";
        string NOBOLD = Console.IsOutputRedirected ? "" : "\x1b[22m";
        string UNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[4m";
        string NOUNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[24m";
        string REVERSE = Console.IsOutputRedirected ? "" : "\x1b[7m";
        string NOREVERSE = Console.IsOutputRedirected ? "" : "\x1b[27m";
        int selectedOptionIndex = 0;
        while (true)
        {
            Console.Clear();

            Console.WriteLine(Towrite1);
            Console.WriteLine(Towrite2);

            Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
            Console.WriteLine($"│     {CYAN}{titles.Item1.PadRight(56)}{NORMAL} |");
            Console.WriteLine($"│                                                              | ");
            Console.WriteLine($"│     {CYAN}{titles.Item2.PadRight(56)}{NORMAL} |");
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
                Console.Write(key.KeyChar);
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);

                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();

        return password;
    }

    public static string GetString(string prompt, string suffix, int padLeft)
    {
        Console.Write(prompt);
        string input = "";
        ConsoleKeyInfo key;
        Console.Write(new string(' ', padLeft) + suffix);
        Console.SetCursorPosition(prompt.Length, Console.CursorTop);

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
            {
                input += key.KeyChar;
                Console.Write(key.KeyChar + new string(' ', padLeft - input.Length) + suffix);
                Console.SetCursorPosition(prompt.Length + input.Length, Console.CursorTop);
            }
            else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input = input.Substring(0, input.Length - 1);
                Console.SetCursorPosition(prompt.Length + input.Length, Console.CursorTop);
                Console.Write(" " + new string(' ', padLeft - input.Length) + suffix + " ");
                Console.SetCursorPosition(prompt.Length + input.Length, Console.CursorTop);
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();

        return input;
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
            Console.Write(new string(' ', Console.WindowWidth - 1) + "\r");
        }
    }
}