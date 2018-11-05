using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using genomgång_Menushell.Domain;


namespace MenuShell_inlämning.Domain
{

    class UserListView
    {
        //public List<User>
        //    public static void Connection()
        //{
        //    string connectionString = "Data Source=(local);Initial Catalog=MenuShell;Integrated Security=true";

        //    using (var Connection = new SqlConnection(connectionString))
        //    {
        //        Connection.Open();
        //    }
        //}

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

                var yes = Console.ReadKey(true).Key;

                if (yes == ConsoleKey.Y)
                {
                    Program.Users.Remove(deleteInput);
                    //users.Remove(deleteInput);
                }
            }
        }
    }
}
