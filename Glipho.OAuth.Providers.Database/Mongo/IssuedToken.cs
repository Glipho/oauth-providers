namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;

    /// <summary>
    /// The base class for all issued tokens.
    /// </summary>
    [DebuggerDisplay("{ToString()}"), BsonIgnoreExtraElements, BsonKnownTypes(typeof(AccessToken), typeof(RequestToken))]
    public abstract class IssuedToken
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="IssuedToken"/> class.
        /// </summary>
        protected IssuedToken()
        {
            this.Created = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the identifier of the token.
        /// </summary>
        [BsonId]
        public BsonObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the consumer.
        /// </summary>
        [BsonElement("consumer"), BsonRequired]
        public ConsumerStub Consumer { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [BsonElement("username"), BsonIgnoreIfNull, BsonIgnoreIfDefault]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        [BsonElement("token"), BsonRequired]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the token secret.
        /// </summary>
        [BsonElement("secret"), BsonIgnoreIfNull, BsonIgnoreIfDefault]
        public string TokenSecret { get; set; }

        /// <summary>
        /// Gets or sets the created date of the token.
        /// </summary>
        [BsonElement("created"), BsonRequired, BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        [BsonElement("scope"), BsonIgnoreIfNull, BsonIgnoreIfDefault]
        public IEnumerable<string> Scope { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        [BsonElement("type"), BsonRequired]
        public TokenType Type { get; protected set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="IssuedToken"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="IssuedToken"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "{0} [{1}, {2}, {3}, {4}, {5}, {6}, {7}]",
                this.GetType().Name,
                this.Id,
                this.Username,
                this.Token,
                this.TokenSecret,
                this.Created,
                this.Scope,
                this.Type);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="IssuedToken"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="IssuedToken"/>.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="IssuedToken"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="IssuedToken"/>.</param>
        /// <returns>
        /// true if the specified <see cref="System.Object"/> is equal to the current <see cref="IssuedToken"/>; otherwise false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as IssuedToken);
        }

        /// <summary>
        /// Determines whether the specified <see cref="IssuedToken"/> is equal to the current <see cref="IssuedToken"/>.
        /// </summary>
        /// <param name="token">The <see cref="IssuedToken"/> to compare with the current <see cref="IssuedToken"/>.</param>
        /// <returns>
        /// true if the specified <see cref="IssuedToken"/> is equal to the current <see cref="IssuedToken"/>; otherwise false.
        /// </returns>
        public bool Equals(IssuedToken token)
        {
            if (token == null)
            {
                return false;
            }

            return this.Id == token.Id
                && this.Username == token.Username
                && this.Token == token.Token
                && this.TokenSecret == token.TokenSecret
                && this.Created == token.Created
                && (this.Scope != null && token.Scope != null && this.Scope.Equals(token.Scope))
                && this.Type == token.Type
                && this.Consumer.Equals(token.Consumer);
        }

        /// <summary>
        /// Create a new token from a database token.
        /// </summary>
        /// <param name="issuedToken">The database token to create a new token from.</param>
        /// <param name="consumer">The consumer for the request token.</param>
        /// <returns>A new token created from the database token.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        internal static IssuedToken FromIssuedToken(Database.IssuedToken issuedToken, ConsumerStub consumer)
        {
            if (issuedToken == null)
            {
                throw new ArgumentNullException("issuedToken", "issuedToken is null");
            }

            if (issuedToken is Database.AccessToken)
            {
                return AccessToken.FromAccessToken(issuedToken as Database.AccessToken, consumer);
            }

            if (issuedToken is Database.RequestToken)
            {
                return RequestToken.FromAccessToken(issuedToken as Database.RequestToken, consumer);
            }

            throw new NotSupportedException(string.Format("Issued token of type \"{0}\" is not supported.", issuedToken.GetType()));
        }

        /// <summary>
        /// Convert this token into a database token.
        /// </summary>
        /// <returns>The database token created from this token.</returns>
        internal abstract Database.IssuedToken ToToken();

        /// <summary>
        /// Get the update statement for the token.
        /// </summary>
        /// <returns><see cref="IMongoUpdate"/> containing the update statement.</returns>
        internal abstract IMongoUpdate GetUpdateStatement();
    }
}
