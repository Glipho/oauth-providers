using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System.Diagnostics;
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
    }
}
