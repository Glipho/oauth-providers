namespace Glipho.OAuth.Providers.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using DotNetOpenAuth.OAuth.ChannelElements;
    using DotNetOpenAuth.OAuth.Messages;

    /// <summary>
    /// The authentication http module.
    /// </summary>
    public class AuthenticationHttpModule : IHttpModule
    {
        /// <summary>
        /// The service provider configuration.
        /// </summary>
        private readonly Configuration.ServiceProvider serviceProviderConfiguration;

        /// <summary>
        /// The OAuth service provider.
        /// </summary>
        private readonly OAuthServiceProvider serviceProvider;

        /// <summary>
        /// The current HTTP application.
        /// </summary>
        private HttpApplication application;

        /// <summary>
        /// Initialises a new instance of the <see cref="AuthenticationHttpModule"/> class.
        /// </summary>
        public AuthenticationHttpModule()
        {
            var consumers = DependencyResolver.Current.GetService<Database.IConsumers>();
            var issuedTokens = DependencyResolver.Current.GetService<Database.IIssuedTokens>();
            var nonces = DependencyResolver.Current.GetService<Database.INonces>();
            this.serviceProviderConfiguration = Configuration.OAuthSectionGroup.ServiceProvider;
            this.serviceProvider = new OAuthServiceProvider(consumers, issuedTokens, nonces);
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application.</param>
        public void Init(HttpApplication context)
        {
            this.application = context;
            this.application.AuthenticateRequest += this.AuthenticateRequestContext;
            this.RegisterRoleProvider();
        }

        /// <summary>
        /// Handles the AuthenticateRequest event of the HttpApplication.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void AuthenticateRequestContext(object sender, EventArgs e)
        {
            // Don't read OAuth messages directed at the OAuth controller or else we'll fail nonce checks.
            if (this.IsOAuthRequest())
            {
                return;
            }

            var incomingMessage = this.serviceProvider.ServiceProvider.ReadRequest();
            var authorization = incomingMessage as AccessProtectedResourceRequest;
            if (authorization != null)
            {
                this.application.Context.User = this.serviceProvider.ServiceProvider.CreatePrincipal(authorization);
            }
        }

        /// <summary>
        /// Determine is this request is a OAuth request.
        /// </summary>
        /// <returns>
        /// true if this is an OAuth request; else false.
        /// </returns>
        private bool IsOAuthRequest()
        {
            if (!this.serviceProviderConfiguration.TokenProvider)
            {
                return false;
            }

            var endpoints = new List<Uri>
            {
                new Uri(this.serviceProviderConfiguration.Endpoints.AccessToken.Url), 
                new Uri(this.serviceProviderConfiguration.Endpoints.RequestToken.Url), 
                new Uri(this.serviceProviderConfiguration.Endpoints.UserAuthorisation.Url)
            };

            if (this.serviceProviderConfiguration.ExemptUrls != null && this.serviceProviderConfiguration.ExemptUrls.Count > 0)
            {
                for (var i = 0; i < this.serviceProviderConfiguration.ExemptUrls.Count; i++)
                {
                    endpoints.Add(new Uri(this.serviceProviderConfiguration.ExemptUrls[i].Url));
                }
            }

            return endpoints.Any(u => string.Equals(this.application.Context.Request.Url.AbsolutePath, u.AbsolutePath, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Register a custom role provider.
        /// </summary>
        private void RegisterRoleProvider()
        {
            if (!this.serviceProviderConfiguration.RoleProvider.EnableCustomRoleProvider)
            {
                return;
            }

            // Register an event that allows us to override roles for OAuth requests.
            var roleManager = (RoleManagerModule)this.application.Modules["RoleManager"];
            roleManager.GetRoles += this.RoleManagerGetRoles;
        }

        /// <summary>
        /// Handles the GetRoles event of the roleManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.Security.RoleManagerEventArgs"/> instance containing the event data.</param>
        private void RoleManagerGetRoles(object sender, RoleManagerEventArgs e)
        {
            if (this.application.User is OAuthPrincipal)
            {
                e.RolesPopulated = true;
            }
        }
    }
}
