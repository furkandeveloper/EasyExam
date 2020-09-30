using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Exceptions
{
    /// <summary>
    /// Parameter exception.
    /// </summary>
    public class ParameterException : BaseException
    {
        /// <summary>
        /// Without parameter ctor.
        /// </summary>
        public ParameterException()
        {
        }

        /// <summary>
        /// Exception with key.
        /// </summary>
        /// <param name="key">
        /// Exception key.
        /// </param>
        public ParameterException(string key) : base(key)
        {
        }
        /// <summary>
        /// Exception with key and innerException.
        /// </summary>
        /// <param name="key">
        /// Exception key.
        /// </param>
        /// <param name="innerException">
        /// Exception.
        /// </param>
        public ParameterException(string key, Exception innerException) : base(key, innerException)
        {
        }
    }
}
