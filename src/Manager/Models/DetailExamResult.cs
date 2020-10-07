using Entities.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Models
{
    public class DetailExamResult : SummaryExamResult
    {
        public List<ExamQuestion> ExamQuestions { get; set; }
    }

    public class ExamQuestion : Question
    {
        public QuestionAnswer QuestionAnswer { get; set; }
    }

    public class QuestionAnswer : UserExam
    {
        public bool IsCorrect { get; set; }
    }

}
