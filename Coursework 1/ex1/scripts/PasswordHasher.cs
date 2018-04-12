using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace ex1.scripts
{
    public class PasswordHasher
    {
        // got this code from my old university lecturer Dr Ian sexton and adapted it.
        // also followed some videos for help on sha256 passwords https://www.youtube.com/watch?v=oJpZ5ygg4qQ
        // also used this link as well for help https://www.youtube.com/watch?v=0dgTf9TUDHU
        // guidence from https://codeshare.co.uk/blog/sha-256-and-sha-512-hash-examples/


        public static string GetPasswordHash(string password)
        {
            SHA256 sha256 = SHA256Managed.Create(); // create the sha256 password you can have 512 and 128 but 256 is strong enough
            byte[] hash = sha256.ComputeHash(Encoding.ASCII.GetBytes(password)); // it encodes the hash
            string pwdHash = "";
            foreach (byte b in hash)
                pwdHash += b.ToString("X2");
            return pwdHash; // returns the paswwrod in a hash value
        }
    }
}