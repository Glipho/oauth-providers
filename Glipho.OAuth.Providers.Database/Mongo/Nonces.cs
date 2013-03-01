namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// MongoDB implementation of the <see cref="INonces"/> database.
    /// </summary>
    public class Nonces : MongoDbClient, INonces
    {
        /// <summary>
        /// The nonces collection name.
        /// </summary>
        private const string NoncesCollectionName = "nonces";

        /// <summary>
        /// Indicated if the indexes used by this class have been created.
        /// </summary>
        private static bool indexesCreated;

        /// <summary>
        /// The consumers collection.
        /// </summary>
        private MongoCollection<Nonce> noncesCollection;

        /// <summary>
        /// Initialises a new instance of the <see cref="Nonces"/> class.
        /// </summary>
        public Nonces()
        {
            this.InitialiseClass();
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Nonces"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public Nonces(string connectionString)
            : base(connectionString)
        {
            this.InitialiseClass();
        }

        /// <summary>
        /// Adds a nonce to the database.
        /// </summary>
        /// <param name="nonce">Details of the nonce to add.</param>
        /// <returns>true if nonce was successful added; else false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public bool Add(Database.Nonce nonce)
        {
            if (nonce == null)
            {
                throw new ArgumentNullException("nonce", "nonce is null");
            }

            try
            {
                var result = this.noncesCollection.Insert(Nonce.FromNonce(nonce), WriteConcern.WMajority);
                return result.Ok;
            }
            catch (MongoException ex)
            {
                throw new OAuthException("Unable to add nonce to the database. A database error has occurred.", ex, ErrorCode.Database);
            }
        }

        /// <summary>
        /// Remove all expired nonces from the database.
        /// </summary>
        /// <returns>true if removal was successful; else false.</returns>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public bool RemoveExpired()
        {
            try
            {
                var query = Query<Nonce>.LT(n => n.Expires, DateTime.UtcNow);
                var result = this.noncesCollection.Remove(query, RemoveFlags.None, WriteConcern.WMajority);
                return result.Ok;
            }
            catch (MongoException ex)
            {
                throw new OAuthException("Unable to remove expired nonces. A database error has occurred.", ex, ErrorCode.Database);
            }
        }

        /// <summary>
        /// Initialise the class.
        /// </summary>
        private void InitialiseClass()
        {
            this.noncesCollection = this.InitialiseCollection<Nonce>(NoncesCollectionName);
            this.EnsureIndexesExist();
        }

        /// <summary>
        /// Ensure the relevant indexes exist.
        /// </summary>
        private void EnsureIndexesExist()
        {
            if (indexesCreated)
            {
                return;
            }

            lock (NoncesCollectionName)
            {
                if (indexesCreated)
                {
                    return;
                }

                var uniqueNonceIndex = IndexKeys<Nonce>.Ascending(n => n.Context).Ascending(n => n.Code).Ascending(n => n.Issued);
                var indexOptions = IndexOptions.SetBackground(true).SetUnique(true);
                this.noncesCollection.EnsureIndex(uniqueNonceIndex, indexOptions);

                var expiryDateIndex = IndexKeys<Nonce>.Ascending(n => n.Expires);
                this.noncesCollection.EnsureIndex(expiryDateIndex, IndexOptions.SetBackground(true));
                indexesCreated = true;
            }
        }
    }
}
