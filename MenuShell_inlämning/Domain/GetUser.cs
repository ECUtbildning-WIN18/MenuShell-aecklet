using System;
using System.Data.SqlClient;

namespace MenuShell_inlämning.Domain
{
    class GetUser
    {
        public void Fetch(string username)
        {
            string connectionString = "Data Source=(local);Initial Catalog=MenuShell;Integrated Security=true";

            using (var connection = new SqlConnection(connectionString))
            {                
                
                SqlCommand command;
                //SqlDataAdapter adapter = new SqlDataAdapter();
                string sql, output = "";

                connection.Open();

                sql = $"SELECT '{username}' FROM [Users]";

                command = new SqlCommand(sql, connection);

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    output = dataReader.GetValue(0).ToString();
                }

                Console.WriteLine(output);

                Console.ReadKey();
            }            
        }        
    }
}
