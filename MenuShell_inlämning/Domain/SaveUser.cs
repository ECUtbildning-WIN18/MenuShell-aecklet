using System;
using System.Data.SqlClient;

namespace MenuShell_inlämning.Domain
{
    class SaveUser
    {
        public void saveUser(string username, string password, string role)
        {
            string connectionString = "Data Source=(local);Initial Catalog=MenuShell;Integrated Security=true";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command;
                string sql, output = "";

                connection.Open();

                sql = $"INSERT INTO [Users] VALUES ('{username}','{password}','{role}')";

                command = new SqlCommand(sql, connection);

                var dataReader = command.ExecuteNonQuery();

                if (dataReader == 1)
                {
                    Console.WriteLine("User added");
                }

                Console.WriteLine(output);

                Console.ReadKey();
            }
        }
    }
}
