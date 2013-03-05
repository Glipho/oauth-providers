namespace Glipho.OAuth.Providers.Database
{
    using System;
    using System.Diagnostics;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// The consumer.
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    public class Consumer
    {
        /// <summary>
        /// Gets or sets the id of the consumer.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the callback.
        /// </summary>
        public Uri Callback { get; set; }

        /// <summary>
        /// Gets or sets the secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets the verification code format.
        /// </summary>
        public int VerificationCodeFormat { get; set; }

        /// <summary>
        /// Gets or sets the verification code length.
        /// </summary>
        public int VerificationCodeLength { get; set; }

        /// <summary>
        /// Gets or sets the certificate.
        /// </summary>
        public X509Certificate2 Certificate { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Consumer"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Consumer"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "{0} [{1}, {2}, {3}, {4}, {5}]",
                this.GetType().Name,
                this.Id,
                this.Name,
                this.Callback,
                this.VerificationCodeFormat,
                this.VerificationCodeLength);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Consumer"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Consumer"/>.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="Consumer"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="Consumer"/>.</param>
        /// <returns>
        /// true if the specified <see cref="System.Object"/> is equal to the current <see cref="Consumer"/>; otherwise false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Consumer);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Consumer"/> is equal to the current <see cref="Consumer"/>.
        /// </summary>
        /// <param name="consumer">The <see cref="Consumer"/> to compare with the current <see cref="Consumer"/>.</param>
        /// <returns>
        /// true if the specified <see cref="Consumer"/> is equal to the current <see cref="Consumer"/>; otherwise false.
        /// </returns>
        public bool Equals(Consumer consumer)
        {
            if (consumer == null)
            {
                return false;
            }

            return this.Name == consumer.Name
                && this.Callback == consumer.Callback
                && this.Id == consumer.Id
                && this.Secret == consumer.Secret
                && this.VerificationCodeFormat == consumer.VerificationCodeFormat
                && this.VerificationCodeLength == consumer.VerificationCodeLength
                && (this.Certificate != null && consumer.Certificate != null && this.Certificate.Equals(consumer.Certificate));
        }
    }
}
