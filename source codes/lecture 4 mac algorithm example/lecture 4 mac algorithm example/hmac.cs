using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace lecture_4_mac_algorithm_example
{
    public static class hmac
    {
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string computeMacValue(string srInput, string srKey)
        {
            //since the collision chance of SHA256 is close to 0, this should pretty well work
            return ComputeSha256Hash(srKey + srInput);
        }

    }
}
