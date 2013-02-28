namespace Glipho.OAuth.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// Interface for accessing OAuth consumers.
    /// </summary>
    public interface IConsumers
    {
        /// <summary>
        /// Create a new consumer.
        /// </summary>
        /// <param name="name">The name of the <see cref="Consumer"/> to create.</param>
        /// <returns>The created <see cref="Consumer"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        Consumer Create(string name);

        /// <summary>
        /// Create a new <see cref="Consumer"/> with a callback URL.
        /// </summary>
        /// <param name="name">The name of the <see cref="Consumer"/> to create.</param>
        /// <param name="callback">The callback URL of the <see cref="Consumer"/>.</param>
        /// <returns>The created <see cref="Consumer"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        Consumer Create(string name, Uri callback);

        /// <summary>
        /// Create a new <see cref="Consumer"/> with a X509 certificate.
        /// </summary>
        /// <param name="name">The name of the <see cref="Consumer"/> to create.</param>
        /// <param name="certificate">The X509 certificate for the user.</param>
        /// <returns>The created <see cref="Consumer"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        Consumer Create(string name, X509Certificate2 certificate);

        /// <summary>
        /// Create a new <see cref="Consumer"/> with a callback URL and a X509 certificate.
        /// </summary>
        /// <param name="name">The name of the <see cref="Consumer"/> to create.</param>
        /// <param name="callback">The callback URL of the <see cref="Consumer"/>.</param>
        /// <param name="certificate">The X509 certificate for the user.</param>
        /// <returns>The created <see cref="Consumer"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        Consumer Create(string name, Uri callback, X509Certificate2 certificate);

        /// <summary>
        /// Retrieve a <see cref="Consumer"/>.
        /// </summary>
        /// <param name="key">The key of the <see cref="Consumer"/> to return.</param>
        /// <returns>The <see cref="Consumer"/> if found; else null.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        Consumer Get(string key);

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
