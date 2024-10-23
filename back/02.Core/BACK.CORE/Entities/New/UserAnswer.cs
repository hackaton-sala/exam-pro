using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Entities.New
{
    public class UserAnswer
    {
        public int UserAnswerId { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string? AnswerText { get; set; }
        public int? SelectedOptionId { get; set; }
        public Option? SelectedOption { get; set; }
        public DateTime AnswerDate { get; set; }
        public decimal? Score { get; set; }
        public string QuestionStatus { get; set; }
    }   
}
