﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Library.Helpers
{
    public static class Utils
    {
        /// <summary>
        /// Calculates SHA1 hash
        /// </summary>
        /// <param name="text">input string</param>
        /// <param name="enc">Character encoding</param>
        /// <returns>SHA1 hash</returns>
        public static string CalculateSHA1(string text, Encoding enc)
        {
            // Convert the input string to a byte array
            byte[] buffer = enc.GetBytes(text);

            // In doing your test, you won't want to re-initialize like this every time you test a 
            // string.
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();

            // The replace won't be necessary for your tests so long as you are consistent in what
            // you compare.    
            string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }
    }
}
