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
    public class RequestToken : IssuedToken
    {
        public RequestToken()
        {
            this.Type = TokenType.RequestToken;
        }

        public RequestToken(IServiceProviderRequestToken requestToken, IssuedToken existingToken)
        {
            this.Type = TokenType.RequestToken;
            this.Callback = requestToken.Callback;
            this.Consumer = existingToken.Consumer;
            this.ConsumerVersion = requestToken.ConsumerVersion != null ? requestToken.ConsumerVersion.ToString() : null;
            this.Created = existingToken.Created;
            this.Id = existingToken.Id;
            this.Scope = existingToken.Scope;
            this.Token = requestToken.Token;
            this.TokenSecret = existingToken.TokenSecret;
            this.User = existingToken.User;
            this.VerificationCode = requestToken.VerificationCode;
        }

        public RequestToken(IServiceProviderRequestToken requestToken, ConsumerStub consumer, User user)
        {
            this.Type = TokenType.RequestToken;
            this.Callback = requestToken.Callback;
            this.Consumer = consumer;
            this.ConsumerVersion = requestToken.ConsumerVersion != null ? requestToken.ConsumerVersion.ToString() : null;
            this.Token = requestToken.Token;
            this.User = user;
            this.VerificationCode = requestToken.VerificationCode;
        }

        public RequestToken(IssuedTokens.RequestToken requestToken, ConsumerStub consumer, User user)
        {
            this.Type = TokenType.RequestToken;
            this.Callback = requestToken.Callback;
            this.Consumer = consumer;
            this.ConsumerVersion = requestToken.ConsumerVersion != null ? requestToken.ConsumerVersion.ToString() : null;
            this.Created = requestToken.Created;
            this.Scope = requestToken.Scope;
            this.Token = requestToken.Token;
            this.TokenSecret = requestToken.TokenSecret;
            this.User = user;
            this.VerificationCode = requestToken.VerificationCode;
        }

        [BsonIgnoreIfNull]
        public Uri Callback { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public string ConsumerVersion { get; set; }

        [BsonRequired]
        public string VerificationCode { get; set; }

        public IssuedTokens.RequestToken ToRequestToken()
        {
            return new IssuedTokens.RequestToken
            {
                Callback = this.Callback,
                ConsumerKey = this.Consumer.Key,
                ConsumerVersion = this.ConsumerVersion != null ? new Version(this.ConsumerVersion) : null,
                Created = this.Created,
                CreatedOn = this.Created.ToLocalTime(),
                Scope = this.Scope,
                Token = this.Token,
                TokenSecret = this.TokenSecret,
                VerificationCode = this.VerificationCode
            };
        }

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
    }
}
