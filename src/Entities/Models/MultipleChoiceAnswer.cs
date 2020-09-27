using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    /// <summary>
    /// Multiple Choice Answer Model.
    /// For example;
    /// a) bla bla b) bla bla bla c) bla bla bla bla
    /// </summary>
    public class MultipleChoiceAnswer : BaseModel,IAnswerModel
    {
        /// <summary>
        /// Answer Key For Example 'a')
        /// </summary>
        public string Key { get; set; }
        
        /// <summary>
        /// Answer value for example a) 'bla bla'
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// This answer is right?
        /// </summary>
        public bool IsCorrect { get; set; }
    }
}
