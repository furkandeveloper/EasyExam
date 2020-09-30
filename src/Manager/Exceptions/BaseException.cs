using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Exceptions
{
    /// <summary>
    /// Base Exception
    /// </summary>
    public class BaseException : Exception
    {
        /// <summary>
        /// Without paramater ctor.
        /// </summary>
        public BaseException():base()
        {

        }

        /// <summary>
        /// Exception with key.
        /// </summary>
        /// <param name="key">
        /// Exception key.
        /// </param>
        public BaseException(string key) : base(key)
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
        public BaseException(string key, Exception innerException) : base(key,innerException)
        {

        }
    }
}
