using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.UserDTO
{
    public class LoginTokenDTO
    {
        public string Email { get; set; }
        public string Nickname { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
    }
}
