namespace Glipho.OAuth
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents errors that occur during social network execution.
    /// </summary>
    public class OAuthException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="OAuthException" /> class.
        /// </summary>
        /// <param name="errorCode">The code of the error that being thrown.</param>
        public OAuthException(ErrorCode errorCode)
            : base()
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="OAuthException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="errorCode">The code of the error that being thrown.</param>
        public OAuthException(string message, ErrorCode errorCode)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="OAuthException" /> class with serialized data.
        /// </summary>
        /// <param name="info">
        /// The <see cref="System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data
        /// about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="System.Runtime.Serialization.StreamingContext"/> that contains contextual information 
        /// about the source or destination.
        /// </param>
        /// <param name="errorCode">The code of the error that being thrown.</param>
        /// <exception cref="System.ArgumentNullException">
        /// The info parameter is null.
        /// </exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">
        /// The class name is null or <see cref="System.Exception.HResult"/> is zero (0).
        /// </exception>
        public OAuthException(SerializationInfo info, StreamingContext context, ErrorCode errorCode)
            : base(info, context)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="OAuthException" /> class with a specified
        /// error message and a reference to the inner exception that is the cause of
        /// this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, 
        /// or a null reference (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        /// <param name="errorCode">The code of the error that being thrown.</param>
        public OAuthException(string message, Exception innerException, ErrorCode errorCode)
            : base(message, innerException)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the error code of the exception.
        /// </summary>
        public ErrorCode ErrorCode { get; private set; }
    }
}
