namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// MongoDB implementation of the <see cref="IIssuedTokens"/> database.
    /// </summary>
    public class IssuedTokens : MongoDbClient, IIssuedTokens
    {
        /// <summary>
        /// The tokens collection name.
        /// </summary>
        internal const string TokensCollectionName = "tokens";

        /// <summary>
        /// Indicated if the indexes used by this class have been created.
        /// </summary>
        private static bool indexesCreated;

        /// <summary>
        /// The consumers collection.
        /// </summary>
        private MongoCollection<Consumer> consumersCollection;

        /// <summary>
        /// The tokens collection.
        /// </summary>
        private MongoCollection<IssuedToken> tokensCollection;

        /// <summary>
        /// Initialises a new instance of the <see cref="IssuedTokens"/> class.
        /// </summary>
        public IssuedTokens()
        {
            this.InitialiseClass();
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="IssuedTokens"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public IssuedTokens(string connectionString)
            : base(connectionString)
        {
            this.InitialiseClass();
        }

        /// <summary>
        /// Create a new token.
        /// </summary>
        /// <param name="issuedToken">The details of the token to create.</param>
        /// <returns>Identifier of the newly created token.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public string Create(Database.IssuedToken issuedToken)
        {
            if (issuedToken == null)
            {
                throw new ArgumentNullException("issuedToken", "issuedToken is null");
            }

            try
            {
                var mongoToken = IssuedToken.FromIssuedToken(issuedToken, this.GetConsumerStub(issuedToken.ConsumerKey));
                this.tokensCollection.Insert(mongoToken, WriteConcern.WMajority);
                return mongoToken.Id.ToString();
            }
            catch (MongoException ex)
            {
                throw new OAuthException("Unable to token in the database. A database error has occurred.", ex, ErrorCode.Database);
            }
        }

        /// <summary>
        /// Retrieve a consumer from the database.
        /// </summary>
        /// <param name="token">The token of the issued token to retrieve.</param>
        /// <returns>The <see cref="Database.IssuedToken"/> if found; else null.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public Database.IssuedToken Get(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("token does not have a value.", "token");
            }

            try
            {
                var foundToken = this.tokensCollection.FindOne(Query<IssuedToken>.EQ(t => t.Token, token));
                return foundToken != null ? foundToken.ToToken() : null;
            }
            catch (MongoException ex)
            {
                throw new OAuthException("Unable to retrieve requested token. A database error has occurred.", ex, ErrorCode.Database);
            }
        }

        /// <summary>
        /// Remove an issued token.
        /// </summary>
        /// <param name="id">The identifier of the token to remove.</param>
        /// <returns>true if removal was successful; else false.</returns>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public bool Remove(string id)
        {
            try
            {
                var query = Query<IssuedToken>.LT(t => t.Id, new BsonObjectId(id));
                var result = this.tokensCollection.Remove(query, RemoveFlags.Single, WriteConcern.WMajority);
                return result.Ok;
            }
            catch (MongoException ex)
            {
                throw new OAuthException("Unable to remove token. A database error has occurred.", ex, ErrorCode.Database);
            }
        }

        /// <summary>
        /// Update an existing token.
        /// </summary>
        /// <param name="token">The token of the issued token to update.</param>
        /// <param name="updatedToken">Details to update the token with.</param>
        /// <returns>true if update was successful; else false.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public bool Update(string token, Database.IssuedToken updatedToken)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("token does not have a value.", "token");
            }

            if (updatedToken == null)
            {
                throw new ArgumentNullException("updatedToken", "updatedToken is null");
            }

            try
            {
                var mongoToken = IssuedToken.FromIssuedToken(updatedToken, this.GetConsumerStub(updatedToken.ConsumerKey));
                var query = Query<IssuedToken>.EQ(t => t.Token, token);
                var sort = SortBy<IssuedToken>.Ascending(t => t.Id);
                var existingToken = this.tokensCollection.FindOne(query);
                mongoToken.Id = existingToken.Id;
                var result = this.tokensCollection.FindAndModify(query, sort, mongoToken.GetUpdateStatement(), true, false);
                return result.Ok;
            }
            catch (MongoException ex)
            {
                throw new OAuthException(string.Format("Unable to update token with token of \"{0}\" in the database. A database error has occurred.", token), ex, ErrorCode.Database);
            }
        }

        /// <summary>
        /// Get a consumer stub.
        /// </summary>
        /// <param name="key">The key of the consumer.</param>
        /// <returns>The <see cref="ConsumerStub"/>.</returns>
        private ConsumerStub GetConsumerStub(string key)
        {
            var consumer = this.consumersCollection.FindAs<ConsumerStub>(Query<ConsumerStub>.EQ(c => c.Id, new BsonObjectId(key)));
            consumer.SetFields(ConsumerStub.GetFields());
            consumer.SetLimit(1);
            return consumer.Single();
        }

        /// <summary>
        /// Initialise the class.
        /// </summary>
        private void InitialiseClass()
        {
            this.tokensCollection = this.InitialiseCollection<IssuedToken>(TokensCollectionName);
            this.consumersCollection = this.InitialiseCollection<Consumer>(Consumers.ConsumersCollectionName);
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

            lock (TokensCollectionName)
            {
                if (indexesCreated)
                {
                    return;
                }

                var uniqueTokenIndex = IndexKeys<IssuedToken>.Ascending(t => t.Token);
                var indexOptions = IndexOptions.SetBackground(true).SetUnique(true);
                this.tokensCollection.EnsureIndex(uniqueTokenIndex, indexOptions);
                indexesCreated = true;
            }
        }
    }
}
