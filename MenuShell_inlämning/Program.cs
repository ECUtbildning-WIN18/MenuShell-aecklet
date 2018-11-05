using System;
using System.Collections.Generic;
using System.Threading;
using genomgång_Menushell.Domain;
using MenuShell_inlämning.Domain;

namespace MenuShell_inlämning
{
    class Program
    {     
        const string Administrator = "Administrator";
        const string Receptionist = "Receptionist";
        const string Veterinarian = "Veterinarian";

        public static Dictionary<string, User> Users = new Dictionary<string, User>
        {
            {"admin", new User("admin", "password", Administrator)},
            {"jake", new User("user", "password", Receptionist)},
            {"john", new User("user","password", Veterinarian)},
            {"jane", new User("user","password", "")}
        };

        static void Main()
        {
            var getUser = new GetUser();
            var saveUser = new SaveUser();
            var deletUser = new DeleteUser();            
                               
            logout:

            bool notLoggedIn = true;                       

            var search = new UserSearchView();
            var delete = new UserListView();           

            User user = null;            

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

            if (user.Role == Administrator)
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

                        Console.WriteLine($"Role: 1. {Administrator} 2. {Receptionist} 3. {Veterinarian} \n");

                        var answer = Console.ReadKey(true).Key;

                        switch (answer)
                        {
                            case ConsoleKey.D1:
                                saveUser.saveUser(username, password, Administrator);
                                //Users.Add(username, new User(username, password, Administrator));
                                break;
                            case ConsoleKey.D2:
                                saveUser.saveUser(username, password, Receptionist);
                                //Users.Add(username, new User(username, password, Receptionist));
                                break;
                            case ConsoleKey.D3:
                                saveUser.saveUser(username, password, Veterinarian);
                                //Users.Add(username, new User(username, password, Veterinarian));
                                break;
                        }

                        Console.WriteLine("Press any key to return to previous menu.");

                        Console.ReadKey();

                        goto Start;

                    case ConsoleKey.D2:

                        Console.Clear();

                        Console.Write("Enter Username: ");
                        string searchUserName = Console.ReadLine();

                        Console.Write("Enter Role: ");
                        string searchRole = Console.ReadLine();

                        getUser.Fetch(searchUserName);

                    //var searchResult = search.Display(Users);

                    //delete.Display(searchResult);

                        goto Start;

                    case ConsoleKey.D3:

                        Console.Clear();

                        Console.WriteLine("Enter Username: ");
                        string deleteUserName = Console.ReadLine();

                        Console.WriteLine("Enter role: ");
                        string deleteRole = Console.ReadLine();

                        deletUser.deleteUser(deleteUserName, deleteRole);

                        goto Start;
                   
                    case ConsoleKey.D4:

                        goto logout;
                }
            }
            else if (user.Role == Receptionist)
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
                }
            }
            else if (user.Role == Veterinarian)
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
                }
            }
        }

        static void ShowAdministratorArea()
        {
            //admin
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Search users");
            Console.WriteLine("3. Remove user");
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
