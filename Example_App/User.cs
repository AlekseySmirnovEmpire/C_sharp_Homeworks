using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_App
{
    internal class User
    {
        public int id { get; set; }

        private string login, password;

        public string Login 
        { 
            get { return login; } 
            set { login = value; } 
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public User()
        {
        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public override string ToString()
        {
            return "Пользователь с логином: " + Login;
        }
    }
}
