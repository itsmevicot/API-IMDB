using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IHasher
    {
        string EncryptPassword(string senha);
        bool VerifyPassword(string senha, string senhaEncriptada);

    }
}
