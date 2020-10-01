using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    /// <summary>
    /// Exam entity
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Exam : BaseModel
    {
        /// <summary>
        /// Exam title
        /// </summary>
        public virtual string Title { get; set; }
        
        /// <summary>
        /// Exam Start Date
        /// </summary>
        public virtual DateTime StartDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Exam End date
        /// </summary>
        public virtual DateTime EndDate { get; set; } = DateTime.UtcNow.AddHours(1);

        /// <summary>
        /// Users taking exam
        /// </summary>
        public virtual List<User> Users { get; set; } = new List<User>();

        /// <summary>
        /// Questions in exam.
        /// </summary>
        public virtual List<Question> Questions { get; set; } = new List<Question>();
    }
}
