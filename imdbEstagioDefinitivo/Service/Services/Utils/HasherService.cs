using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Utils
{
    public class HasherService : IHasherService
    {
        private readonly HashAlgorithm _hasher;
        public HasherService()
        {
            _hasher = SHA256.Create();
        }
        public string EncryptPassword(string senha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var senhaEncriptada = _hasher.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caractere in senhaEncriptada)
            {
                sb.Append(caractere.ToString("X2"));
            }
            return sb.ToString();
        }

        public bool VerifyPassword(string password, string encryptedPassword)
        {
            var _encryptedPassword = EncryptPassword(password);
            return _encryptedPassword.Equals(encryptedPassword);
        }
    }
}
