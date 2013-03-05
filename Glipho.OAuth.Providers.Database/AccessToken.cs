namespace Glipho.OAuth.Providers.Database
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// The access token.
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    public class AccessToken : IssuedToken
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AccessToken"/> class.
        /// </summary>
        public AccessToken()
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="AccessToken"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="accessTokenSecret">The access token secret.</param>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="scope">The scope.</param>
        /// <param name="username">The username.</param>
        public AccessToken(string accessToken, string accessTokenSecret, string consumerKey, IEnumerable<string> scope, string username)
        {
            this.Token = accessToken;
            this.TokenSecret = accessTokenSecret;
            this.ConsumerKey = consumerKey;
            this.Scope = scope;
            this.Username = username;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="IssuedToken"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="IssuedToken"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "{0} [{1}, {2}, {3}, {4}, {5}]",
                this.GetType().Name,
                this.Id,
                this.ConsumerKey,
                this.Token,
                this.TokenSecret,
                this.Username);
        }
    }
}
