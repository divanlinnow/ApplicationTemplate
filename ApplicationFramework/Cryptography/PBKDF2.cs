using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace ApplicationFramework.Cryptography
{
    public class PBKDF2 : ICryptoService
    {
        public PBKDF2()
        {
            HashIterations = 100000;
            SaltSize = 34;
        }

        public int HashIterations { get; set; }

        public int SaltSize { get; set; }

        public string PlainText { get; set; }

        public string HashedText { get; set; }

        public string Salt { get; set; }

        public string Compute()
        {
            if (string.IsNullOrEmpty(PlainText))
            {
                throw new InvalidOperationException("PlainText cannot be empty");
            }

            if (string.IsNullOrEmpty(Salt))
            {
                GenerateSalt();
            }

            HashedText = CalculateHash(HashIterations);

            return HashedText;
        }

        public string Compute(string textToHash)
        {
            PlainText = textToHash;
            Compute();
            return HashedText;
        }

        public string Compute(string textToHash, int saltSize, int hashIterations)
        {
            PlainText = textToHash;
            SaltSize = saltSize;
            HashIterations = hashIterations;
            GenerateSalt(HashIterations, SaltSize);
            Compute();
            return HashedText;
        }

        public string Compute(string textToHash, string salt)
        {
            PlainText = textToHash;
            Salt = salt;
            ExpandSalt();
            Compute();
            return HashedText;
        }

        public string GenerateSalt()
        {
            if (SaltSize < 1)
            {
                throw new InvalidOperationException($"Cannot generate a salt of size {SaltSize}, use a value greater than 1, recommended : 16");
            }

            var randomNumber = RandomNumberGenerator.Create();

            var ret = new byte[SaltSize];

            randomNumber.GetBytes(ret);

            // Assign the generated salt in the format of {iterations}.{salt}
            Salt = $"{HashIterations}.{Convert.ToBase64String(ret)}";

            return Salt;
        }

        public string GenerateSalt(int hashIterations, int saltSize)
        {
            HashIterations = hashIterations;
            SaltSize = saltSize;
            return GenerateSalt();
        }

        public int GetElapsedTimeForIteration(string password, string salt, int iterations)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            CalculateHash(iterations);
            return (int)stopWatch.ElapsedMilliseconds;
        }

        public bool Compare(string passwordHash1, string passwordHash2)
        {
            if (passwordHash1 == null || passwordHash2 == null)
            {
                return false;
            }

            int min_length = Math.Min(passwordHash1.Length, passwordHash2.Length);
            int result = 0;

            for (int i = 0; i < min_length; i++)
            {
                result |= passwordHash1[i] ^ passwordHash2[i];
            }

            return 0 == result;
        }

        private void ExpandSalt()
        {
            try
            {
                // Get the position of the '.' that splits the string
                var index = Salt.IndexOf('.');

                // Get the hash iteration from the first index
                HashIterations = int.Parse(Salt.Substring(0, index), System.Globalization.NumberStyles.Number);

            }
            catch (Exception)
            {
                throw new FormatException("The salt was not in an expected format of {int}.{string}");
            }
        }

        private string CalculateHash(int hashIterations)
        {
            // Convert the salt into a byte array
            var saltBytes = Encoding.UTF8.GetBytes(Salt);

            var pbkdf2 = new Rfc2898DeriveBytes(PlainText, saltBytes, hashIterations);
            var key = pbkdf2.GetBytes(64);

            return Convert.ToBase64String(key);
        }
    }
}
