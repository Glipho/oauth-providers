namespace Glipho.OAuth.Providers.Web
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Mvc;
    using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;

    /// <summary>
    /// Authorise using OAuth instead of a built in authorisation method.
    /// </summary>
    public class OAuthAuthoriseAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// The service provider configuration.
        /// </summary>
        private readonly OAuthServiceProvider serviceProvider;

        /// <summary>
        /// Initialises a new instance of the <see cref="OAuthAuthoriseAttribute"/> class.
        /// </summary>
        public OAuthAuthoriseAttribute()
        {
            var consumers = DependencyResolver.Current.GetService<Database.IConsumers>();
            var issuedTokens = DependencyResolver.Current.GetService<Database.IIssuedTokens>();
            var nonces = DependencyResolver.Current.GetService<Database.INonces>();
            this.serviceProvider = new OAuthServiceProvider(consumers, issuedTokens, nonces);
        }

        /// <summary>
        /// Gets or sets the scope of the action or controller decorated with this attribute.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>Indicates whether the specified control is authorized.</summary>
        /// <returns>true if the control is authorized; otherwise, false.</returns>
        /// <param name="actionContext">The context.</param>
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var controllerAllowAnonymous = actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<OAuthAllowAnonymous>().Count > 0;
            var actionAllowAnonymous = actionContext.ActionDescriptor.GetCustomAttributes<OAuthAllowAnonymous>().Count > 0;
            if (controllerAllowAnonymous || actionAllowAnonymous)
            {
                return true;
            }

            var sp = this.serviceProvider.ServiceProvider;
            var user = ((ApiController)actionContext.ControllerContext.Controller).User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                return false;
            }

            var token = ((DotNetOpenAuth.OAuth.ChannelElements.OAuthPrincipal)user).AccessToken;
            if (string.IsNullOrWhiteSpace(token))
            {
                return false;
            }

            var accessToken = sp.TokenManager.GetAccessToken(token) as AccessToken;
            if (accessToken != null)
            {
                // Only allow this method call if the access token scope permits it.
                return string.IsNullOrWhiteSpace(this.Scope) || accessToken.Scope.Any(s => string.Equals(s, this.Scope, StringComparison.OrdinalIgnoreCase));
            }

            return false;
        }
    }
}
