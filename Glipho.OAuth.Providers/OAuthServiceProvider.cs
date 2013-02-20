using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glipho.OAuth.Providers
{
    using System.Web;
    using DotNetOpenAuth.Messaging;
    using DotNetOpenAuth.OAuth;
    using DotNetOpenAuth.OAuth.ChannelElements;
    using DotNetOpenAuth.OAuth.Messages;

    public class OAuthServiceProvider
    {
        private const string PendingAuthorizationRequestSessionKey = "PendingAuthorizationRequest";

        /// <summary>
        /// The shared service description for this web site.
        /// </summary>
        private static ServiceProviderDescription serviceDescription;

        private static TokenManager tokenManager;

        /// <summary>
        /// The shared service provider object.
        /// </summary>
        private static ServiceProvider serviceProvider;

        /// <summary>
        /// The lock to synchronize initialization of the <see cref="serviceProvider"/> field.
        /// </summary>
        private static readonly object InitializerLock = new object();

        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        public static ServiceProvider ServiceProvider
        {
            get
            {
                EnsureInitialized();
                return serviceProvider;
            }
        }

        /// <summary>
        /// Gets the service description.
        /// </summary>
        /// <value>The service description.</value>
        public static ServiceProviderDescription ServiceDescription
        {
            get
            {
                EnsureInitialized();
                return serviceDescription;
            }
        }

        public static UserAuthorizationRequest PendingAuthorizationRequest
        {
            // HACK: This should probably be stored in a better way and might cause multi server issues.
            get { return HttpContext.Current.Session[PendingAuthorizationRequestSessionKey] as UserAuthorizationRequest; }
            set { HttpContext.Current.Session[PendingAuthorizationRequestSessionKey] = value; }
        }

        public static IConsumerDescription PendingAuthorizationConsumer
        {
            get
            {
                ITokenContainingMessage message = PendingAuthorizationRequest;
                if (message == null)
                {
                    throw new InvalidOperationException();
                }

                var token = tokenManager.GetRequestToken(message.Token);
                return tokenManager.GetConsumer(token.ConsumerKey);
            }
        }

        public static void AuthorizePendingRequestToken(string username)
        {
            var response = AuthorizePendingRequestTokenAndGetResponse(username);
            if (response != null)
            {
                serviceProvider.Channel.Send(response);
            }
        }

        public static OutgoingWebResponse AuthorizePendingRequestTokenAsWebResponse(string username)
        {
            var response = AuthorizePendingRequestTokenAndGetResponse(username);
            if (response != null)
            {
                return serviceProvider.Channel.PrepareResponse(response);
            }
            else
            {
                return null;
            }
        }

        private static UserAuthorizationResponse AuthorizePendingRequestTokenAndGetResponse(string username)
        {
            var pendingRequest = PendingAuthorizationRequest;
            if (pendingRequest == null)
            {
                throw new InvalidOperationException("No pending authorization request to authorize.");
            }

            ITokenContainingMessage message = pendingRequest;
            var token = tokenManager.GetRequestToken(message.Token);
            tokenManager.AuthoriseRequestToken(username, token);

            PendingAuthorizationRequest = null;
            var response = serviceProvider.PrepareAuthorizationResponse(pendingRequest);
            return response;
        }

        /// <summary>
        /// Initializes the <see cref="serviceProvider"/> field if it has not yet been initialized.
        /// </summary>
        private static void EnsureInitialized()
        {
            if (serviceProvider != null)
            {
                return;
            }

            lock (InitializerLock)
            {
                if (serviceDescription == null)
                {
                    var requestTokenUrl = new MessageReceivingEndpoint(new Uri(Utilities.ApplicationRoot, "OAuth/RequestToken"), HttpDeliveryMethods.PostRequest);
                    var accessTokenUrl = new MessageReceivingEndpoint(new Uri(Utilities.ApplicationRoot, "OAuth/AccessToken"), HttpDeliveryMethods.GetRequest);
                    var authorisationUrl = new MessageReceivingEndpoint(new Uri(Utilities.ApplicationRoot, "OAuth/Authenticate"), HttpDeliveryMethods.GetRequest);
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
                    // TODO: Put this back in
                    ////tokenManager = new TokenManager();
                }

                if (serviceProvider == null)
                {
                    serviceProvider = new ServiceProvider(serviceDescription, tokenManager);
                }
            }
        }
    }
}
