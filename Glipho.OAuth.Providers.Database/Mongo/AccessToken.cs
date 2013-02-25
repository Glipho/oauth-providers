using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System.Diagnostics;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [DebuggerDisplay("{ToString}"), BsonIgnoreExtraElements]
    public class AccessToken : IssuedToken
    {
        public AccessToken()
        {
            this.Type = TokenType.AccessToken;
        }

        public AccessToken(IssuedTokens.AccessToken accessToken, ConsumerStub consumer, User user)
        {
            this.Type = TokenType.AccessToken;
            this.Consumer = consumer;
            this.Created = accessToken.Created;
            this.ExpirationDate = accessToken.ExpirationDate.HasValue ? (DateTime?)accessToken.ExpirationDate.Value.ToUniversalTime() : null;
            this.Scope = accessToken.Scope;
            this.Token = accessToken.Token;
            this.TokenSecret = accessToken.TokenSecret;
            this.User = user;
        }

        [BsonIgnoreIfNull, BsonIgnoreIfDefault, BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? ExpirationDate { get; set; }

        public IssuedTokens.AccessToken ToAccessToken()
        {
            return new Database.AccessToken
            {
                Created = this.Created,
                ExpirationDate = this.ExpirationDate.HasValue ? (DateTime?)this.ExpirationDate.Value.ToLocalTime() : null,
                Roles = this.User.Roles.ToArray(),
                Scope = this.Scope,
                Token = this.Token,
                TokenSecret = this.TokenSecret,
                Username = this.User.Username,
            };
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
                ExpirationDate = null,
                Id = new BsonObjectId(accessToken.Id.ToString()),
                Scope = accessToken.Scope,
                Token = accessToken.Token,
                TokenSecret = accessToken.TokenSecret,
                Username = accessToken.Username,
            };
        }
    }
}
