﻿using System;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
public class Program 
{
    static void Main()
    {
        Menu.StartMenu();
        List<Flight> flights = Flight.LoadJson();
        Account account = new();
       
        Console.Title = "Flight Application";
        Thread.Sleep(2000);
        string NL = Environment.NewLine; // shortcut
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
        bool state = true;


        Console.CursorVisible = false;
        while(state)
        {
            int selectedOptionIndex = Menu.MenuPanel("Login Menu", "Here u can login", ["Login", "Sign up", "Search Flight", "Show all flights", "Quit Program"]);
        
                    
                    switch (selectedOptionIndex)
                    {
                        case 0:  
                            string email = Menu.GetString("ENTER email: ");
                            string password = Menu.GetString("ENTER PASSWORD: ");

                            bool UserState = account.Logintodb(email, password);
                            Console.Clear();
                            Menu.LoadingBar("Loading account", TimeSpan.FromSeconds(2));
                            if (account.IsAdminbool)
                            {
                                bool AdminPanelState = true;
                                while (AdminPanelState)
                                {
                                    int AdminPanelIndex = Menu.MenuPanel("Admin panel", "Here u can control all the reservations and flights", ["Add a flight", "Remove a flight", "Change a flight", "Search a flight", "Show all flights", "Log out", "Quit Program"]);

                                    switch(AdminPanelIndex)
                                    {
                                        case 0:
                                            Console.WriteLine("Add a flight");
                                            Console.ReadKey();
                                            break;
                                        
                                        case 1:
                                            Console.WriteLine("Remove a flight");
                                            Console.ReadKey();
                                            break;
                                        
                                        case 2:
                                            Console.WriteLine("Change a flight");
                                            Console.ReadKey();
                                            break;

                                        case 3:
                                            Console.WriteLine("Search a flight");
                                            Console.ReadKey();
                                            break;
                                        
                                        case 4:
                                            Console.Clear();
                                            Menu.LoadingBar("Loading flights", TimeSpan.FromSeconds(1));
                                            Console.Clear();
                                            Flightinfo.DisplayFlights(flights);
                                            Console.WriteLine("Enter a key to go back to the menu");
                                            Console.ReadKey();
                                            break;

                                        case 5:
                                            Menu.LoadingBar("Logging out", TimeSpan.FromSeconds(2));
                                            account.logout();
                                            AdminPanelState = false;
                                            break;
                                        
                                        case 6:
                                            Console.WriteLine($"{NORMAL}CLOSING THE APPLICATION{NORMAL}");
                                            Thread.Sleep(1000);
                                            Environment.Exit(1);
                                            break;
                                    }
                                }
                            }
                            else if(account.IsLoggedIn)
                            {
                                bool UserPanelState = true;
                                while(UserPanelState)
                                {
                                    int UserPanelIndex = Menu.MenuPanel("Guest Menu","Here u can", ["Search for a flight", "Make a reservation","Change reservation", "Display all flights", "logout", "Quit Program"]);

                                    switch(UserPanelIndex)
                                    {
                                        case 0:
                                            Console.Clear();
                                            bool SearchingState = true;
                                            while(SearchingState)
                                            {
                                                int SearchingOptionIndex = Menu.MenuPanel("Searching options", "Choose between these 3 options", ["Destination", "Departure Date", "Airplane Model", "Back to admin panel"]);
                                                    
                                                    switch(SearchingOptionIndex)
                                                    {
                                                        case 0:
                                                            Console.Clear();
                                                            string DestAnswer = Menu.GetString("Enter a destination to look for: ");
                                                            Console.Clear();
                                                            Menu.LoadingBar("Looking for result with correct desitnation", TimeSpan.FromSeconds(1));
                                                            Searching.Destination(DestAnswer, flights);
                                                            Console.WriteLine("Enter a key to go back to the searching menu");
                                                            Console.ReadKey();
                                                            break;

                                                        case 3:
                                                            Console.Clear();
                                                            SearchingState = false;
                                                            break;
                                                    }                     
                                            }
                                            break;

                                        case 1:
                                            Console.WriteLine("Make a reservation");
                                            Console.ReadKey();
                                            break;

                                        case 2:
                                            Console.WriteLine("Change reservation");
                                            Console.ReadKey();
                                            break;

                                        case 3:
                                            Console.Clear();
                                            Menu.LoadingBar("Loading flights", TimeSpan.FromSeconds(1));
                                            Console.Clear();
                                            Flightinfo.DisplayFlights(flights);
                                            Console.WriteLine("Enter a key to go back to the menu");
                                            Console.ReadKey();
                                            break;
                                        
                                        case 4:
                                            Menu.LoadingBar("Logging out", TimeSpan.FromSeconds(2));
                                            account.logout();
                                            UserPanelState = false;
                                            break;

                                        case 5:
                                            Console.WriteLine($"{NORMAL}CLOSING THE APPLICATION{NORMAL}");
                                            Thread.Sleep(1000);
                                            Environment.Exit(1);
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Account doesnt exist\nReturning to login screen");
                                Thread.Sleep(1400);
                            }
                            

                            
                            break;
                        case 1:
                            string newUserEmail = Menu.GetString("ENTER A NEW EMAIL: ");

                            while(!Account.IsValidEmail(newUserEmail))
                            {
                                Console.WriteLine("Invalid email, Try again");
                                newUserEmail = Menu.GetString("ENTER A NEW EMAIL: ");
                                Console.Clear();
                            }
                            string newUserPassword = Menu.GetString("ENTER A PASSWORD: ");
                            
                            while(!Account.IsNotNull(newUserPassword))
                            {
                                Console.WriteLine("Password cant be empty!");
                                newUserPassword = Menu.GetString("ENTER A PASSWORD: ");
                                Console.Clear();
                            }

                            Console.Clear();
                            account.Addtodb(newUserEmail, newUserPassword);
                            Menu.LoadingBar("Adding account to database", TimeSpan.FromSeconds(2));
                            break;
                        
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Search a flight");
                            Console.ReadKey();
                            break;
                            
                        case 3:
                            Console.Clear();
                            Menu.LoadingBar("Loading flights", TimeSpan.FromSeconds(1));
                            Console.Clear();
                            Flightinfo.DisplayFlights(flights);
                            Console.WriteLine("Enter a key to go back to the menu");
                            Console.ReadKey();
                            break;

                        case 4:
                            Console.WriteLine($"{NORMAL}CLOSING THE APPLICATION{NORMAL}");
                            Thread.Sleep(1000);
                            Environment.Exit(1);
                            break;
                    }
                    
        }
            
    }
}