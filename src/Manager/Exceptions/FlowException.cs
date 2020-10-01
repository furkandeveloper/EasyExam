using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Exceptions
{
    /// <summary>
    /// Flow exception class.
    /// For example;
    /// ```csharp
    /// var exam = new Exam()
    /// {
    ///     Users = new List<User>()   <---- throw new FlowException(nameof(Users));
    /// }
    /// ```
    /// </summary>
    public class FlowException : BaseException
    {
        /// <summary>
        /// Without parameter ctor.
        /// </summary>
        public FlowException()
        {
        }

        /// <summary>
        /// Exception with key.
        /// </summary>
        /// <param name="key">
        /// Exception key.
        /// </param>
        public FlowException(string key) : base(key)
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
        public FlowException(string key, Exception innerException) : base(key, innerException)
        {
        }
    }
}
