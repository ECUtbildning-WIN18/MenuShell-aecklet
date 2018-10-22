using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using genomgång_Menushell.Domain;
using MenuShell_inlämning.Domain;

namespace genomgång_Menushell
{
    class Program
    {
        const string administrator = "Administrator";
        const string receptionist = "Receptionist";
        const string veterinarian = "Veterinarian";

        public static Dictionary<string, User> Users = new Dictionary<string, User>();
        //{
        //    {"admin", new User("admin", "8008135", administrator)},
        //    {"jake", new User("user", "8008135", receptionist)},
        //    {"john", new User("user","8008135", veterinarian)},
        //    {"jane", new User("user","8008135", "")}
        //};

        static void Main(string[] args)
        {
            logout:

            bool notLoggedIn = true;            

            var admin = new User("admin", "secret", "Administrator");

            var search = new UserSearchView();
            var delete = new UserListView();           

            User user = null;

            Users.Add("admin", new User("admin", "8008135", administrator));
            Users.Add("jake", new User("user", "8008135", receptionist));
            Users.Add("john", new User("user", "8008135", veterinarian));

            do
            {
                Console.Clear();

                Console.Write("Username: ");
                var username = Console.ReadLine();

                Console.Write("Password: ");
                var password = Console.ReadLine();

                Console.WriteLine("Is this correct? (Y)es (N)o");

                var answer = Console.ReadKey(true).Key;

                if (answer == ConsoleKey.Y)
                {
                    if (Users.ContainsKey(username) && Users[username].Password == password)
                    {
                        user = Users[username];
                        notLoggedIn = false;
                    }
                    else
                    {
                        Console.WriteLine("\nInvlaid input, try again.");
                        Thread.Sleep(2000);
                    }
                }
                else if (answer != ConsoleKey.N)
                {
                    Console.WriteLine("\nInvalid selection");
                    Thread.Sleep(2000);
                }

            } while (notLoggedIn);

            Console.Clear();

            if (user.Role == administrator)
            {
                Start:

                Console.Clear();
                ShowAdministratorArea();

                var menuSelection = Console.ReadKey(true).Key;

                switch (menuSelection)
                {
                    case ConsoleKey.D1:
                        Console.Clear();

                        Console.Write("Username: ");
                        string username = Console.ReadLine();

                        Console.Write("Password: ");
                        string password = Console.ReadLine();

                        Console.WriteLine($"Role: 1. {administrator} 2. {receptionist} 3. {veterinarian} \n");

                        var answer = Console.ReadKey(true).Key;

                        switch (answer)
                        {
                            case ConsoleKey.D1:
                                Users.Add(username, new User(username, password, administrator));
                                break;
                            case ConsoleKey.D2:
                                Users.Add(username, new User(username, password, receptionist));
                                break;
                            case ConsoleKey.D3:
                                Users.Add(username, new User(username, password, veterinarian));
                                break;
                        }

                        Console.WriteLine("Press any key to return to previous menu.");

                        Console.ReadKey();

                        goto Start;

                    case ConsoleKey.D2:

                        Console.Clear();

                        var searchResult = search.Display(Users);

                        delete.Display(searchResult);


                        //    Console.WriteLine("Search by username:");

                        //    string input = Console.ReadLine();                       

                        //    var searchResult = users.Keys.Where(key => key.Contains(input));

                        //    Console.Clear();                       

                        //    Console.WriteLine("Results:");

                        //    foreach (var name in searchResult)
                        //    {
                        //         Console.WriteLine(name);
                        //    }

                        //    Console.Write("\n(D)elete");

                        //    var delete = Console.ReadKey(true).Key;

                        //    if (delete == ConsoleKey.D)
                        //    {
                        //        Console.Clear();

                        //        foreach (var name in searchResult)
                        //        {
                        //            Console.WriteLine(name);
                        //        }

                        //        Console.Write("\nDelete: ");

                        //        var deleteInput = Console.ReadLine();

                        //        Console.Write("(Y)es (N)o ");

                        //        var Yes = Console.ReadKey(true).Key;

                        //        if (Yes == ConsoleKey.Y)
                        //        {
                        //            users.Remove(deleteInput);
                        //        }                      
                        //    }

                        //users.ToList().ForEach(x => Console.WriteLine(x.Key));

                        //Console.WriteLine("\nPress any key to return to previous menu.");                        

                        goto Start;

                    //case ConsoleKey.D3:

                    //    Console.Clear();

                    //    users.ToList().ForEach(x => Console.WriteLine(x.Key));

                    //    Console.WriteLine("\nEnter name of the user you wish to delete.");

                    //    users.Remove(Console.ReadLine());

                    //    Console.Clear();

                    //    users.ToList().ForEach(x => Console.WriteLine(x.Key));

                    //    Console.WriteLine("\nPress any key to return to previous menu.");

                    //    Console.ReadKey();

                    //goto Start;

                    case ConsoleKey.D4:

                        goto logout;
                }
            }
            else if (user.Role == receptionist)
            {
                ShowReceptionistAre();

                var menuSelection = Console.ReadKey(true).Key;

                switch (menuSelection)
                {
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            else if (user.Role == veterinarian)
            {
                ShowVeterinarianArea();

                var menuSelection = Console.ReadKey(true).Key;

                switch (menuSelection)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D2:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        static void ShowAdministratorArea()
        {
            //admin
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Search users");
            //Console.WriteLine("3. Remove user");
            Console.WriteLine("4. Exit");
        }
        static void ShowReceptionistAre()
        {
            //receptionist
            Console.WriteLine("1. Register customer");
            Console.WriteLine("2. Make appointment");
            Console.WriteLine("3. Exit");
        }

        static void ShowVeterinarianArea()
        {
            //vetrinarian
            Console.WriteLine("1. List appointment");
            Console.WriteLine("2. Exit");
        }
    }
}
