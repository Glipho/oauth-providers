namespace Glipho.OAuth.Providers.Database
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// The request token.
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    public class RequestToken : IssuedToken
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RequestToken"/> class.
        /// </summary>
        public RequestToken()
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RequestToken"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="token">The token.</param>
        /// <param name="tokenSecret">The token secret.</param>
        /// <param name="scope">The scope.</param>
        public RequestToken(Uri callback, string consumerKey, string token, string tokenSecret, IEnumerable<string> scope)
        {
            this.Callback = callback;
            this.ConsumerKey = consumerKey;
            this.Token = token;
            this.TokenSecret = tokenSecret;
            this.Scope = scope;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the request token has been authorised.
        /// </summary>
        public bool Authorised { get; set; }

        /// <summary>
        /// Gets or sets the callback.
        /// </summary>
        public Uri Callback { get; set; }

        /// <summary>
        /// Gets or sets the consumer version.
        /// </summary>
        public Version ConsumerVersion { get; set; }

        /// <summary>
        /// Gets or sets the verification code.
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="RequestToken"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="RequestToken"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "{0} [{1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}]",
                this.GetType().Name,
                this.Id,
                this.ConsumerKey,
                this.Token,
                this.TokenSecret,
                this.Username,
                this.Authorised,
                this.ConsumerVersion,
                this.Callback);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="RequestToken"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="RequestToken"/>.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="RequestToken"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="RequestToken"/>.</param>
        /// <returns>
        /// true if the specified <see cref="System.Object"/> is equal to the current <see cref="RequestToken"/>; otherwise false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as RequestToken);
        }

        /// <summary>
        /// Determines whether the specified <see cref="RequestToken"/> is equal to the current <see cref="RequestToken"/>.
        /// </summary>
        /// <param name="token">The <see cref="RequestToken"/> to compare with the current <see cref="RequestToken"/>.</param>
        /// <returns>
        /// true if the specified <see cref="RequestToken"/> is equal to the current <see cref="RequestToken"/>; otherwise false.
        /// </returns>
        public bool Equals(RequestToken token)
        {
            if (token == null)
            {
                return false;
            }

            return base.Equals(token)
                && this.Authorised == token.Authorised
                && this.Callback == token.Callback
                && this.ConsumerVersion == token.ConsumerVersion
                && this.VerificationCode == token.VerificationCode;
        }
    }
}
