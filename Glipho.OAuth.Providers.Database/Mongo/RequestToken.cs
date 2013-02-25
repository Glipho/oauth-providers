namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System;
    using System.Diagnostics;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// The request token.
    /// </summary>
    [DebuggerDisplay("{ToString}"), BsonIgnoreExtraElements]
    public class RequestToken : IssuedToken
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RequestToken"/> class.
        /// </summary>
        public RequestToken()
        {
            this.Type = TokenType.RequestToken;
        }

        /// <summary>
        /// Gets or sets the callback.
        /// </summary>
        [BsonElement("callback"), BsonIgnoreIfNull]
        public Uri Callback { get; set; }

        /// <summary>
        /// Gets or sets the consumer version.
        /// </summary>
        [BsonElement("version"), BsonIgnoreIfNull, BsonIgnoreIfDefault]
        public string ConsumerVersion { get; set; }

        /// <summary>
        /// Gets or sets the verification code.
        /// </summary>
        [BsonElement("code"), BsonRequired]
        public string VerificationCode { get; set; }

        /// <summary>
        /// Create a new request token from a database request token.
        /// </summary>
        /// <param name="requestToken">The database request token to create a new request token from.</param>
        /// <param name="consumer">The consumer for the request token.</param>
        /// <returns>A new request token created from the database request token.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        internal static RequestToken FromAccessToken(Database.RequestToken requestToken, ConsumerStub consumer)
        {
            if (requestToken == null)
            {
                throw new ArgumentNullException("requestToken", "requestToken is null");
            }

            if (consumer == null)
            {
                throw new ArgumentNullException("consumer", "consumer is null");
            }

            return new RequestToken
            {
                Callback = requestToken.Callback,
                Consumer = consumer,
                Created = requestToken.Created,
                ConsumerVersion = requestToken.ConsumerVersion != null ? requestToken.ConsumerVersion.ToString() : null,
                Id = new BsonObjectId(requestToken.Id.ToString()),
                Scope = requestToken.Scope,
                Token = requestToken.Token,
                TokenSecret = requestToken.TokenSecret,
                Username = requestToken.Username,
                VerificationCode = requestToken.VerificationCode,
            };
        }

        /// <summary>
        /// Convert this token into a database token.
        /// </summary>
        /// <returns>The database token created from this token.</returns>
        internal override Database.IssuedToken ToToken()
        {
            return new Database.RequestToken
            {
                Authorised = !string.IsNullOrWhiteSpace(this.Username),
                Callback = this.Callback,
                ConsumerKey = this.Consumer.Id.ToString(),
                ConsumerVersion = this.ConsumerVersion != null ? new Version(this.ConsumerVersion) : null,
                Created = this.Created,
                Id = this.Id.ToInt32(),
                Scope = this.Scope,
                Token = this.Token,
                TokenSecret = this.TokenSecret,
                VerificationCode = this.VerificationCode
            };
        }

        /// <summary>
        /// Get the update statement for the token.
        /// </summary>
        /// <returns><see cref="IMongoUpdate"/> containing the update statement.</returns>
        internal override IMongoUpdate GetUpdateStatement()
        {
            return Update.Replace(this);
        }
    }
}
