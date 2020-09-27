using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    /// <summary>
    /// Base Model
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Bson object id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public virtual string Id { get; set; }

        /// <summary>
        /// Document create date
        /// </summary>
        public virtual DateTime CreateDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Document update date
        /// </summary>
        public virtual DateTime UpdateDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Is document active
        /// </summary>
        public virtual bool IsActive { get; set; } = true;

        /// <summary>
        /// Generate object id
        /// </summary>
        /// <returns>
        /// string bson id
        /// </returns>
        public string GenerateId()
        {
            return Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
