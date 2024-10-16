using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Resources
{
    public class ExamQuestionResource
    {
        public int QuestionId { get; set; }
        public int GramaticalExamId { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }
        public bool? IsCorrect { get; set; }  // Se evalúa después de responder
        //public GramaticalExam GramaticalExam { get; set; }
    }
}