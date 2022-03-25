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

        public void ChangeName(string newNickname)
        {
            Nickname = newNickname;
        }

        public void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }

        public void ChangeRole(Role role)
        {
            Role = role;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
     
        public void IsActive(bool status)
        {
            Active = status;
        }

        public void InactivateUser()
        {
            Active = false;
        }

    }
}
