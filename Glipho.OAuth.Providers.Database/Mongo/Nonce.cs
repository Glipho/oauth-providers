namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System;
    using System.Diagnostics;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// Mongo nonce representation.
    /// </summary>
    [DebuggerDisplay("{ToString}"), BsonIgnoreExtraElements]
    public class Nonce
    {
        /// <summary>
        /// Gets or sets the identifier of the nonce.
        /// </summary>
        [BsonId]
        public BsonObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        [BsonRequired]
        public string Context { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [BsonRequired]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the issued date of the nonce.
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Issued { get; set; }

        /// <summary>
        /// Gets or sets the expiry date of the nonce.
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
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

        /// <summary>
        /// Create a new nonce from a database nonce.
        /// </summary>
        /// <param name="nonce">The database nonce to create a new nonce from.</param>
        /// <returns>A new nonce created from the database nonce.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        internal static Nonce FromNonce(Database.Nonce nonce)
        {
            if (nonce == null)
            {
                throw new ArgumentNullException("nonce", "nonce is null");
            }

            return new Nonce
            {
                Code = nonce.Code,
                Context = nonce.Context,
                Expires = nonce.Expires.ToUniversalTime(),
                Id = new BsonObjectId(nonce.Id.ToString()),
                Issued = nonce.Issued.ToUniversalTime(),
            };
        }
    }
}
