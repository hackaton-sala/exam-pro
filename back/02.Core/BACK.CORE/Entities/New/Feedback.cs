using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Entities.New
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string FeedbackText { get; set; } = null!;
        public DateTime GenerationDate { get; set; }
    }
}
