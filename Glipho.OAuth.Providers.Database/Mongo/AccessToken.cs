namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// The access token.
    /// </summary>
    [DebuggerDisplay("{ToString}"), BsonIgnoreExtraElements]
    public class AccessToken : IssuedToken
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AccessToken"/> class.
        /// </summary>
        public AccessToken()
        {
            this.Type = TokenType.AccessToken;
        }

        /// <summary>
        /// Create a new access token from a database access token.
        /// </summary>
        /// <param name="accessToken">The database access token to create a new access token from.</param>
        /// <param name="consumer">The consumer for the access token.</param>
        /// <returns>A new access token created from the database access token.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        internal static AccessToken FromAccessToken(Database.AccessToken accessToken, ConsumerStub consumer)
        {
            if (accessToken == null)
            {
                throw new ArgumentNullException("accessToken", "accessToken is null");
            }

            if (consumer == null)
            {
                throw new ArgumentNullException("consumer", "consumer is null");
            }

            return new AccessToken
            {
                Consumer = consumer,
                Created = accessToken.Created,
                Id = new BsonObjectId(accessToken.Id.ToString()),
                Scope = accessToken.Scope,
                Token = accessToken.Token,
                TokenSecret = accessToken.TokenSecret,
                Username = accessToken.Username,
            };
        }

        /// <summary>
        /// Convert this token into a database token.
        /// </summary>
        /// <returns>The database token created from this token.</returns>
        internal override Database.IssuedToken ToToken()
        {
            return new Database.AccessToken
            {
                ConsumerKey = this.Consumer.Id.ToString(),
                Created = this.Created,
                Id = this.Id.ToInt32(),
                Scope = this.Scope,
                Token = this.Token,
                TokenSecret = this.TokenSecret,
                Username = this.Username,
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
