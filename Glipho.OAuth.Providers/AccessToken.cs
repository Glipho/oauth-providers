namespace Glipho.OAuth.Providers
{
    using System;
    using System.Collections.Generic;
    using DotNetOpenAuth.OAuth.ChannelElements;

    /// <summary>
    /// Implementation of the <see cref="IServiceProviderAccessToken"/> interface.
    /// </summary>
    public class AccessToken : IServiceProviderAccessToken
    {
        /// <summary>
        /// Gets the expiration date (local time) for the access token. 
        /// </summary> 
        /// <value>
        /// The expiration date, or <c>null</c> if there is no expiration date.
        /// </value>
        public DateTime? ExpirationDate { get; private set; }

        /// <summary>
        /// Gets the roles that the OAuth principal should belong to. 
        /// </summary> 
        /// <value>
        /// The roles that the user belongs to, or a subset of these according to the rights
        /// granted when the user authorized the request token. 
        /// </value>
        public string[] Roles { get; private set; }

        /// <summary>
        /// Gets the token itself. 
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Gets the username of the principal that will be impersonated by this access token. 
        /// </summary> 
        /// <value>
        /// The name of the user who authorized the OAuth request token originally. 
        /// </value>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the scope of the access token.
        /// </summary>
        public IEnumerable<string> Scope { get; private set; }

        /// <summary>
        /// Create a new access token from a database access token.
        /// </summary>
        /// <param name="accessToken">The database access token to create a new access token from.</param>
        /// <returns>A new access token created from the database access token.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        internal static IServiceProviderAccessToken FromDataAccessToken(Database.AccessToken accessToken)
        {
            if (accessToken == null)
            {
                throw new ArgumentNullException("accessToken", "accessToken is null");
            }

            return new AccessToken
            {
                ExpirationDate = null,
                Roles = new[]
                {
                    "delegated"
                },
                Scope = accessToken.Scope,
                Token = accessToken.Token,
                Username = accessToken.Username,
            };
        }
    }
}
