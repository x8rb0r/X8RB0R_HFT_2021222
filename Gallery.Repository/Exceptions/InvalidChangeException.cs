// <copyright file="InvalidChangeException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Repository.Exceptions
{
    using System;

    /// <summary>
    /// Exception class for when an invalid change is detected.
    /// </summary>
    public class InvalidChangeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidChangeException"/> class.
        /// </summary>
        /// <param name="message">Message from when the exception is thrown.</param>
        public InvalidChangeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidChangeException"/> class.
        /// </summary>
        /// <param name="message">Message from when the exception is thrown.</param>
        /// <param name="innerException">Value that was passed into the Exception.</param>
        public InvalidChangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidChangeException"/> class.
        /// </summary>
        public InvalidChangeException()
        {
        }
    }
}