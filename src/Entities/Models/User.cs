using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    /// <summary>
    /// Users taking exam.
    /// </summary>
    public class User : BaseModel
    {
        /// <summary>
        /// User's name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Users's surname
        /// </summary>
        public virtual string Surname { get; set; }

        /// <summary>
        /// User's email
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Users' answers in exam.
        /// </summary>
        public virtual List<UserExam> UserExams { get; set; } = new List<UserExam>();
    }
}
