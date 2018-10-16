using System;
using System.Collections.Generic;
using System.Text;

namespace genomgång_Menushell.Domain
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
