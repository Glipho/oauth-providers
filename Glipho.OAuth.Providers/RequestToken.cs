namespace Glipho.OAuth.Providers
{
    using System;
    using DotNetOpenAuth.OAuth.ChannelElements;
    using DotNetOpenAuth.OAuth.Messages;

    /// <summary>
    /// Implementation of the <see cref="IServiceProviderRequestToken"/> interface.
    /// </summary>
    public class RequestToken : IServiceProviderRequestToken
    {
        /// <summary>
        /// Gets or sets the callback associated specifically with this token, if any. 
        /// </summary> 
        /// <value>
        /// The callback URI; or <c>null</c> if no callback was specifically assigned to this token.
        /// </value>
        public Uri Callback { get; set; }

        /// <summary>
        /// Gets the consumer key that requested this token. 
        /// </summary>
        public string ConsumerKey { get; private set; }

        /// <summary>
        /// Gets or sets the version of the Consumer that requested this token. 
        /// </summary> 
        /// <remarks>
        /// This property is used to determine whether a <see cref="IServiceProviderRequestToken.VerificationCode"/> must be
        /// generated when the user authorizes the Consumer or not. 
        /// </remarks>
        public Version ConsumerVersion { get; set; }

        /// <summary>
        /// Gets the (local) date that this request token was first created on. 
        /// </summary>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// Gets the token itself. 
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Gets or sets the verifier that the consumer must include in the <see cref="AuthorizedTokenRequest"/>
        /// message to exchange this request token for an access token. 
        /// </summary> 
        /// <value>
        /// The verifier code, or <c>null</c> if none has been assigned (yet).
        /// </value>
        public string VerificationCode { get; set; }

        /// <summary>
        /// Create a new request token from a database request token.
        /// </summary>
        /// <param name="requestToken">The database request token to create a new request token from.</param>
        /// <returns>A new request token created from the database request token.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        internal static IServiceProviderRequestToken FromDataRequestToken(Database.RequestToken requestToken)
        {
            if (requestToken == null)
            {
                throw new ArgumentNullException("requestToken", "requestToken is null");
            }

            return new RequestToken
            {
                Callback = requestToken.Callback,
                ConsumerKey = requestToken.ConsumerKey,
                ConsumerVersion = requestToken.ConsumerVersion,
                CreatedOn = requestToken.Created.ToLocalTime(),
                Token = requestToken.Token,
                VerificationCode = requestToken.VerificationCode,
            };
        }
    }
}
