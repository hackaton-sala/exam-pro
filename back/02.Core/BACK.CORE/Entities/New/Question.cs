using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Entities.New
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string ExamType { get; set; }
        public string ExamPart { get; set; }
        public string EnglishLevel { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public string? DefaultFeedback { get; set; }
        public decimal MaxScore { get; set; }

        public ICollection<Option> Options { get; set; }
    }
}
