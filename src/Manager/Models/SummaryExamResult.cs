using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Models
{
    public class SummaryExamResult
    {
        public User User { get; set; }

        public int TotalQuestion { get; set; }

        public int TotalCorrect { get; set; }

        public int TotalWrong { get; set; }
    }
}
