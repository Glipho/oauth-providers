namespace Glipho.OAuth.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DotNetOpenAuth.OAuth.ChannelElements;
    using DotNetOpenAuth.OAuth.Messages;

    /// <summary>
    /// Implementation of the <see cref="IServiceProviderTokenManager"/> interface from DotNetOpenAuth.
    /// </summary>
    public class TokenManager : IServiceProviderTokenManager
    {
        /// <summary>
        /// The consumers database client.
        /// </summary>
        private readonly Database.IConsumers consumers;

        /// <summary>
        /// The issued tokens database client.
        /// </summary>
        private readonly Database.IIssuedTokens issuedTokens;

        /// <summary>
        /// Initialises a new instance of the <see cref="TokenManager"/> class.
        /// </summary>
        /// <param name="consumers">The consumers database client.</param>
        /// <param name="issuedTokens">The issued tokens database client.</param>
        public TokenManager(Database.IConsumers consumers, Database.IIssuedTokens issuedTokens)
        {
            this.consumers = consumers;
            this.issuedTokens = issuedTokens;
        }

        /// <summary>
        /// Gets details on the named access token. 
        /// </summary>
        /// <param name="token">The access token.</param>
        /// <returns> A description of the token. Never null.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the token cannot be found.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        /// <remarks>
        /// It is acceptable for implementations to find the token, see that it has expired,
        /// delete it from the database and then throw <see cref="KeyNotFoundException"/>,
        /// or alternatively it can return the expired token anyway and the OAuth channel will
        /// log and throw the appropriate error. 
        /// </remarks>
        public IServiceProviderAccessToken GetAccessToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("token does not have a value.", "token");
            }

            var accessToken = this.issuedTokens.Get(token) as Database.AccessToken;
            if (accessToken == null)
            {
                throw new KeyNotFoundException(string.Format("Access token with token \"{0}\" cannot be found.", token));
            }

            return AccessToken.FromDataAccessToken(accessToken);
        }

        /// <summary>
        /// Gets the Consumer description for a given a Consumer Key. 
        /// </summary>
        /// <param name="consumerKey">The Consumer Key.</param>
        /// <returns> A description of the consumer. Never null. </returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the consumer key cannot be found.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public IConsumerDescription GetConsumer(string consumerKey)
        {
            if (string.IsNullOrWhiteSpace(consumerKey))
            {
                throw new ArgumentException("consumerKey does not have a value.", "consumerKey");
            }

            var consumer = this.consumers.Get(consumerKey);
            if (consumer == null)
            {
                throw new KeyNotFoundException(string.Format("Consumer with key \"{0}\" cannot be found.", consumerKey));
            }

            return Consumer.FromDataConsumer(consumer);
        }

        /// <summary>
        /// Gets details on the named request token. 
        /// </summary>
        /// <param name="token">The request token.</param>
        /// <returns> A description of the token. Never null. </returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the token cannot be found.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        /// <remarks>
        /// It is acceptable for implementations to find the token, see that it has expired,
        /// delete it from the database and then throw <see cref="KeyNotFoundException"/>,
        /// or alternatively it can return the expired token anyway and the OAuth channel will
        /// log and throw the appropriate error. 
        /// </remarks>
        public IServiceProviderRequestToken GetRequestToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("token does not have a value.", "token");
            }

            var requestToken = this.issuedTokens.Get(token) as Database.RequestToken;
            if (requestToken == null)
            {
                throw new KeyNotFoundException(string.Format("Request token with token \"{0}\" cannot be found.", token));
            }

            return RequestToken.FromDataRequestToken(requestToken);
        }

        /// <summary>
        /// Checks whether a given request token has already been authorized
        /// by some user for use by the Consumer that requested it.
        /// </summary>
        /// <param name="requestToken">The Consumer's request token.</param>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        /// <returns>
        /// True if the request token has already been fully authorized by the user
        /// who owns the relevant protected resources.  False if the token has not yet
        /// been authorized, has expired or does not exist.
        /// </returns>
        public bool IsRequestTokenAuthorized(string requestToken)
        {
            if (string.IsNullOrWhiteSpace(requestToken))
            {
                return false;
            }

            var token = this.issuedTokens.Get(requestToken) as Database.RequestToken;
            return token != null && token.Authorised;
        }

        /// <summary>
        /// Persists any changes made to the token. 
        /// </summary>
        /// <param name="token">The token whose properties have been changed.</param>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="token"/> is not a <see cref="Database.RequestToken"/>.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        /// <remarks>
        /// This library will invoke this method after making a set
        /// of changes to the token as part of a web request to give the host
        /// the opportunity to persist those changes to a database.
        /// Depending on the object persistence framework the host site uses,
        /// this method MAY not need to do anything (if changes made to the token
        /// will automatically be saved without any extra handling). 
        /// </remarks>
        public void UpdateToken(IServiceProviderRequestToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token", "token is null");
            }

            var requestToken = token as RequestToken;
            if (requestToken == null)
            {
                throw new InvalidOperationException(string.Format("token is of type \"{0}\" and not of expected type RequestToken.", token.GetType()));
            }

            var dataToken = requestToken.ToDataRequestToken();
            this.issuedTokens.Update(token.Token, dataToken);
        }

        /// <summary>
        /// Deletes a request token and its associated secret and stores a new access token and secret. 
        /// </summary>
        /// <param name="consumerKey">The Consumer that is exchanging its request token for an access token.</param>
        /// <param name="requestToken">The Consumer's request token that should be deleted/expired.</param>
        /// <param name="accessToken">The new access token that is being issued to the Consumer.</param>
        /// <param name="accessTokenSecret">The secret associated with the newly issued access token.</param>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        /// <remarks> 
        /// <para>
        /// Any scope of granted privileges associated with the request token from the
        /// original call to <see cref="TokenManager.StoreNewRequestToken(UnauthorizedTokenRequest,ITokenSecretContainingMessage)"/> should be carried over
        /// to the new Access Token. 
        /// </para> 
        /// <para>
        /// To associate a user account with the new access token,
        /// <see cref="System.Web.HttpContext.User">HttpContext.Current.User</see> may be
        /// useful in an ASP.NET web application within the implementation of this method.
        /// Alternatively you may store the access token here without associating with a user account,
        /// and wait until WebConsumer.ProcessUserAuthorization or
        /// DesktopConsumer.ProcessUserAuthorization return the access
        /// token to associate the access token with a user account at that point. 
        /// </para> 
        /// </remarks>
        public void ExpireRequestTokenAndStoreNewAccessToken(string consumerKey, string requestToken, string accessToken, string accessTokenSecret)
        {
            if (string.IsNullOrWhiteSpace(consumerKey))
            {
                throw new ArgumentException("consumerKey does not have a value.", "consumerKey");
            }

            if (string.IsNullOrWhiteSpace(requestToken))
            {
                throw new ArgumentException("requestToken does not have a value.", "requestToken");
            }

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken does not have a value.", "accessToken");
            }

            if (string.IsNullOrWhiteSpace(accessTokenSecret))
            {
                throw new ArgumentException("accessTokenSecret does not have a value.", "accessTokenSecret");
            }

            var dataRequestToken = this.issuedTokens.Get(requestToken) as Database.RequestToken;
            if (dataRequestToken == null)
            {
                throw new KeyNotFoundException(string.Format("Request token with token \"{0}\" cannot be found.", requestToken));
            }

            this.issuedTokens.Remove(dataRequestToken.Id);
            var dataAccessToken = new Database.AccessToken(accessToken, accessTokenSecret, consumerKey, dataRequestToken.Scope, dataRequestToken.Username);
            this.issuedTokens.Create(dataAccessToken);
        }

        /// <summary>
        /// Gets the Token Secret given a request or access token. 
        /// </summary>
        /// <param name="token">The request or access token.</param>
        /// <returns> The secret associated with the given token.</returns>
        /// <exception cref="ArgumentException">Thrown if the secret cannot be found for the given token.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public string GetTokenSecret(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("token does not have a value.", "token");
            }

            var issuedToken = this.issuedTokens.Get(token);
            if (issuedToken == null)
            {
                throw new ArgumentException(string.Format("Issued token with token \"{0}\" cannot be found.", token));
            }

            if (string.IsNullOrWhiteSpace(issuedToken.TokenSecret))
            {
                throw new ArgumentException(string.Format("Issued token with token \"{0}\" does not have a valid token secret.", token));
            }

            return issuedToken.TokenSecret;
        }

        /// <summary>
        /// Classifies a token as a request token or an access token. 
        /// </summary>
        /// <param name="token">The token to classify.</param>
        /// <returns>Request or Access token, or invalid if the token is not recognized.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public TokenType GetTokenType(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("token does not have a value.", "token");
            }

            var issuedToken = this.issuedTokens.Get(token);
            if (issuedToken == null)
            {
                return TokenType.InvalidToken;
            }

            return issuedToken is Database.RequestToken ? TokenType.RequestToken : TokenType.AccessToken;
        }

        /// <summary>
        /// Stores a newly generated unauthorized request token, secret, and optional
        /// application-specific parameters for later recall. 
        /// </summary>
        /// <param name="request">The request message that resulted in the generation of a new unauthorized request token.</param>
        /// <param name="response">The response message that includes the unauthorized request token.</param>
        /// <exception cref="ArgumentException">Thrown if the consumer key is not registered, or a required parameter was not found in the parameters collection.</exception>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        /// <remarks>
        /// Request tokens stored by this method SHOULD NOT associate any user account with this token.
        /// It usually opens up security holes in your application to do so.  Instead, you associate a user
        /// account with access tokens (not request tokens) in the <see cref="TokenManager.ExpireRequestTokenAndStoreNewAccessToken(string, string, string, string)"/>
        /// method. 
        /// </remarks>
        public void StoreNewRequestToken(UnauthorizedTokenRequest request, ITokenSecretContainingMessage response)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request", "request is null");
            }

            if (response == null)
            {
                throw new ArgumentNullException("response", "response is null");
            }

            var consumer = this.consumers.Get(request.ConsumerKey);
            if (consumer == null)
            {
                throw new ArgumentException(string.Format("Consumer with key \"{0}\" does not exist.", request.ConsumerKey));
            }

            string scope;
            request.ExtraData.TryGetValue("scope", out scope);

            var requestToken = new Database.RequestToken(request.Callback, consumer.Id, response.Token, response.TokenSecret, scope != null ? scope.Split(',').AsEnumerable() : null);
            this.issuedTokens.Create(requestToken);
        }

        /// <summary>
        /// Authorise a request token by adding a user to it.
        /// </summary>
        /// <param name="username">The username of the user to authorise the request token with.</param>
        /// <param name="requestToken">The request token being authorised.</param>
        /// <returns>true if authorisation successful; else null.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        public bool AuthoriseRequestToken(string username, IServiceProviderRequestToken requestToken)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("username does not have a value.", "username");
            }

            if (requestToken == null)
            {
                throw new ArgumentNullException("requestToken", "requestToken is null");
            }

            var token = this.issuedTokens.Get(requestToken.Token) as Database.RequestToken;
            if (token == null)
            {
                return false;
            }

            token.Username = username;
            token.Authorised = true;
            return this.issuedTokens.Update(requestToken.Token, token);
        }
    }
}
