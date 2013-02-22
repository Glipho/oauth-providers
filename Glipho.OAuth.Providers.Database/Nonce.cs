namespace Glipho.OAuth.Providers.Database
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The nonce.
    /// </summary>
    [DebuggerDisplay("{ToString}")]
    public class Nonce
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Nonce"/> class.
        /// </summary>
        public Nonce()
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Nonce"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="code">The code.</param>
        /// <param name="issued">The issued.</param>
        /// <param name="expires">The expires.</param>
        public Nonce(string context, string code, DateTime issued, DateTime expires)
        {
            this.Code = code;
            this.Context = context;
            this.Issued = issued;
            this.Expires = expires;
        }

        /// <summary>
        /// Gets or sets the identifier of the Nonce.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the issued date.
        /// </summary>
        public DateTime Issued { get; set; }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        public DateTime Expires { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Nonce"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Nonce"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "{0} [{1}, {2}, {3}, {4}, {5}]",
                this.GetType().Name,
                this.Id,
                this.Context,
                this.Code,
                this.Issued,
                this.Expires);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Nonce"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Nonce"/>.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="Nonce"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="Nonce"/>.</param>
        /// <returns>
        /// true if the specified <see cref="System.Object"/> is equal to the current <see cref="Nonce"/>; otherwise false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Nonce);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Nonce"/> is equal to the current <see cref="Nonce"/>.
        /// </summary>
        /// <param name="nonce">The <see cref="Nonce"/> to compare with the current <see cref="Nonce"/>.</param>
        /// <returns>
        /// true if the specified <see cref="Nonce"/> is equal to the current <see cref="Nonce"/>; otherwise false.
        /// </returns>
        public bool Equals(Nonce nonce)
        {
            if (nonce == null)
            {
                return false;
            }

            return this.Context == nonce.Context
                && this.Code == nonce.Code
                && this.Id == nonce.Id
                && this.Issued == nonce.Issued
                && this.Expires == nonce.Expires;
        }
    }
}
