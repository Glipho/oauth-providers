﻿namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System;
    using System.Diagnostics;
    using System.Security.Cryptography.X509Certificates;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// Mongo consumer representation.
    /// </summary>
    [DebuggerDisplay("{ToString()}"), BsonIgnoreExtraElements]
    public class Consumer : ConsumerStub
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Consumer"/> class.
        /// </summary>
        public Consumer()
        {
            this.Created = DateTime.UtcNow;
            this.LastModified = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the callback.
        /// </summary>
        [BsonElement("callback"), BsonIgnoreIfNull]
        public Uri Callback { get; set; }

        /// <summary>
        /// Gets or sets the secret.
        /// </summary>
        [BsonElement("secret"), BsonRequired]
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets the verification code format.
        /// </summary>
        [BsonElement("code_format"), BsonRequired]
        public int VerificationCodeFormat { get; set; }

        /// <summary>
        /// Gets or sets the verification code length.
        /// </summary>
        [BsonElement("code_length"), BsonDefaultValue(10)]
        public int VerificationCodeLength { get; set; }

        /// <summary>
        /// Gets or sets the certificate.
        /// </summary>
        [BsonElement("cert"), BsonIgnoreIfNull]
        public byte[] Certificate { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        [BsonElement("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        [BsonElement("modified")]
        public DateTime LastModified { get; set; }

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
                && this.Certificate == consumer.Certificate;
        }

        /// <summary>
        /// Create a new consumer from a database consumer.
        /// </summary>
        /// <param name="consumer">The database consumer to create a new consumer from.</param>
        /// <returns>A new consumer created from the database consumer.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        internal static Consumer FromConsumer(Database.Consumer consumer)
        {
            if (consumer == null)
            {
                throw new ArgumentNullException("consumer", "consumer is null");
            }

            return new Consumer
            {
                Callback = consumer.Callback,
                Certificate = consumer.Certificate != null ? consumer.Certificate.RawData : null,
                Id = consumer.Id != null ? new BsonObjectId(consumer.Id) : null,
                Name = consumer.Name,
                Secret = consumer.Secret,
                VerificationCodeFormat = consumer.VerificationCodeFormat,
                VerificationCodeLength = consumer.VerificationCodeLength,
            };
        }

        /// <summary>
        /// Convert this consumer into a database consumer.
        /// </summary>
        /// <returns>The database consumer created from this consumer.</returns>
        internal Database.Consumer ToConsumer()
        {
            return new Database.Consumer
            {
                Callback = this.Callback,
                Certificate = this.Certificate != null ? new X509Certificate2(this.Certificate) : null,
                Id = this.Id.ToString(),
                Name = this.Name,
                Secret = this.Secret,
                VerificationCodeFormat = this.VerificationCodeFormat,
                VerificationCodeLength = this.VerificationCodeLength,
            };
        }
    }
}
