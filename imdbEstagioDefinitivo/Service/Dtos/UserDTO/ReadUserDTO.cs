using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.UserDTO
{
    public class ReadUserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
