using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    /// <summary>
    /// This class merges user and exam.
    /// </summary>
    public class UserExam
    {
        /// <summary>
        /// Question document id.
        /// </summary>
        public string QuestionId { get; set; }

        /// <summary>
        /// Answer of question.
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Note of answer.
        /// </summary>
        public string AnswerNote { get; set; }
    }
}
