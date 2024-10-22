using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Resources
{
    public class ReadingQuestionResource
    {
        public int ReadingQuestionId { get; set; }
        public string Text { get; set; }
        public string Question { get; set; }
        public string [] Options { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }
    }
}