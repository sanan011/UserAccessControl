using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_login_page
{
    internal class Profile
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole userRole { get; set; }

        public Profile(string name, string surname, int age, string email, string password, UserRole userRole)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Password = password;
            this.userRole = userRole;
        }
    }
}
