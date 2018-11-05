using genomgång_Menushell.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MenuShell_inlämning.Domain
{
    class GetUsers
    {
        public IList<User> GetAllUsers(string x)
        {
            var users = new List<User>();

            var connectionString = "Data Source=(local);Initial Catalog=DbTraining;Integrated Security=true";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = "SELECT Username, Password, Role FROM Users";

                var sqlCommand = new SqlCommand(sql, connection);

                var dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    var username = dataReader["Username"].ToString();
                    var password = dataReader["Password"].ToString();
                    var role = dataReader["Role"].ToString();

                    var user = new User(username, password, role);
                    users.Add(user);
                }
            }

            return users;
        }
    }
}
