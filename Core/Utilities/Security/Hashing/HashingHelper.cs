using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)  //Şifre hashi ve saltı oluşturur. out ile dışarı hashe ve salt çıkarıyoruz.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())   //hmac: Kriptografide kullandığımız classa denk gelir. 512 algoritmasını kullanıyoruz hashlemede.
            {
                passwordSalt = hmac.Key;   //hmac her kullanıcı için bize salt şifre oluşturur.
                passwordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(password));  //Şifreyi byte dönüştürdük parantez içinde.Hash şifre oluşturduk.
            }
        }


        public static bool VerifyPasswordHash(string password,  byte[] passwordHash,  byte[] passwordSalt)   //Yukarıda oluşan hash ile kullanıcını girdiği şifreyi doğruladığımız yer.
        {
            using ( var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));  //Kullanıcının girdiği şifreyi doğruluyoruz tekrar vererek.

                for(int i = 0; i <= computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordSalt[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }


    }
}
