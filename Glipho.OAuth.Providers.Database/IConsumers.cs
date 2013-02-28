namespace Glipho.OAuth.Providers.Database
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Consumers database interface.
    /// </summary>
    public interface IConsumers
    {
        /// <summary>
        /// Create a new consumer.
        /// </summary>
        /// <param name="newConsumer">The <see cref="Consumer"/> to create.</param>
        /// <returns>The created <see cref="Consumer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        Consumer Create(Consumer newConsumer);
        
        /// <summary>
        /// Retrieve a consumer from the database.
        /// </summary>
        /// <param name="id">The identifier of the consumer to retrieve.</param>
        /// <returns>The <see cref="Consumer"/> if found; else null.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        Consumer Get(string id);

        /// <summary>
        /// List all consumers by name.
        /// </summary>
        /// <param name="offset">The amount to offset the results by. Minimum of 0.</param>
        /// <param name="limit">The maximum number of results to return. Maximum of 100.</param>
        /// <returns>A list of <see cref="Consumer"/> within the specified range.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if a parameter is outside of a permitted range.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        /// <remarks>
        /// <para>
        /// If there are no results with the given range, an empty list should be returned.
        /// </para>
        /// </remarks>
        IList<Consumer> List(int offset, int limit);
    }
}
