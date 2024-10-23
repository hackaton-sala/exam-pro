using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Entities
{
    public class Exam
    {
        public int ExamId { get; set; }
        public int UserId { get; set; }
        public ExamType Type { get; set; }
        public string Level { get; set; }
        public string Part { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public decimal? TotalScore { get; set; }
        public string Feedback { get; set; }
        public User User { get; set; }
        //public ICollection<UserAnswer> UserAnswers { get; set; }
    }
    public enum ExamType
    {
        Grammar,
        Speaking,
        Reading,
        Listening
    }
}
