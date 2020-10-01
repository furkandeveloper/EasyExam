using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Exceptions
{
    /// <summary>
    /// Entity Not Found Exception.
    /// For Example;
    /// ```csharp
    /// var entity = db.GetCollection<x>().Find(Builders<x>.Filter.Eq(x=>x.Id,id))
    ///                     ?? throw new EntityNotFoundException(nameof(X));
    /// ```
    /// </summary>
    public class EntityNotFoundException : BaseException
    {
        /// <summary>
        /// Without parameter ctor.
        /// </summary>
        public EntityNotFoundException()
        {
        }

        /// <summary>
        /// Exception with key.
        /// </summary>
        /// <param name="key">
        /// Exception key.
        /// </param>
        public EntityNotFoundException(string key) : base(key)
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
        public EntityNotFoundException(string key, Exception innerException) : base(key, innerException)
        {
        }
    }
}
