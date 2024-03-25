
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private int id;
        private string name;
        private string password;
        private UserRolesEnum role;
        private DateTime expires;

        public User()
        {
            
        }
        public User(string name, string password, UserRolesEnum role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }
        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

     
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [AllowNull]
        public UserRolesEnum Role
        {
            get { return role; }
            set { _=role = value; }
        }

        [AllowNull]
        public DateTime Expires
        {
            get { return expires; }
            set { expires = value; }
        }
    }
}
