using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : Entity<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public Role Role { get; set; } = Role.Usuario;
        public virtual ICollection<Vote> Votes { get; set; }    
        
        public User()
        {

        }

        public User(int id, string password, string nickname, string email, Role role)
        {
            Id = id;
            Password = password;
            Nickname = nickname;
            Email = email;
            Role = role;
        }

        public void ChangeName(string newNickname)
        {
            Nickname = newNickname;
        }

        public void ChangeRole(Role role)
        {
            Role = role;
        }

        public void IsActive(bool status)
        {
            Active = status;
        }

    }
}
