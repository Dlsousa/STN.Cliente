using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace STN.Clientes.Domain.Helpers
{
    public static class StringHelpers
    {
        public static string Encrypt(this string senha)
        {
            var salt = "D31161315836465094A38F1A3F10369DB2B0131CEEF14CDCA67B61736BD4E3B2";
            var arrayByteOriginal = Encoding.UTF8.GetBytes(senha + salt);

            byte[] arrayByteCripto;

            using (var sha = SHA512.Create())
            {
                arrayByteCripto = sha.ComputeHash(arrayByteOriginal);
            }

            return Convert.ToBase64String(arrayByteCripto);
        }
    }
}
