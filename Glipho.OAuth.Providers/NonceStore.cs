namespace Glipho.OAuth.Providers
{
    using System;
    using DotNetOpenAuth.Configuration;
    using DotNetOpenAuth.Messaging.Bindings;

    /// <summary>
    /// A database-backed nonce store for OAuth services.
    /// </summary>
    public class NonceDbStore : INonceStore
    {
        /// <summary>
        /// The nonce lock.
        /// </summary>
        private const string NonceLock = "Nonce Clearance Lock";

         /// <summary>
        /// The nonce clearing interval.
        /// </summary>
        private static readonly TimeSpan NonceClearingInterval = new TimeSpan(0, 10, 00);

        /// <summary>
        /// The last nonce clearance time.
        /// </summary>
        private static DateTime lastNonceClearance;

       /// <summary>
        /// The nonces database client.
        /// </summary>
        private readonly Database.INonces nonces;

        /// <summary>
        /// Initialises static members of the <see cref="NonceDbStore"/> class.
        /// </summary>
        static NonceDbStore()
        {
            var configuration = new Configuration.ServiceProvider();
            NonceClearingInterval = configuration.Nonces.ClearingInterval;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="NonceDbStore"/> class.
        /// </summary>
        /// <param name="nonces">
        /// The nonces database client.
        /// </param>
        public NonceDbStore(Database.INonces nonces)
        {
            this.nonces = nonces;
        }

        /// <summary>
        /// Stores a given nonce and timestamp. 
        /// </summary>
        /// <param name="context">The context, or namespace, within which the
        /// <paramref name="nonce"/> must be unique.
        /// The context SHOULD be treated as case-sensitive.
        /// The value will never be <c>null</c> but may be the empty string.</param>
        /// <param name="nonce">A series of random characters.</param>
        /// <param name="timestampUtc">The UTC timestamp that together with the nonce string make it unique
        /// within the given <paramref name="context"/>.
        /// The timestamp may also be used by the data store to clear out old nonces.</param>
        /// <returns>
        /// True if the context+nonce+timestamp (combination) was not previously in the database.
        /// False if the nonce was stored previously with the same timestamp and context. 
        /// </returns>
        /// <remarks>
        /// The nonce must be stored for no less than the maximum time window a message may
        /// be processed within before being discarded as an expired message.
        /// This maximum message age can be looked up via the
        /// <see cref="P:DotNetOpenAuth.Configuration.MessagingElement.MaximumMessageLifetime"/>
        /// property, accessible via the <see cref="P:DotNetOpenAuth.Configuration.MessagingElement.Configuration"/>
        /// property. 
        /// </remarks>
        public bool StoreNonce(string context, string nonce, DateTime timestampUtc)
        {
            if (string.IsNullOrWhiteSpace(context))
            {
                throw new ArgumentException("context does not have a value.", "context");
            }

            if (string.IsNullOrWhiteSpace(nonce))
            {
                throw new ArgumentException("nonce does not have a value.", "nonce");
            }

            var nonceEntity = new Database.Nonce(context, nonce, timestampUtc, timestampUtc + DotNetOpenAuthSection.Messaging.MaximumMessageLifetime);
            var nonceAdded = this.nonces.Add(nonceEntity);
            if (nonceAdded)
            {
                // Only clear nonces after successfully storing a nonce.
                // This mitigates cheap DoS attacks that take up a lot of
                // database cycles.
                this.ClearNoncesIfAppropriate();
            }

            return nonceAdded;
        }

        /// <summary>
        /// Clears the nonces if appropriate.
        /// </summary>
        private void ClearNoncesIfAppropriate()
        {
            if (DateTime.UtcNow <= lastNonceClearance + NonceClearingInterval)
            {
                return;
            }

            lock (NonceLock)
            {
                if (DateTime.UtcNow <= lastNonceClearance + NonceClearingInterval)
                {
                    return;
                }

                this.nonces.RemoveExpired();
                lastNonceClearance = DateTime.UtcNow;
            }
        }
    }
}
