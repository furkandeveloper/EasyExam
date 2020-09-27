using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    /// <summary>
    /// Users taking exam.
    /// </summary>
    public class User
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
    }
}
