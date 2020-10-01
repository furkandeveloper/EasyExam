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
        public string Title { get; set; }

        /// <summary>
        /// Question Type
        /// </summary>
        public QuestionType QuestionType { get; set; }

        /// <summary>
        /// Answer the question
        /// </summary>
        public dynamic Answers { get; set; }

        /// <summary>
        /// Question status flag.
        /// </summary>
        public bool IsCanceled { get; set; }
    }
}
