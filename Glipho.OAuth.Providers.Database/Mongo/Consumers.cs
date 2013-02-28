namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        /// Create a new consumer.
        /// </summary>
        /// <param name="newConsumer">The <see cref="Database.Consumer"/> to create.</param>
        /// <returns>The created <see cref="Database.Consumer"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public Database.Consumer Create(Database.Consumer newConsumer)
        {
            if (newConsumer == null)
            {
                throw new ArgumentNullException("newConsumer", "newConsumer is null");
            }

            try
            {
                var dataConsumer = Consumer.FromConsumer(newConsumer);
                this.consumersCollection.Insert(dataConsumer, WriteConcern.WMajority);
                return dataConsumer.ToConsumer();
            }
            catch (MongoException ex)
            {
                throw new OAuthException("Unable to create a consumer. A database error has occurred.", ex, ErrorCode.Database);
            }
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
        /// List all consumers by name.
        /// </summary>
        /// <param name="offset">The amount to offset the results by. Minimum of 0.</param>
        /// <param name="limit">The maximum number of results to return. Maximum of 100.</param>
        /// <returns>A list of <see cref="Database.Consumer"/> within the specified range.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if a parameter is outside of a permitted range.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        /// <remarks>
        /// <para>
        /// If there are no results with the given range, an empty list should be returned.
        /// </para>
        /// </remarks>
        public IList<Database.Consumer> List(int offset, int limit)
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

            var cursor = this.consumersCollection.FindAll();
            cursor.SetSkip(offset).SetLimit(limit);
            return cursor.Select(c => c.ToConsumer()).ToList();
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
