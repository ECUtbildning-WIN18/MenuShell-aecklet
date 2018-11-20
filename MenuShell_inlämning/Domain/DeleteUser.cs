using System;
using System.Data.SqlClient;

namespace MenuShell_inlämning.Domain
{
    class DeleteUser
    {
        public void deleteUser(string username, string role)
        {
            string connectionString = "Data Source=(local);Initial Catalog=MenuShell;Integrated Security=true";

            using (var connection = new SqlConnection(connectionString))
            {

                SqlCommand command;
                //SqlDataAdapter adapter = new SqlDataAdapter();
                string sql, output = "";

                connection.Open();

                sql = $"DELETE FROM [Users] WHERE Username ='{username}'";

                command = new SqlCommand(sql, connection);

                var dataReader = command.ExecuteNonQuery();

                Console.WriteLine("User deleted.");

                Console.WriteLine(output);

                Console.ReadKey();
            }
        }
    }
}
