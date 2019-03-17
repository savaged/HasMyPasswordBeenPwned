using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Savaged.HasMyPasswordBeenPwned.Lib
{
    public class HashService
    {
        private readonly string _input;

        public HashService(string input)
        {
            _input = input;
            if (!string.IsNullOrEmpty(_input))
            {
                Hash = ToHash(_input);
            }
            else
            {
                Hash = string.Empty;
            }
        }

        public string Hash { get; }

        private string ToHash(string input)
        {
            var value = string.Empty;
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                var hash = sha1.ComputeHash(
                    Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder();
                foreach (var b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                value = sb.ToString();
            }
            return value;
        }
    }
}
