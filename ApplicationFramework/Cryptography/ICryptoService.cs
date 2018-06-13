namespace ApplicationFramework.Cryptography
{
    public interface ICryptoService
    {
        /// <summary>
        /// Gets or sets the number of iterations that the hash will go through
        /// </summary>
        /// <value>
        /// The amount of hash iterations
        /// </value>
        int HashIterations { get; set; }

        /// <summary>
        /// Gets or sets the size of the salt that will be generated if no salt was explicitly set
        /// </summary>
        /// <value>
        /// The size of the salt
        /// </value>
        int SaltSize { get; set; }

        /// <summary>
        /// Gets or sets the plain text to be hashed
        /// </summary>
        /// <value>
        /// The plain text
        /// </value>
        string PlainText { get; set; }

        /// <summary>
        /// Gets the hashed text
        /// </summary>
        /// <value>
        /// The hashed text
        /// </value>
        string HashedText { get; }

        /// <summary>
        /// Gets or sets the salt that will be used in computing the hashed plain text
        /// </summary>
        /// <value>
        /// The salt
        /// </value>
        string Salt { get; set; }

        /// <summary>
        /// Computes the hash
        /// </summary>
        /// <returns>
        /// The computed hash
        /// </returns>
        string Compute();

        /// <summary>
        /// Computes the hash
        /// </summary>
        /// <param name="textToHash">The plain text to hash</param>
        /// <returns>
        /// The computed hash
        /// </returns>
        string Compute(string textToHash);

        /// <summary>
        /// Computes the hash
        /// </summary>
        /// <param name="textToHash">The plain text to hash</param>
        /// <param name="saltSize">Size of the salt</param>
        /// <param name="hashIterations">The hash iterations</param>
        /// <returns>
        /// The computed hash
        /// </returns>
        string Compute(string textToHash, int saltSize, int hashIterations);

        /// <summary>
        /// Computes the hash
        /// </summary>
        /// <param name="textToHash">The plain text to hash</param>
        /// <param name="salt">The salt</param>
        /// <returns>
        /// The computed hash
        /// </returns>
        string Compute(string textToHash, string salt);

        /// <summary>
        /// Generates a salt with default salt size and iterations
        /// </summary>
        /// <returns>
        /// The generated salt
        /// </returns>
        string GenerateSalt();

        /// <summary>
        /// Generates the salt
        /// </summary>
        /// <param name="hashIterations">The hash iteration amount to add to the salt</param>
        /// <param name="saltSize">Size of the salt</param>
        /// <returns>
        /// The generated salt
        /// </returns>
        string GenerateSalt(int hashIterations, int saltSize);

        /// <summary>
        /// Gets the time in milliseconds that it takes to complete the hash for the given amount of iterations
        /// </summary>
        /// <param name="password">The password</param>
        /// <param name="salt">The salt</param>
        /// <param name="iterations">The iterations</param>
        /// <returns>
        /// The time in milliseconds that it takes to complete the hash for the given amount of iterations
        /// </returns>
        int GetElapsedTimeForIteration(string password, string salt, int iterations);

        /// <summary>
        /// Compares the given password hashes for equality
        /// </summary>
        /// <param name="passwordHash1">The first password hash</param>
        /// <param name="passwordHash2">The second password hash</param>
        /// <returns>
        /// true: indicating the password hashes are the same, otherwise false: indicating that the hashes are not the same
        /// </returns>
        bool Compare(string passwordHash1, string passwordHash2);
    }
}
