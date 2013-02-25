namespace Glipho.OAuth.Providers.Database.Mongo
{
    /// <summary>
    /// The types of <see cref="IssuedToken"/> stored in the database.
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// Indicates that a token is of type access token.
        /// </summary>
        AccessToken = 1,

        /// <summary>
        /// Indicates that a token is of type request token.
        /// </summary>
        RequestToken = 2,
    }
}
