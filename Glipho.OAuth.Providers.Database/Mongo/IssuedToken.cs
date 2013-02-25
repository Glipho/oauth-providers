namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System;
    using System.Diagnostics;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// The base class for all issued tokens.
    /// </summary>
    [DebuggerDisplay("{ToString}"), BsonIgnoreExtraElements, BsonKnownTypes(typeof(AccessToken), typeof(RequestToken))]
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
        [BsonRequired]
        public ConsumerStub Consumer { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [BsonIgnoreIfNull, BsonIgnoreIfDefault]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        [BsonRequired]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the token secret.
        /// </summary>
        [BsonIgnoreIfNull, BsonIgnoreIfDefault]
        public string TokenSecret { get; set; }

        /// <summary>
        /// Gets or sets the created date of the token.
        /// </summary>
        [BsonRequired, BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        [BsonIgnoreIfNull, BsonIgnoreIfDefault]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        [BsonRequired]
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
        /// <param name="nonce">The <see cref="IssuedToken"/> to compare with the current <see cref="IssuedToken"/>.</param>
        /// <returns>
        /// true if the specified <see cref="IssuedToken"/> is equal to the current <see cref="IssuedToken"/>; otherwise false.
        /// </returns>
        public bool Equals(IssuedToken nonce)
        {
            if (nonce == null)
            {
                return false;
            }

            return this.Id == nonce.Id
                && this.Username == nonce.Username
                && this.Token == nonce.Token
                && this.TokenSecret == nonce.TokenSecret
                && this.Created == nonce.Created
                && this.Scope == nonce.Scope
                && this.Type == nonce.Type
                && this.Consumer.Equals(nonce.Consumer);
        }

        internal static IssuedToken FromIssuedToken(Database.IssuedToken issuedToken)
        {
            throw new NotImplementedException();
        }

        internal abstract Database.IssuedToken ToToken();

        internal abstract MongoDB.Driver.IMongoUpdate GetUpdateStatement();
    }
}
