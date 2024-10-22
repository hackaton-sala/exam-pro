using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Resources
{
    public class UseOfEnglishQuestionResource
    {
        public int UseOfEnglishQuestionId { get; set; }
        public string TextWithSpaces { get; set; }
        public string [] Options { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }
    }
}