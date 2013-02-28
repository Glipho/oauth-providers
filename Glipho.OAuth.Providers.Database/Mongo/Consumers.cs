namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// MongoDB implementation of the <see cref="IConsumers"/> database.
    /// </summary>
    public class Consumers : MongoDbClient, IConsumers
    {
        /// <summary>
        /// The consumers collection name.
        /// </summary>
        internal const string ConsumersCollectionName = "consumers";

        /// <summary>
        /// Indicated if the indexes used by this class have been created.
        /// </summary>
        private static bool indexesCreated;

        /// <summary>
        /// The consumers collection.
        /// </summary>
        private MongoCollection<Consumer> consumersCollection;

        /// <summary>
        /// Initialises a new instance of the <see cref="Consumers"/> class.
        /// </summary>
        public Consumers()
        {
            this.InitialiseClass();
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Consumers"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public Consumers(string connectionString)
            : base(connectionString)
        {
            this.InitialiseClass();
        }

        /// <summary>
        /// Retrieve a consumer from the database.
        /// </summary>
        /// <param name="id">The identifier of the consumer to retrieve.</param>
        /// <returns>The <see cref="Database.Consumer"/> if found; else null.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public Database.Consumer Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("key does not have a value.", "id");
            }

            try
            {
                var consumer = this.consumersCollection.FindOne(Query<Consumer>.EQ(c => c.Id, new BsonObjectId(id)));
                return consumer.ToConsumer();
            }
            catch (MongoException ex)
            {
                throw new OAuthException("Unable to retrieve requested consumer. A database error has occurred.", ex, ErrorCode.Database);
            }
        }

        /// <summary>
        /// Initialise the class.
        /// </summary>
        private void InitialiseClass()
        {
            this.consumersCollection = this.InitialiseCollection<Consumer>(ConsumersCollectionName);
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

            lock (ConsumersCollectionName)
            {
                if (indexesCreated)
                {
                    return;
                }

                indexesCreated = true;
            }
        }
    }
}
