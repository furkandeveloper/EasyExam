using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    /// <summary>
    /// Question types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuestionType
    {
        /// <summary>
        /// For Example a),b),c)
        /// </summary>
        MultipleChoice,
        /// <summary>
        /// Comment questions
        /// </summary>
        Classical,
        /// <summary>
        /// For example "bla bla bla ?" *True * False
        /// </summary>
        TrueFalse,
        /// <summary>
        /// For example "bla __ bla bla" a)bla b)two bla
        /// </summary>
        GapFill
    }
}
