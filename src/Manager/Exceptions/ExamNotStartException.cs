using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Exceptions
{
    /// <summary>
    /// Exception class. Entry is not allowed before the exam starts.
    /// </summary>
    public class ExamNotStartException : BaseException
    {
        /// <summary>
        /// Without parameter.
        /// </summary>
        public ExamNotStartException()
        {
        }

        /// <summary>
        /// Exception with key.
        /// </summary>
        /// <param name="key">
        /// Exception key.
        /// </param>
        public ExamNotStartException(string key) : base(key)
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
        public ExamNotStartException(string key, Exception innerException) : base(key, innerException)
        {
        }
    }
}
