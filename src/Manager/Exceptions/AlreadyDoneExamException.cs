using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Exceptions
{
    /// <summary>
    /// Already done exam exception class.
    /// </summary>
    public class AlreadyDoneExamException : BaseException
    {
        /// <summary>
        /// Without parameter.
        /// </summary>
        public AlreadyDoneExamException()
        {
        }

        /// <summary>
        /// Exception with key.
        /// </summary>
        /// <param name="key">
        /// Exception key.
        /// </param>
        public AlreadyDoneExamException(string key) : base(key)
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
        public AlreadyDoneExamException(string key, Exception innerException) : base(key, innerException)
        {
        }
    }
}
