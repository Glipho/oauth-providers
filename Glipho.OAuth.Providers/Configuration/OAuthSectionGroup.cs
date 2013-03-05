namespace Glipho.OAuth.Providers.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The OAuth configuration section group.
    /// </summary>
    public class OAuthSectionGroup
    {
        /// <summary>
        /// The service provider configuration section.
        /// </summary>
        private static readonly ServiceProvider ServiceProviderConfigSection = ConfigurationManager.GetSection("glipho.oAuth/serviceProvider") as ServiceProvider;

        /// <summary>
        /// Gets the service provider configuration section.
        /// </summary>
        public static ServiceProvider ServiceProvider
        {
            get
            {
                return ServiceProviderConfigSection;
            }
        }
    }
}
