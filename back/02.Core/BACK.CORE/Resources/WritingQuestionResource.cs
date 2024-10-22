using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Resources
{
    public class WritingQuestionResource
    {
        public int WritingQuestionId { get; set; }
        
        public string Question { get; set; }
        public string UserAnswer { get; set; }
        public string Feedback { get; set; }
    }
}