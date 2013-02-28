namespace Glipho.OAuth.Providers.Database
{
    using System;

    /// <summary>
    /// The Issued Tokens database interface.
    /// </summary>
    public interface IIssuedTokens
    {
        /// <summary>
        /// Create a new token.
        /// </summary>
        /// <param name="issuedToken">The details of the token to create.</param>
        /// <returns>Identifier of the newly created token.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        int Create(IssuedToken issuedToken);

        /// <summary>
        /// Retrieve a consumer from the database.
        /// </summary>
        /// <param name="token">The token of the issued token to retrieve.</param>
        /// <returns>The <see cref="IssuedToken"/> if found; else null.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        IssuedToken Get(string token);

        /// <summary>
        /// Remove an issued token.
        /// </summary>
        /// <param name="id">The identifier of the token to remove.</param>
        /// <returns>true if removal was successful; else false.</returns>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        bool Remove(string id);

        /// <summary>
        /// Update an existing token.
        /// </summary>
        /// <param name="token">The token of the issued token to update.</param>
        /// <param name="updatedToken">Details to update the token with.</param>
        /// <returns>true if update was successful; else false.</returns>
        /// <exception cref="ArgumentException">Thrown if a parameter is not valid.</exception>
        /// <exception cref="ArgumentNullException">Thrown if a parameter is null.</exception>
        /// <exception cref="Glipho.OAuth.OAuthException">Thrown if an error occurs while executing the requested command.</exception>
        bool Update(string token, IssuedToken updatedToken);
    }
}
