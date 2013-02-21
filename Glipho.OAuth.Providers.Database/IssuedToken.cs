namespace Glipho.OAuth.Providers.Database
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Base entity for an issued token.
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    public abstract class IssuedToken
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="IssuedToken"/> class.
        /// </summary>
        protected IssuedToken()
        {
            this.Created = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the identifier of the token.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the consumer key.
        /// </summary>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the token secret.
        /// </summary>
        public string TokenSecret { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        public IEnumerable<string> Scope { get; set; }

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

        /// <summary>
        /// Serves as a hash function for a <see cref="IssuedToken"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="IssuedToken"/>.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="IssuedToken"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="IssuedToken"/>.</param>
        /// <returns>
        /// true if the specified <see cref="System.Object"/> is equal to the current <see cref="IssuedToken"/>; otherwise false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as IssuedToken);
        }

        /// <summary>
        /// Determines whether the specified <see cref="IssuedToken"/> is equal to the current <see cref="IssuedToken"/>.
        /// </summary>
        /// <param name="token">The <see cref="IssuedToken"/> to compare with the current <see cref="IssuedToken"/>.</param>
        /// <returns>
        /// true if the specified <see cref="IssuedToken"/> is equal to the current <see cref="IssuedToken"/>; otherwise false.
        /// </returns>
        public bool Equals(IssuedToken token)
        {
            if (token == null)
            {
                return false;
            }

            return this.ConsumerKey == token.ConsumerKey
                && this.Created == token.Created
                && this.Id == token.Id
                && this.Token == token.Token
                && this.TokenSecret == token.TokenSecret
                && this.Username == token.Username
                && (this.Scope != null && token.Scope != null && this.Scope.Equals(token.Scope));
        }
    }
}
