﻿using System.Text;

namespace Core.Utilities.Security.Hashing
{
    //Araç classın arayüzü açık kalsa da sorun olmaz
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var coumputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < coumputedHash.Length ; i++)
                {
                    if (coumputedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
    }
}