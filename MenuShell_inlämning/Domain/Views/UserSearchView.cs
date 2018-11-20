using System;
using System.Collections.Generic;
using System.Linq;
using genomgång_Menushell.Domain;

namespace MenuShell_inlämning.Domain
{
    class UserSearchView
    {
        public static IEnumerable<string> SearchResult;
        
        public IEnumerable<string> Display (Dictionary<string, User> users)
        {

            Console.Write("Search by username: ");

            string input = Console.ReadLine();

            var getallusers = new GetUser();

            Console.Clear();

            Console.Write("Results: \n");

            getallusers.Fetch(input);

            foreach (var name in SearchResult)
            {
                Console.WriteLine(name);
            }

            return SearchResult;
           

            //Console.Write("\n(D)elete");

            //var delete = Console.ReadKey(true).Key;

            //if (delete == ConsoleKey.D)
            //{
            //    Console.Clear();

            //    foreach (var name in searchResult)
            //    {
            //        Console.WriteLine(name);
            //    }

            //    Console.Write("\nDelete: ");

            //    var deleteInput = Console.ReadLine();

            //    Console.Write("(Y)es (N)o ");

            //    var Yes = Console.ReadKey(true).Key;

            //    if (Yes == ConsoleKey.Y)
            //    {
            //        users.Remove(deleteInput);
            //    }                      

        }
    }
}
