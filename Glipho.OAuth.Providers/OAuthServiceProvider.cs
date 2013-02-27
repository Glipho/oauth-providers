namespace Glipho.OAuth.Providers
{
    using System;
    using System.Web;
    using DotNetOpenAuth.Messaging;
    using DotNetOpenAuth.OAuth;
    using DotNetOpenAuth.OAuth.ChannelElements;
    using DotNetOpenAuth.OAuth.Messages;

    /// <summary>
    /// A service provider for web applications.
    /// </summary>
    public class OAuthServiceProvider
    {
        /// <summary>
        /// Request session key for pending authorisations.
        /// </summary>
        private const string PendingAuthorisationRequestSessionKey = "PendingAuthorisationRequest";

        /// <summary>
        /// The lock to synchronize initialization of the <see cref="serviceProvider"/> field.
        /// </summary>
        private static readonly object InitializerLock = new object();

        /// <summary>
        /// The shared service description for this web site.
        /// </summary>
        private static ServiceProviderDescription serviceDescription;

        /// <summary>
        /// Reference to a token manager.
        /// </summary>
        private static TokenManager tokenManager;

        /// <summary>
        /// The shared service provider object.
        /// </summary>
        private static ServiceProvider serviceProvider;

        /// <summary>
        /// The consumers database client.
        /// </summary>
        private readonly Database.IConsumers consumers;

        /// <summary>
        /// The issued tokens database client.
        /// </summary>
        private readonly Database.IIssuedTokens issuedTokens;

        /// <summary>
        /// Initialises a new instance of the <see cref="OAuthServiceProvider"/> class.
        /// </summary>
        /// <param name="consumers">The consumers database client.</param>
        /// <param name="issuedTokens">The issued tokens database client.</param>
        public OAuthServiceProvider(Database.IConsumers consumers, Database.IIssuedTokens issuedTokens)
        {
            this.consumers = consumers;
            this.issuedTokens = issuedTokens;
        }

        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        public ServiceProvider ServiceProvider
        {
            get
            {
                this.EnsureInitialized();
                return serviceProvider;
            }
        }

        /// <summary>
        /// Gets the service description.
        /// </summary>
        /// <value>The service description.</value>
        public ServiceProviderDescription ServiceDescription
        {
            get
            {
                this.EnsureInitialized();
                return serviceDescription;
            }
        }

        /// <summary>
        /// Gets or sets the pending authorisation request.
        /// </summary>
        public UserAuthorizationRequest PendingAuthorisationRequest
        {
            // HACK: This should probably be stored in a better way and might cause multi server issues.
            get { return HttpContext.Current.Session[PendingAuthorisationRequestSessionKey] as UserAuthorizationRequest; }
            set { HttpContext.Current.Session[PendingAuthorisationRequestSessionKey] = value; }
        }

        /// <summary>
        /// Gets the pending authorization consumer.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throw if the pending authorisation request does not have a value.</exception>
        public IConsumerDescription PendingAuthorizationConsumer
        {
            get
            {
                ITokenContainingMessage message = this.PendingAuthorisationRequest;
                if (message == null)
                {
                    throw new InvalidOperationException();
                }

                var token = tokenManager.GetRequestToken(message.Token);
                return tokenManager.GetConsumer(token.ConsumerKey);
            }
        }

        /// <summary>
        /// Authorize the pending request token.
        /// </summary>
        /// <param name="username">The username to authorise with request token with.</param>
        public void AuthorizePendingRequestToken(string username)
        {
            var response = this.AuthorizePendingRequestTokenAndGetResponse(username);
            if (response != null)
            {
                serviceProvider.Channel.Send(response);
            }
        }

        /// <summary>
        /// Authorize the pending request token as a web response.
        /// </summary>
        /// <param name="username">The username to authorise with request token with.</param>
        /// <returns>
        /// The <see cref="OutgoingWebResponse"/>.</returns>
        public OutgoingWebResponse AuthorizePendingRequestTokenAsWebResponse(string username)
        {
            var response = this.AuthorizePendingRequestTokenAndGetResponse(username);
            return response != null ? serviceProvider.Channel.PrepareResponse(response) : null;
        }

        /// <summary>
        /// Authorize the pending request token and get the response.
        /// </summary>
        /// <param name="username">The username to authorise with request token with.</param>
        /// <returns>
        /// The <see cref="UserAuthorizationResponse"/>.</returns>
        /// <exception cref="InvalidOperationException">Throw if the pending authorisation request does not have a value.</exception>
        private UserAuthorizationResponse AuthorizePendingRequestTokenAndGetResponse(string username)
        {
            var pendingRequest = this.PendingAuthorisationRequest;
            if (pendingRequest == null)
            {
                throw new InvalidOperationException("No pending authorization request to authorize.");
            }

            ITokenContainingMessage message = pendingRequest;
            var token = tokenManager.GetRequestToken(message.Token);
            tokenManager.AuthoriseRequestToken(username, token);

            this.PendingAuthorisationRequest = null;
            var response = serviceProvider.PrepareAuthorizationResponse(pendingRequest);
            return response;
        }

        /// <summary>
        /// Initializes the <see cref="serviceProvider"/> field if it has not yet been initialized.
        /// </summary>
        private void EnsureInitialized()
        {
            if (serviceProvider != null)
            {
                return;
            }

            lock (InitializerLock)
            {
                if (serviceDescription == null)
                {
                    var providerConfig = Configuration.OAuthSectionGroup.ServiceProvider;
                    var requestTokenUrl = new MessageReceivingEndpoint(new Uri(providerConfig.Endpoints.RequestToken.Url), HttpDeliveryMethods.PostRequest);
                    var accessTokenUrl = new MessageReceivingEndpoint(new Uri(providerConfig.Endpoints.AccessToken.Url), HttpDeliveryMethods.GetRequest);
                    var authorisationUrl = new MessageReceivingEndpoint(new Uri(providerConfig.Endpoints.UserAuthorisation.Url), HttpDeliveryMethods.GetRequest);
                    serviceDescription = new ServiceProviderDescription
                    {
                        TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() },
                        RequestTokenEndpoint = requestTokenUrl,
                        AccessTokenEndpoint = accessTokenUrl,
                        UserAuthorizationEndpoint = authorisationUrl,
                    };
                }

                if (tokenManager == null)
                {
                    tokenManager = new TokenManager(this.consumers, this.issuedTokens);
                }

                if (serviceProvider == null)
                {
                    serviceProvider = new ServiceProvider(serviceDescription, tokenManager);
                }
            }
        }
    }
}
