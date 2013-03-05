namespace Glipho.OAuth.Providers.Extensions
{
    using System;
    using DotNetOpenAuth.OAuth.ChannelElements;

    /// <summary>
    /// The service provider request token extensions.
    /// </summary>
    internal static class ServiceProviderRequestTokenExtensions
    {
        /// <summary>
        /// Convert a <see cref="IServiceProviderRequestToken"/> into a database request token.
        /// </summary>
        /// <param name="requestToken">The request token.</param>
        /// <param name="existingToken">The existing token.</param>
        /// <returns>
        /// The constructed <see cref="RequestToken"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        internal static Database.RequestToken ToDataRequestToken(this IServiceProviderRequestToken requestToken, Database.RequestToken existingToken)
        {
            if (existingToken == null)
            {
                throw new ArgumentNullException("existingToken", "existingToken is null");
            }

            return new Database.RequestToken
            {
                Authorised = existingToken.Authorised,
                Callback = requestToken.Callback,
                ConsumerKey = requestToken.ConsumerKey,
                ConsumerVersion = requestToken.ConsumerVersion,
                Created = existingToken.Created,
                Id = existingToken.Id,
                Scope = existingToken.Scope,
                Token = requestToken.Token,
                TokenSecret = existingToken.TokenSecret,
                Username = existingToken.Username,
                VerificationCode = requestToken.VerificationCode,
            };
        }
    }
}
