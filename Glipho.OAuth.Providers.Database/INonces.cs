namespace Glipho.OAuth.Providers.Database
{
    using System;

    /// <summary>
    /// The Nonces database interface.
    /// </summary>
    public interface INonces
    {
        /// <summary>
        /// Adds a nonce to the database.
        /// </summary>
        /// <param name="nonce">Details of the nonce to add.</param>
        /// <returns>true if nonce was successful added; else false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        bool Add(Nonce nonce);

        /// <summary>
        /// Remove all expired nonces from the database.
        /// </summary>
        /// <returns>true if removal was successful; else false.</returns>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        bool RemoveExpired();
    }
}
