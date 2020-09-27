using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    /// <summary>
    /// Exam entity
    /// </summary>
    public class Exam : BaseModel
    {
        /// <summary>
        /// Exam title
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Exam Start Date
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Exam End date
        /// </summary>
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddHours(1);

        // Note: To be Added question model using reflection.
    }
}
