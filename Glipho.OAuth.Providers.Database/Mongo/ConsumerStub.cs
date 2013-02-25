namespace Glipho.OAuth.Providers.Database.Mongo
{
    using System.Diagnostics;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// Mongo consumer representation.
    /// </summary>
    [DebuggerDisplay("{ToString}"), BsonIgnoreExtraElements]
    public class ConsumerStub
    {
        /// <summary>
        /// Gets or sets the id of the consumer.
        /// </summary>
        [BsonId]
        public BsonObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [BsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="ConsumerStub"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="ConsumerStub"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "{0} [{1}, {2}]",
                this.GetType().Name,
                this.Id,
                this.Name);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="ConsumerStub"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="ConsumerStub"/>.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ConsumerStub"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="ConsumerStub"/>.</param>
        /// <returns>
        /// true if the specified <see cref="System.Object"/> is equal to the current <see cref="ConsumerStub"/>; otherwise false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as ConsumerStub);
        }

        /// <summary>
        /// Determines whether the specified <see cref="ConsumerStub"/> is equal to the current <see cref="ConsumerStub"/>.
        /// </summary>
        /// <param name="consumer">The <see cref="ConsumerStub"/> to compare with the current <see cref="ConsumerStub"/>.</param>
        /// <returns>
        /// true if the specified <see cref="ConsumerStub"/> is equal to the current <see cref="ConsumerStub"/>; otherwise false.
        /// </returns>
        public bool Equals(ConsumerStub consumer)
        {
            if (consumer == null)
            {
                return false;
            }

            return this.Name == consumer.Name
                && this.Id == consumer.Id;
        }

        /// <summary>
        /// Gets the fields required to populate a consumer stub.
        /// </summary>
        /// <returns>A <see cref="FieldsBuilder"/> containing the fields of the consumer stub.</returns>
        internal static FieldsBuilder<ConsumerStub> GetFields()
        {
            return Fields<ConsumerStub>.Include(c => c.Id).Include(c => c.Name);
        }
    }
}
