namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System.Configuration;
    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// Base class for any class accessing a MongoDB database.
    /// </summary>
    public abstract class MongoDbClient
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="MongoDbClient" /> class.
        /// </summary>
        protected MongoDbClient()
        {
            // TODO: Maybe move this to the configuration section
            // Get the default connection string and instantiate the client with it
            this.ConnectionString = ConfigurationManager.ConnectionStrings["Glipho.OAuth.Providers.Database.ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="MongoDbClient" /> class with a connection string.
        /// </summary>
        /// <param name="connectionString">The connection string to initialize the class with.</param>
        protected MongoDbClient(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Gets the connection string for the client.
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// Initialises the profiles collection from MongoDB.
        /// </summary>
        /// <param name="collectionName">The name of the collection to initialise.</param>
        /// <returns>Initialised <see cref="MongoCollection"/> of <see cref="BsonDocument"/>.</returns>
        /// <exception cref="OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        protected MongoCollection<BsonDocument> InitialiseCollection(string collectionName)
        {
            return this.InitialiseCollection<BsonDocument>(collectionName);
        }

        /// <summary>
        /// Initialises the profiles collection from MongoDB.
        /// </summary>
        /// <typeparam name="T">The type of documents to initialise the collection with.</typeparam>
        /// <param name="collectionName">The name of the collection to initialise.</param>
        /// <returns>Initialised <see cref="MongoCollection"/> of <see cref="T"/>.</returns>
        /// <exception cref="OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        protected MongoCollection<T> InitialiseCollection<T>(string collectionName)
        {
            try
            {
                // Load up the database and collection.
                var url = new MongoUrl(this.ConnectionString);
                var client = new MongoClient(url.Url);
                var server = client.GetServer();
                var database = server.GetDatabase(url.DatabaseName);
                return database.GetCollection<T>(collectionName);
            }
            catch (MongoException ex)
            {
                throw new OAuthException("Unable initialise connection to the database.", ex, ErrorCode.Database);
            }
        }
    }
}
