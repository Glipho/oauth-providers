namespace Glipho.OAuth.Providers.Database
{
    using System;

    /// <summary>
    /// The Consumers database interface.
    /// </summary>
    public interface IConsumers
    {
        /// <summary>
        /// Retrieve a consumer from the database.
        /// </summary>
        /// <param name="id">The identifier of the consumer to retrieve.</param>
        /// <returns>The <see cref="Consumer"/> if found; else null.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        Consumer Get(string id);
    }
}
