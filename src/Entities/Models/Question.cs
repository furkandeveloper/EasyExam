using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    /// <summary>
    /// Question Model
    /// </summary>
    public class Question : BaseModel
    {
        /// <summary>
        /// Question Title
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Question Type
        /// </summary>
        public virtual QuestionType QuestionType { get; set; }

        /// <summary>
        /// Answer the question
        /// </summary>
        public virtual dynamic Answers { get; set; }

        /// <summary>
        /// Question status flag.
        /// </summary>
        public virtual bool IsCanceled { get; set; }
    }
}
