using System;
using System.Collections.Generic;
using genomgång_Menushell.Domain;
using genomgång_Menushell;

namespace MenuShell_inlämning.Domain
{
    class UserListView
    {
        /// <inheritdoc />
        public void Display(IEnumerable<string> searchResult)
        {

            Console.Write("\n(D)elete");

            var delete = Console.ReadKey(true).Key;

            if (delete == ConsoleKey.D)
            {
                Console.Clear();

                foreach (var name in searchResult)
                {
                    Console.WriteLine(name);
                }

                Console.Write("\nDelete: ");

                var deleteInput = Console.ReadLine();

                Console.Write("(Y)es (N)o ");

                var Yes = Console.ReadKey(true).Key;

                if (Yes == ConsoleKey.Y)
                {
                    Program.Users.Remove(deleteInput);
                    //users.Remove(deleteInput);
                }
            }
        }
    }
}
