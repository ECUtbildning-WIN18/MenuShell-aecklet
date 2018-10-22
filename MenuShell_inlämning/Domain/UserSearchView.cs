using System;
using System.Collections.Generic;
using System.Linq;
using genomgång_Menushell.Domain;

namespace MenuShell_inlämning.Domain
{
    class UserSearchView
    {
        public static IEnumerable<string> searchResult;
        
        public IEnumerable<string> Display (Dictionary<string, User> users)
        {

            Console.Write("Search by username: ");

            string input = Console.ReadLine();

            searchResult = users.Keys.Where(key => key.Contains(input));

            Console.Clear();

            Console.Write("Results: \n");

            foreach (var name in searchResult)
            {
                Console.WriteLine(name);
            }

            return searchResult;
           

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
