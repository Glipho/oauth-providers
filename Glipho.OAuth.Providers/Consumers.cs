namespace Glipho.OAuth.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using DotNetOpenAuth.OAuth;

    /// <summary>
    /// Implementation of the IConsumers interface.
    /// </summary>
    public class Consumers : IConsumers
    {
        /// <summary>
        /// Desired length of the consumer secret.
        /// </summary>
        /// <remarks>
        /// TODO: Move this into the configuration section.
        /// </remarks>
        private const int ConsumerSecretLength = 25;

        /// <summary>
        /// The verification code format.
        /// </summary>
        /// <remarks>
        /// TODO: Move this into the configuration section.
        /// </remarks>
        private const VerificationCodeFormat VerificationFormat = VerificationCodeFormat.AlphaNumericNoLookAlikes;

        /// <summary>
        /// The verification code length.
        /// </summary>
        /// <remarks>
        /// TODO: Move this into the configuration section.
        /// </remarks>
        private const int VerificationCodeLength = 10;

        /// <summary>
        /// Random number generator used in generating a consumer secret.
        /// </summary>
        private static readonly RandomNumberGenerator CryptoRandomDataGenerator = new RNGCryptoServiceProvider();

        /// <summary>
        /// The consumers database client.
        /// </summary>
        private readonly Database.IConsumers consumers;

        /// <summary>
        /// Initialises a new instance of the <see cref="Consumers"/> class.
        /// </summary>
        /// <param name="consumers">The consumers database client.</param>
        public Consumers(Database.IConsumers consumers)
        {
            this.consumers = consumers;
        }

        /// <summary>
        /// Create a new consumer.
        /// </summary>
        /// <param name="name">The name of the <see cref="Consumer"/> to create.</param>
        /// <returns>The created <see cref="Consumer"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public Consumer Create(string name)
        {
            return this.Create(name, null, null);
        }

        /// <summary>
        /// Create a new <see cref="Consumer"/> with a callback URL.
        /// </summary>
        /// <param name="name">The name of the <see cref="Consumer"/> to create.</param>
        /// <param name="callback">The callback URL of the <see cref="Consumer"/>.</param>
        /// <returns>The created <see cref="Consumer"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public Consumer Create(string name, Uri callback)
        {
            return this.Create(name, callback, null);
        }

        /// <summary>
        /// Create a new <see cref="Consumer"/> with a X509 certificate.
        /// </summary>
        /// <param name="name">The name of the <see cref="Consumer"/> to create.</param>
        /// <param name="certificate">The X509 certificate for the user.</param>
        /// <returns>The created <see cref="Consumer"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public Consumer Create(string name, X509Certificate2 certificate)
        {
            return this.Create(name, null, certificate);
        }

        /// <summary>
        /// Create a new <see cref="Consumer"/> with a callback URL and a X509 certificate.
        /// </summary>
        /// <param name="name">The name of the <see cref="Consumer"/> to create.</param>
        /// <param name="callback">The callback URL of the <see cref="Consumer"/>.</param>
        /// <param name="certificate">The X509 certificate for the user.</param>
        /// <returns>The created <see cref="Consumer"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public Consumer Create(string name, Uri callback, X509Certificate2 certificate)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name does not have a value.", "name");
            }

            var secret = GenerateConsumerSecret(ConsumerSecretLength);
            var dataConsumer = new Database.Consumer
            {
                Callback = callback,
                Certificate = certificate,
                Name = name,
                Secret = secret,
                VerificationCodeFormat = (int)VerificationFormat,
                VerificationCodeLength = VerificationCodeLength,
            };
            var createdConsumer = this.consumers.Create(dataConsumer);
            return Consumer.FromDataConsumer(createdConsumer);
        }

        /// <summary>
        /// Retrieve a <see cref="Consumer"/>.
        /// </summary>
        /// <param name="key">The key of the <see cref="Consumer"/> to return.</param>
        /// <returns>The <see cref="Consumer"/> if found; else null.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public Consumer Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("key does not have a value.", "key");
            }

            var consumer = this.consumers.Get(key);
            if (consumer == null)
            {
                return null;
            }

            return Consumer.FromDataConsumer(consumer);
        }

        /// <summary>
        /// List all consumers by name.
        /// </summary>
        /// <param name="offset">The amount to offset the results by. Minimum of 0.</param>
        /// <param name="limit">The maximum number of results to return. Minimum of 0 and maximum of 100.</param>
        /// <returns>A list of <see cref="Consumer"/> within the specified range.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if a parameter is outside of a permitted range.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        /// <remarks>
        /// <para>
        /// If there are no results with the given range, an empty list should be returned.
        /// </para>
        /// </remarks>
        public IList<Consumer> List(int offset, int limit)
        {
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("offset", offset, "offset is less than 0.");
            }

            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException("limit", limit, "limit is less than 0.");
            }

            if (limit > 100)
            {
                throw new ArgumentOutOfRangeException("limit", limit, "limit is greater than 100.");
            }

            return this.consumers.List(offset, limit).Select(Consumer.FromDataConsumer).ToList();
        }

        /// <summary>
        /// Gets a cryptographically strong random sequence of values.
        /// </summary>
        /// <param name="length">The length of the sequence to generate.</param>
        /// <returns>The generated values, which may contain zeros.</returns>
        private static byte[] GetCryptoRandomData(int length)
        {
            var buffer = new byte[length];
            CryptoRandomDataGenerator.GetBytes(buffer);
            return buffer;
        }

        /// <summary>
        /// Gets a cryptographically strong random sequence of values.
        /// </summary>
        /// <param name="binaryLength">The length of the byte sequence to generate.</param>
        /// <returns>A base64 encoding of the generated random data, 
        /// whose length in characters will likely be greater than <paramref name="binaryLength"/>.</returns>
        private static string GenerateConsumerSecret(int binaryLength)
        {
            var uniqBytes = GetCryptoRandomData(binaryLength);
            var uniq = Convert.ToBase64String(uniqBytes);
            return uniq;
        }
    }
}
