// <copyright file="NoInstanceFoundException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Repository.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Exception class for when an instance in a table is not found.
    /// </summary>
    public class NoInstanceFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoInstanceFoundException"/> class.
        /// </summary>
        /// <param name="message">Message from when the exception is thrown.</param>
        public NoInstanceFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoInstanceFoundException"/> class.
        /// </summary>
        /// <param name="message">Message from when the exception is thrown.</param>
        /// <param name="innerException">Value that was passed into the Exception.</param>
        public NoInstanceFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoInstanceFoundException"/> class.
        /// </summary>
        public NoInstanceFoundException()
        {
        }
    }
}
