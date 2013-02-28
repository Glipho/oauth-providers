namespace Glipho.OAuth.Providers
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using DotNetOpenAuth.OAuth;
    using DotNetOpenAuth.OAuth.ChannelElements;

    /// <summary>
    /// Implementation of the <see cref="IConsumerDescription"/> interface.
    /// </summary>
    public class Consumer : IConsumerDescription
    {
        /// <summary>
        /// Gets the friendly name of the consumer.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the callback URI that this consumer has pre-registered with the service provider, if any. 
        /// </summary> 
        /// <value>
        /// A URI that user authorization responses should be directed to; or <c>null</c> if no preregistered callback was arranged.
        /// </value>
        public Uri Callback { get; private set; }

        /// <summary>
        /// Gets the certificate that can be used to verify the signature of an incoming
        /// message from a Consumer. 
        /// </summary> 
        /// <returns>
        /// The public key from the Consumer's X.509 Certificate, if one can be found; otherwise <c>null</c>.
        /// </returns> 
        /// <remarks>
        /// This property must be implemented only if the RSA-SHA1 algorithm is supported by the Service Provider. 
        /// </remarks>
        public X509Certificate2 Certificate { get; private set; }

        /// <summary>
        /// Gets the Consumer key. 
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the consumer secret. 
        /// </summary>
        public string Secret { get; private set; }

        /// <summary>
        /// Gets the verification code format that is most appropriate for this consumer
        /// when a callback URI is not available. 
        /// </summary> 
        /// <value>
        /// A set of characters that can be easily keyed in by the user given the Consumer's
        /// application type and form factor.
        /// </value> 
        /// <remarks>
        /// The value <see cref="F:DotNetOpenAuth.OAuth.VerificationCodeFormat.IncludedInCallback"/> should NEVER be returned
        /// since this property is only used in no callback scenarios anyway. 
        /// </remarks>
        public VerificationCodeFormat VerificationCodeFormat { get; private set; }

        /// <summary>
        /// Gets the length of the verification code to issue for this Consumer. 
        /// </summary> 
        /// <value>
        /// A positive number, generally at least 4.
        /// </value>
        public int VerificationCodeLength { get; private set; }

        /// <summary>
        /// Create a new consumer from a database consumer.
        /// </summary>
        /// <param name="consumer">The database consumer to create a new consumer from.</param>
        /// <returns>A new consumer created from the database consumer.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        internal static Consumer FromDataConsumer(Database.Consumer consumer)
        {
            if (consumer == null)
            {
                throw new ArgumentNullException("consumer", "consumer is null");
            }

            return new Consumer
            {
                Callback = consumer.Callback,
                Certificate = consumer.Certificate,
                Key = consumer.Id,
                Name = consumer.Name,
                Secret = consumer.Secret,
                VerificationCodeFormat = (VerificationCodeFormat)consumer.VerificationCodeFormat,
                VerificationCodeLength = consumer.VerificationCodeLength,
            };
        }
    }
}
