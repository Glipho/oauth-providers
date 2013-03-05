namespace Glipho.OAuth
{
    /// <summary>
    /// Represents the errors types that can be thrown.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Represents a database exception has occurred.
        /// </summary>
        Database,

        /// <summary>
        /// Represents a no response from an external provider.
        /// </summary>
        NoResponseFromProvider,

        /// <summary>
        /// Represents an invalid token response for OAuth 1.0.
        /// </summary>
        InvalidTokenResponse,

        /// <summary>
        /// Represents an error from an external API.
        /// </summary>
        ExternalApiError,
    }
}
