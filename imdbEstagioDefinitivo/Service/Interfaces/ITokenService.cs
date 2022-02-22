using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(int id, string email, Role role);
    }
}
