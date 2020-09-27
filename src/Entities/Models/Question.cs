using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    /// <summary>
    /// Question Model
    /// </summary>
    /// <typeparam name="T">
    /// This T must be inherited from the IAnswerModel type.
    /// </typeparam>
    public class Question<T> : BaseModel where T :class,IAnswerModel,new()
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
        public List<T> Answers { get; set; } = new List<T>();

        /// <summary>
        /// Question status flag.
        /// </summary>
        public bool IsCanceled { get; set; }
    }
}
